// <copyright file="PyModule.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using PyRough.Native.Python310;
using PyRough.Python.Interop;

namespace PyRough.Python.Types;

public unsafe class PyModule : PyObject
{
    internal PyModule(_PyObject* handle)
        : base(handle)
    {
        if (!HasType(handle, Runtime.Api.PyModule_Type))
        {
            throw new InvalidCastException();
        }
    }

    public static PyModule Import(string name)
    {
        using Utf8String str = new(name);
        _PyObject* module = Runtime.Api.PyImport_ImportModule((sbyte*)str.Pointer);
        if (module == null)
        {
            if (Runtime.Api.PyErr_Occurred() != null)
            {
                Runtime.Api.PyErr_Print();
            }
            throw new InvalidOperationException();
        }
        return new PyModule(module);
    }
}
