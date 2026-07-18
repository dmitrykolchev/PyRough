// <copyright file="Runtime.cs" company="Dmitry Kolchev">
// Copyright (c) 2026 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Runtime.InteropServices;
using PyRough.Native.Python310;
using PyRough.Python.Interop;
using PyRough.Python.Types;

namespace PyRough.Python;

public partial class Runtime
{
    private static Runtime Instance = null!;

    private readonly Python310ApiTable _api;

    private Runtime(Python310ApiTable api)
    {
        _api = api;
    }

    public static bool IsInitialize => Instance != null;

    public static PyObject True { get; private set; } = null!;
    public static PyObject False { get; private set; } = null!;
    public static PyObject None { get; private set; } = null!;

    internal static Python310ApiTable Api => Instance._api;

    public static void Initialize(PythonConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);

        if (!NativeLibrary.TryLoad(config.PythonDll, typeof(Runtime).Assembly, null, out var module))
        {
            throw new InvalidOperationException();
        }
        var api = new Python310ApiTable(module);
        Instance = new Runtime(api);
        Instance.InitializeInternal(config);
    }

    private unsafe void InitializeInternal(PythonConfiguration config)
    {
        if (_api.Py_IsInitialized() == 0)
        {
            using UcsString programName = new(config.ProgramName);
            _api.Py_SetProgramName((ushort*)programName.Pointer);
            using UcsString pythonHome = new(config.PythonHome);
            _api.Py_SetPythonHome((ushort*)pythonHome.Pointer);
            if (config.Path != null)
            {
                var separator = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ';' : ':';
                using UcsString path = new(string.Join(separator, config.Path));
                _api.Py_SetPath((ushort*)path.Pointer);
            }

            _api.Py_InitializeEx(1);

            if (_api.PyEval_ThreadsInitialized() != 0)
            {
                _api.PyEval_InitThreads();
            }
            using var buildins = PyModule.Import("builtins");
            None = buildins.GetAttr("None")!;
            True = buildins.GetAttr("True")!;
            False = buildins.GetAttr("False")!;
        }
    }

    public static GILState AcquireLock()
    {
        return new GILState();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="script"></param>
    /// <returns></returns>
    public static unsafe int Run(string script)
    {
        using Utf8String buffer = new(script);
        return Api.PyRun_SimpleStringFlags((sbyte*)buffer.Pointer, null);
    }
}
