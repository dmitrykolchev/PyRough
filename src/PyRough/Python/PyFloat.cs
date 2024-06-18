using PyRough.Python.Interop;

namespace PyRough.Python;

public unsafe class PyFloat : PyObject
{
    internal PyFloat(PythonApi314._PyObject* pyobj) : base(pyobj)
    {
        if ((*pyobj).ob_type != PyEngine.Api.PyFloat_Type)
        {
            throw new InvalidCastException();
        }
    }

    public double Value => ToDouble();

    public double ToDouble()
    {
        return PyEngine.Api.PyFloat_AsDouble(ToPyObject());
    }

    public static PyFloat FromDouble(double value)
    {
        return new PyFloat(PyEngine.Api.PyFloat_FromDouble(value));
    }

    public static explicit operator double(PyFloat value)
    {
        return value.ToDouble();
    }
}
