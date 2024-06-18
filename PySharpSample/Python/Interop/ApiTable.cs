using System.Reflection;
using System.Runtime.InteropServices;

namespace PySharpSample.Python.Interop;
internal abstract class ApiTable
{
    private readonly nint _module;

    protected ApiTable(nint module)
    {
        _module = module;
        Initialize();
    }

    public nint Module => _module;

    protected virtual void Initialize()
    {
        var importFields = GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(t => t.GetCustomAttribute<ImportAttribute>() != null);
        foreach (var importField in importFields)
        {
            ImportAttribute importAttribute = importField.GetCustomAttribute<ImportAttribute>()!;
            string importName = importAttribute.Name ?? importField.Name;
            importField.SetValue(this, GetExport(importName));
        }
    }

    private nint GetExport(string name)
    {
        return NativeLibrary.GetExport(Module, name);
    }
}
