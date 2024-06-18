using System.Runtime.InteropServices;
using Py_ssize_t = nint;

namespace PySharpSample.Python.Interop;

#pragma warning disable CS0649

internal unsafe class PythonApi314(nint module) : ApiTable(module)
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
        public _PyObject* tp_dict;
        public nint /* descrgetfunc */ tp_descr_get;
        public nint /* descrsetfunc */ tp_descr_set;
        public Py_ssize_t tp_dictoffset;
        public nint /* initproc */ tp_init;
        public nint /* allocfunc */ tp_alloc;
        public nint /* newfunc */ tp_new;
        public nint /* freefunc */ tp_free;
        public nint /* inquiry */ tp_is_gc;
        public _PyObject* tp_bases;
        public _PyObject* tp_mro;
        public _PyObject* tp_cache;
        public void* tp_subclasses;
        public _PyObject* tp_weaklist;
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
        public _PyObject* exc_value;
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
        public _PyObject* c_profileobj;
        public _PyObject* c_traceobj;
        public _PyObject* current_exception;
        public nint /* _PyErr_StackItem* */ exc_info;
        public _PyObject* dict;
        public int gilstate_counter;
        public _PyObject* async_exc;
        public uint thread_id;
        public uint native_thread_id;
        public _PyObject* delete_later;
        public nint /* uintptr_t */ critical_section;
        public int coroutine_origin_tracking_depth;
        public _PyObject* async_gen_firstiter;
        public _PyObject* async_gen_finalizer;
        public _PyObject* context;
        public ulong /* uint64_t */ context_ver;
        public ulong /* uint64_t */ id;
        public nint /* _PyStackChunk* */ datastack_chunk;
        public _PyObject** datastack_top;
        public _PyObject** datastack_limit;
        public _PyErr_StackItem exc_state;
        public _PyObject* previous_executor;
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

    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, void> Py_IncRef;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, void> Py_DecRef;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, void> _Py_Dealloc;

    [Import] public delegate* unmanaged[Cdecl]<char*, void> Py_SetProgramName;
    [Import] public delegate* unmanaged[Cdecl]<char*, void> Py_SetPythonHome;
    [Import] public delegate* unmanaged[Cdecl]<char*, void> Py_SetPath;


    [Import] public _PyTypeObject* PyByteArray_Type;
    [Import] public _PyTypeObject* PyByteArrayIter_Type;

    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyByteArray_FromObject;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> PyByteArray_Concat;
    [Import] public delegate* unmanaged[Cdecl]<byte*, Py_ssize_t, _PyObject*> PyByteArray_FromStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, Py_ssize_t> PyByteArray_Size;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte*> PyByteArray_AsString;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, Py_ssize_t, int> PyByteArray_Resize;


    [Import] public _PyTypeObject* PyBytes_Type;
    [Import] public _PyTypeObject* PyBytesIter_Type;

    [Import] public delegate* unmanaged[Cdecl]<byte*, Py_ssize_t, _PyObject*> PyBytes_FromStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<byte*, _PyObject*> PyBytes_FromString;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyBytes_FromObject;
    //[Import] public delegate* unmanaged[Cdecl]< PyObject* PyBytes_FromFormatV(const char*, va_list);
    //[Import] public delegate* unmanaged[Cdecl]< PyObject* PyBytes_FromFormat(const char*, ...);
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, Py_ssize_t> PyBytes_Size;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte*> PyBytes_AsString;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, int, _PyObject*> PyBytes_Repr;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject**, _PyObject*, void> PyBytes_Concat;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject**, _PyObject*, void> PyBytes_ConcatAndDel;
    [Import] public delegate* unmanaged[Cdecl]<byte*, Py_ssize_t, byte*, Py_ssize_t, byte*, _PyObject*> PyBytes_DecodeEscape;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte**, Py_ssize_t*, int> PyBytes_AsStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject**, Py_ssize_t, int> _PyBytes_Resize;

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
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*> PyErr_Occurred;

    [Import] public delegate* unmanaged[Cdecl]<_PyObject*> PyImport_GetModuleDict;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyImport_GetModule;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyImport_AddModuleObject;
    [Import] public delegate* unmanaged[Cdecl]<byte*, _PyObject*> PyImport_AddModule;
    [Import] public delegate* unmanaged[Cdecl]<byte*, _PyObject*> PyImport_ImportModule;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyImport_Import;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyImport_ReloadModule;

    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> PyObject_CallObject;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyObject_Type;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, Py_ssize_t> PyObject_Size;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, Py_ssize_t> PyObject_Length;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> PyObject_GetItem;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*, int> PyObject_SetItem;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte*, _PyObject*> PyObject_GetAttrString;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, byte*, _PyObject*, int> PyObject_SetAttrString;

    [StructLayout(LayoutKind.Sequential)]
    public struct _PyCompilerFlags
    {
        public int cf_flags;
        public int cf_feature_version;
    }
    [Import] public delegate* unmanaged[Cdecl]<byte*, _PyCompilerFlags*, int> PyRun_SimpleStringFlags;
    [Import] public delegate* unmanaged[Cdecl]<byte*, int, _PyObject*, _PyObject*, _PyCompilerFlags*, _PyObject*> PyRun_StringFlags;

    [Import] public _PyTypeObject* PyTuple_Type;
    [Import] public _PyTypeObject* PyTupleIter_Type;

    [Import] public delegate* unmanaged[Cdecl]<Py_ssize_t, _PyObject*> PyTuple_New;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, Py_ssize_t> PyTuple_Size;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, Py_ssize_t, _PyObject*> PyTuple_GetItem;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, Py_ssize_t, _PyObject*, int> PyTuple_SetItem;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, Py_ssize_t, Py_ssize_t, _PyObject*> PyTuple_GetSlice;

    [StructLayout(LayoutKind.Sequential)]
    public struct _PyTupleObject
    {
        public _PyVarObject ob_base;
        public _PyObject* ob_item;
    }

    [Import] public delegate* unmanaged[Cdecl]<_PyObject**, Py_ssize_t, int> _PyTuple_Resize;

    [Import] public delegate* unmanaged[Cdecl]<void*, byte*> _PyType_Name;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, void> _PyObject_Dump;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, void> PyObject_CallFinalizer;

    [Import] public _PyTypeObject* PyUnicode_Type;
    [Import] public _PyTypeObject* PyUnicodeIter_Type;

    [Import] public delegate* unmanaged[Cdecl]<byte*, _PyObject*> PyUnicode_DecodeFSDefault;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, nint> PyUnicode_GetLength;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, char*, nint, nint> PyUnicode_AsWideChar;
    [Import] public delegate* unmanaged[Cdecl]<char*, nint, _PyObject*> PyUnicode_FromWideChar;
    [Import] public delegate* unmanaged[Cdecl]<byte*, nint, _PyObject*> PyUnicode_FromStringAndSize;
    [Import] public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> PyUnicode_FromObject;
}

#pragma warning restore CS0649
