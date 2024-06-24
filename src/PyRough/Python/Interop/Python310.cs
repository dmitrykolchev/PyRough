// <copyright file="Python310.cs" company="Division By Zero">
// Copyright (c) 2024 Dmitry Kolchev. All rights reserved.
// See LICENSE in the project root for license information
// </copyright>

using System.Runtime.InteropServices;
using Py_ssize_t = nint;

namespace PyRough.Python.Interop;

#pragma warning disable CS0649

internal unsafe partial class Python310(nint module) : ApiTable(module)
{
    /// <summary>
    /// Part of the Limited API. (Only some members are part of the stable ABI.)
    /// 
    /// All object types are extensions of this type. This is a type which contains the information
    /// Python needs to treat a pointer to an object as an object. In a normal “release” build, it
    /// contains only the object’s reference count and a pointer to the corresponding type object.
    /// Nothing is actually declared to be a PyObject, but every pointer to a Python object can be
    /// cast to a PyObject*. Access to the members must be done by using the macros Py_REFCNT and Py_TYPE.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct _PyObject
    {
        public Py_ssize_t ob_refcnt;
        public _PyTypeObject* ob_type;
    }

    /// <summary>
    /// Part of the Limited API. (Only some members are part of the stable ABI.)
    /// 
    /// This is an extension of PyObject that adds the ob_size field. This is only used for objects
    /// that have some notion of length. This type does not often appear in the Python/C API. Access
    /// to the members must be done by using the macros Py_REFCNT, Py_TYPE, and Py_SIZE.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct _PyVarObject
    {
        public _PyObject ob_base;
        public Py_ssize_t ob_size;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _PyMethodDef
    {
        public byte* /* const char* */ ml_name;
        public nint /* PyCFunction */ ml_meth;
        public int ml_flags;
        public byte* /* const char* */ ml_doc;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct _PyMemberDef
    {
        public byte* /* const char* */ name;
        public int type;
        public Py_ssize_t offset;
        public int flags;
        public byte* /* const char* */ doc;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct _PyGetSetDef
    {
        public byte* /* const char* */ name;
        public nint /* getter */ get;
        public nint /* setter */ set;
        public byte* /* const char* */ doc;
        public void* closure;
    };

    /// <summary>
    /// Part of the Limited API (as an opaque struct).
    /// 
    /// The C structure of the objects used to describe built-in types.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct _PyTypeObject
    {
        public _PyVarObject ob_base;
        public byte* /* const char* */ tp_name;
        public Py_ssize_t tp_basicsize, tp_itemsize;
        public nint /* destructor */ tp_dealloc;
        public Py_ssize_t tp_vectorcall_offset;
        public nint /* getattrfunc */ tp_getattr;
        public nint /* setattrfunc */ tp_setattr;
        public nint /* PyAsyncMethods* */ tp_as_async;
        public nint /* reprfunc */ tp_repr;
        public nint /* PyNumberMethods* */ tp_as_number;
        public nint /* PySequenceMethods* */ tp_as_sequence;
        public nint /* PyMappingMethods* */ tp_as_mapping;
        public nint /* hashfunc */ tp_hash;
        public nint /* ternaryfunc */ tp_call;
        public nint /* reprfunc */ tp_str;
        public nint /* getattrofunc */ tp_getattro;
        public nint /* setattrofunc */ tp_setattro;
        public nint /* PyBufferProcs* */ tp_as_buffer;
        public uint tp_flags;
        public byte* /* const char* */ tp_doc;
        public nint /* traverseproc */ tp_traverse;
        public nint /* inquiry */ tp_clear;
        public nint /* richcmpfunc */ tp_richcompare;
        public Py_ssize_t tp_weaklistoffset;
        public nint /* getiterfunc*/ tp_iter;
        public nint /* iternextfunc*/ tp_iternext;
        public _PyMethodDef* tp_methods;
        public _PyMemberDef* tp_members;
        public _PyGetSetDef* tp_getset;
        public _PyTypeObject* tp_base;
        public PyObjectHandle tp_dict;
        public nint /* descrgetfunc */ tp_descr_get;
        public nint /* descrsetfunc */ tp_descr_set;
        public Py_ssize_t tp_dictoffset;
        public nint /* initproc */ tp_init;
        public nint /* allocfunc */ tp_alloc;
        public nint /* newfunc */ tp_new;
        public nint /* freefunc */ tp_free;
        public nint /* inquiry */ tp_is_gc;
        public PyObjectHandle tp_bases;
        public PyObjectHandle tp_mro;
        public PyObjectHandle tp_cache;
        public void* tp_subclasses;
        public PyObjectHandle tp_weaklist;
        public nint /* destructor */ tp_del;
        public uint tp_version_tag;
        public nint /* destructor */ tp_finalize;
        public nint /* vectorcallfunc */ tp_vectorcall;
        public byte tp_watched;
        public ushort tp_versions_used;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct _PyErr_StackItem
    {
        public PyObjectHandle exc_value;
        public _PyErr_StackItem* previous_item;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct _PyThreadState
    {
        public _PyThreadState* prev;
        public _PyThreadState* next;
        public nint /* PyInterpreterState* */ interp;
        public nint eval_breaker;
        public int _status;
        public int _whence;
        public int state;
        public int py_recursion_remaining;
        public int py_recursion_limit;
        public int c_recursion_remaining;
        public int recursion_headroom;
        public int tracing;
        public int what_event;
        public nint /* _PyInterpreterFrame * */ current_frame;
        public nint /* Py_tracefunc */ c_profilefunc;
        public nint /* Py_tracefunc */ c_tracefunc;
        public PyObjectHandle c_profileobj;
        public PyObjectHandle c_traceobj;
        public PyObjectHandle current_exception;
        public nint /* _PyErr_StackItem* */ exc_info;
        public PyObjectHandle dict;
        public int gilstate_counter;
        public PyObjectHandle async_exc;
        public uint thread_id;
        public uint native_thread_id;
        public PyObjectHandle delete_later;
        public nint /* uintptr_t */ critical_section;
        public int coroutine_origin_tracking_depth;
        public PyObjectHandle async_gen_firstiter;
        public PyObjectHandle async_gen_finalizer;
        public PyObjectHandle context;
        public ulong /* uint64_t */ context_ver;
        public ulong /* uint64_t */ id;
        public nint /* _PyStackChunk* */ datastack_chunk;
        public PyObjectHandle* datastack_top;
        public PyObjectHandle* datastack_limit;
        public _PyErr_StackItem exc_state;
        public PyObjectHandle previous_executor;
        public ulong /* uint64_t */ dict_global_version;
    };
    /// <summary>
    /// Part of the Stable ABI.
    ///
    /// Initialize the Python interpreter.In an application embedding Python, this should be
    /// called before using any other Python/C API functions; see Before Python Initialization
    /// for the few exceptions.
    ///
    /// This initializes the table of loaded modules(sys.modules), and creates the fundamental
    /// modules builtins, __main__ and sys.It also initializes the module search path (sys.path).
    /// It does not set sys.argv; use PySys_SetArgvEx() for that.This is a no-op when called for
    /// a second time(without calling Py_FinalizeEx() first). There is no return value; it is a
    /// fatal error if the initialization fails.
    ///
    /// Use the Py_InitializeFromConfig() function to customize the Python
    /// Initialization Configuration.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<void> Py_Initialize;
    /// <summary>
    /// Part of the Stable ABI.
    /// This function works like Py_Initialize() if initsigs is 1. If initsigs is 0,
    /// it skips initialization registration of signal handlers, which might be useful
    /// when Python is embedded.
    /// Use the Py_InitializeFromConfig() function to customize the Python
    /// Initialization Configuration.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<int, void> Py_InitializeEx;

    /// <summary>
    /// Part of the Stable ABI.
    /// This is a backwards-compatible version of Py_FinalizeEx() that disregards the return value.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<void> Py_Finalize;
    /// <summary>
    /// Part of the Stable ABI since version 3.6.
    /// Undo all initializations made by Py_Initialize() and subsequent use of Python/C API
    /// functions, and destroy all sub-interpreters(see Py_NewInterpreter() below) that were
    /// created and not yet destroyed since the last call to Py_Initialize(). Ideally, this frees
    /// all memory allocated by the Python interpreter.This is a no-op when called for a second time
    /// (without calling Py_Initialize() again first).
    /// Since this is the reverse of Py_Initialize(), it should be called in the same thread
    /// with the same interpreter active. That means the main thread and the main interpreter.
    /// This should never be called while Py_RunMain() is running.
    /// Normally the return value is 0. If there were errors during finalization (flushing buffered data),
    /// -1 is returned.
    /// This function is provided for a number of reasons. An embedding application might want to
    /// restart Python without having to restart the application itself. An application that has
    /// loaded the Python interpreter from a dynamically loadable library (or DLL) might want to
    /// free all memory allocated by Python before unloading the DLL.During a hunt for memory leaks
    /// in an application a developer might want to free all memory allocated by Python before exiting
    /// from the application.
    /// Bugs and caveats: The destruction of modules and objects in modules is done in random order;
    /// this may cause destructors(__del__() methods) to fail when they depend on other objects
    /// (even functions) or modules.Dynamically loaded extension modules loaded by Python are not
    /// unloaded.
    /// Small amounts of memory allocated by the Python interpreter may not be freed (if you find a leak,
    /// please report it). Memory tied up in circular references between objects is not freed.
    /// Some memory allocated by extension modules may not be freed.Some extensions may not work properly
    /// if their initialization routine is called more than once; this can happen if an application calls
    /// Py_Initialize() and Py_FinalizeEx() more than once.
    /// Raises an auditing event cpython._PySys_ClearAuditHooks with no arguments.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<int> Py_FinalizeEx;
    /// <summary>
    /// Part of the Stable ABI.
    /// Return true (nonzero) when the Python interpreter has been initialized, false (zero) if not.
    /// After Py_FinalizeEx() is called, this returns false until Py_Initialize() is called again.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<int> Py_IsInitialized;
    /// <summary>
    /// Part of the Stable ABI.
    /// Create a new sub-interpreter.This is essentially just a wrapper around Py_NewInterpreterFromConfig()
    /// with a config that preserves the existing behavior.The result is an unisolated sub-interpreter
    /// that shares the main interpreter’s GIL, allows fork/exec, allows daemon threads, and allows
    /// single-phase init modules.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<_PyThreadState*> Py_NewInterpreter;
    /// <summary>
    /// Destroy the (sub-)interpreter represented by the given thread state. The given thread state
    /// must be the current thread state. See the discussion of thread states below. When the call
    /// returns, the current thread state is NULL. All thread states associated with this interpreter
    /// are destroyed. The global interpreter lock used by the target interpreter must be held before
    /// calling this function. No GIL is held when it returns.
    /// 
    /// Py_FinalizeEx() will destroy all sub-interpreters that haven’t been explicitly destroyed
    /// at that point.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<_PyThreadState*, void> Py_EndInterpreter;

    /// <summary>
    /// Part of the Stable ABI.
    ///
    /// Register a cleanup function to be called by Py_FinalizeEx(). The cleanup function will
    /// be called with no arguments and should return no value. At most 32 cleanup functions can
    /// be registered. When the registration is successful, Py_AtExit() returns 0; on failure,
    /// it returns -1. The cleanup function registered last is called first. Each cleanup function
    /// will be called at most once. Since Python’s internal finalization will have completed
    /// before the cleanup function, no Python APIs should be called by func.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<nint, int> Py_AtExit;
    /// <summary>
    /// Part of the Stable ABI.
    /// Exit the current process. This calls Py_FinalizeEx() and then calls the standard C library
    /// function exit(status). If Py_FinalizeEx() indicates an error, the exit status is set to 120.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<int, void> Py_Exit;

    /// <summary>
    /// Part of the Stable ABI.
    /// Indicate taking a new strong reference to object o. A function version of Py_XINCREF().
    /// It can be used for runtime dynamic embedding of Python.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, void> Py_IncRef;
    /// <summary>
    /// Part of the Stable ABI.
    /// Release a strong reference to object o. A function version of Py_XDECREF(). It can be used
    /// for runtime dynamic embedding of Python.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, void> Py_DecRef;
    /// <summary>
    /// Part of the Stable ABI.
    /// This API is kept for backward compatibility: setting PyConfig.program_name should be used instead,
    /// see Python Initialization Configuration.
    /// This function should be called before Py_Initialize() is called for the first time, if it is
    /// called at all. It tells the interpreter the value of the argv[0] argument to the main() function
    /// of the program (converted to wide characters). This is used by Py_GetPath() and some other
    /// functions below to find the Python run-time libraries relative to the interpreter executable.
    /// The default value is 'python'. The argument should point to a zero-terminated wide character
    /// string in static storage whose contents will not change for the duration of the program’s execution.
    /// No code in the Python interpreter will change the contents of this storage.
    /// Use Py_DecodeLocale() to decode a bytes string to get a wchar_t* string.
    /// Deprecated since version 3.11.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<UcsString, void> Py_SetProgramName;
    /// <summary>
    /// Part of the Stable ABI.
    /// This API is kept for backward compatibility: setting PyConfig.home should be used instead,
    /// see Python Initialization Configuration.
    /// 
    /// Set the default “home” directory, that is, the location of the standard Python libraries.
    /// See PYTHONHOME for the meaning of the argument string.
    /// 
    /// The argument should point to a zero-terminated character string in static storage whose
    /// contents will not change for the duration of the program’s execution. No code in the
    /// Python interpreter will change the contents of this storage.
    /// 
    /// Use Py_DecodeLocale() to decode a bytes string to get a wchar_* string.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<UcsString, void> Py_SetPythonHome;

    /// <summary>
    /// Part of the Stable ABI since version 3.7.
    /// This API is kept for backward compatibility: setting PyConfig.module_search_paths and
    /// PyConfig.module_search_paths_set should be used instead, see Python Initialization Configuration.
    /// 
    /// Set the default module search path. If this function is called before Py_Initialize(),
    /// then Py_GetPath() won’t attempt to compute a default search path but uses the one
    /// provided instead. This is useful if Python is embedded by an application that has full
    /// knowledge of the location of all modules. The path components should be separated by
    /// the platform dependent delimiter character, which is ':' on Unix and macOS, ';' on Windows.
    /// 
    /// This also causes sys.executable to be set to the program full path (see Py_GetProgramFullPath())
    /// and for sys.prefix and sys.exec_prefix to be empty. It is up to the caller to modify these
    /// if required after calling Py_Initialize().
    /// 
    /// Use Py_DecodeLocale() to decode a bytes string to get a wchar_* string.
    /// 
    /// The path argument is copied internally, so the caller may free it after the call completes.
    /// 
    /// Changed in version 3.8: The program full path is now used for sys.executable, instead of the program name.
    /// 
    /// Deprecated since version 3.11.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<UcsString, void> Py_SetPath;

    /// <summary>
    /// Part of the Stable ABI.
    /// This instance of PyTypeObject represents the Python bytearray type; it is the same object as
    /// bytearray in the Python layer.
    /// </summary>
    [Import] public nint PyByteArray_Type;
    [Import] public nint PyByteArrayIter_Type;

    /// <summary>
    /// Return value: New reference. Part of the Stable ABI.
    /// Return a new bytearray object from any object, o, that implements the buffer protocol.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyByteArray_FromObject;
    /// <summary>
    /// Return value: New reference. Part of the Stable ABI.
    /// Concat bytearrays a and b and return a new bytearray with the result.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, PyObjectHandle> PyByteArray_Concat;
    /// <summary>
    /// Return value: New reference. Part of the Stable ABI.
    /// Create a new bytearray object from string and its length, len. On failure, NULL is returned.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<byte*, Py_ssize_t, PyObjectHandle> PyByteArray_FromStringAndSize;
    /// <summary>
    /// Part of the Stable ABI.
    /// Return the size of bytearray after checking for a NULL pointer.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t> PyByteArray_Size;
    /// <summary>
    /// Part of the Stable ABI.
    /// Return the contents of bytearray as a char array after checking for a NULL pointer.
    /// The returned array always has an extra null byte appended.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, byte*> PyByteArray_AsString;
    /// <summary>
    /// Part of the Stable ABI.
    /// Resize the internal buffer of bytearray to len.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t, int> PyByteArray_Resize;


    /// <summary>
    /// Part of the Stable ABI.
    /// This instance of PyTypeObject represents the Python bytes type; it is the same
    /// object as bytes in the Python layer.
    /// </summary>
    [Import] public nint PyBytes_Type;
    [Import] public nint PyBytesIter_Type;

    /// <summary>
    /// Return value: New reference. Part of the Stable ABI.
    /// Return a new bytes object with a copy of the string v as value and length len on success,
    /// and NULL on failure. If v is NULL, the contents of the bytes object are uninitialized.
    /// </summary>
    [Import] public delegate* unmanaged[Cdecl]<byte*, Py_ssize_t, PyObjectHandle> PyBytes_FromStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyBytes_FromObject;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t> PyBytes_Size;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, byte*> PyBytes_AsString;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, int, PyObjectHandle> PyBytes_Repr;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle*, PyObjectHandle, void> PyBytes_Concat;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle*, PyObjectHandle, void> PyBytes_ConcatAndDel;
    [Import] public delegate* unmanaged[Cdecl]<byte*, Py_ssize_t, byte*, Py_ssize_t, byte*, PyObjectHandle> PyBytes_DecodeEscape;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, byte**, Py_ssize_t*, int> PyBytes_AsStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle*, Py_ssize_t, int> _PyBytes_Resize;

    [StructLayout(LayoutKind.Sequential)]
    public struct _PyBytesObject
    {
        public _PyVarObject ob_base;
        public nint /*Py_hash_t*/ ob_shash;
        public byte ob_sval;
    }

    [Import] public delegate* unmanaged[Cdecl]<void> PyErr_Print;
    [Import] public delegate* unmanaged[Cdecl]<int, void> PyErr_PrintEx;
    [Import] public delegate* unmanaged[Cdecl]<void> PyErr_Clear;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle> PyErr_Occurred;

    [Import] public delegate* unmanaged[Cdecl]<int> PyEval_ThreadsInitialized;
    [Import] public delegate* unmanaged[Cdecl]<void> PyEval_InitThreads;

    [Import] public nint PyFloat_Type;
    [Import] public delegate* unmanaged[Cdecl]<double> PyFloat_GetMax;
    [Import] public delegate* unmanaged[Cdecl]<double> PyFloat_GetMin;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle> PyFloat_GetInfo;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyFloat_FromString;
    [Import] public delegate* unmanaged[Cdecl]<double, PyObjectHandle> PyFloat_FromDouble;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, double> PyFloat_AsDouble;

    public enum PyGILState_STATE : int
    {
        PyGILState_LOCKED,
        PyGILState_UNLOCKED
    }

    [Import] public delegate* unmanaged[Cdecl]<int> PyGILState_Check;
    [Import] public delegate* unmanaged[Cdecl]<PyGILState_STATE> PyGILState_Ensure;
    [Import] public delegate* unmanaged[Cdecl]<PyGILState_STATE, void> PyGILState_Release;

    internal PyGILState AcquireLock()
    {
        return PyGILState_Ensure() == PyGILState_STATE.PyGILState_LOCKED
            ? PyGILState.Locked
            : PyGILState.Unlocked;
    }
    internal void ReleaseLock(PyGILState state)
    {
        PyGILState_Release(state == PyGILState.Locked
            ? PyGILState_STATE.PyGILState_LOCKED
            : PyGILState_STATE.PyGILState_UNLOCKED);
    }

    [Import] public nint PyModule_Type;

    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle> PyImport_GetModuleDict;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyImport_GetModule;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyImport_AddModuleObject;
    [Import] public delegate* unmanaged[Cdecl]<Utf8String, PyObjectHandle> PyImport_AddModule;
    [Import] public delegate* unmanaged[Cdecl]<Utf8String, PyObjectHandle> PyImport_ImportModule;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyImport_Import;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyImport_ReloadModule;

    [Import] public nint PyLong_Type;
    [Import] public nint PyBool_Type;

    [Import] public nint PyList_Type;
    [Import] public nint PyListIter_Type;
    [Import] public nint PyListRevIter_Type;

    [Import] public delegate* unmanaged[Cdecl]<Py_ssize_t, PyObjectHandle> PyList_New;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t> PyList_Size;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t, PyObjectHandle> PyList_GetItem;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t, PyObjectHandle, int> PyList_SetItem;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t, PyObjectHandle, int> PyList_Insert;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, int> PyList_Append;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t, Py_ssize_t, PyObjectHandle> PyList_GetSlice;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t, Py_ssize_t, PyObjectHandle, int> PyList_SetSlice;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, int> PyList_Sort;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, int> PyList_Reverse;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyList_AsTuple;

    [Import] public nint PyDict_Type;

    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle> PyDict_New;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, PyObjectHandle> PyDict_GetItem;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, PyObjectHandle> PyDict_GetItemWithError;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, PyObjectHandle, int> PyDict_SetItem;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, int> PyDict_DelItem;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, void> PyDict_Clear;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyDict_Keys;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyDict_Values;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyDict_Items;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t> PyDict_Size;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyDict_Copy;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, int> PyDict_Contains;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, int> PyDict_Update;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Utf8String, PyObjectHandle> PyDict_GetItemString;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Utf8String, PyObjectHandle, int> PyDict_SetItemString;

    [Import] public delegate* unmanaged[Cdecl]<int, PyObjectHandle> PyLong_FromLong;
    [Import] public delegate* unmanaged[Cdecl]<uint, PyObjectHandle> PyLong_FromUnsignedLong;
    [Import] public delegate* unmanaged[Cdecl]<nint, PyObjectHandle> PyLong_FromSize_t;
    [Import] public delegate* unmanaged[Cdecl]<Py_ssize_t, PyObjectHandle> PyLong_FromSsize_t;
    [Import] public delegate* unmanaged[Cdecl]<double, PyObjectHandle> PyLong_FromDouble;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, int> PyLong_AsLong;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, uint> PyLong_AsUnsignedLong;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle> PyLong_GetInfo;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, double> PyLong_AsDouble;
    [Import] public delegate* unmanaged[Cdecl]<void*, PyObjectHandle> PyLong_FromVoidPtr;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, void*> PyLong_AsVoidPtr;
    [Import] public delegate* unmanaged[Cdecl]<long, PyObjectHandle> PyLong_FromLongLong;
    [Import] public delegate* unmanaged[Cdecl]<ulong, PyObjectHandle> PyLong_FromUnsignedLongLong;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, long> PyLong_AsLongLong;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, ulong> PyLong_AsUnsignedLongLong;

    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, PyObjectHandle, PyObjectHandle> PyObject_Call;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, PyObjectHandle> PyObject_CallObject;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyObject_CallNoArgs;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyObject_Type;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t> PyObject_Size;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t> PyObject_Length;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, PyObjectHandle> PyObject_GetItem;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, PyObjectHandle, int> PyObject_SetItem;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Utf8String, PyObjectHandle> PyObject_GetAttrString;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Utf8String, PyObjectHandle, int> PyObject_SetAttrString;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, void> _PyObject_Dump;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, void> PyObject_CallFinalizer;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyObject_Str;

    [StructLayout(LayoutKind.Sequential)]
    public struct _PyCompilerFlags
    {
        public int cf_flags;
        public int cf_feature_version;
    }

    [Import] public delegate* unmanaged[Cdecl]<Utf8String, _PyCompilerFlags*, int> PyRun_SimpleStringFlags;
    [Import] public delegate* unmanaged[Cdecl]<byte*, int, PyObjectHandle, PyObjectHandle, _PyCompilerFlags*, PyObjectHandle> PyRun_StringFlags;

    [Import] public nint PyTuple_Type;
    [Import] public nint PyTupleIter_Type;

    [Import] public delegate* unmanaged[Cdecl]<Py_ssize_t, PyObjectHandle> PyTuple_New;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t> PyTuple_Size;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t, PyObjectHandle> PyTuple_GetItem;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t, PyObjectHandle, int> PyTuple_SetItem;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t, Py_ssize_t, PyObjectHandle> PyTuple_GetSlice;

    [StructLayout(LayoutKind.Sequential)]
    public struct _PyTupleObject
    {
        public _PyVarObject ob_base;
        public PyObjectHandle ob_item;
    }

    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle*, Py_ssize_t, int> _PyTuple_Resize;

    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, byte*> _PyType_Name;

    [Import] public nint PyUnicode_Type;
    [Import] public nint PyUnicodeIter_Type;

    [Import] public delegate* unmanaged[Cdecl]<byte*, PyObjectHandle> PyUnicode_DecodeFSDefault;
    [Import] public delegate* unmanaged[Cdecl]<byte*, nint, PyObjectHandle> PyUnicode_DecodeFSDefaultAndSize;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, nint> PyUnicode_GetLength;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, char*, nint, nint> PyUnicode_AsWideChar;
    [Import] public delegate* unmanaged[Cdecl]<char*, nint, PyObjectHandle> PyUnicode_FromWideChar;
    [Import] public delegate* unmanaged[Cdecl]<byte*, nint, PyObjectHandle> PyUnicode_FromStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyUnicode_FromObject;
}

#pragma warning restore CS0649
