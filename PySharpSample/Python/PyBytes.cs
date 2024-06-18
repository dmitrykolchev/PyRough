using PySharpSample.Python.Interop;

namespace PySharpSample.Python;

public unsafe class PyBytes : PyObject
{
    internal PyBytes(PythonApi314._PyObject* handler) : base(handler)
    {
    }

    public static PyByteArray FromObject(PyObject obj)
    {
        return new PyByteArray(Py.Api.PyBytes_FromObject(obj.ToPyObject()));
    }

    public static PyByteArray FromStringAndSize(ReadOnlySpan<byte> bytes)
    {
        fixed (byte* ptr = bytes)
        {
            return new PyByteArray(Py.Api.PyBytes_FromStringAndSize(ptr, bytes.Length));
        }
    }

    public int GetLength()
    {
        return Py.Api.PyBytes_Size(ToPyObject()).ToInt32();
    }

    public int Read(Span<byte> bytes, int offset)
    {
        byte* ptr;
        nint size;
        int result = Py.Api.PyBytes_AsStringAndSize(ToPyObject(), &ptr, &size);
        if (offset >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(offset));
        }
        int sourceRest = size.ToInt32() - offset;
        fixed (byte* dest = bytes)
        {
            int copySize = Math.Min(bytes.Length, sourceRest);
            Buffer.MemoryCopy(ptr + offset, dest, copySize, copySize);
            return copySize;
        }
    }

    public byte[] ToArray()
    {
        byte* ptr;
        nint size;
        int result = Py.Api.PyBytes_AsStringAndSize(ToPyObject(), &ptr, &size);

        int length = size.ToInt32();
        byte[] array = new byte[length];
        fixed (byte* dest = array)
        {
            Buffer.MemoryCopy(ptr, dest, length, length);
        }
        return array;
    }

    public static PyBytes Cast(PyObject o)
    {
        if (o.GetPyType().Handler == (nint)Py.Api.PyBytes_Type)
        {
            PythonApi314._PyObject* pyObj = o.ToPyObject();
            Py.Api.Py_IncRef(pyObj);
            return new PyBytes(pyObj);
        }
        throw new InvalidCastException();
    }

    public override PyTypeObject GetPyType()
    {
        return new PyTypeObject(Py.Api.PyBytes_Type);
    }
}
