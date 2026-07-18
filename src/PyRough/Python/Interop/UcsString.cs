// <copyright file="UcsString.cs" company="Dmitry Kolchev">
// Copyright (c) 2026 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace PyRough.Python.Interop;

[StructLayout(LayoutKind.Sequential)]
internal readonly ref struct UcsString
{
    internal static readonly int _UCS = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 2 : 4;
    internal static readonly Encoding PyEncoding = _UCS == 2 ? Encodings.UTF16 : Encodings.UTF32;

    private readonly ArrayPool<byte> _pool;
    private readonly byte[] _buffer;
    private readonly GCHandle _handle;

    public UcsString(string value) : this(value, PyEncoding) { }

    private unsafe UcsString(string value, Encoding encoding, ArrayPool<byte>? pool = default)
    {
        ArgumentNullException.ThrowIfNull(value);
        _pool = pool ?? ArrayPool<byte>.Shared;
        var byteCount = encoding.GetMaxByteCount(value.Length);
        _buffer = _pool.Rent(checked(byteCount + _UCS));
        var written = encoding.GetBytes(value, _buffer);
        for (var i = 0; i < _UCS; ++i)
        {
            _buffer[written + i] = 0;
        }
        Length = written;
        // Используем только Pinned, так как адрес нужен в 99% случаев.
        _handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
    }

    /// <summary>
    /// byte buffer length without terminating \0
    /// </summary>
    public int Length { get; }

    public nint Pointer
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _handle.AddrOfPinnedObject();
    }

    public void Dispose()
    {
        // Сначала освобождаем дескриптор, чтобы распинить память для GC
        if (_handle.IsAllocated)
        {
            _handle.Free();
        }

        // Возвращаем массив в пул
        if (_buffer != null)
        {
            _pool.Return(_buffer);
        }
    }
}
