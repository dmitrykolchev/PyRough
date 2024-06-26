﻿// <copyright file="Encodings.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Text;

namespace PyRough.Python.Interop;

internal static class Encodings
{
    public static Encoding UTF8 = new UTF8Encoding(false, true);
    public static Encoding UTF16 = new UnicodeEncoding(!BitConverter.IsLittleEndian, false, true);
    public static Encoding UTF32 = new UTF32Encoding(!BitConverter.IsLittleEndian, false, true);
}
