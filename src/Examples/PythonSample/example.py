from datetime import datetime
import io
import sys;
import token
from diffusers.loaders import lora
import StableDiffusionImageGenerator
from safetensors.torch import load_file

import torch
from diffusers import StableDiffusionXLPipeline
from diffusers.schedulers import DPMSolverMultistepScheduler, EulerAncestralDiscreteScheduler
from compel import Compel, DiffusersTextualInversionManager, ReturnedEmbeddingsType


def sayHello(name):
    greeting = "Hello, " + name + "!"
    print(greeting) 
    return greeting


def add(l, r):
    return l + r


def sayHelloWorld():
    for i in range(10):
        print(f"{i}: Hello World!")
    return "Hello World"


def makeImage():
    sd = StableDiffusionImageGenerator.StableDiffusionImageGenerator()
    loras = [
            ("Fant5yP0ny", 0.7),
            ("Expressive_H-000001", 0.6),
            ("add-detail-xl", 0.7),
            # ("Photo 2 Style SDXL_LoRA_Pony Diffusion V6 XL", 0.7),
            ("incase_style_v3-1_ponyxl_ilff", 0.5),
            ("g0th1cPXL", 0.45),
            # ("MJ52", 0.4)
            ("RELSM_v1", 0.9),
            # ("d4rk01lXLP", 0.8),
            # ("Concept Art Twilight Style SDXL_LoRA_Pony Diffusion V6 XL", 0.8)
        ]
    sd.initialize("ponyDiffusionV6XL_v6StartWithThisOne.safetensors", 
                  "realcartoonXL_v6.safetensors", 
                  loras)   
    prompt = "score_9, score_8_up, score_7_up, sexy girl, bright skin, topless, bow hair, pretty face, hazel eyes, blonde , bow hairstyle, large breasts,  boobs squeeze together , grab breast, cleavage , nipples,  military camouflage pants, boob focus, sexy pose , sexy , posing , wet,  halfbody portrait ,UHD, 8K, ultra detailed, a cinematic photograph of {prompt}, beautiful lighting, great composition, g0th1c, UHD, 8K, ultra detailed, a cinematic photograph of {prompt}, beautiful lighting, great composition, photo realistic, raw"
    negative_prompt = "score_6, score_5, score_4, worst quality, low quality, child, baby, Asian, anime, manga, anorexic, anorexia, canvas frame, text, old, mature, lazy eye, crossed eyes,  gun, drawing, overexposed, high contrast, cartoon, 3d, disfigured, bad art, deformed, extra limbs, b&w, blurry, duplicate, morbid, mutilated,  out of frame, extra fingers, mutated hands, drawing, poorly drawn hands, poorly drawn face, mutation, deformed, ugly, blurry, weapon, bad anatomy,  bad proportions, painting, extra limbs, cloned face, disfigured, out of frame, ugly, extra limbs, text, bad anatomy, large breasts"
    image = sd.run(prompt, negative_prompt, -1, 832, 1216, 30, 4, 2)
    buffer = io.BytesIO()
    image.save(buffer, format="PNG")    
    data = buffer.getvalue()        
    return data

def createPipeline(modelPath: str, loras: list, embeding: str):
    print("loading")    
    print(modelPath)    
    
    torch.set_grad_enabled(False)    
    pipeline = StableDiffusionXLPipeline.from_single_file(
        modelPath,
        torch_dtype=torch.float16, 
        variant="fp16", 
        use_safetensors=True).to("cuda")


    embedding_path = f"C:\\StableDiffusion\\models\\embeddings\\{embeding}.safetensors"
    # pipeline.load_textual_inversion(embedding_path)
    
    # load embeddings to the text encoders
    state_dict = load_file(embedding_path)
    print(state_dict.keys)
    print(state_dict)

    pipeline.load_textual_inversion(
        embedding_path,
        token=embeding,
        text_encoder=pipeline.text_encoder,
        tokenizer=pipeline.tokenizer)
    
    # # load embeddings of text_encoder 1 (CLIP ViT-L/14)
    # pipeline.load_textual_inversion(
    #     state_dict["clip_l"],
    #     token=embeding,
    #     text_encoder=pipeline.text_encoder,
    #     tokenizer=pipeline.tokenizer,
    # )
    # # load embeddings of text_encoder 2 (CLIP ViT-G/14)
    # pipeline.load_textual_inversion(
    #     state_dict["clip_g"],
    #     token=embeding,
    #     text_encoder=pipeline.text_encoder_2,
    #     tokenizer=pipeline.tokenizer_2,
    # )    
    
    lora_path = "C:\\StableDiffusion\\models\\loras\\"
    adapters = [];
    weights = [];

    if loras:
        for item in loras:
            print(f"<{item[0]}:{item[1]}>")        
            pipeline.load_lora_weights(f"{lora_path}{item[0]}.safetensors", adapter_name = item[0])
            adapters.append(item[0])        
            weights.append(item[1])        

    # scales = {
    #     "text_encoder": 0.7,
    #     "text_encoder_2": 0.7,  # only usable if pipe has a 2nd text encoder
    #     "unet": {
    #         "down": 0.9,  # all transformers in the down-part will use scale 0.9
    #         # "mid"  # in this example "mid" is not given, therefore all transformers in the mid part will use the default scale 1.0
    #         "up": {
    #             "block_0": 0.6,  # all 3 transformers in the 0th block in the up-part will use scale 0.6
    #             "block_1": [0.4, 0.8, 1.0],  # the 3 transformers in the 1st block in the up-part will use scales 0.4, 0.8 and 1.0 respectively
    #         }
    #     }
    # }
    print(adapters, weights)        
    pipeline.set_adapters(adapters, weights)    

    scheduler = EulerAncestralDiscreteScheduler.from_config(pipeline.scheduler.config)
    # scheduler = DPMSolverMultistepScheduler.from_config(pipeline.scheduler.config)    
    # scheduler.config.use_karras_sigmas = True
    # scheduler.config.euler_at_final = True    
    # scheduler.config.algorithm_type = "sde-dpmsolver++"
    pipeline.scheduler = scheduler

    # try:
    #     pipeline.unet = torch.compile(pipeline.unet, mode="reduce-overhead", fullgraph=True)
    # except:
    #     print(repr(sys.exception()))
                
    
    pipeline.enable_xformers_memory_efficient_attention()
    pipeline.enable_model_cpu_offload()
    return pipeline    
    
def createPrompt(pipeline:object, prompt: str, negative_prompt: str):
    compel = Compel(
      tokenizer = [pipeline.tokenizer, pipeline.tokenizer_2] ,
      text_encoder = [pipeline.text_encoder, pipeline.text_encoder_2],
      returned_embeddings_type = ReturnedEmbeddingsType.PENULTIMATE_HIDDEN_STATES_NON_NORMALIZED,
      requires_pooled = [False, True],
      truncate_long_prompts = False
    )

    conditioning, pooled = compel(prompt)
    negative, pooled_negative = compel(negative_prompt)
    [conditioning, negative] = compel.pad_conditioning_tensors_to_same_length([conditioning, negative])
    return [conditioning, pooled, negative, pooled_negative];

def generateImage(pipeline: object, 
                  prompt: list, 
                  seed: int, 
                  width: int, height: int, 
                  steps: int, 
                  scale: float, 
                  clip_skip: int):
   
    if seed == -1:
        seed = torch.seed()

    generator = torch.Generator(device="cuda").manual_seed(seed)
    
    print(f"Size: {width}x{height}")
    image = pipeline(prompt_embeds = prompt[0],                     #.conditioning,
                      pooled_prompt_embeds = prompt[1],             #.pooled,
                      negative_prompt_embeds = prompt[2],           # .negative,
                      negative_pooled_prompt_embeds = prompt[3],    #.pooled_negative,
                      guidance_scale = scale,
                      guidance_rescale = 0,
                      generator = generator,
                      num_inference_steps = steps,
                      width = width,
                      height = height,
                      clip_skip = clip_skip).images[0]
    print(image)    
    buffer = io.BytesIO()
    image.save(buffer, format="PNG")    
    data = buffer.getvalue()    
    return {"scale": scale, 
            "image": data, 
            "seed": seed, 
            "width": width, 
            "height": height, 
            "clip_skip": clip_skip
            }
        
