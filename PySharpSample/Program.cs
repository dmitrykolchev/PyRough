using PySharpSample.Python;
using PySharpSample.Python.Interop;

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

        using var sayHelloFunc = module1.GetAttribute("sayHello");
        using var tuple = PyTuple.Create(1);
        using PyObject? a1 = PyUnicode.Convert("Dmitry Kolchev");
        tuple.SetItem(0, a1!);
        var r = sayHelloFunc.Call(tuple);
        Console.WriteLine(PyUnicode.ToString(r));

        using var func = module1.GetAttribute("txt2image");

        using var result = func.Call();

        using var pyArray = PyBytes.Cast(result);

        
        byte[] data = pyArray.ToArray();
        Span<byte> chunk = stackalloc byte[1024];
        int length = pyArray.GetLength();

        using(var output = File.Create($"net_{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")}.png"))
        {
            for(int offset = 0; offset < length; )
            {
                int read = pyArray.Read(chunk, offset);
                if (read == 0)
                {
                    break;
                }
                output.Write(chunk.Slice(0, read));
                offset += read;
            }
        }
        Console.WriteLine(PyUnicode.ToString(result));
    }
}
