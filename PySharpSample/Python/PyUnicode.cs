using PySharpSample.Python.Interop;
using System.Text;

namespace PySharpSample.Python;

internal unsafe class PyUnicode : PyObject
{
    public PyUnicode(Py.PythonApi._PyObject* o) : base(o)
    {
    }

    public int GetLength()
    {
        return Py.Api.PyUnicode_GetLength(ToPyObject()).ToInt32();
    }

    public override string ToString()
    {
        int length = GetLength() + 1;
        fixed (char* ptr = new char[length])
        {
            int read = Py.Api.PyUnicode_AsWideChar(ToPyObject(), ptr, length).ToInt32();
            return new string(ptr);
        }
    }

    public static string ToString(PyObject o)
    {
        int length = Py.Api.PyUnicode_GetLength(o.ToPyObject()).ToInt32() + 1;
        fixed (char* ptr = new char[length])
        {
            int read = Py.Api.PyUnicode_AsWideChar(o.ToPyObject(), ptr, length).ToInt32();
            return new string(ptr);
        }
    }

    public static PyUnicode? Convert(string s)
    {
        ArgumentNullException.ThrowIfNull(s);
        fixed (char* ptr = s)
        {
            var result = Py.Api.PyUnicode_FromWideChar(ptr, s.Length);
            return new PyUnicode(result);
        }
    }
}
