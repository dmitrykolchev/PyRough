using PySharpSample.Python.Interop;

namespace PySharpSample.Python;

public unsafe class PyFloat : PyObject
{
    internal PyFloat(PythonApi314._PyObject* pyobj) : base(pyobj)
    {
        if ((*pyobj).ob_type != Py.Api.PyFloat_Type)
        {
            throw new InvalidCastException();
        }
    }

    public double Value => ToDouble();

    public double ToDouble()
    {
        return Py.Api.PyFloat_AsDouble(ToPyObject());
    }

    public static PyFloat FromDouble(double value)
    {
        return new PyFloat(Py.Api.PyFloat_FromDouble(value));
    }

    public static explicit operator double(PyFloat value)
    {
        return value.ToDouble();
    }
}
