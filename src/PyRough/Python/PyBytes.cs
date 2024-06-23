// <copyright file="PyBytes.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using PyRough.Python.Interop;

namespace PyRough.Python;

public unsafe class PyBytes : PyObject
{
    internal PyBytes(PyObjectHandle handle) : base(handle)
    {
        if (handle.GetPyType().Handle != Runtime.Api.PyBytes_Type)
        {
            throw new InvalidCastException();
        }
    }

    public PyBytes(byte[] bytes) : this(FromStringAndSize(bytes))
    {
    }

    public int Length => GetLength();

    public int GetLength()
    {
        return Runtime.Api.PyBytes_Size(Handle).ToInt32();
    }

    public int Read(Span<byte> bytes, int offset)
    {
        ReadOnlySpan<byte> result = AsStringAndSize(Handle);
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
        var result = AsStringAndSize(Handle);
        byte[] array = new byte[result.Length];
        result.CopyTo(array);
        return array;
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

    internal static unsafe ReadOnlySpan<byte> AsStringAndSize(PyObjectHandle ob)
    {
        byte* bytes;
        nint size;
        int result = Runtime.Api.PyBytes_AsStringAndSize(ob, &bytes, &size);
        return new ReadOnlySpan<byte>(bytes, size.ToInt32());
    }
}
