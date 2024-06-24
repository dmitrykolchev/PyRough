// <copyright file="ImportAttribute.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

namespace PyRough.Python.Interop;

/// <summary>
/// Attribute for exported python3xx.dll API
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class ImportAttribute : Attribute
{
    /// <summary>
    /// Exported name
    /// </summary>
    public string? Name { get; set; }
}
