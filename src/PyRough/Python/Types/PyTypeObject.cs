// <copyright file="PyTypeObject.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using PyRough.Native.Python310;
using PyRough.Python.Interop;

namespace PyRough.Python.Types;

public unsafe class PyTypeObject : PyObject
{
    private static readonly ConcurrentDictionary<nint, WeakReference<PyTypeObject>> _resolvedTypes = new();

    internal PyTypeObject(nint handle)
        : base((_PyObject*)handle.ToPointer())
    {
    }

    protected override void Dispose(bool disposing)
    {
    }

    public string Name => GetName();


    public string GetName()
    {
        sbyte* ptr = Runtime.Api._PyType_Name((_PyTypeObject*)Handle);
        return Marshal.PtrToStringUTF8((nint)ptr)!;
    }
}
