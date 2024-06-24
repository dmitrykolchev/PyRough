// <copyright file="PythonConfiguration.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

namespace PyRough.Python;

public class PythonConfiguration
{
    public required string PythonDll { get; init; }
    public required string ProgramName { get; init; }
    public required string PythonHome { get; init; }
    public required IEnumerable<string> Path { get; init; }
}
