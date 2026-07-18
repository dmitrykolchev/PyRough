// <copyright file="PyFloat.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using PyRough.Native.Python310;

namespace PyRough.Python.Types;

public unsafe class PyFloat : PyObject
{
    internal PyFloat(_PyObject* handle) : base(handle)
    {
        if ((nint)handle->ob_type != Runtime.Api.PyFloat_Type)
        {
            throw new InvalidCastException();
        }
    }

    public PyFloat(double value) : this(FromDouble(value))
    {
    }

    public PyFloat(float value) : this(FromDouble(value))
    {
    }

    internal static _PyObject* FromDouble(double value)
    {
        return Runtime.Api.PyFloat_FromDouble(value);
    }

    public double Value => ToDouble();

    public double ToDouble()
    {
        return Runtime.Api.PyFloat_AsDouble(ObjectPtr);
    }

    public static explicit operator double(PyFloat value)
    {
        return value.ToDouble();
    }
}
