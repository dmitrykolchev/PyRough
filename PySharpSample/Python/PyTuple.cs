using PySharpSample.Python.Interop;
using System.Reflection;

namespace PySharpSample.Python;
public unsafe class PyTuple : PyObject
{
    internal PyTuple(Py.PythonApi._PyObject* handler) : base(handler)
    {
    }

    public static PyTuple Create(int size)
    {
        Py.PythonApi._PyObject* tuple = Py.Api.PyTuple_New(size);
        return new PyTuple(tuple);
    }

    public void SetItem(int index, PyObject value)
    {
        Py.PythonApi._PyObject* v = value == null ? null : value.ToPyObject();
        int result = Py.Api.PyTuple_SetItem(ToPyObject(), index, v);
        if (result == -1)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public PyObject GetItem(int index)
    {
        Py.PythonApi._PyObject* result = Py.Api.PyTuple_GetItem(ToPyObject(), index);
        return new PyObject(result);
    }
}
