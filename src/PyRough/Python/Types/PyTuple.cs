// <copyright file="PyTuple.cs" company="Dmitry Kolchev">
// Copyright (c) 2026 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Runtime.CompilerServices;
using PyRough.Native.Python310;

namespace PyRough.Python.Types;

public unsafe class PyTuple : PyObject
{
    internal PyTuple(_PyObject* handle) : base(handle)
    {
        if (!HasType(handle, Runtime.Api.PyTuple_Type))
        {
            throw new InvalidCastException();
        }
    }

    public PyTuple(int size) : this(Runtime.Api.PyTuple_New(size))
    {
    }

    public PyTuple(params object?[] values) : this(FromList(values))
    {
    }

    public PyObject? this[int index] => GetItem(index);

    public int Length => (int)GetSize();

    public long GetSize()
    {
        return Runtime.Api.PyTuple_Size(ObjectPtr);
    }

    public PyObject? GetItem(int index)
    {
        var result = GetItemInternal(index);
        return PyObjectFactory.Wrap(result, true);
    }

    internal static void SetItemInternal(_PyObject* tuple, int index, _PyObject* handle)
    {
        ArgumentNullException.ThrowIfNull(tuple);
        var result = Runtime.Api.PyTuple_SetItem(tuple, index, handle);
        if (result != 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    internal _PyObject* GetItemInternal(int index)
    {
        return Runtime.Api.PyTuple_GetItem(ObjectPtr, index);
    }

    internal static _PyObject* FromTuple(ITuple tuple)
    {
        var result = Runtime.Api.PyTuple_New(tuple.Length);
        for (var i = 0; i < tuple.Length; ++i)
        {
            SetItemInternal(result, i, PyObjectFactory.FromClrObject(tuple[i]));
        }
        return result;
    }

    internal static _PyObject* FromList(params object?[] values)
    {
        var result = Runtime.Api.PyTuple_New(values.Length);
        for (var i = 0; i < values.Length; ++i)
        {
            SetItemInternal(result, i, PyObjectFactory.FromClrObject(values[i]));
        }
        return result;
    }
}
