using PyRough.Python.Interop;
using System.Runtime.CompilerServices;

namespace PyRough.Python;

public unsafe class PyTuple : PyObject
{
    internal PyTuple(PyObjectHandle handle) : base(handle)
    {
        if (handle.GetPyType().Handle != Runtime.Api.PyTuple_Type)
        {
            throw new InvalidCastException();
        }
    }

    public PyTuple(int size) : this(Runtime.Api.PyTuple_New(size))
    {
    }

    public PyTuple(params object?[] values) : this(FromList(values))
    {
    }

    public PyObject this[int index]
    {
        get => GetItem(index);
    }

    public int Length => GetSize();

    public int GetSize()
    {
        return Runtime.Api.PyTuple_Size(Handle).ToInt32();
    }

    public PyObject GetItem(int index)
    {
        PyObjectHandle result = GetItemInternal(index);
        return PyObjectFactory.Wrap(result, true);
    }

    internal static void SetItemInternal(PyObjectHandle tuple, int index, PyObjectHandle handle)
    {
        int result = Runtime.Api.PyTuple_SetItem(tuple, index, handle);
        if (result != 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    internal PyObjectHandle GetItemInternal(int index)
    {
        return Runtime.Api.PyTuple_GetItem(Handle, index);
    }

    internal static PyObjectHandle FromTuple(ITuple tuple)
    {
        PyObjectHandle result = Runtime.Api.PyTuple_New(tuple.Length);
        for (int i = 0; i < tuple.Length; ++i)
        {
            SetItemInternal(result, i, PyObjectFactory.FromClrObject(tuple[i]));
        }
        return result;
    }

    internal static PyObjectHandle FromList(params object?[] values)
    {
        PyObjectHandle result = Runtime.Api.PyTuple_New(values.Length);
        for (int i = 0; i < values.Length; ++i)
        {
            SetItemInternal(result, i, PyObjectFactory.FromClrObject(values[i]));
        }
        return result;
    }
}
