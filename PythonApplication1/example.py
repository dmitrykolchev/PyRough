import token
import torch
from diffusers import StableDiffusion3Pipeline
from datetime import datetime
import io

import sys;


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

print(sys.path)
