from datetime import datetime
import io
import sys;
import token

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

def createPipeline(modelPath: str):
    print("loading")    
    print(modelPath)    
    
    torch.set_grad_enabled(False)    
    pipeline = StableDiffusionXLPipeline.from_single_file(
        modelPath,
        torch_dtype=torch.bfloat16, 
        variant="fp16", 
        use_safetensors=True).to("cuda")

    pipeline.load_lora_weights("C:\StableDiffusion\models\loras\Fant5yP0ny.safetensors", adapter_name = "Fant5yP0ny")
    pipeline.load_lora_weights("C:\StableDiffusion\models\loras\Expressive_H-000001.safetensors", adapter_name = "Expressive_H")
    pipeline.load_lora_weights("C:\StableDiffusion\models\loras\RELSM_v1.safetensors", "relsm")
    pipeline.load_lora_weights("C:\StableDiffusion\models\loras\d4rk01lXLP.safetensors", "d4rk01l")
    pipeline.load_lora_weights("C:\StableDiffusion\models\loras\Concept Art Twilight Style SDXL_LoRA_Pony Diffusion V6 XL.safetensors", "twilight")
    scales = {
        "text_encoder": 0.7,
        "text_encoder_2": 0.7,  # only usable if pipe has a 2nd text encoder
        "unet": {
            "down": 0.9,  # all transformers in the down-part will use scale 0.9
            # "mid"  # in this example "mid" is not given, therefore all transformers in the mid part will use the default scale 1.0
            "up": {
                "block_0": 0.6,  # all 3 transformers in the 0th block in the up-part will use scale 0.6
                "block_1": [0.4, 0.8, 1.0],  # the 3 transformers in the 1st block in the up-part will use scales 0.4, 0.8 and 1.0 respectively
            }
        }
    }
    pipeline.set_adapters(["Fant5yP0ny", "Expressive_H", "relsm", "d4rk01l", "twilight"], [scales, 0.6, 0.9, 0.8, 0.8])    

    scheduler = EulerAncestralDiscreteScheduler.from_config(pipeline.scheduler.config)
    scheduler.config.use_karras_sigmas = False
    # scheduler.config.euler_at_final = True    
    # scheduler.config.algorithm_type = "sde-dpmsolver++"
    pipeline.scheduler = scheduler
    
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

def generateImage(pipeline: object, prompt, 
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
    return data    

