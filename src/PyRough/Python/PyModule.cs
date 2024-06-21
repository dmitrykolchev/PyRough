using PyRough.Python.Interop;

namespace PyRough.Python;

public class PyModule : PyObject
{
    internal PyModule(PyObjectHandle handle)
        : base(handle)
    {
        if (handle.GetPyType().Handle != Runtime.Api.PyModule_Type)
        {
            throw new InvalidCastException();
        }
    }

    public static unsafe PyModule Import(string name)
    {
        using Utf8String str = new(name);
        PyObjectHandle module = Runtime.Api.PyImport_ImportModule(str);
        if (module.IsNull)
        {
            if (!Runtime.Api.PyErr_Occurred().IsNull)
            {
                Runtime.Api.PyErr_Print();
            }
            throw new InvalidOperationException();
        }
        return new PyModule(module);
    }
}
