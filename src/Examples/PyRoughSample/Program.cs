// <copyright file="Program.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using PyRough.Python;

namespace PyRoughSample;

internal class Program
{
    private const string PythonDll = @"C:\Program Files\Python310\python310.dll";

    private static void Main(string[] args)
    {
        Initialize();

        SayHello();

        PyModule module = PyModule.Import(@"example");

        //PyObject makeImage = module.GetAttr("makeImage")!;
        //PyBytes image = (PyBytes)makeImage.Invoke()!;
        //SaveImage(image!);

        //return;

        var createPipeline = module.GetAttr("createPipeline")!;

        //string model = @"C:\StableDiffusion\models\checkpoints\ponyDiffusionV6XL_v6StartWithThisOne.safetensors";
        string model = @"C:\StableDiffusion\models\checkpoints\realcartoonXL_v6.safetensors";
        //string model = @"C:\StableDiffusion\models\checkpoints\juggernautXL_juggernautX.safetensors";
        //string model = @"C:\StableDiffusion\models\checkpoints\sd_xl_base_1.0_0.9vae.safetensors";

        List<(string, double)> loras = [
            //("Fant5yP0ny", 0.9),
            ("Expressive_H-000001", 0.45),
            //("add-detail-xl", 0.7),
            //("Photo 2 Style SDXL_LoRA_Pony Diffusion V6 XL", 0.7),
            ("incase_style_v3-1_ponyxl_ilff", 0.6),
            ("g0th1cPXL", 0.55),
            ("Granblue_Fantasy_PSXL", 0.2)
            //("MJ52", 0.4)
            //("RELSM_v1", 0.9),
            //("d4rk01lXLP", 0.5),
            //("Concept Art Twilight Style SDXL_LoRA_Pony Diffusion V6 XL", 0.8),
            //("Pony_DetailV1_0", 0.9)
        ];
        PyList pyLoras = new(loras);
        var pipeline = createPipeline.Invoke(model, pyLoras, "easynegative")!;
        Console.WriteLine("SDXL pipeline created");

        var createPrompt = module.GetAttr("createPrompt")!;
        var prompt = createPrompt.Invoke(
            pipeline,
            //"score_9, score_8_up, score_7_up, score_6_up, realistic, raw, rating_explicit, editorial (full body:1.6) wide angle photograph of a beautiful young 1970s \\(style\\) redhead teen woman posing++ under a wooden dock at the ocean, waist deep in water, large waves crashing, (seductive:1.6), wet skin, ((low camera angle)), strong wind through her hair, tattoos, highly detailed face, sexy, cleavage, (sheer:1.2) shirt and panties, by lee jeffries, nikon d850, film stock photograph, 4 kodak portra 400, soft cinematic light and color, dreamlike soft focus, camera f1.6 lens, rich colors, hyper realistic, lifelike texture, dramatic lighting, cinestill 800",
            //"score_9, score_8_up, score_8_up, 1girl, in a bathtub, naked, soap,  ((sexy eye contact)), parted lips, kneeling, Ass up,  nsfw,  wet skin, showing off her body,  dreamy eyes, sweaty skin, panam palmer, arching back, fit body, thick thighs, thin waists, godrays, shower tiles, bathroom interior, steam, rain, view from above, chairs, expressiveh, d4rk01l, raw, conceptual art",
            //"score_9, score_8_up, score_7_up, sexy girl , bright skin, topless, bow hair, pretty face, hazel eyes, blonde , bow hairstyle, large breasts,  boobs squeeze together , grab breast, cleavage , nipples,  military camouflage pants, boob focus, sexy pose , sexy , posing , raining, wet,  halfbody portrait ,UHD, 8K, ultra detailed, a cinematic photograph of {prompt}, beautiful lighting, great composition, g0th1c, UHD, 8K, ultra detailed, a cinematic photograph of {prompt}, beautiful lighting, great composition, photo realistic, raw",
            //"score_9, score_8_up, score_7_up, score_6_up, score_5_up, score_4_up, 1 sexy kawaii girl, 20 years old, smiling, wink, perfect cute face, thighs, long brown wavy hair, freckles, pale skin,  hazel eyes, twin ponytails, blushing, big breasts, (embarrassed:0.4), sitting on a pool chair, side view, beach, horny girl, legs spread, spread legs, upskirt, open bikini, navel, topless, flashing, exhibitionism, surrounded by people, people applauding, bystanders, girl in centre, crowd, onlookers, UHD, 8K, ultra detailed, a cinematic photograph of {prompt}, beautiful lighting, great composition, g0th1c",
            //"score_9, score_8_up, score_8, score_7_up, score_7, score_6_up, score_6, score_5_up, Score_5, girl, beautiful face, turn back,long blonde hair,  narrow hips ,  stockings , juicy ass, sexy adult  ,  halfbody portrait , back view , room , lingerie photoshoot , standing , from below",
            //"score_9, score_8_up, score_7_up, 1girl, red hair, green eyes, triss merigold, lingerie, cleavage, huge breasts, shiny skin, wet skin, in a palace, fabrics, pillows, drinking wine, dutch angle, fantasy, perfect quality, high quality, photorealistic, on all fours, crawling to viewer BREAK orange and blue hue, (abstract:0.2), at night, fire particles, expressiveH",
            //"((Anime Oil Painting)). (detailed), Turning view of ((short toned and stocky Half-Scottish/Hungarian girl)), ((pretty girl)), (Nude)), alone on small stage, ((eshy and embarrassed)), (dancing nervously), (wet hair), ((sweaty skin)), ((very oily skin)), ((cheek-dimples)). ((Extremely toned buttocks)), clavicles. (((tiny perky breasts))), ((detailed erect nipples)), ((Navel)). ((neatly-trimmed pubic hair)), ((legs wide apart)), (beads of sweat), (((Hands reaching to touch her))), (((Faint shocked distant faces in a wild crowd))), ((Thick ground-mist up to thigh-level)) (((appropriate shadowing))), ((appropriate direction of light)), Very Dark background",
            "score_9, score_8_up, score_8_up, 1girl, in a swimming pool, lying on pool edge, posing sexy, nsfw,  front view, ass up face down, wet skin, tight swimsuit, swimsuit material detail, showing off her body, dreamy eyes, sweaty skin, arching back, fit body, tight tits, teardrop shaped tits,, thin waists, godrays, beautiful pool, sunset sky, orange purple sky, Los Angeles city skyline, city skyline in the background pool chairs, negative_hand, g0thicPXL, GTA",
            //"score_6, score_5, score_4, worst quality, low quality, child, baby, Asian, anime, manga, anorexic, anorexia, canvas frame, text, old, mature, lazy eye, crossed eyes,  gun, drawing, overexposed, high contrast, cartoon, 3d, disfigured, bad art, deformed, extra limbs, b&w, blurry, duplicate, morbid, mutilated,  out of frame, extra fingers, mutated hands, drawing, poorly drawn hands, poorly drawn face, mutation, deformed, ugly, blurry, weapon, bad anatomy,  bad proportions, painting, extra limbs, cloned face, disfigured, out of frame, ugly, extra limbs, text, bad anatomy, large breasts"
            //"core_6, score_5, score_4, worst quality, low quality, text, censored, deformed, bad hand, blurry, (watermark), multiple phones, weights, bunny ears, extra hands,"
            //"core_6, score_5, score_4, worst quality, low quality, text, censored, deformed, bad hand, blurry, (watermark), multiple phones, weights, bunny ears, extra hands,ugly, deformed, noisy, blurry, NSFW"
            //"core_6, score_5, score_4, worst quality, low quality, text, censored, deformed, bad hand, blurry, (watermark), multiple phones, weights, bunny ears, extra hands, easynegative,ugly, deformed, noisy, blurry, NSFW, longbody, lowres, bad anatomy, bad hands, missing fingers, pubic hair,extra digit, fewer digits, cropped, worst quality, low quality"
            //"core_6, score_5, score_4, worst quality, low quality, text, censored, deformed, bad hand, blurry, (watermark), multiple phones, weights, bunny ears, extra hands,"
            //"score_6, score_5, score_4, negativeXL_D, skinny, anorexic, furry, <negativeXL_D>"
            //"(worst quality:1.6),(low quality:1.6), easynegative, shorts, ((bra)), underwear, sagging, inaccurate face, inaccurate ankles, inaccurate feet, bad feet, fringe, big ass, large thighs, tan-lines, writing, Japanese writing, logos, labels, patches, dress, bare legs, cross-legged, other people, sagging breasts, shorts, pagoda, big breasts, small nipples, highly saturated, moles, scars, spots, freckles, inaccurate fingers, inaccurate toes, inaccurate eyes, red belt, brown belt, white belt, leather belt, ((sun)), ((sunset)), (pagoda), temple, (bikini),"
            "core_6, score_5, score_4, worst quality, low quality, text, censored, deformed, bad hand, blurry, (watermark), multiple phones, weights, bunny ears, extra hands,easynegative"
            )!;

        Console.WriteLine($"{prompt.ToString()}");

        var generateImage = module.GetAttr("generateImage")!;
        long seed = -1;
        for (int i = 0; i < 10; ++i)
        {
            if(seed >= 0)
            {
                seed++;
            }
            var p = new PyTuple(
               pipeline,
               prompt,
               seed,
               832,        // width
               1216,       // height
               41,
               7.5,
               2);
            using PyDict? result = GenerateImage(generateImage, p);
        }
    }

    private static void Initialize()
    {
        string pythonHome = @"C:\Program Files\Python310";
        string pythonVenv = @"C:\Projects\venv";
        List<string> paths = [
            "",
            "C:\\Projects\\2024\\PythonInterop\\src\\Examples\\PythonSample",
            pythonHome,
            Path.Combine(pythonHome, "python310.zip"),
            Path.Combine(pythonHome, "DLLs"),
            Path.Combine(pythonHome, "lib"),
            pythonVenv,
            Path.Combine(pythonVenv, "Library", "bin"),
            Path.Combine(pythonVenv, "lib", "site-packages")
        ];
        Runtime.Initialize(new()
        {
            PythonDll = PythonDll,
            ProgramName = "PySharpSample",
            PythonHome = pythonHome,
            Path = string.Join(";", paths)
        });
    }

    private static void SayHello()
    {
        string script = @"s = ""Hello, World""
print(s)
";
        Console.WriteLine(Runtime.Run(script));
    }

    private static PyDict? GenerateImage(PyObject generateImage, PyTuple p)
    {
        PyObject result = generateImage.Invoke(p)!;
        if (result is PyDict dict)
        {
            SaveImage((PyBytes)dict.GetItem("image"));
            return dict;
        }
        return null;
    }

    private static void SaveImage(PyBytes result)
    {
        string path = "D:\\Images";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName = Path.Combine(path, $"net_{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")}.png");

        using (var output = File.Create(fileName))
        {
            Span<byte> chunk = stackalloc byte[1024];
            int length = result.GetLength();

            for (int offset = 0; offset < length;)
            {
                int read = result.Read(chunk, offset);
                if (read == 0)
                {
                    break;
                }
                output.Write(chunk.Slice(0, read));
                offset += read;
            }
        }
        Console.WriteLine($"Image written to {fileName}");
    }
}
