using PyRough.Python.Interop;

namespace PyRough.Python;

public unsafe class PyLong : PyObject
{
    internal PyLong(PythonApi314._PyObject* pyobj) : base(pyobj)
    {
        if((*pyobj).ob_type != PyEngine.Api.PyLong_Type)
        {
            throw new InvalidCastException();
        }
    }

    public long ToInt64()
    {
        return PyEngine.Api.PyLong_AsLongLong(ToPyObject());
    }

    public int ToInt32()
    {
        return PyEngine.Api.PyLong_AsLong(ToPyObject());
    }

    public double ToDouble()
    {
        return PyEngine.Api.PyLong_AsDouble(ToPyObject());
    }

    public static PyLong FromInt64(long value)
    {
        return new PyLong(PyEngine.Api.PyLong_FromLongLong(value));
    }

    public static PyLong FromInt32(int value)
    {
        return new PyLong(PyEngine.Api.PyLong_FromLong(value));
    }

    public static PyLong FromDouble(double value)
    {
        return new PyLong(PyEngine.Api.PyLong_FromDouble(value));
    }
}
