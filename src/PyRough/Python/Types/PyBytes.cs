// <copyright file="PyBytes.cs" company="Dmitry Kolchev">
// Copyright (c) 2026 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using PyRough.Native.Python310;

namespace PyRough.Python.Types;

/// <summary>
/// This subtype of <seealso cref="PyObject"/> represents a Python bytes object.
/// </summary>
public unsafe class PyBytes : PyObject
{
    /// <summary>
    /// Internal consstructor
    /// </summary>
    /// <param name="handle">Handle to Python native object</param>
    /// <exception cref="InvalidCastException"></exception>
    internal PyBytes(_PyObject* handle) : base(handle)
    {
        if (!HasType(handle, Runtime.Api.PyBytes_Type))
        {
            throw new InvalidCastException();
        }
    }
    /// <summary>
    /// Creates PyBytes object from CLR byte array
    /// </summary>
    /// <param name="bytes">array of bytes</param>
    public PyBytes(byte[] bytes) : this(FromStringAndSize(bytes))
    {
    }
    /// <summary>
    /// Returns length of the bytes
    /// </summary>
    public long Length => Size();

    /// <summary>
    /// Allows read large PyBytes using small size chuncks
    /// </summary>
    /// <param name="bytes">buffer</param>
    /// <param name="offset">read offset from start of PyBytes</param>
    /// <returns>number of read bytes</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public int Read(Span<byte> bytes, int offset)
    {
        var result = AsStringAndSize(Handle);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(offset, result.Length);
        var sourceRest = result.Length - offset;
        fixed (byte* dest = bytes)
        {
            var copySize = Math.Min(bytes.Length, sourceRest);
            result.Slice(offset, copySize).CopyTo(new Span<byte>(dest, copySize));
            return copySize;
        }
    }

    /// <summary>
    /// Copyes PyBytes data to new CLR byte array
    /// </summary>
    /// <returns>new byte arrray</returns>
    public byte[] ToArray()
    {
        var result = AsStringAndSize(Handle);
        var array = new byte[result.Length];
        result.CopyTo(array);
        return array;
    }

    public static PyBytes FromObject(PyObject obj)
    {
        return new(Runtime.Api.PyBytes_FromObject(obj.Handle));
    }

    internal long Size()
    {
        return Runtime.Api.PyBytes_Size(Handle);
    }

    internal static _PyObject* FromStringAndSize(ReadOnlySpan<byte> bytes)
    {
        fixed (void* ptr = bytes)
        {
            return Runtime.Api.PyBytes_FromStringAndSize((sbyte*)ptr, bytes.Length);
        }
    }

    internal static unsafe ReadOnlySpan<byte> AsStringAndSize(_PyObject* ob)
    {
        sbyte* bytes;
        long size;
        Runtime.Api.PyBytes_AsStringAndSize(ob, &bytes, &size);
        return new ReadOnlySpan<byte>(bytes, (int)size);
    }
}
