import os
from diffusers.pipelines.kandinsky import text_encoder
import torch
from diffusers import StableDiffusionXLPipeline, StableDiffusionXLImg2ImgPipeline
from diffusers.schedulers import DPMSolverMultistepScheduler, EulerAncestralDiscreteScheduler
from compel import Compel, DiffusersTextualInversionManager, ReturnedEmbeddingsType


class StableDiffusionImageGenerator(object):
    def __init__(self) -> None:
        self.checkpoint_directory = "C:\\StableDiffusion\\models\\checkpoints"
        self.loras_directory = "C:\\StableDiffusion\\models\\loras"        

    def initialize(self, baseModel:str, refinerModel:str, loras: list):

        self.base = StableDiffusionXLPipeline.from_single_file(
            os.path.join(self.checkpoint_directory, baseModel),
            torch_dtype=torch.float16, 
            variant="fp16", 
            local_files_only = True,
            use_safetensors=True).to("cuda")

        self.refiner = StableDiffusionXLImg2ImgPipeline.from_single_file(
            os.path.join(self.checkpoint_directory, refinerModel),
            text_encoder = self.base.text_encoder,            
            text_encoder_2 = self.base.text_encoder_2,
            vae = self.base.vae,                                    
            torch_dtype=torch.float16, 
            variant="fp16", 
            local_files_only = True,
            use_safetensors=True).to("cuda")

        if loras:
            adapters = []
            weights = []
            i = 0            
            for item in loras:
                i = i + 1                
                print(f"<{item[0]}:{item[1]}>")        
                lora_path = os.path.join(self.loras_directory,f"{item[0]}.safetensors") 
                print(lora_path)
                self.base.load_lora_weights(
                    lora_path, 
                    adapter_name = f"a{i}_b", 
                    weight_name = f"a{i}_b", 
                    local_files_only = True)
                self.refiner.load_lora_weights(
                    lora_path, 
                    adapter_name = f"a{i}_r", 
                    weight_name = f"a{i}_r", 
                    local_files_only = True)            
                adapters.append(f"a{i}_b")        
                weights.append(item[1])        
                adapters.append(f"a{i}_r")        
                weights.append(item[1])        
            
            self.base.set_adapters(adapters, weights)
            #self.refiner.set_adapters(adapters, weights)            

        scheduler = EulerAncestralDiscreteScheduler.from_config(self.base.scheduler.config)    
        # scheduler.config.use_karras_sigmas = True
        # scheduler.config.euler_at_final = True    
        # scheduler.config.algorithm_type = "sde-dpmsolver++"
        self.base.scheduler = scheduler
        self.refiner.scheduler = scheduler

        self.base.enable_xformers_memory_efficient_attention()
        self.base.enable_model_cpu_offload()
       
        self.refiner.enable_xformers_memory_efficient_attention()
        self.refiner.enable_model_cpu_offload()

    def run(self,
            prompt: str, negative_prompt: str, 
            seed: int, 
            width: int, height: int, 
            steps: int, 
            scale: float, 
            clip_skip: int):

        compel = Compel(
          tokenizer = [self.base.tokenizer, self.base.tokenizer_2] ,
          text_encoder = [self.base.text_encoder, self.base.text_encoder_2],
          returned_embeddings_type = ReturnedEmbeddingsType.PENULTIMATE_HIDDEN_STATES_NON_NORMALIZED,
          requires_pooled = [False, True],
          truncate_long_prompts = False
        )

        conditioning, pooled = compel(prompt)
        negative, pooled_negative = compel(negative_prompt)
        [conditioning, negative] = compel.pad_conditioning_tensors_to_same_length(
            [conditioning, negative])

        if seed == -1:
            seed = torch.seed()
        generator = torch.Generator(device="cuda").manual_seed(seed)


        # shape (1, 4, 152, 104)
        # torch.Size([4, 152, 104])
        image = self.base(prompt_embeds = conditioning,                     #.conditioning,
                          pooled_prompt_embeds = pooled,                    #.pooled,
                          negative_prompt_embeds = negative,                # .negative,
                          negative_pooled_prompt_embeds = pooled_negative,  #.pooled_negative,
                          guidance_scale = scale,
                          guidance_rescale = 0,
                          generator = generator,
                          num_inference_steps = steps,
                          denoising_end = 0.6,                          
                          width = width,
                          height = height,
                          clip_skip = clip_skip,
                          output_type = "latent").images[0]
        
        image = self.refiner(prompt_embeds = conditioning,                     #.conditioning,
                             pooled_prompt_embeds = pooled,                    #.pooled,
                             negative_prompt_embeds = negative,                # .negative,
                             negative_pooled_prompt_embeds = pooled_negative,  #.pooled_negative,
                             guidance_scale = scale,
                             guidance_rescale = 0,
                             #strength = 0.75,
                             image=image,       
                             #latents = torch.reshape(image, (1, 4, 152, 104)),
                             clip_skip = clip_skip,
                             num_inference_steps=steps,   
                             denoising_start=0.6).images[0]                            
        return image