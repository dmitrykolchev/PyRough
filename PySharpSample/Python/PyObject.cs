using PySharpSample.Python.Interop;
using System.Text;

namespace PySharpSample.Python;

public unsafe class PyObject : IDisposable
{
    private bool _disposed;
    private PythonApi314._PyObject* _handler;

    internal PyObject(PythonApi314._PyObject* handler)
    {
        if (handler == null)
        {
            throw new InvalidOperationException();
        }
        _handler = handler;
    }

    internal nint Handler => (nint)_handler;

    internal PythonApi314._PyObject* ToPyObject()
    {
        return _handler;
    }

    public bool IsDisposed => _disposed;

    public PyObject GetAttribute(string name)
    {
        using Utf8String s = Utf8String.Create(name);
        fixed (byte* p = s.Data)
        {
            PythonApi314._PyObject* result = Py.Api.PyObject_GetAttrString(ToPyObject(), p);
            return new PyObject(result);
        }
    }

    public void SetAttribute(string name, PyObject value)
    {
        throw new NotImplementedException();
    }

    public PyObject Call(PyTuple args)
    {
        PythonApi314._PyObject* result = Py.Api.PyObject_CallObject(ToPyObject(), args.ToPyObject());
        return new PyObject(result);
    }

    public PyObject Call()
    {
        PythonApi314._PyObject* result = Py.Api.PyObject_CallObject(ToPyObject(), null);
        return new PyObject(result);
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
            Py.Api.Py_DecRef(_handler);
            _handler = null;
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
}
