using PyRough.Python.Interop;

namespace PyRough.Python;

public unsafe class PyFloat : PyObject
{
    internal PyFloat(PyObjectHandle handle) : base(handle)
    {
        if (handle.GetPyType().Handle != Runtime.Api.PyFloat_Type)
        {
            throw new InvalidCastException();
        }
    }

    public PyFloat(double value) : this(FromDouble(value))
    {
    }

    public PyFloat(float value) : this(FromDouble(value))
    {
    }

    internal static PyObjectHandle FromDouble(double value)
    {
        return Runtime.Api.PyFloat_FromDouble(value);
    }

    public double Value => ToDouble();

    public double ToDouble()
    {
        return Runtime.Api.PyFloat_AsDouble(Handle);
    }

    public static explicit operator double(PyFloat value)
    {
        return value.ToDouble();
    }
}
