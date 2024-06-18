using PySharpSample.Python.Interop;
using System.Runtime.InteropServices;

namespace PySharpSample.Python;

public unsafe class PyTypeObject : PyObject
{
    internal PyTypeObject(Py.PythonApi._PyObject* handler) : base(handler)
    {
    }

    protected override void Dispose(bool disposing)
    {
    }

    public string Name => GetName();

    public static PyTypeObject GetPyType(PyObject obj)
    {
        Py.PythonApi._PyObject* pyObj = obj.ToPyObject();
        return new PyTypeObject((Py.PythonApi._PyObject*)(*pyObj).ob_type.ToPointer());
    }

    public string GetName()
    {
        byte* ptr = Py.Api._PyType_Name(ToPyObject());
        return Marshal.PtrToStringUTF8((nint)ptr)!;
    }
}
