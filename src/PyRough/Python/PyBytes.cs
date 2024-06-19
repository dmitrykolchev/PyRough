using PyRough.Python.Interop;
using System;

namespace PyRough.Python;

public unsafe class PyBytes : PyObject
{
    internal PyBytes(PythonApi314._PyObject* handler) : base(handler)
    {
    }

    public static PyByteArray FromObject(PyObject obj)
    {
        return new PyByteArray(PyEngine.Api.PyBytes_FromObject(obj.ToPyObject()));
    }

    public static PyByteArray FromStringAndSize(ReadOnlySpan<byte> bytes)
    {
        fixed (byte* ptr = bytes)
        {
            return new PyByteArray(PyEngine.Api.PyBytes_FromStringAndSize(ptr, bytes.Length));
        }
    }

    public int GetLength()
    {
        return PyEngine.Api.PyBytes_Size(ToPyObject()).ToInt32();
    }

    public unsafe int Read(Span<byte> bytes, int offset)
    {
        ReadOnlySpan<byte> result = PyBytes_AsStringAndSize(ToPyObject());
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
        byte* ptr;
        nint size;
        int result = PyEngine.Api.PyBytes_AsStringAndSize(ToPyObject(), &ptr, &size);

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
        if (o.GetPyType().Handler == (nint)PyEngine.Api.PyBytes_Type)
        {
            PythonApi314._PyObject* pyObj = o.ToPyObject();
            PyEngine.Api.Py_IncRef(pyObj);
            return new PyBytes(pyObj);
        }
        throw new InvalidCastException();
    }

    public override PyTypeObject GetPyType()
    {
        return new PyTypeObject(PyEngine.Api.PyBytes_Type);
    }

    private unsafe static ReadOnlySpan<byte> PyBytes_AsStringAndSize(PythonApi314._PyObject* ob)
    {
        byte* bytes;
        nint size;
        int result = PyEngine.Api.PyBytes_AsStringAndSize(ob, &bytes, &size);
        return new ReadOnlySpan<byte>(bytes, size.ToInt32());
    }

}
