using PyRough.Python.Interop;
using static PyRough.Python.PyEngine;

namespace PyRough.Python;

public unsafe class PyModule : PyObject
{
    internal PyModule(PythonApi314._PyObject* pyobj)
        : base(pyobj)
    {
    }

    public static PyModule Import(string name)
    {
        using Utf8NativeString str = new (name);
        PythonApi314._PyObject* module;
        module = Api.PyImport_ImportModule(str);
        if (module == null)
        {
            if (Api.PyErr_Occurred() != null)
            {
                Api.PyErr_Print();
            }
            throw new InvalidOperationException();
        }
        return new PyModule(module);
    }
}
