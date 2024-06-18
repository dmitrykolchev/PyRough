namespace PyRough.Python.Interop;

[AttributeUsage(AttributeTargets.Field)]
public class ImportAttribute : Attribute
{
    public string? Name { get; set; }
}
