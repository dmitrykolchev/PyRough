// <copyright file="Python310.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Runtime.InteropServices;

namespace PyRough.Python.Interop;
#pragma warning disable CS0649

internal unsafe class Python310(nint module) : ApiTable(module)
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _PyObject
    {
        public nint ob_refcnt;
        public nint ob_type;
    }
    [Import] public delegate* unmanaged[Cdecl]<int, void> Py_InitializeEx;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, void> Py_IncRef;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, void> Py_DecRef;
    [Import] public delegate* unmanaged[Cdecl]<char*, void> Py_SetProgramName;
    [Import] public delegate* unmanaged[Cdecl]<char*, void> Py_SetPythonHome;
    [Import] public delegate* unmanaged[Cdecl]<char*, void> Py_SetPath;

    [Import] public delegate* unmanaged[Cdecl]<void> PyByteArray_Type;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte*> PyByteArray_AsString;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> PyByteArray_Concat;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint> PyByteArray_Size;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint, int> PyByteArray_Resize;
    [Import] public delegate* unmanaged[Cdecl]<byte*, nint, _PyObject*> PyByteArray_FromStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyByteArray_FromObject;

    [Import] public delegate* unmanaged[Cdecl]<void> PyBytesIter_Type;
    [Import] public delegate* unmanaged[Cdecl]<void> PyBytes_Type;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte*> PyBytes_AsString;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte**, nint*, int> PyBytes_AsStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject**, _PyObject*, void> PyBytes_Concat;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject**, _PyObject*, void> PyBytes_ConcatAndDel;
    [Import] public delegate* unmanaged[Cdecl]<byte*, nint, byte*, nint, byte*, _PyObject*> PyBytes_DecodeEscape;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyBytes_FromObject;
    [Import] public delegate* unmanaged[Cdecl]<byte*, _PyObject*> PyBytes_FromString;
    [Import] public delegate* unmanaged[Cdecl]<byte*, nint, _PyObject*> PyBytes_FromStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, int, _PyObject*> PyBytes_Repr;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint> PyBytes_Size;

    [Import] public delegate* unmanaged[Cdecl]<void> PyErr_Print;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*> PyErr_Occurred;

    [StructLayout(LayoutKind.Sequential)]
    public struct _PyVarObject
    {
        public PyObject ob_base;
        public nint ob_size;
    }

    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyImport_Import;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte*, _PyObject*> PyObject_GetAttrString;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> PyObject_CallObject;

    [StructLayout(LayoutKind.Sequential)]
    public struct _PyCompilerFlags
    {
        public int cf_flags;
        public int cf_feature_version;
    }
    [Import] public delegate* unmanaged[Cdecl]<byte*, _PyCompilerFlags*, int> PyRun_SimpleStringFlags;

    [Import] public delegate* unmanaged[Cdecl]<nint, _PyObject*> PyTuple_New;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint> PyTuple_Size;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint, _PyObject*> PyTuple_GetItem;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint, _PyObject*, int> PyTuple_SetItem;

    [Import] public delegate* unmanaged[Cdecl]<void*, byte*> _PyType_Name;

    [Import] public delegate* unmanaged[Cdecl]<byte*, _PyObject*> PyUnicode_DecodeFSDefault;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint> PyUnicode_GetLength;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, char*, nint, nint> PyUnicode_AsWideChar;
    [Import] public delegate* unmanaged[Cdecl]<char*, nint, _PyObject*> PyUnicode_FromWideChar;

}

#pragma warning restore CS0649
