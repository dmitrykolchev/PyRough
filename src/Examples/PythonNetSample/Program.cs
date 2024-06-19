using Python.Runtime;
using System.Reflection;

namespace PythonNetSample;

internal class Program
{
    static void Main(string[] args)
    {
        string PythonDll = @"C:\Program Files\Python310\python310.dll";
        Runtime.PythonDLL = PythonDll;

        PythonEngine.ProgramName = "PySharpSample";
        string pythonHome = @"C:\Program Files\Python310";
        PythonEngine.PythonHome = pythonHome;
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
        PythonEngine.PythonPath = string.Join(";", paths);

        PythonEngine.Initialize();

        SayHello();

        using var module = PyModule.Import("example");

        var createPipeline = module.GetAttr("createPipeline");

        string model = @"C:\StableDiffusion\models\checkpoints\ponyDiffusionV6XL_v6StartWithThisOne.safetensors";
        
        var pipeline = createPipeline.Invoke(model);
        Console.WriteLine("SDXL pipeline created");

        var createPrompt = module.GetAttr("createPrompt");
        var prompt = createPrompt.Invoke(
            pipeline,
            "score_9, score_8_up, score_7_up, score_6_up, sex anal, HDR, editorial (full body:1.6) wide angle photograph of a beautiful young 1970s \\(style\\) redhead teen woman posing++ under a wooden dock at the ocean, waist deep in water, large waves crashing, (seductive:1.6), wet skin, ((low camera angle)), strong wind through her hair, tattoos, highly detailed face, sexy, cleavage, (sheer:1.2) shirt and panties, film stock photograph, soft cinematic light and color, dreamlike soft focus, rich colors, hyper realistic, lifelike texture, dramatic lighting, rating_explicit",
            "child, baby, Asian, big breasts, anime, manga, anorexic, anorexia, canvas frame, text, old, mature, lazy eye, crossed eyes,  gun, drawing, overexposed, high contrast, cartoon, 3d, disfigured, bad art, deformed, extra limbs, b&w, blurry, duplicate, morbid, mutilated,  out of frame, extra fingers, mutated hands, drawing, poorly drawn hands, poorly drawn face, mutation, deformed, ugly, blurry, weapon, bad anatomy,  bad proportions, painting, extra limbs, cloned face, disfigured, out of frame, ugly, extra limbs, text, bad anatomy"
            );

        Console.WriteLine("prompt created");
        prompt!.Dump();

        PyObject generateImage = module.GetAttr("generateImage");
        PyTuple p = PyTuple.Create(
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

        PythonEngine.Shutdown();
    }

    private static void SayHello()
    {
        string script1 = "s = \"Hello, World\"\n";

        Console.WriteLine(PythonEngine.RunSimpleString(script1));

        string script2 = @"
print(s)
";
        Console.WriteLine(PythonEngine.RunSimpleString(script2));
    }

    private static void GenerateImage(PyObject generateImage, PyTuple p)
    {
        using var result = generateImage.Invoke(p)!;

        SaveImage(result);
    }

    private static void SaveImage(PyObject bytes)
    {
        PyBytes result = new (bytes);

        byte[] data = result.ToArray();
        Span<byte> chunk = stackalloc byte[1024];
        int length = result.Size;

        string path = "C:\\Projects\\2024\\PythonInterop\\images";
        if(!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
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
