using PyRough.Python;

namespace PyRoughSample;

internal class Program
{
    private const string PythonDll = @"C:\Program Files\Python310\python310.dll";

    private static void Main(string[] args)
    {
        Initialize();

        SayHello();

        using PyModule module1 = PyModule.Import(@"example");
        
        using var createPipeline = module1.GetAttribute("createPipeline");
        // @"C:\StableDiffusion\models\checkpoints\halcyonSDXL_v13NSFW.safetensors"
        //string model = @"C:\StableDiffusion\models\checkpoints\ponyDiffusionV6XL_v6StartWithThisOne.safetensors";
        string model = @"C:\StableDiffusion\models\checkpoints\dreamDiffusionPonyBy_v1.safetensors";
        using var pipeline = createPipeline.Call(model);
        Console.WriteLine("SDXL pipeline created");
        pipeline!.Dump();

        using var createPrompt = module1.GetAttribute("createPrompt");
        using var prompt = createPrompt.Call(
            pipeline,
            "score_9, score_8_up, score_7_up, score_6_up, HDR, editorial (full body:1.6) wide angle photograph of a beautiful young 1970s \\(style\\) redhead teen woman posing++ under a wooden dock at the ocean, waist deep in water, large waves crashing, (seductive:1.6), wet skin, ((low camera angle)), strong wind through her hair, tattoos, highly detailed face, sexy, cleavage, (sheer:1.2) shirt and panties, by lee jeffries, nikon d850, film stock photograph, 4 kodak portra 400, soft cinematic light and color, dreamlike soft focus, camera f1.6 lens, rich colors, hyper realistic, lifelike texture, dramatic lighting, cinestill 800, rating_explicit",
            "child, baby, Asian, big breasts, anime, manga, anorexic, anorexia, canvas frame, text, old, mature, lazy eye, crossed eyes,  gun, drawing, overexposed, high contrast, cartoon, 3d, disfigured, bad art, deformed, extra limbs, b&w, blurry, duplicate, morbid, mutilated,  out of frame, extra fingers, mutated hands, drawing, poorly drawn hands, poorly drawn face, mutation, deformed, ugly, blurry, weapon, bad anatomy,  bad proportions, painting, extra limbs, cloned face, disfigured, out of frame, ugly, extra limbs, text, bad anatomy"
            );

        Console.WriteLine("prompt created");
        prompt!.Dump();

        using var generateImage = module1.GetAttribute("generateImage");
        using var p = PyTuple.FromList(
            pipeline,
            prompt,
            -1,
            896,        // width
            1152,       // height
            30,
            7.5,
            0);
        for (int i = 0; i < 10; ++i)
        {
            GenerateImage(generateImage, p);
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
        PyEngine.Initialize(new()
        {
            PythonDll = PythonDll,
            ProgramName = "PySharpSample",
            Home = pythonHome,
            Path = string.Join(";", paths)
        });
    }

    private static void SayHello()
    {
        string script1 = "s = \"Hello, World\"\n";

        Console.WriteLine(PyEngine.Run(script1));

        string script2 = @"
print(s)
";
        Console.WriteLine(PyEngine.Run(script2));
    }

    private static void GenerateImage(PyObject generateImage, PyTuple p)
    {
        PyBytes result = (PyBytes)generateImage.Call(p)!;

        SaveImage(result);
    }

    private static void SaveImage(PyBytes result)
    {
        byte[] data = result.ToArray();
        Span<byte> chunk = stackalloc byte[1024];
        int length = result.GetLength();

        string path = "C:\\Projects\\2024\\PythonInterop\\src\\Examples\\PyRoughSample\\images";
        string fileName = Path.Combine(path, $"net_{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")}.png");

        using (var output = File.Create(fileName))
        {
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
