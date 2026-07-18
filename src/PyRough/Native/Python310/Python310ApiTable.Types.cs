// <copyright file="Python310ApiTable.Types.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using PyRough.Python;
using PyRough.Python.Interop;

namespace PyRough.Native.Python310;

#pragma warning disable CS0649 

internal unsafe partial class Python310ApiTable
{
    [Import] public nint PyBool_Type;
    [Import] public nint PyByteArray_Type;
    [Import] public nint PyByteArrayIter_Type;
    [Import] public nint PyBytes_Type;
    [Import] public nint PyBytesIter_Type;
    [Import] public nint PyDict_Type;
    [Import] public nint PyFloat_Type;
    [Import] public nint PyModule_Type;
    [Import] public nint PyLong_Type;
    [Import] public nint PyList_Type;
    [Import] public nint PyListIter_Type;
    [Import] public nint PyListRevIter_Type;
    [Import] public nint PyTuple_Type;
    [Import] public nint PyTupleIter_Type;
    [Import] public nint PyUnicode_Type;
    [Import] public nint PyUnicodeIter_Type;

    internal PyGILState AcquireLock()
    {
        return PyGILState_Ensure() == PyGILState_STATE.PyGILState_LOCKED
            ? PyGILState.Locked
            : PyGILState.Unlocked;
    }

    internal void ReleaseLock(PyGILState state)
    {
        PyGILState_Release(state == PyGILState.Locked
            ? PyGILState_STATE.PyGILState_LOCKED
            : PyGILState_STATE.PyGILState_UNLOCKED);
    }
}

#pragma warning restore CS0649 
