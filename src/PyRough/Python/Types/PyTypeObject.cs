// <copyright file="PyTypeObject.cs" company="Dmitry Kolchev">
// Copyright (c) 2026 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Runtime.InteropServices;
using PyRough.Native.Python310;

namespace PyRough.Python.Types;

public unsafe class PyTypeObject : PyObject
{
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
        var ptr = Runtime.Api._PyType_Name((_PyTypeObject*)ObjectPtr);
        return Marshal.PtrToStringUTF8((nint)ptr)!;
    }
}
