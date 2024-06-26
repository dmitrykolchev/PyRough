﻿// <copyright file="PyDict.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using PyRough.Python.Interop;

namespace PyRough.Python.Types;

public unsafe class PyDict : PyObject
{
    internal PyDict(PyObjectHandle handle) : base(handle)
    {
        if (handle.GetPyType().Handle != Runtime.Api.PyDict_Type)
        {
            throw new InvalidCastException();
        }
    }

    public PyDict() : base(Create())
    {
    }

    public int Count => Size();

    public bool Contains(string key)
    {
        ArgumentNullException.ThrowIfNull(key);
        using Utf8String strKey = new(key);
        PyObjectHandle item = Runtime.Api.PyDict_GetItemString(Handle, strKey);
        return !item.IsNull;
    }

    public PyObject GetItem(string key)
    {
        ArgumentNullException.ThrowIfNull(key);
        using Utf8String strKey = new(key);
        PyObjectHandle item = Runtime.Api.PyDict_GetItemString(Handle, strKey);
        return PyObjectFactory.Wrap(item, true);
    }

    public bool SetItem(string key, PyObject value)
    {
        ArgumentNullException.ThrowIfNull(key);
        using Utf8String strKey = new(key);
        return Runtime.Api.PyDict_SetItemString(Handle, strKey, value.Handle) == 0;
    }

    public PyObject GetKeys()
    {
        PyObjectHandle keys = Runtime.Api.PyDict_Keys(Handle);
        return PyObjectFactory.Wrap(keys, true);
    }
    public PyObject GetValues()
    {
        PyObjectHandle keys = Runtime.Api.PyDict_Values(Handle);
        return PyObjectFactory.Wrap(keys, true);
    }

    internal int Size()
    {
        return Runtime.Api.PyDict_Size(Handle).ToInt32();
    }

    internal static PyObjectHandle Create()
    {
        return Runtime.Api.PyDict_New();
    }
}
