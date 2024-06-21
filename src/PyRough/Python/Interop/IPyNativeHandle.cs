namespace PyRough.Python.Interop;

internal interface IPyNativeHandle
{
    nint Handle { get; }

    public bool IsNull { get; }
}
