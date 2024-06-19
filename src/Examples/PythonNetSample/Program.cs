using Python.Runtime;

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

        using var createPipeline = module.GetAttr("createPipeline");

        string model = @"C:\StableDiffusion\models\checkpoints\dreamDiffusionPonyBy_v1.safetensors";
        using var pipeline = createPipeline.Invoke(model);
        Console.WriteLine("SDXL pipeline created");

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

    private static void SaveImage(PyObject result)
    {
        //byte[] data = result.ToArray();
        //Span<byte> chunk = stackalloc byte[1024];
        //int length = result.GetLength();

        //string path = "C:\\Projects\\2024\\PythonInterop\\src\\Examples\\PyRoughSample\\images";
        //string fileName = Path.Combine(path, $"net_{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")}.png");

        //using (var output = File.Create(fileName))
        //{
        //    for (int offset = 0; offset < length;)
        //    {
        //        int read = result.Read(chunk, offset);
        //        if (read == 0)
        //        {
        //            break;
        //        }
        //        output.Write(chunk.Slice(0, read));
        //        offset += read;
        //    }
        //}
        //Console.WriteLine($"Image written to {fileName}");
    }

}
