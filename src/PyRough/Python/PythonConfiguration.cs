// <copyright file="PythonConfiguration.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

namespace PyRough.Python;

public class PythonConfiguration
{
    public required string PythonDll { get; set; }
    public required string ProgramName { get; set; }
    public required string PythonHome { get; set; }
    public required string Path { get; set; }
}
