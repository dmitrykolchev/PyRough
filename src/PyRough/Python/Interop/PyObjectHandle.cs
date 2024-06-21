using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PyRough.Python.Interop;

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct PyObjectHandle : IPyNativeHandle
{
    public static readonly PyObjectHandle Null = new();

    private readonly Python314._PyObject* _pobj;

    public PyObjectHandle(Python314._PyObject* handle)
    {
        _pobj = handle;
    }

    public nint Handle => (nint)_pobj;

    public bool IsNull => Handle == nint.Zero;

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal PyTypeObjectHandle GetPyType()
    {
        if (IsNull)
        {
            throw new InvalidOperationException();
        }
        return new PyTypeObjectHandle(_pobj[0].ob_type);
    }

    public PyObjectHandle AddRef()
    {
        if (IsNull)
        {
            throw new InvalidOperationException();
        }
        Runtime.Api.Py_IncRef(this);
        return this;
    }

    public void Release()
    {
        if (IsNull)
        {
            throw new InvalidOperationException();
        }
        Runtime.Api.Py_DecRef(this);
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public nint GetRefCount()
    {
        if (IsNull)
        {
            throw new InvalidOperationException();
        }
        return _pobj[0].ob_refcnt;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is IPyNativeHandle poh)
        {
            return poh.Handle == Handle;
        }
        return false;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override int GetHashCode()
    {
        return ((nint)_pobj).GetHashCode();
    }
}
