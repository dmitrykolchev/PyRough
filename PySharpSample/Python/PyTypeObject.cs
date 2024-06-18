using PySharpSample.Python.Interop;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace PySharpSample.Python;

public unsafe class PyTypeObject : PyObject
{
    private static readonly ConcurrentDictionary<nint, WeakReference<PyTypeObject>> _resolvedTypes = new();

    internal PyTypeObject(PythonApi314._PyTypeObject* handler)
        : base((PythonApi314._PyObject*)handler)
    {
    }

    protected override void Dispose(bool disposing)
    {
    }

    public string Name => GetName();

    public static PyTypeObject GetPyType(PyObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        PythonApi314._PyObject* pyObj = obj.ToPyObject();
        nint obType = (nint)(*pyObj).ob_type;
        if (!_resolvedTypes.TryGetValue(obType, out WeakReference<PyTypeObject>? value))
        {
            PyTypeObject result = new((*pyObj).ob_type);
            _resolvedTypes.TryAdd(obType, new WeakReference<PyTypeObject>(result));
            return result;
        }
        else 
        {
            if (!value.TryGetTarget(out PyTypeObject? reference))
            {
                reference = new((*pyObj).ob_type);
                value.SetTarget(reference);
            }
            return reference!;
        }
    }

    public string GetName()
    {
        byte* ptr = Py.Api._PyType_Name(ToPyObject());
        return Marshal.PtrToStringUTF8((nint)ptr)!;
    }
}
