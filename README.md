# PyRough

PyRough is a package that gives .Net prorgammers to embed Python into the .NET runtime environment


## Python Runtime initialization

``` csharp
string pythonHome = @"C:\Program Files\Python310";
string pythonVenv = @"C:\Projects\venv";

List<string> paths = [
    "",
    Path.Combine(projectHome, "Examples", "PythonSample"),
    Path.Combine(pythonHome, "python310.zip"),
    Path.Combine(pythonHome, "DLLs"),
    Path.Combine(pythonHome, "lib"),
    pythonHome,
    pythonVenv,
    Path.Combine(pythonVenv, "Library", "bin"),
    Path.Combine(pythonVenv, "lib", "site-packages")
];
Runtime.Initialize(new()
{
    PythonDll = PythonDll,
    ProgramName = "PyRoughSample",
    PythonHome = pythonHome,
    Path = string.Join(";", paths)
});
```

## Simple way to run Python from .NET

``` csharp
private static void SayHello()
{
    string script = @"s = ""Hello, World""
print(s)
";
    Console.WriteLine(Runtime.Run(script));
}
```
