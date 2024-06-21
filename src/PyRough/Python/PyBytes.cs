using PyRough.Python.Interop;

namespace PyRough.Python;

public unsafe class PyBytes : PyObject
{
    internal PyBytes(PyObjectHandle handle) : base(handle)
    {
    }

    public static PyBytes FromObject(PyObject obj)
    {
        return new PyBytes(Runtime.Api.PyBytes_FromObject(obj.Handle));
    }

    internal static PyObjectHandle FromStringAndSize(ReadOnlySpan<byte> bytes)
    {
        fixed (byte* ptr = bytes)
        {
            return Runtime.Api.PyBytes_FromStringAndSize(ptr, bytes.Length);
        }
    }

    public int GetLength()
    {
        return Runtime.Api.PyBytes_Size(Handle).ToInt32();
    }

    public int Read(Span<byte> bytes, int offset)
    {
        ReadOnlySpan<byte> result = Runtime.PyBytes_AsStringAndSize(Handle);
        if (offset >= result.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(offset));
        }
        int sourceRest = result.Length - offset;
        fixed (byte* dest = bytes)
        {
            int copySize = Math.Min(bytes.Length, sourceRest);
            result.Slice(offset, copySize).CopyTo(new Span<byte>(dest, copySize));
            return copySize;
        }
    }

    public byte[] ToArray()
    {
        var result = Runtime.PyBytes_AsStringAndSize(Handle);
        byte[] array = new byte[result.Length];
        result.CopyTo(array);
        return array;
    }
}
