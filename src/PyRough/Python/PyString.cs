using PyRough.Python.Interop;

namespace PyRough.Python;

internal unsafe class PyString : PyObject
{
    internal PyString(PyObjectHandle o) : base(o)
    {
        if (o.GetPyType().Handle != Runtime.Api.PyUnicode_Type)
        {
            throw new InvalidCastException();
        }
    }

    public PyString(string value): this(FromString(value))
    {
    }

    public int Length => GetLength();

    public string Value => ToString();

    public int GetLength()
    {
        return Runtime.Api.PyUnicode_GetLength(Handle).ToInt32();
    }

    public override string ToString()
    {
        int length = GetLength();
        fixed (char* ptr = new char[length])
        {
            int read = Runtime.Api.PyUnicode_AsWideChar(Handle, ptr, length).ToInt32();
            return new string(ptr, 0, length);
        }
    }

    internal static PyObjectHandle FromString(string s)
    {
        ArgumentNullException.ThrowIfNull(s);
        fixed (char* ptr = s)
        {
            return Runtime.Api.PyUnicode_FromWideChar(ptr, s.Length);
        }
    }
}
