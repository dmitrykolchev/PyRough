﻿// <copyright file="PyObject.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>


// <copyright file="PyObject.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using PyRough.Python.Interop;

namespace PyRough.Python.Types;

public unsafe class PyObject : IDisposable
{
    private static long CurrentObjectId = 0;
    private readonly long _objectId;

    private bool _disposed;
    private PyObjectHandle _handle;

    internal PyObject()
    {
    }

    internal PyObject(PyObjectHandle handle)
    {
        if (handle.IsNull)
        {
            throw new ArgumentNullException(nameof(handle));
        }
        _objectId = Interlocked.Increment(ref CurrentObjectId);
        _handle = handle;
    }

    internal long ObjectId => _objectId;

    internal bool IsDisposed => _disposed;

    internal PyObjectHandle Handle => _handle;

    public PyObject? GetAttr(string name)
    {
        using Utf8String s = new(name);
        PyObjectHandle result = Runtime.Api.PyObject_GetAttrString(Handle, s);
        if (result.IsNull)
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
        PyObjectHandle result = Runtime.Api.PyObject_CallObject(Handle, args.Handle);
        if (!Runtime.Api.PyErr_Occurred().IsNull)
        {
            Runtime.Api.PyErr_Print();
            throw new InvalidOperationException();
        }
        if (result.IsNull)
        {
            return default;
        }
        return PyObjectFactory.Wrap(result, true);
    }

    public PyObject? Invoke(PyTuple args, PyDict kwargs)
    {
        ArgumentNullException.ThrowIfNull(args);
        ArgumentNullException.ThrowIfNull(kwargs);
        PyObjectHandle result = Runtime.Api.PyObject_Call(Handle, args.Handle, kwargs.Handle);
        if (!Runtime.Api.PyErr_Occurred().IsNull)
        {
            Runtime.Api.PyErr_Print();
            throw new InvalidOperationException();
        }
        if (result.IsNull)
        {
            return default;
        }
        return PyObjectFactory.Wrap(result, true);
    }

    public PyObject? Invoke()
    {
        PyObjectHandle result = Runtime.Api.PyObject_CallNoArgs(Handle);
        if (!Runtime.Api.PyErr_Occurred().IsNull)
        {
            Runtime.Api.PyErr_Print();
            throw new InvalidOperationException();
        }
        if (result.IsNull)
        {
            return default;
        }
        return PyObjectFactory.Wrap(result, true);
    }

    public void Dump()
    {
        Runtime.Api._PyObject_Dump(Handle);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            Handle.Release();
            _handle = PyObjectHandle.Null;
            _disposed = true;
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

    public PyTypeObject GetPyType()
    {
        ;
        return new PyTypeObject(Handle.GetPyType().Handle);
    }

    public override bool Equals(object? obj)
    {
        if (obj is PyObject pyo)
        {
            return Handle.Handle == pyo.Handle.Handle;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Handle.Handle.GetHashCode();
    }

    internal void Attach(PyObjectHandle handle)
    {
        if (handle.IsNull)
        {
            throw new ArgumentNullException(nameof(handle));
        }
        if (!_handle.IsNull)
        {
            _handle.Release();
        }
        _handle = handle;
    }

    internal PyObjectHandle Detach()
    {
        PyObjectHandle result = _handle;
        _handle = PyObjectHandle.Null;
        return result;
    }

}
