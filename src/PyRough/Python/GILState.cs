namespace PyRough.Python;

public enum PyGILState : int
{
    Locked,
    Unlocked
}

public class GILState : IDisposable
{
    private readonly PyGILState _state;
    private bool _disposed;

    internal GILState()
    {
        _state = Runtime.Api.AcquireLock();
    }

    public virtual void Dispose()
    {
        if (_disposed)
        {
            return;
        }
        Runtime.Api.ReleaseLock(_state);
        GC.SuppressFinalize(this);
        _disposed = true;
    }

    ~GILState()
    {
        throw new InvalidOperationException("GIL must always be released, and it must be released from the same thread that acquired it.");
    }
}
