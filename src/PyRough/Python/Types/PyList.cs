// <copyright file="PyList.cs" company="Dmitry Kolchev">
// Copyright (c) 2026 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Collections;
using PyRough.Native.Python310;

namespace PyRough.Python.Types;

public unsafe class PyList : PyObject
{
    internal PyList(_PyObject* handle) : base(handle)
    {
        if (!HasType(handle, Runtime.Api.PyList_Type))
        {
            throw new InvalidCastException();
        }
    }

    public PyList(int size) : this(Runtime.Api.PyList_New(size))
    {
    }

    public PyList(IEnumerable items) : this(Create(items))
    {
    }

    public int Length => (int)GetSize();

    public PyObject? this[int index]
    {
        get => GetItem(index);
        set => SetItem(index, value);
    }

    public long GetSize()
    {
        return Runtime.Api.PyList_Size(Handle);
    }

    public bool Append(PyObject value)
    {
        return AppendInternal(Handle, value.Handle);
    }

    public bool Sort()
    {
        return Runtime.Api.PyList_Sort(Handle) == 0;
    }

    public PyObject? GetItem(int index)
    {
        var item = GetItemInternal(Handle, index);
        if (item == null)
        {
            return null;
        }
        return PyObjectFactory.Wrap(item, true);
    }

    public bool SetItem(int index, PyObject? value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        return SetItemInternal(Handle, index, value?.Handle);
    }

    internal static _PyObject* GetItemInternal(_PyObject* list, int index)
    {
        return Runtime.Api.PyList_GetItem(list, index);
    }

    internal static bool SetItemInternal(_PyObject* list, int index, _PyObject* item)
    {
        return Runtime.Api.PyList_SetItem(list, index, item) == 0;
    }

    internal static _PyObject* Create(IEnumerable items)
    {
        var result = Runtime.Api.PyList_New(0);
        foreach (var item in items)
        {
            var pyObj = PyObjectFactory.FromClrObject(item);
            AppendInternal(result, pyObj);
        }
        return result;
    }

    internal static bool AppendInternal(_PyObject* list, _PyObject* value)
    {
        return Runtime.Api.PyList_Append(list, value) == 0;
    }
}
