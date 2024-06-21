using PyRough.Python.Interop;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace PyRough.Python;

public unsafe class PyTypeObject : PyObject
{
    private static readonly ConcurrentDictionary<nint, WeakReference<PyTypeObject>> _resolvedTypes = new();

    internal PyTypeObject(nint handle)
        : base(new PyObjectHandle((Python314._PyObject*)handle.ToPointer()))
    {
    }

    protected override void Dispose(bool disposing)
    {
    }

    public string Name => GetName();


    public string GetName()
    {
        byte* ptr = Runtime.Api._PyType_Name(Handle);
        return Marshal.PtrToStringUTF8((nint)ptr)!;
    }
}
