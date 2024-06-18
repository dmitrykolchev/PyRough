using System.Runtime.InteropServices;

namespace PySharpSample.Python.Interop;

internal unsafe partial class Py
{
    private static Py _instance = null!;

    private readonly PythonApi _api;

#pragma warning disable CS0649
    internal class PythonApi(nint module) : ApiTable(module)
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct _PyObject
        {
            public nint ob_refcnt;
            public nint ob_type;
        }
        [Import] public delegate* unmanaged[Cdecl]<int, void> Py_InitializeEx;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, void> Py_IncRef;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, void> Py_DecRef;
        [Import] public delegate* unmanaged[Cdecl]<char*, void> Py_SetProgramName;
        [Import] public delegate* unmanaged[Cdecl]<char*, void> Py_SetPythonHome;
        [Import] public delegate* unmanaged[Cdecl]<char*, void> Py_SetPath;

        [Import] public delegate* unmanaged[Cdecl]<void> PyByteArray_Type;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte*> PyByteArray_AsString;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> PyByteArray_Concat;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint> PyByteArray_Size;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint, int> PyByteArray_Resize;
        [Import] public delegate* unmanaged[Cdecl]<byte*, nint, _PyObject*> PyByteArray_FromStringAndSize;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyByteArray_FromObject;

        [Import] public delegate* unmanaged[Cdecl]<void> PyBytesIter_Type;
        [Import] public delegate* unmanaged[Cdecl]<void> PyBytes_Type;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte*> PyBytes_AsString;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte**, nint*, int> PyBytes_AsStringAndSize;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject**, _PyObject*, void> PyBytes_Concat;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject**, _PyObject*, void> PyBytes_ConcatAndDel;
        [Import] public delegate* unmanaged[Cdecl]<byte*, nint, byte*, nint, byte*, _PyObject*> PyBytes_DecodeEscape;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyBytes_FromObject;
        [Import] public delegate* unmanaged[Cdecl]<byte*, _PyObject*> PyBytes_FromString;
        [Import] public delegate* unmanaged[Cdecl]<byte*, nint, _PyObject*> PyBytes_FromStringAndSize;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, int, _PyObject*> PyBytes_Repr;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint> PyBytes_Size;

        [Import] public delegate* unmanaged[Cdecl]<void> PyErr_Print;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*> PyErr_Occurred;

        [StructLayout(LayoutKind.Sequential)]
        public struct _PyVarObject
        {
            public PyObject ob_base;
            public nint ob_size;
        }

        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyImport_Import;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte*, _PyObject*> PyObject_GetAttrString;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> PyObject_CallObject;

        [StructLayout(LayoutKind.Sequential)]
        public struct _PyCompilerFlags
        {
            public int cf_flags;
            public int cf_feature_version;
        }
        [Import] public delegate* unmanaged[Cdecl]<byte*, _PyCompilerFlags*, int> PyRun_SimpleStringFlags;

        [Import] public delegate* unmanaged[Cdecl]<nint, _PyObject*> PyTuple_New;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint> PyTuple_Size;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint, _PyObject*> PyTuple_GetItem;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint, _PyObject*, int> PyTuple_SetItem;

        [Import] public delegate* unmanaged[Cdecl]<void*, byte*> _PyType_Name;

        [Import] public delegate* unmanaged[Cdecl]<byte*, _PyObject*> PyUnicode_DecodeFSDefault;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint> PyUnicode_GetLength;
        [Import] public delegate* unmanaged[Cdecl]<_PyObject*, char*, nint, nint> PyUnicode_AsWideChar;
        [Import] public delegate* unmanaged[Cdecl]<char*, nint, _PyObject*> PyUnicode_FromWideChar;

    }

#pragma warning restore CS0649

    private Py(PythonApi api)
    {
        _api = api;
    }

    private static Py Instance => _instance;

    public static PythonApi Api => Instance._api;

    public static void Initialize(PythonConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);

        string pythonDll = config.PythonDll;
        string programName = config.ProgramName;
        string home = config.Home;
        string path = config.Path;

        if (!NativeLibrary.TryLoad(pythonDll, typeof(Py).Assembly, null, out nint module))
        {
            throw new InvalidOperationException();
        }
        var api = new PythonApi(module);
        _instance = new Py(api);
        _instance.Initialize(programName, home, path);
    }

    private void Initialize(string programName, string home, string path)
    {
        fixed (char* p = programName)
        {
            _api.Py_SetProgramName(p);
        }
        fixed (char* p = home)
        {
            _api.Py_SetPythonHome(p);
        }
        fixed (char* p = path)
        {
            _api.Py_SetPath(p);
        }
        _api.Py_InitializeEx(1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="script"></param>
    /// <returns></returns>
    public static int Run(string script)
    {
        using Utf8String buffer = Utf8String.Create(script);
        fixed (byte* ptr = buffer.Data)
        {
            return Api.PyRun_SimpleStringFlags(ptr, null);
        }
    }
}
