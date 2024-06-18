using PyRough.Python.Interop;

namespace PyRough.Python;

public unsafe class PyByteArray : PyObject
{
    internal PyByteArray(PythonApi314._PyObject* handler) : base(handler)
    {
    }

    public static PyByteArray FromObject(PyObject obj)
    {
        return new PyByteArray(PyEngine.Api.PyByteArray_FromObject(obj.ToPyObject()));
    }

    public static PyByteArray FromStringAndSize(ReadOnlySpan<byte> bytes)
    {
        fixed (byte* ptr = bytes)
        {
            return new PyByteArray(PyEngine.Api.PyByteArray_FromStringAndSize(ptr, bytes.Length));
        }
    }

    public int GetLength()
    {
        return PyEngine.Api.PyByteArray_Size(ToPyObject()).ToInt32();
    }

    public byte[] ToArray()
    {
        byte* ptr = PyEngine.Api.PyByteArray_AsString(ToPyObject());
        int length = GetLength();
        byte[] result = new byte[length];
        fixed (byte* source = result)
        {
            Buffer.MemoryCopy(ptr, source, length, length);
        }
        return result;
    }

    public static PyByteArray Cast(PyObject o)
    {
        if (o.GetPyType().Handler == (nint)PyEngine.Api.PyByteArray_Type)
        {
            PythonApi314._PyObject* pyObj = o.ToPyObject();
            PyEngine.Api.Py_IncRef(pyObj);
            return new PyByteArray(pyObj);
        }
        throw new InvalidCastException();
    }

    public override PyTypeObject GetPyType()
    {
        return new PyTypeObject(PyEngine.Api.PyByteArray_Type);
    }
}
