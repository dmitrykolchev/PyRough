using PySharpSample.Python.Interop;
using System.Runtime.InteropServices;

namespace PySharpSample.Python;

public unsafe class PyTypeObject : PyObject
{
    internal PyTypeObject(PythonApi314._PyTypeObject* handler)
        : base((PythonApi314._PyObject*)handler)
    {
    }

    protected override void Dispose(bool disposing)
    {
    }

    public string Name => GetName();

    public static PyTypeObject GetPyType(PyObject obj)
    {
        PythonApi314._PyObject* pyObj = obj.ToPyObject();
        return new PyTypeObject((*pyObj).ob_type);
    }

    public string GetName()
    {
        byte* ptr = Py.Api._PyType_Name(ToPyObject());
        return Marshal.PtrToStringUTF8((nint)ptr)!;
    }
}
