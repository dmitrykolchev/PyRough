// <copyright file="PyObject.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using PyRough.Native.Python310;
using PyRough.Python.Interop;

namespace PyRough.Python.Types;

public unsafe class PyObject : IDisposable
{
    private static long _currentObjectId;

    internal PyObject()
    {
    }

    internal PyObject(_PyObject* handle)
    {
        if (handle == null)
        {
            throw new ArgumentNullException(nameof(handle));
        }
        ObjectId = Interlocked.Increment(ref _currentObjectId);
        Handle = handle;
    }

    internal long ObjectId { get; }

    internal bool IsDisposed { get; private set; }

    internal _PyObject* Handle { get; private set; }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal PyTypeObjectHandle GetPyType()
    {
        return new PyTypeObjectHandle(GetPyType(Handle));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static _PyTypeObject* GetPyType(_PyObject* obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        return obj->ob_type;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void AddRef(_PyObject* obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        Runtime.Api.Py_IncRef(obj);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void Release(_PyObject* obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        Runtime.Api.Py_DecRef(obj);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static long GetRefCount(_PyObject* obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        return obj->ob_refcnt;
    }

    internal PyObject AddRef()
    {
        AddRef(Handle);
        return this;
    }

    internal void Release()
    {
        Release(Handle);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal long GetRefCount()
    {
        return GetRefCount(Handle);
    }

    public PyObject? GetAttr(string name)
    {
        using Utf8String s = new(name);
        _PyObject* result = Runtime.Api.PyObject_GetAttrString(Handle, (sbyte*)s.Pointer);
        if (result == null)
        {
            return Runtime.None;
        }
        return PyObjectFactory.Wrap(result, true);
    }

    public void SetAttr(string name, PyObject value) => throw new NotImplementedException();

    public PyObject? Invoke(params object[] args)
    {
        using var tuple = new PyTuple(args);
        return Invoke(tuple);
    }

    public PyObject? Invoke(PyTuple args)
    {
        _PyObject* result = Runtime.Api.PyObject_CallObject(Handle, args.Handle);
        if (Runtime.Api.PyErr_Occurred() != null)
        {
            Runtime.Api.PyErr_Print();
            throw new InvalidOperationException();
        }
        if (result == null)
        {
            return default;
        }
        return PyObjectFactory.Wrap(result, true);
    }

    public PyObject? Invoke(PyTuple args, PyDict kwargs)
    {
        ArgumentNullException.ThrowIfNull(args);
        ArgumentNullException.ThrowIfNull(kwargs);
        _PyObject* result = Runtime.Api.PyObject_Call(Handle, args.Handle, kwargs.Handle);
        if (Runtime.Api.PyErr_Occurred() != null)
        {
            Runtime.Api.PyErr_Print();
            throw new InvalidOperationException();
        }
        if (result == null)
        {
            return default;
        }
        return PyObjectFactory.Wrap(result, true);
    }

    public PyObject? Invoke()
    {
        _PyObject* result = Runtime.Api.PyObject_CallNoArgs(Handle);
        if (Runtime.Api.PyErr_Occurred() != null)
        {
            Runtime.Api.PyErr_Print();
            throw new InvalidOperationException();
        }
        if (result == null)
        {
            return default;
        }
        return PyObjectFactory.Wrap(result, true);
    }

    public void Dump() => Runtime.Api._PyObject_Dump(Handle);

    protected virtual void Dispose(bool disposing)
    {
        if (!IsDisposed)
        {
            IsDisposed = true;
            Release();
            Handle = null;
        }
    }

    ~PyObject()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public override bool Equals(object? obj)
    {
        if (obj is PyObject pyo)
        {
            return Handle == pyo.Handle;
        }
        return false;
    }

    public override int GetHashCode() => Handle->GetHashCode();

    internal static bool HasType(_PyObject* obj, _PyTypeObject* type)
    {
        return obj->ob_type == type;
    }
    internal static bool HasType(_PyObject* obj, nint type)
    {
        return obj->ob_type == (_PyTypeObject*)type;
    }
}
