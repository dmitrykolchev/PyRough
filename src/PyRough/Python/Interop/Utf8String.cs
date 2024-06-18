using System.Buffers;
using System.Text;

namespace PyRough.Python.Interop;
public struct Utf8String : IDisposable
{
    private static Encoder Encoder = Encoding.UTF8.GetEncoder();
    private static Decoder Decoder = Encoding.UTF8.GetDecoder();

    private byte[] _data;

    public static Utf8String Create(string s)
    {
        int byteCount = Encoder.GetByteCount(s, false);
        byte[] buffer = ArrayPool<byte>.Shared.Rent(byteCount + 1);
        Encoder.GetBytes(s, buffer, false);
        buffer[byteCount] = (byte)0;
        return new Utf8String { _data = buffer };
    }

    public byte[] Data => _data;

    public void Dispose()
    {
        ArrayPool<byte>.Shared.Return(_data);
    }
}
