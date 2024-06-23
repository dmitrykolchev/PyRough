// <copyright file="ImportAttribute.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

namespace PyRough.Python.Interop;

[AttributeUsage(AttributeTargets.Field)]
public class ImportAttribute : Attribute
{
    public string? Name { get; set; }
}
