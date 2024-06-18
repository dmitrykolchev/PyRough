using PySharpSample.Python.Interop;

namespace PySharpSample.Python;
public unsafe class PyByteArray : PyObject
{
    internal PyByteArray(Py.PythonApi._PyObject* handler) : base(handler)
    {
    }

    public static PyByteArray FromObject(PyObject obj)
    {
        return new PyByteArray(Py.Api.PyByteArray_FromObject(obj.ToPyObject()));
    }

    public static PyByteArray FromStringAndSize(ReadOnlySpan<byte> bytes)
    {
        fixed (byte* ptr = bytes)
        {
            return new PyByteArray(Py.Api.PyByteArray_FromStringAndSize(ptr, bytes.Length));
        }
    }

    public int GetLength()
    {
        return Py.Api.PyByteArray_Size(ToPyObject()).ToInt32();
    }

    public byte[] ToArray()
    {
        byte* ptr = Py.Api.PyByteArray_AsString(ToPyObject());
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
        if (o.GetPyType().Handler == (nint)Py.Api.PyByteArray_Type)
        {
            Py.PythonApi._PyObject* pyObj = o.ToPyObject();
            Py.Api.Py_IncRef(pyObj);
            return new PyByteArray(pyObj);
        }
        throw new InvalidCastException();
    }

    public override PyTypeObject GetPyType()
    {
        return new PyTypeObject((Py.PythonApi._PyObject*)Py.Api.PyByteArray_Type);
    }
}
