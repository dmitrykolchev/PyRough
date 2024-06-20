using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PyRough.Python.Interop;

[StructLayout(LayoutKind.Sequential)]
internal struct UcsNativeString: IDisposable
{
    internal static readonly int _UCS = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 2 : 4;
    internal static readonly Encoding PyEncoding = _UCS == 2 ? Encodings.UTF16 : Encodings.UTF32;

    private IntPtr _ptr;

    public UcsNativeString(string value) : this(value, PyEncoding) { }

    private unsafe UcsNativeString(string value, Encoding encoding)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(encoding);
        value = value + "\0";
        int byteCount = encoding.GetByteCount(value);
        _ptr = Marshal.AllocHGlobal(checked(byteCount));
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

    public void Dispose()
    {
        if (RawPointer != IntPtr.Zero)
        {
            Marshal.FreeHGlobal(RawPointer);
            _ptr = IntPtr.Zero;
        }
    }
}
