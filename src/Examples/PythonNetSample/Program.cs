using Python.Runtime;

namespace PythonNetSample;

internal class Program
{
    private static void Main(string[] args)
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
            //"score_9, score_8_up, score_7_up, Expressiveh, one sexy dark-skinned Mexican girl, long wet hair, female focus, lustrous skin, parted lips, slender, large breasts, through breasts silhouette, blurry body silhouette, naked transparent shirt, oversized shirt, shirt overhang, see-through shirt, see-through silhouette, HD32k, expressiveh, arched back, sexy pose, under an outdoor shower, wet skin, wet hair, perfect body, wide hips, narrow waist, barefoot, bottomless, perfect innie pussy, tight thin labia, hands on own head, wet hair, wet skin, wet shirt, supermodel pose, chest thrust out, outdoors, on the beach, sun high in the sky, well lit, sexy trimmed pubic hair, standing, showering, eyes closed, 3/4 angle view, three quarter view, view from below, (head titled up:1.4), (outdoor shower), arched back, contrapposto pose, (3/4 view:1.5),  (wet hair:1.4)",
            //"score_9, score_8_up, score_7_up,  1girl, valkyrie in gorgeous armor is holding a spear in hand, (side view, solo:1.1), standing, golden laurel wreath crown, goddess, pale skin, beautiful face, armored dress, wings, looking at viewer, cloudy sky, holy light, light from clouds, fantasy theme, expressiveh, d4rk01l",
            //"score_9, score_8_up, score_8, score_7_up, score_7, score_6_up, score_6, score_5_up, Score_5, girl, beautiful face, turn back, wet small hair,  narrow hips , naked, juicy ass, sexy adult  , posing , halfbody portrait , back view , bathroom , wet , soapy body , foam , shower , from below , luxury bathroom , blue tiles , dynamic",
            "score_9, score_8_up, score_8_up, 1girl, in a bathtub, naked, soap,  ((sexy eye contact)), parted lips, kneeling, Ass up,  nsfw,  wet skin, showing off her body,  dreamy eyes, sweaty skin, panam palmer, arching back,  fit body, thick thighs,, thin waists, godrays, shower tiles, bathroom interior, steam, rain, view from above, chairs, expressiveh, d4rk01l",
            //"score_6, score_5, score_4, pony, gaping, muscular, censored, furry, milf, child, kid, chibi, monochrome, grayscale, bra, panties, upturned eyes"
            //"score_6, score_5, score_4, pony, muscular, censored, furry"
            //"core_6, score_5, score_4, worst quality, low quality, text, censored, deformed, bad hand, blurry, (watermark), multiple phones, weights, bunny ears, extra hands,"
            "core_6, score_5, score_4, worst quality, low quality, text, censored, deformed, bad hand, blurry, (watermark), multiple phones, weights, bunny ears, extra hands,"
            );
        Console.WriteLine("prompt created");

        PyObject generateImage = module.GetAttr("generateImage");
        PyTuple p = PyTuple.Create(
            pipeline,
            prompt,
            1850901881,
            816,           // width
            1152,           // height
            40,
            7,
            2);
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
        PyBytes result = new(bytes);

        byte[] data = result.ToArray();
        Span<byte> chunk = stackalloc byte[1024];
        int length = result.Size;

        string path = "C:\\Projects\\2024\\PythonInterop\\images";
        if (!Directory.Exists(path))
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
