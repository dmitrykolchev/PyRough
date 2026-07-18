// <copyright file="ApiTable.cs" company="Dmitry Kolchev">
// Copyright (c) 2026 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Reflection;
using System.Runtime.InteropServices;

namespace PyRough.Python.Interop;

internal abstract class ApiTable
{
    protected ApiTable(nint module)
    {
        Module = module;
        Initialize();
    }

    public nint Module { get; }

    protected virtual void Initialize()
    {
        var importFields = GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(t => t.GetCustomAttribute<ImportAttribute>() != null);
        foreach (var importField in importFields)
        {
            var importAttribute = importField.GetCustomAttribute<ImportAttribute>()!;
            var importName = importAttribute.Name ?? importField.Name;
            importField.SetValue(this, GetExport(importName));
        }
    }

    private nint GetExport(string name)
    {
        return NativeLibrary.GetExport(Module, name);
    }
}
