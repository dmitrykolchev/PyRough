using PyRough.Python.Interop;

namespace PyRough.Python;

public partial class Runtime
{
    internal static unsafe ReadOnlySpan<byte> PyBytes_AsStringAndSize(PyObjectHandle ob)
    {
        byte* bytes;
        nint size;
        int result = Runtime.Api.PyBytes_AsStringAndSize(ob, &bytes, &size);
        return new ReadOnlySpan<byte>(bytes, size.ToInt32());
    }
}
