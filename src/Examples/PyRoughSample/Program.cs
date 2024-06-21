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

        var createPipeline = module.GetAttr("createPipeline")!;
        // @"C:\StableDiffusion\models\checkpoints\halcyonSDXL_v13NSFW.safetensors"
        string model = @"C:\StableDiffusion\models\checkpoints\ponyDiffusionV6XL_v6StartWithThisOne.safetensors";
        //string model = @"C:\StableDiffusion\models\checkpoints\realcartoonXL_v6.safetensors";
        //string model = @"C:\StableDiffusion\models\checkpoints\juggernautXL_juggernautX.safetensors";

        List<(string, double)> loras = [
            ("Fant5yP0ny", 0.7),
            ("Expressive_H-000001", 0.6),
            ("RELSM_v1", 0.9),
            ("d4rk01lXLP", 0.8),
            ("Concept Art Twilight Style SDXL_LoRA_Pony Diffusion V6 XL", 0.8)
        ];
        PyList pyLoras = new (loras);
        var pipeline = createPipeline.Invoke(model, pyLoras)!;
        Console.WriteLine("SDXL pipeline created");

        var createPrompt = module.GetAttr("createPrompt")!;
        var prompt = createPrompt.Invoke(
            pipeline,
            //"score_9, score_8_up, score_7_up, score_6_up, realistic, raw, rating_explicit, editorial (full body:1.6) wide angle photograph of a beautiful young 1970s \\(style\\) redhead teen woman posing++ under a wooden dock at the ocean, waist deep in water, large waves crashing, (seductive:1.6), wet skin, ((low camera angle)), strong wind through her hair, tattoos, highly detailed face, sexy, cleavage, (sheer:1.2) shirt and panties, by lee jeffries, nikon d850, film stock photograph, 4 kodak portra 400, soft cinematic light and color, dreamlike soft focus, camera f1.6 lens, rich colors, hyper realistic, lifelike texture, dramatic lighting, cinestill 800",
            "score_9, score_8_up, score_8_up, 1girl, in a bathtub, naked, soap,  ((sexy eye contact)), parted lips, kneeling, Ass up,  nsfw,  wet skin, showing off her body,  dreamy eyes, sweaty skin, panam palmer, arching back,  fit body, thick thighs, thin waists, godrays, shower tiles, bathroom interior, steam, rain, view from above, chairs, expressiveh, d4rk01l, raw, conceptual art",
            //"child, baby, Asian, big breasts, anime, manga, anorexic, anorexia, canvas frame, text, old, mature, lazy eye, crossed eyes,  gun, drawing, overexposed, high contrast, cartoon, 3d, disfigured, bad art, deformed, extra limbs, b&w, blurry, duplicate, morbid, mutilated,  out of frame, extra fingers, mutated hands, drawing, poorly drawn hands, poorly drawn face, mutation, deformed, ugly, blurry, weapon, bad anatomy,  bad proportions, painting, extra limbs, cloned face, disfigured, out of frame, ugly, extra limbs, text, bad anatomy"
            "core_6, score_5, score_4, worst quality, low quality, text, censored, deformed, bad hand, blurry, (watermark), multiple phones, weights, bunny ears, extra hands,"
            )!;

        Console.WriteLine($"{prompt.ToString()}");

        var generateImage = module.GetAttr("generateImage")!;
        for (int i = 0; i < 10; ++i)
        {
            var p = new PyTuple(
               pipeline,
               prompt,
               -1,
               1152,        // width
               816,       // height
               30,
               7.5,
               2);
            using PyDict? result = GenerateImage(generateImage, p);
        }
    }

    private static void Initialize()
    {
        string pythonHome = @"C:\Program Files\Python310";

        List<string> paths = [
            "",
            "C:\\Projects\\2024\\PythonInterop\\src\\Examples\\PythonSample",
            "c:\\Program Files\\Python310\\python310.zip",
            "c:\\Program Files\\Python310\\DLLs",
            "c:\\Program Files\\Python310\\lib",
            "c:\\Program Files\\Python310",
            "C:\\Projects\\venv",
            "C:\\Projects\\venv\\Library\\bin",
            "C:\\Projects\\venv\\lib\\site-packages"
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
        string script1 = "s = \"Hello, World\"\n";

        Console.WriteLine(Runtime.Run(script1));

        string script2 = @"
print(s)
";
        Console.WriteLine(Runtime.Run(script2));
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
        string path = "C:\\Projects\\2024\\PythonInterop\\images";
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
