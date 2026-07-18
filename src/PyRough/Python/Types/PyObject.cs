// <copyright file="PyObject.cs" company="Dmitry Kolchev">
// Copyright (c) 2026 Dmitry Kolchev. All rights reserved.
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
    private bool _disposed;

    internal PyObject()
    {
    }

    internal PyObject(_PyObject* obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }
        ObjectId = Interlocked.Increment(ref _currentObjectId);
        ObjectPtr = obj;
    }

    internal long ObjectId { get; }

    internal _PyObject* ObjectPtr { get; private set; }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal PyTypeObjectHandle GetPyType()
    {
        return new PyTypeObjectHandle(GetPyType(ObjectPtr));
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

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal long RefCount() => GetRefCount(ObjectPtr);

    public PyObject? GetAttr(string name)
    {
        using Utf8String s = new(name);
        var result = Runtime.Api.PyObject_GetAttrString(ObjectPtr, (sbyte*)s.Pointer);
        if (result == null)
        {
            return Runtime.None;
        }
        return PyObjectFactory.Wrap(result, true);
    }

    public void SetAttr(string name, PyObject value)
    {
        throw new NotImplementedException();
    }

    public PyObject? Invoke(params object[] args)
    {
        using var tuple = new PyTuple(args);
        return Invoke(tuple);
    }

    public PyObject? Invoke(PyTuple args)
    {
        var result = Runtime.Api.PyObject_CallObject(ObjectPtr, args.ObjectPtr);
        if (Runtime.Api.PyErr_Occurred() != null)
        {
            Runtime.Api.PyErr_Print();
            throw new InvalidOperationException();
        }
        if (result == null)
        {
            return Runtime.None;
        }
        return PyObjectFactory.Wrap(result, true);
    }

    public PyObject Invoke(PyTuple args, PyDict kwargs)
    {
        ArgumentNullException.ThrowIfNull(args);
        ArgumentNullException.ThrowIfNull(kwargs);
        var result = Runtime.Api.PyObject_Call(ObjectPtr, args.ObjectPtr, kwargs.ObjectPtr);
        if (Runtime.Api.PyErr_Occurred() != null)
        {
            Runtime.Api.PyErr_Print();
            throw new InvalidOperationException();
        }
        if (result == null)
        {
            return Runtime.None;
        }
        return PyObjectFactory.Wrap(result, true);
    }

    public PyObject Invoke()
    {
        var result = Runtime.Api.PyObject_CallNoArgs(ObjectPtr);
        if (Runtime.Api.PyErr_Occurred() != null)
        {
            Runtime.Api.PyErr_Print();
            throw new InvalidOperationException();
        }
        if (result == null)
        {
            return Runtime.None;
        }
        return PyObjectFactory.Wrap(result, true);
    }

    public void Dump()
    {
        Runtime.Api._PyObject_Dump(ObjectPtr);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            _disposed = true;
            Release(ObjectPtr);
            ObjectPtr = null;
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
            return ObjectPtr == pyo.ObjectPtr;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return ObjectPtr->GetHashCode();
    }

    internal static bool HasType(_PyObject* obj, _PyTypeObject* type)
    {
        return obj->ob_type == type;
    }
    internal static bool HasType(_PyObject* obj, nint type)
    {
        return obj->ob_type == (_PyTypeObject*)type;
    }
}
