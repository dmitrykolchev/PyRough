using PyRough.Python.Interop;
using System.Runtime.InteropServices;

namespace PyRough.Python;

public partial class Runtime
{
    private static Runtime Instance = null!;

    private readonly Python310 _api;

    private Runtime(Python310 api)
    {
        _api = api;
    }

    public static bool IsInitialize => Instance != null;

    public static PyObject True { get; private set; } = null!;
    public static PyObject False { get; private set; } = null!;
    public static PyObject None { get; private set; } = null!;

    internal static Python310 Api => Instance._api;

    public static void Initialize(PythonConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);

        string pythonDll = config.PythonDll;
        string programName = config.ProgramName;
        string home = config.PythonHome;
        string path = config.Path;

        if (!NativeLibrary.TryLoad(pythonDll, typeof(Runtime).Assembly, null, out nint module))
        {
            throw new InvalidOperationException();
        }
        var api = new Python310(module);
        Instance = new Runtime(api);
        Instance.InitializeInternal(config);
    }

    private unsafe void InitializeInternal(PythonConfiguration config)
    {
        if (_api.Py_IsInitialized() == 0)
        {
            using UcsString programName = new(config.ProgramName);
            _api.Py_SetProgramName(programName);
            using UcsString pythonHome = new(config.PythonHome);
            _api.Py_SetPythonHome(pythonHome);
            using UcsString path = new(config.Path);
            _api.Py_SetPath(path);

            _api.Py_InitializeEx(1);

            if (_api.PyEval_ThreadsInitialized() != 0)
            {
                _api.PyEval_InitThreads();
            }
            using var buildins = PyModule.Import("builtins");
            None = buildins.GetAttr("None")!;
            True = buildins.GetAttr("True")!;
            False = buildins.GetAttr("False")!;
        }
    }

    public static GILState AcquireLock()
    {
        return new GILState();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="script"></param>
    /// <returns></returns>
    public unsafe static int Run(string script)
    {
        using Utf8String buffer = new(script);
        return Api.PyRun_SimpleStringFlags(buffer, null);
    }
}
