using PySharpSample.Python.Interop;
using System.Runtime.CompilerServices;

namespace PySharpSample.Python;

public unsafe class PyObject : IDisposable
{
    private bool _disposed;
    private PythonApi314._PyObject* _pyobj;

    internal PyObject(PythonApi314._PyObject* pyobj)
    {
        if (pyobj == null)
        {
            throw new InvalidOperationException();
        }
        _pyobj = pyobj;
    }

    internal nint Handler => (nint)_pyobj;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal PythonApi314._PyObject* ToPyObject() => _pyobj;

    public bool IsDisposed => _disposed;

    public PyObject GetAttribute(string name)
    {
        using Utf8String s = Utf8String.Create(name);
        fixed (byte* p = s.Data)
        {
            PythonApi314._PyObject* result = Py.Api.PyObject_GetAttrString(ToPyObject(), p);
            return Create(result);
        }
    }

    public void SetAttribute(string name, PyObject value)
    {
        throw new NotImplementedException();
    }

    public PyObject? Call(PyTuple args)
    {
        PythonApi314._PyObject* result = Py.Api.PyObject_CallObject(ToPyObject(), args.ToPyObject());
        if (Py.Api.PyErr_Occurred() != null)
        {
            Py.Api.PyErr_Print();
            throw new InvalidOperationException();
        }
        if (result is null)
        {
            return default;
        }
        return Create(result);
    }

    public PyObject? Call()
    {
        PythonApi314._PyObject* result = Py.Api.PyObject_CallNoArgs(ToPyObject());
        if (Py.Api.PyErr_Occurred() != null)
        {
            Py.Api.PyErr_Print();
            throw new InvalidOperationException();
        }
        if (result is null)
        {
            return default;
        }
        return Create(result);
    }

    public virtual PyTypeObject GetPyType()
    {
        return PyTypeObject.GetPyType(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }
            Py.Api.Py_DecRef(_pyobj);
            _pyobj = null;
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

    internal static PyObject Create(PythonApi314._PyObject* pyobj)
    {
        PythonApi314._PyTypeObject* pyType = (*pyobj).ob_type;
        if (pyType == Py.Api.PyUnicode_Type)
        {
            return new PyUnicode(pyobj);
        }

        if (pyType == Py.Api.PyLong_Type)
        {
            return new PyLong(pyobj);
        }

        if (pyType == Py.Api.PyFloat_Type)
        {
            return new PyFloat(pyobj);
        }

        if (pyType == Py.Api.PyTuple_Type)
        {
            return new PyTuple(pyobj);
        }

        if (pyType == Py.Api.PyBytes_Type)
        {
            return new PyBytes(pyobj);
        }

        if (pyType == Py.Api.PyByteArray_Type)
        {
            return new PyByteArray(pyobj);
        }

        return new PyObject(pyobj);
    }
}
