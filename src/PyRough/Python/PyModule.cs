using PyRough.Python.Interop;
using System.Text;
using static PyRough.Python.PyEngine;

namespace PyRough.Python;

public unsafe class PyModule : PyObject
{
    internal PyModule(nint handler)
        : base((PythonApi314._PyObject*)handler.ToPointer())
    {
    }

    public static PyModule Import(string name)
    {
        //using Utf8String buffer = Utf8String.Create(name);
        byte[] utf8 = Encoding.UTF8.GetBytes(name);
        PythonApi314._PyObject* unicode;
        fixed (byte* ptr = utf8)
        {
            unicode = Api.PyUnicode_DecodeFSDefaultAndSize(ptr, utf8.Length);
        }
        PythonApi314._PyObject* module = Api.PyImport_Import(unicode);
        Api.Py_DecRef(unicode);
        if (module == null)
        {
            if (Api.PyErr_Occurred() != null)
            {
                Api.PyErr_Print();
            }
            throw new InvalidOperationException();
        }
        return new PyModule((nint)module);
    }
}
