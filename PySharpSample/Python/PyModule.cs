using PySharpSample.Python.Interop;
using static PySharpSample.Python.Interop.Py;

namespace PySharpSample.Python;

public unsafe class PyModule : PyObject
{
    internal PyModule(nint handler)
        : base((PythonApi314._PyObject*)handler.ToPointer())
    {
    }

    public static PyModule Import(string name)
    {
        using Utf8String buffer = Utf8String.Create(name);
        PythonApi314._PyObject* unicode;
        fixed (byte* ptr = buffer.Data)
        {
            unicode = Api.PyUnicode_DecodeFSDefault(ptr);
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
