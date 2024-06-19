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

        string model = @"C:\StableDiffusion\models\checkpoints\damnPonyxlRealistic_damnV20EXTREME.safetensors";
        
        var pipeline = createPipeline.Invoke(model);
        Console.WriteLine("SDXL pipeline created");

        var createPrompt = module.GetAttr("createPrompt");
        var prompt = createPrompt.Invoke(
            pipeline,
            "score_9, score_8_up, score_7_up, score_6_up, 1girl, gloves, stockings, lace collar, dark dungeon\r\ngloves, dynamic view angle, dynamic position, reading a book, long hair\r\nconcept art, realistic, lie on back, leaning to king size bed, combat boots, bra, mini skirt, raw, (dark skinned girl:1.4), d4rk01l",
            "score_6_up, score_5_up, score_4_up, female, woman, girl, she, text, watermark, low-quality, signature, moir pattern, downsampling, aliasing, distorted, blurry, glossy, blur, jpeg artifacts, compression artifacts, poorly drawn, low-resolution, bad, distortion, twisted, excessive, exaggerated pose, exaggerated limbs, grainy, symmetrical, duplicate, error, pattern, beginner, pixelated, fake, hyper, glitch, overexposed, high-contrast, bad-contrast, (panties:1.6)"
            );

        Console.WriteLine("prompt created");
        prompt!.Dump();

        PyObject generateImage = module.GetAttr("generateImage");
        PyTuple p = PyTuple.Create(
            pipeline,
            prompt,
            -1,
            512,        // width
            512,       // height
            25,
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
