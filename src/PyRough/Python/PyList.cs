using PyRough.Python.Interop;
using System.Collections;

namespace PyRough.Python;

public unsafe class PyList : PyObject
{
    internal PyList(PyObjectHandle handle) : base(handle)
    {
        if (handle.GetPyType().Handle != Runtime.Api.PyList_Type)
        {
            throw new InvalidCastException();
        }
    }

    public unsafe PyList(int size) : this(Runtime.Api.PyList_New(size))
    {
    }

    public PyList(IEnumerable items) : this(Create(items))
    {
    }

    public int Length => GetSize();

    public PyObject this[int index]
    {
        get => GetItem(index);
        set => SetItem(index, value);
    }

    public int GetSize()
    {
        return Runtime.Api.PyList_Size(Handle).ToInt32();
    }

    public bool Append(PyObject value)
    {
        return AppendInternal(Handle, value.Handle);
    }

    public bool Sort()
    {
        return Runtime.Api.PyList_Sort(Handle) == 0;
    }

    public PyObject GetItem(int index)
    {
        var item = GetItemInternal(Handle, index);
        if (item.IsNull)
        {
            return Runtime.None;
        }
        return PyObjectFactory.Wrap(item, true);
    }

    public bool SetItem(int index, PyObject value)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        ArgumentNullException.ThrowIfNull(value);
        return SetItemInternal(Handle, index, value.Handle);
    }

    internal static PyObjectHandle GetItemInternal(PyObjectHandle list, int index)
    {
        return Runtime.Api.PyList_GetItem(list, index);
    }

    internal static bool SetItemInternal(PyObjectHandle list, int index, PyObjectHandle item)
    {
        return Runtime.Api.PyList_SetItem(list, index, item) == 0;
    }

    internal static PyObjectHandle Create(IEnumerable items)
    {
        PyObjectHandle result = Runtime.Api.PyList_New(0);
        foreach (var item in items)
        {
            PyObjectHandle pyObj = PyObjectFactory.FromClrObject(item);
            AppendInternal(result, pyObj);
        }
        return result;
    }

    internal static bool AppendInternal(PyObjectHandle list, PyObjectHandle value)
    {
        return Runtime.Api.PyList_Append(list, value) == 0;
    }
}
