// <copyright file="UcsNativeString.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Runtime.InteropServices;
using System.Text;

namespace PyRough.Python.Interop;

[StructLayout(LayoutKind.Sequential)]
internal struct UcsString : IDisposable
{
    internal static readonly int _UCS = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 2 : 4;
    internal static readonly Encoding PyEncoding = _UCS == 2 ? Encodings.UTF16 : Encodings.UTF32;

    private IntPtr _ptr;

    public UcsString(string value) : this(value, PyEncoding) { }

    private unsafe UcsString(string value, Encoding encoding)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(encoding);

        int byteCount = encoding.GetByteCount(value);
        _ptr = Marshal.AllocHGlobal(checked(byteCount + _UCS));
        try
        {
            encoding.GetBytes(value, new Span<byte>(Bytes, byteCount));
            for (int i = 0; i < _UCS; ++i)
            {
                Bytes[byteCount + i] = 0;
            }
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
