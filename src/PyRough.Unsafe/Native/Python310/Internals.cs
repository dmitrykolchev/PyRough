// <copyright file="Python310Internals.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Runtime.InteropServices;

namespace PyRough.Native.Python310;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PyMemberDef
{
    public sbyte* name;
    public int type;
    public nint offset;
    public int flags;
    public sbyte* doc;
}

[StructLayout(LayoutKind.Sequential)]
public struct _dictkeysobject { }

[StructLayout(LayoutKind.Sequential)]
public struct _frame { }

[StructLayout(LayoutKind.Sequential)]
public struct _iobuf { }

[StructLayout(LayoutKind.Sequential)]
public struct _PyInterpreterState { }

[StructLayout(LayoutKind.Sequential)]
public struct _PyOpcache { }

