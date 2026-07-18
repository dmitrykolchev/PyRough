// <copyright file="PyDict.cs" company="Dmitry Kolchev">
// Copyright (c) 2026 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using PyRough.Native.Python310;
using PyRough.Python.Interop;

namespace PyRough.Python.Types;

/// <summary>
/// This subtype of PyObject represents a Python dictionary object.
/// </summary>
public unsafe class PyDict : PyObject
{
    /// <summary>
    /// Internal constructor
    /// </summary>
    /// <param name="handle"></param>
    /// <exception cref="InvalidCastException"></exception>
    internal PyDict(_PyObject* handle) : base(handle)
    {
        if (!HasType(handle, Runtime.Api.PyDict_Type))
        {
            throw new InvalidCastException();
        }
    }

    /// <summary>
    /// Instantiates new empty PyDict object
    /// </summary>
    public PyDict() : base(Create())
    {
    }

    /// <summary>
    /// Returns number of entries in PyDict
    /// </summary>
    public int Count => (int)Size();

    public bool Contains(string key)
    {
        ArgumentNullException.ThrowIfNull(key);
        using Utf8String strKey = new(key);
        var item = Runtime.Api.PyDict_GetItemString(Handle, (sbyte*)strKey.Pointer);
        return item != null;
    }

    public PyObject? GetItem(string key)
    {
        ArgumentNullException.ThrowIfNull(key);
        using Utf8String strKey = new(key);
        var item = Runtime.Api.PyDict_GetItemString(Handle, (sbyte*)strKey.Pointer);
        return PyObjectFactory.Wrap(item, true);
    }

    public bool SetItem(string key, PyObject value)
    {
        ArgumentNullException.ThrowIfNull(key);
        using Utf8String strKey = new(key);
        return Runtime.Api.PyDict_SetItemString(Handle, (sbyte*)strKey.Pointer, value.Handle) == 0;
    }

    public PyObject? GetKeys()
    {
        var keys = Runtime.Api.PyDict_Keys(Handle);
        return PyObjectFactory.Wrap(keys, true);
    }

    public PyObject? GetValues()
    {
        var keys = Runtime.Api.PyDict_Values(Handle);
        return PyObjectFactory.Wrap(keys, true);
    }

    internal long Size()
    {
        return Runtime.Api.PyDict_Size(Handle);
    }

    internal static _PyObject* Create()
    {
        return Runtime.Api.PyDict_New();
    }
}
