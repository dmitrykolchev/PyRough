using PySharpSample.Python;
using PySharpSample.Python.Interop;
using System.Reflection;

namespace PySharpSample;

internal class Program
{
    private const string PythonDll = @"C:\Program Files\Python310\python310.dll";

    private static void Main(string[] args)
    {
        string pythonHome = @"C:\Program Files\Python310";

        List<string> paths = [
            "",
            "C:\\Projects\\2024\\PythonInterop\\PythonApplication1",
            "c:\\Program Files\\Python310\\python310.zip",
            "c:\\Program Files\\Python310\\DLLs",
            "c:\\Program Files\\Python310\\lib",
            "c:\\Program Files\\Python310",
            "C:\\Projects\\venv",
            "C:\\Projects\\venv\\Library\\bin",
            "C:\\Projects\\venv\\lib\\site-packages"
        ];
        Py.Initialize(new()
        {
            PythonDll = PythonDll,
            ProgramName = "PySharpSample",
            Home = pythonHome,
            Path = string.Join(";", paths)
        });

        string script1 = "s = \"Здравствуй Мир\"\n";

        Console.WriteLine(Py.Run(script1));

        string script2 = @"
import example
import os
import sys
from pathlib import Path

p = Path.cwd()
print(p)
print(sys.path)
";
        Console.WriteLine(Py.Run(script2));

        using PyModule module1 = PyModule.Import(@"example");

        //using var sayHelloFunc = module1.GetAttribute("sayHello");
        //using var tuple = PyTuple.Create(1);
        //using PyObject? a1 = PyUnicode.FromString("Dmitry Kolchev");
        //tuple.SetItem(0, a1!);
        //var r = sayHelloFunc.Call(tuple);
        //Console.WriteLine(PyUnicode.ToString(r));

        using var generateImage = module1.GetAttribute("generateImage");
        string model = "juggernautXL_juggernautX.safetensors";

        //def generateImage(modelPath: str, seed: int, prompt: str, negative_prompt: str, width: int,
        //                  height: int, steps: int, scale: float, clip_skip: int):

        using var p = PyTuple.FromList(
            $"C:\\StableDiffusion\\models\\checkpoints\\{model}",
            -1,
            "HDR, editorial (full body:1.6) wide angle photograph of a beautiful young 1970s \\(style\\) redhead teen woman posing++ under a wooden dock at the ocean, waist deep in water, large waves crashing, (seductive:1.6), wet skin, ((low camera angle)), strong wind through her hair, tattoos, highly detailed face, sexy, cleavage, (sheer:1.2) shirt and panties, by lee jeffries, nikon d850, film stock photograph, 4 kodak portra 400, soft cinematic light and color, dreamlike soft focus, camera f1.6 lens, rich colors, hyper realistic, lifelike texture, dramatic lighting, cinestill 800",
            "child, baby, Asian, big breasts, anime, manga, anorexic, anorexia, canvas frame, text, old, mature, lazy eye, crossed eyes,  gun, drawing, overexposed, high contrast, cartoon, 3d, disfigured, bad art, deformed, extra limbs, b&w, blurry, duplicate, morbid, mutilated,  out of frame, extra fingers, mutated hands, drawing, poorly drawn hands, poorly drawn face, mutation, deformed, ugly, blurry, weapon, bad anatomy,  bad proportions, painting, extra limbs, cloned face, disfigured, out of frame, ugly, extra limbs, text, bad anatomy",
            896,        // width
            1152,       // height
            30,
            7.5,
            0);

        using PyBytes result = (PyBytes) generateImage.Call(p)!;

        //using var func = module1.GetAttribute("txt2image");

        //using var result = func.Call();

        //using var pyArray = PyBytes.Cast(result);
        
        byte[] data = result.ToArray();
        Span<byte> chunk = stackalloc byte[1024];
        int length = result.GetLength();
        string fileName = $"net_{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")}.png";
        using (var output = File.Create(fileName))
        {
            for(int offset = 0; offset < length; )
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
