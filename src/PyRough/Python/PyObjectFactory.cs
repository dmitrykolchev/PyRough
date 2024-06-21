using PyRough.Python.Interop;
using System.Runtime.CompilerServices;

namespace PyRough.Python;

internal class PyObjectFactory
{
    public static PyObjectHandle FromClrObject(object? value)
    {
        if (value is null)
        {
            return PyObjectHandle.Null;
        }
        var typeCode = Type.GetTypeCode(value.GetType());
        switch (typeCode)
        {
            case TypeCode.Boolean:
                return PyLong.FromInt32((bool)value ? 1 : 0);
            case TypeCode.Byte:
                return PyLong.FromInt32((byte)value)!;
            case TypeCode.Int32:
                return PyLong.FromInt32((int)value);
            case TypeCode.Int64:
                return PyLong.FromInt64((long)value);
            case TypeCode.Double:
                return PyFloat.FromDouble((double)value);
            case TypeCode.Single:
                return PyFloat.FromDouble((float)value);
            case TypeCode.String:
                return PyString.FromString((string)value)!;
            default:
                if (value is byte[] array)
                {
                    return PyBytes.FromStringAndSize(array);
                }
                else if (value is PyObject pyobj)
                {
                    return pyobj.Handle;
                }
                else if(value is ITuple tuple)
                {
                    return PyTuple.FromTuple(tuple);
                }
                else
                {
                    throw new InvalidCastException();
                }
        }
    }

    public static PyObject Wrap(PyObjectHandle handle, bool addRef)
    {
        var pyType = handle.GetPyType().Handle;

        if (addRef)
        {
            handle.AddRef();
        }

        if (pyType == Runtime.Api.PyUnicode_Type)
        {
            return new PyString(handle);
        }

        if (pyType == Runtime.Api.PyLong_Type)
        {
            return new PyLong(handle);
        }

        if (pyType == Runtime.Api.PyFloat_Type)
        {
            return new PyFloat(handle);
        }

        if (pyType == Runtime.Api.PyTuple_Type)
        {
            return new PyTuple(handle);
        }

        if (pyType == Runtime.Api.PyBytes_Type)
        {
            return new PyBytes(handle);
        }

        if(pyType == Runtime.Api.PyList_Type)
        {
            return new PyList(handle);
        }

        if (pyType == Runtime.Api.PyModule_Type)
        {
            return new PyModule(handle);
        }

        return new PyObject(handle);
    }
}
