using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace PyRough.Python.Interop;

internal unsafe struct PyTypeObjectHandle : IPyNativeHandle
{
    private readonly Python314._PyTypeObject* _pobj;

    public PyTypeObjectHandle(Python314._PyTypeObject* pobj)
    {
        _pobj = pobj;
    }

    public nint Handle => (nint)_pobj;

    public bool IsNull => Handle == nint.Zero;

    public string? Name
    {
        get
        {
            if (!IsNull)
            {
                byte* name = (*_pobj).tp_name;
                if (name != null)
                {
                    int i = 0;
                    while (name[i] != 0)
                    {
                        i++;
                    }
                    if (i > 0)
                    {
                        return Encodings.UTF8.GetString(new ReadOnlySpan<byte>(name, i));
                    }
                }
            }
            return null;
        }
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal Python314._PyTypeObject* ToPointer()
    {
        return _pobj;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is IPyNativeHandle ptoh)
        {
            return ptoh.Handle == Handle;
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
