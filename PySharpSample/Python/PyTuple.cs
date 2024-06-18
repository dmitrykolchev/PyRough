using PySharpSample.Python.Interop;

namespace PySharpSample.Python;

public unsafe class PyTuple : PyObject
{
    internal PyTuple(PythonApi314._PyObject* handler) : base(handler)
    {
    }

    public static PyTuple Create(int size)
    {
        PythonApi314._PyObject* tuple = Py.Api.PyTuple_New(size);
        return new PyTuple(tuple);
    }

    public static PyTuple FromList(params object[] values)
    {
        var result = Create(values.Length);
        int index = 0;
        foreach (object value in values)
        {
            var typeCode = Type.GetTypeCode(value.GetType());
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    result[index] = PyLong.FromInt32((bool)value ? 1 : 0);
                    break;
                case TypeCode.Byte:
                    result[index] = PyLong.FromInt32((byte)value)!;
                    break;
                case TypeCode.Int32:
                    result[index] = PyLong.FromInt32((int)value);
                    break;
                case TypeCode.Int64:
                    result[index] = PyLong.FromInt64((long)value);
                    break;
                case TypeCode.Double:
                    result[index] = PyFloat.FromDouble((double)value);
                    break;
                case TypeCode.Single:
                    result[index] = PyFloat.FromDouble((double)(float)value);
                    break;
                case TypeCode.String:
                    result[index] = PyUnicode.FromString((string)value)!;
                    break;
                default:
                    if (value is byte[] array)
                    {
                        result[index] = PyBytes.FromStringAndSize(array);
                    }
                    else
                    {
                        throw new InvalidCastException();
                    }
                    break;
            }
            index++;
        }
        return result;
    }

    public PyObject this[int index]
    {
        get => GetItem(index);
        set => SetItem(index, value);
    }

    public int Length => GetSize();

    public int GetSize()
    {
        return Py.Api.PyTuple_Size(ToPyObject()).ToInt32();
    }

    public void SetItem(int index, PyObject value)
    {
        PythonApi314._PyObject* v = value == null ? null : value.ToPyObject();
        int result = Py.Api.PyTuple_SetItem(ToPyObject(), index, v);
        if (result == -1)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public PyObject GetItem(int index)
    {
        PythonApi314._PyObject* result = Py.Api.PyTuple_GetItem(ToPyObject(), index);
        return PyObject.Create(result);
    }
}
