// <copyright file="PyString.cs" company="Dmitry Kolchev">
// Copyright (c) 2026 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using PyRough.Native.Python310;

namespace PyRough.Python.Types;

internal unsafe class PyString : PyObject
{
    internal PyString(_PyObject* o) : base(o)
    {
        if (!HasType(o, Runtime.Api.PyUnicode_Type))
        {
            throw new InvalidCastException();
        }
    }

    public PyString(string value) : this(FromString(value))
    {
    }

    public int Length => (int)GetLength();

    public string Value => ToString();

    public long GetLength()
    {
        return Runtime.Api.PyUnicode_GetLength(Handle);
    }

    public override string ToString()
    {
        var length = (int)GetLength();
        fixed (ushort* ptr = new ushort[length])
        {
            var read = Runtime.Api.PyUnicode_AsWideChar(Handle, ptr, length);
            return new string((char*)ptr, 0, length);
        }
    }

    internal static _PyObject* FromString(string s)
    {
        ArgumentNullException.ThrowIfNull(s);
        fixed (void* ptr = s)
        {
            return Runtime.Api.PyUnicode_FromWideChar((ushort*)ptr, s.Length);
        }
    }
}
