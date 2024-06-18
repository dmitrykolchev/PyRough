using Python.Runtime;

namespace PythonNetSample;

internal class Program
{
    static void Main(string[] args)
    {
        Runtime.PythonDLL = @"C:\Program Files\Python310\python310.dll";
        var pathToVirtualEnv = "C:\\Projects\\2024\\PythonInterop\\PythonApplication1\\venv";

        Environment.SetEnvironmentVariable("CUDA_PATH", "C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v12.1", EnvironmentVariableTarget.Process);
        // be sure not to overwrite your existing "PATH" environmental variable.
        //var path = Environment.GetEnvironmentVariable("PATH").TrimEnd(';');
        //path = string.IsNullOrEmpty(path) ? pathToVirtualEnv : path + ";" + pathToVirtualEnv;
        //Environment.SetEnvironmentVariable("PATH", path, EnvironmentVariableTarget.Process);
        //Environment.SetEnvironmentVariable("PATH", pathToVirtualEnv, EnvironmentVariableTarget.Process);
        // Environment.SetEnvironmentVariable("PYTHONHOME", pathToVirtualEnv, EnvironmentVariableTarget.Process);
        //Environment.SetEnvironmentVariable("PYTHONPATH", $"{pathToVirtualEnv}\\Lib\\site-packages;{pathToVirtualEnv}\\Lib", EnvironmentVariableTarget.Process);

        List<string> paths = [
            "",
            "C:\\Projects\\2024\\PythonInterop\\PythonNetSample",
            "c:\\Program Files\\Python310\\python310.zip",
            "c:\\Program Files\\Python310\\DLLs",
            "c:\\Program Files\\Python310\\lib",
            "c:\\Program Files\\Python310",
            "C:\\Projects\\2024\\PythonInterop\\PythonApplication1\\venv",
            "C:\\Projects\\2024\\PythonInterop\\PythonApplication1\\venv\\lib\\site-packages"
        ];

        PythonEngine.PythonHome = pathToVirtualEnv;
        PythonEngine.PythonPath = string.Join(";", paths);

        PythonEngine.Initialize();

        PythonEngine.Exec(@"import sys

import torch");

    }
}
