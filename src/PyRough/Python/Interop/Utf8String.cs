using System.Text;

namespace PyRough.Python.Interop;

public class Utf8String
{
    private byte[] _data = null!;

    private Utf8String() { }

    public static Utf8String Create(string s)
    {
        byte[] utf8 = new byte[Encoding.UTF8.GetByteCount(s) + 1];
        Encoding.UTF8.GetBytes(s, 0, s.Length, utf8, 0);
        return new Utf8String { _data = utf8 };
    }

    public byte[] Data => _data;
    public int Length => _data.Length - 1;
}
