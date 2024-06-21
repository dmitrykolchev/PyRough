using System.Runtime.InteropServices;
using Py_ssize_t = nint;

namespace PyRough.Python.Interop;

#pragma warning disable CS0649

internal unsafe partial class Python314(nint module) : ApiTable(module)
{
    [StructLayout(LayoutKind.Sequential)]
    public struct _PyObject
    {
        public Py_ssize_t ob_refcnt;
        public _PyTypeObject* ob_type;
    }

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

    [Import] public delegate* unmanaged[Cdecl]<void> Py_Initialize;
    [Import] public delegate* unmanaged[Cdecl]<int, void> Py_InitializeEx;

    [Import] public delegate* unmanaged[Cdecl]<void> Py_Finalize;
    [Import] public delegate* unmanaged[Cdecl]<int> Py_FinalizeEx;
    [Import] public delegate* unmanaged[Cdecl]<int> Py_IsInitialized;
    [Import] public delegate* unmanaged[Cdecl]<_PyThreadState*> Py_NewInterpreter;
    [Import] public delegate* unmanaged[Cdecl]<_PyThreadState*, void> Py_EndInterpreter;
    [Import] public delegate* unmanaged[Cdecl]<nint, int> Py_AtExit;
    [Import] public delegate* unmanaged[Cdecl]<int, void> Py_Exit;

    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, void> Py_IncRef;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, void> Py_DecRef;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, void> _Py_Dealloc;

    [Import] public delegate* unmanaged[Cdecl]<UcsNativeString, void> Py_SetProgramName;
    [Import] public delegate* unmanaged[Cdecl]<UcsNativeString, void> Py_SetPythonHome;
    [Import] public delegate* unmanaged[Cdecl]<UcsNativeString, void> Py_SetPath;


    [Import] public nint PyByteArray_Type;
    [Import] public nint PyByteArrayIter_Type;

    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyByteArray_FromObject;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle, PyObjectHandle> PyByteArray_Concat;
    [Import] public delegate* unmanaged[Cdecl]<byte*, Py_ssize_t, PyObjectHandle> PyByteArray_FromStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t> PyByteArray_Size;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, byte*> PyByteArray_AsString;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, Py_ssize_t, int> PyByteArray_Resize;

    [Import] public nint PyBytes_Type;
    [Import] public nint PyBytesIter_Type;

    [Import] public delegate* unmanaged[Cdecl]<byte*, Py_ssize_t, PyObjectHandle> PyBytes_FromStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<byte*, PyObjectHandle> PyBytes_FromString;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, PyObjectHandle> PyBytes_FromObject;
    //[Import] public delegate* unmanaged[Cdecl]< PyObject* PyBytes_FromFormatV(const char*, va_list);
    //[Import] public delegate* unmanaged[Cdecl]< PyObject* PyBytes_FromFormat(const char*, ...);
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
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, double>  PyFloat_AsDouble;

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
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, uint>PyLong_AsUnsignedLong;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle> PyLong_GetInfo;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, double> PyLong_AsDouble;
    [Import] public delegate* unmanaged[Cdecl]<void*, PyObjectHandle> PyLong_FromVoidPtr;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, void*> PyLong_AsVoidPtr;
    [Import] public delegate* unmanaged[Cdecl]<long, PyObjectHandle> PyLong_FromLongLong;
    [Import] public delegate* unmanaged[Cdecl]<ulong, PyObjectHandle> PyLong_FromUnsignedLongLong;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, long> PyLong_AsLongLong;
    [Import] public delegate* unmanaged[Cdecl]<PyObjectHandle, ulong> PyLong_AsUnsignedLongLong;

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
