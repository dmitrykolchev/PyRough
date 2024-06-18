using PySharpSample.Python.Interop;

namespace PySharpSample.Python;
public unsafe class PyTuple : PyObject
{
    internal PyTuple(PythonApi314._PyObject* handler) : base(handler)
    {
    }

    public static PyTuple Create(int size)
    {
        PythonApi314._PyObject* tuple = Py.Api.PyTuple_New(size);
        return new PyTuple(tuple);
    }

    public void SetItem(int index, PyObject value)
    {
        PythonApi314._PyObject* v = value == null ? null : value.ToPyObject();
        int result = Py.Api.PyTuple_SetItem(ToPyObject(), index, v);
        if (result == -1)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public PyObject GetItem(int index)
    {
        PythonApi314._PyObject* result = Py.Api.PyTuple_GetItem(ToPyObject(), index);
        return new PyObject(result);
    }
}
