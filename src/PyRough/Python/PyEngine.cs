using System.Runtime.InteropServices;
using PyRough.Python.Interop;

namespace PyRough.Python;

public unsafe partial class PyEngine
{
    private static PyEngine _instance = null!;

    private readonly PythonApi314 _api;


    private PyEngine(PythonApi314 api)
    {
        _api = api;
    }

    private static PyEngine Instance => _instance;

    internal static PythonApi314 Api => Instance._api;

    public static void Initialize(PythonConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);

        string pythonDll = config.PythonDll;
        string programName = config.ProgramName;
        string home = config.Home;
        string path = config.Path;

        if (!NativeLibrary.TryLoad(pythonDll, typeof(PyEngine).Assembly, null, out nint module))
        {
            throw new InvalidOperationException();
        }
        var api = new PythonApi314(module);
        _instance = new PyEngine(api);
        _instance.Initialize(programName, home, path);
    }

    private void Initialize(string programName, string home, string path)
    {
        _api.Py_SetProgramName(new UcsNativeString(programName));
        _api.Py_SetPythonHome(new UcsNativeString(home));
        _api.Py_SetPath(new UcsNativeString(path));

        _api.Py_InitializeEx(0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="script"></param>
    /// <returns></returns>
    public static int Run(string script)
    {
        using Utf8NativeString buffer = new (script);
        return Api.PyRun_SimpleStringFlags(buffer, null);
    }
}
