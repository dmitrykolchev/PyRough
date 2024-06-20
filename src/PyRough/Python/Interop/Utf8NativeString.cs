using System.Runtime.InteropServices;
using System.Text;

namespace PyRough.Python.Interop;

[StructLayout(LayoutKind.Sequential)]
internal struct Utf8NativeString : IDisposable
{
    private IntPtr _ptr;

    public unsafe Utf8NativeString(string value) : this(value, Encodings.UTF8) { }

    private unsafe Utf8NativeString(string value, Encoding encoding)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(encoding);
        int byteCount = encoding.GetByteCount(value);
        _ptr = Marshal.AllocHGlobal(checked(byteCount + 1));
        try
        {
            encoding.GetBytes(value, new Span<byte>(Bytes, byteCount));
            Bytes[byteCount] = 0;
        }
        catch
        {
            Dispose();
            throw;
        }
    }

    public IntPtr RawPointer => _ptr;

    private unsafe byte* Bytes => (byte*)_ptr;

    public unsafe string? ToString(Encoding encoding)
    {
        ArgumentNullException.ThrowIfNull(encoding);

        if (RawPointer == IntPtr.Zero)
        {
            return null;
        }
        return encoding.GetString(Bytes, byteCount: checked((int)GetByteCount()));
    }

    public unsafe nuint GetByteCount()
    {
        if (RawPointer == IntPtr.Zero)
        {
            throw new InvalidOperationException();
        }

        nuint zeroIndex = 0;
        while (Bytes[zeroIndex] != 0)
        {
            zeroIndex++;
        }
        return zeroIndex;
    }

    public void Dispose()
    {
        if (RawPointer != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(RawPointer);
            _ptr = IntPtr.Zero;
        }
    }
}
