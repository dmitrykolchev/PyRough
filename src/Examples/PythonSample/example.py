from datetime import datetime
import io
import sys;
import token

import torch
from diffusers import (
    StableDiffusionXLPipeline, 
    AutoencoderKL, 
    AutoencoderTiny,
    StableDiffusion3Pipeline)
from diffusers.schedulers import DPMSolverMultistepScheduler
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

def txt2image():
    access_token = "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"
    pipe = StableDiffusion3Pipeline.from_pretrained("stabilityai/stable-diffusion-3-medium-diffusers",
        torch_dtype=torch.float16, 
        text_encoder_3=None,
        tokenizer_3=None,                                                    
        token = access_token)
    pipe = pipe.to("cuda")

    seed = 264073133673528
    seed = torch.seed() ^ (torch.seed() >> 16)
    generator = torch.Generator(device="cuda").manual_seed(seed)

    image = pipe(
        #"A cat holding a sign that says hello world",
        "HDR, editorial (full body:1.6) wide angle photograph of a beautiful young 1970s \\(style\\) redhead teen woman posing++ under a wooden dock at the ocean, waist deep in water, large waves crashing, (seductive:1.6), wet skin, ((low camera angle)), strong wind through her hair, tattoos, highly detailed face, sexy, cleavage, (sheer:1.2) shirt and panties, soft cinematic light and color, dreamlike soft focus, camera f1.6 lens, rich colors, hyper realistic, lifelike texture, dramatic lighting",
        negative_prompt="",
        num_inference_steps=14,
        guidance_scale=7.0,
        generator = generator
    ).images[0]
    date_string = datetime.now().strftime("%Y%m%d_%H%M%S")
    file_name = f"{date_string}_{seed}"    
    image.save(f".\\{file_name}.png")    
    buffer = io.BytesIO()
    image.save(buffer, format="PNG")    
    data = buffer.getvalue()    
    return data    

def createPipeline(modelPath: str):
    print("loading")    
    print(modelPath)    
    pipeline = StableDiffusionXLPipeline.from_single_file(
        modelPath,
        torch_dtype=torch.float16, 
        variant="fp16", 
        use_safetensors=True).to("cuda")
    scheduler = DPMSolverMultistepScheduler.from_config(pipeline.scheduler.config)
    scheduler.config.use_karras_sigmas = True
    scheduler.config.algorithm_type = "sde-dpmsolver++"
    pipeline.scheduler = scheduler
    pipeline.enable_xformers_memory_efficient_attention()
    
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

# model = "juggernautXL_juggernautX.safetensors"

# generateImage(
#     f"C:\\StableDiffusion\\models\\checkpoints\\{model}",
#     -1,
#     "HDR, editorial (full body:1.6) wide angle photograph of a beautiful young 1970s \\(style\\) redhead teen woman posing++ under a wooden dock at the ocean, waist deep in water, large waves crashing, (seductive:1.6), wet skin, ((low camera angle)), strong wind through her hair, tattoos, highly detailed face, sexy, cleavage, (sheer:1.2) shirt and panties, by lee jeffries, nikon d850, film stock photograph, 4 kodak portra 400, soft cinematic light and color, dreamlike soft focus, camera f1.6 lens, rich colors, hyper realistic, lifelike texture, dramatic lighting, cinestill 800",
#     "child, baby, Asian, big breasts, anime, manga, anorexic, anorexia, canvas frame, text, old, mature, lazy eye, crossed eyes,  gun, drawing, overexposed, high contrast, cartoon, 3d, disfigured, bad art, deformed, extra limbs, b&w, blurry, duplicate, morbid, mutilated,  out of frame, extra fingers, mutated hands, drawing, poorly drawn hands, poorly drawn face, mutation, deformed, ugly, blurry, weapon, bad anatomy,  bad proportions, painting, extra limbs, cloned face, disfigured, out of frame, ugly, extra limbs, text, bad anatomy",
#     896,        
#     1152,       
#     30,
#     7.5,
#     0)
