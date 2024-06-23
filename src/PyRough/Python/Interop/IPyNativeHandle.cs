// <copyright file="IPyNativeHandle.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

namespace PyRough.Python.Interop;

internal interface IPyNativeHandle
{
    nint Handle { get; }

    public bool IsNull { get; }
}
