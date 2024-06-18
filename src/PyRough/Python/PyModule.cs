using PyRough.Python.Interop;
using System.Text;
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
        byte[] buffer = new byte[Encoding.UTF8.GetByteCount(name) + 1];
        Encoding.UTF8.GetBytes(name, 0, name.Length, buffer, 0);
        PythonApi314._PyObject* module;
        fixed (byte* ptr = buffer)
        {
            module = Api.PyImport_ImportModule(ptr);
        }
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
