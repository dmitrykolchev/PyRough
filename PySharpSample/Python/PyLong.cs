using PySharpSample.Python.Interop;

namespace PySharpSample.Python;

public unsafe class PyLong : PyObject
{
    internal PyLong(PythonApi314._PyObject* pyobj) : base(pyobj)
    {
        if((*pyobj).ob_type != Py.Api.PyLong_Type)
        {
            throw new InvalidCastException();
        }
    }

    public long ToInt64()
    {
        return Py.Api.PyLong_AsLongLong(ToPyObject());
    }

    public int ToInt32()
    {
        return Py.Api.PyLong_AsLong(ToPyObject());
    }

    public double ToDouble()
    {
        return Py.Api.PyLong_AsDouble(ToPyObject());
    }

    public static PyLong FromInt64(long value)
    {
        return new PyLong(Py.Api.PyLong_FromLongLong(value));
    }

    public static PyLong FromInt32(int value)
    {
        return new PyLong(Py.Api.PyLong_FromLong(value));
    }

    public static PyLong FromDouble(double value)
    {
        return new PyLong(Py.Api.PyLong_FromDouble(value));
    }
}
