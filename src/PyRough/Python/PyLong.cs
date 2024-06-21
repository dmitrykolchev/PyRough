using PyRough.Python.Interop;

namespace PyRough.Python;

public unsafe class PyLong : PyObject
{
    internal PyLong(PyObjectHandle handle) : base(handle)
    {
        if(handle.GetPyType().Handle != Runtime.Api.PyLong_Type)
        {
            throw new InvalidCastException();
        }
    }

    public PyLong(int value) : base(FromInt32(value))
    {
    }

    public PyLong(long value): base(FromInt64(value))
    {
    }

    public PyLong(double value): base(FromDouble(value))
    {
    }

    internal static PyObjectHandle FromInt64(long value)
    {
        return Runtime.Api.PyLong_FromLongLong(value);
    }

    internal static PyObjectHandle FromInt32(int value)
    {
        return Runtime.Api.PyLong_FromLong(value);
    }

    internal static PyObjectHandle FromDouble(double value)
    {
        return Runtime.Api.PyLong_FromDouble(value);
    }

    public static explicit operator long(PyLong value)
    {
        return value.ToInt64();
    }

    public static explicit operator int(PyLong value)
    {
        return value.ToInt32();
    }

    public static explicit operator double(PyLong value)
    {
        return value.ToDouble();
    }

    public long ToInt64()
    {
        return Runtime.Api.PyLong_AsLongLong(Handle);
    }

    public int ToInt32()
    {
        return Runtime.Api.PyLong_AsLong(Handle);
    }

    public double ToDouble()
    {
        return Runtime.Api.PyLong_AsDouble(Handle);
    }
}
