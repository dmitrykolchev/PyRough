using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PyRough.Native.Python310
{
    public unsafe partial struct _PyObject
    {
        [NativeTypeName("Py_ssize_t")]
        public long ob_refcnt;

        [NativeTypeName("PyTypeObject *")]
        public _PyTypeObject* ob_type;
    }

    public partial struct PyVarObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("Py_ssize_t")]
        public long ob_size;
    }

    public unsafe partial struct PyType_Slot
    {
        public int slot;

        public void* pfunc;
    }

    public unsafe partial struct PyType_Spec
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        public int basicsize;

        public int itemsize;

        [NativeTypeName("unsigned int")]
        public uint flags;

        public PyType_Slot* slots;
    }

    public enum PySendResult
    {
        PYGEN_RETURN = 0,
        PYGEN_ERROR = -1,
        PYGEN_NEXT = 1,
    }

    public unsafe partial struct _Py_Identifier
    {
        [NativeTypeName("const char *")]
        public sbyte* @string;

        [NativeTypeName("Py_ssize_t")]
        public long index;
    }

    public unsafe partial struct _PyBufferInfo
    {
        public void* buf;

        [NativeTypeName("PyObject *")]
        public _PyObject* obj;

        [NativeTypeName("Py_ssize_t")]
        public long len;

        [NativeTypeName("Py_ssize_t")]
        public long itemsize;

        public int @readonly;

        public int ndim;

        [NativeTypeName("char *")]
        public sbyte* format;

        [NativeTypeName("Py_ssize_t *")]
        public long* shape;

        [NativeTypeName("Py_ssize_t *")]
        public long* strides;

        [NativeTypeName("Py_ssize_t *")]
        public long* suboffsets;

        public void* @internal;
    }

    public unsafe partial struct PyNumberMethods
    {
        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_add;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_subtract;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_multiply;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_remainder;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_divmod;

        [NativeTypeName("ternaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*, _PyObject*> nb_power;

        [NativeTypeName("unaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> nb_negative;

        [NativeTypeName("unaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> nb_positive;

        [NativeTypeName("unaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> nb_absolute;

        [NativeTypeName("inquiry")]
        public delegate* unmanaged[Cdecl]<_PyObject*, int> nb_bool;

        [NativeTypeName("unaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> nb_invert;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_lshift;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_rshift;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_and;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_xor;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_or;

        [NativeTypeName("unaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> nb_int;

        public void* nb_reserved;

        [NativeTypeName("unaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> nb_float;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_add;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_subtract;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_multiply;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_remainder;

        [NativeTypeName("ternaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*, _PyObject*> nb_inplace_power;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_lshift;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_rshift;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_and;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_xor;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_or;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_floor_divide;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_true_divide;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_floor_divide;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_true_divide;

        [NativeTypeName("unaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> nb_index;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_matrix_multiply;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> nb_inplace_matrix_multiply;
    }

    public unsafe partial struct PySequenceMethods
    {
        [NativeTypeName("lenfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, long> sq_length;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> sq_concat;

        [NativeTypeName("ssizeargfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, long, _PyObject*> sq_repeat;

        [NativeTypeName("ssizeargfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, long, _PyObject*> sq_item;

        public void* was_sq_slice;

        [NativeTypeName("ssizeobjargproc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, long, _PyObject*, int> sq_ass_item;

        public void* was_sq_ass_slice;

        [NativeTypeName("objobjproc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, int> sq_contains;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> sq_inplace_concat;

        [NativeTypeName("ssizeargfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, long, _PyObject*> sq_inplace_repeat;
    }

    public unsafe partial struct PyMappingMethods
    {
        [NativeTypeName("lenfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, long> mp_length;

        [NativeTypeName("binaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> mp_subscript;

        [NativeTypeName("objobjargproc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*, int> mp_ass_subscript;
    }

    public unsafe partial struct PyAsyncMethods
    {
        [NativeTypeName("unaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> am_await;

        [NativeTypeName("unaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> am_aiter;

        [NativeTypeName("unaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> am_anext;

        [NativeTypeName("sendfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject**, PySendResult> am_send;
    }

    public unsafe partial struct PyBufferProcs
    {
        [NativeTypeName("getbufferproc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyBufferInfo*, int, int> bf_getbuffer;

        [NativeTypeName("releasebufferproc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyBufferInfo*, void> bf_releasebuffer;
    }

    public unsafe partial struct _PyTypeObject
    {
        public PyVarObject ob_base;

        [NativeTypeName("const char *")]
        public sbyte* tp_name;

        [NativeTypeName("Py_ssize_t")]
        public long tp_basicsize;

        [NativeTypeName("Py_ssize_t")]
        public long tp_itemsize;

        [NativeTypeName("destructor")]
        public delegate* unmanaged[Cdecl]<_PyObject*, void> tp_dealloc;

        [NativeTypeName("Py_ssize_t")]
        public long tp_vectorcall_offset;

        [NativeTypeName("getattrfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, sbyte*, _PyObject*> tp_getattr;

        [NativeTypeName("setattrfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, sbyte*, _PyObject*, int> tp_setattr;

        public PyAsyncMethods* tp_as_async;

        [NativeTypeName("reprfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> tp_repr;

        public PyNumberMethods* tp_as_number;

        public PySequenceMethods* tp_as_sequence;

        public PyMappingMethods* tp_as_mapping;

        [NativeTypeName("hashfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, long> tp_hash;

        [NativeTypeName("ternaryfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*, _PyObject*> tp_call;

        [NativeTypeName("reprfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> tp_str;

        [NativeTypeName("getattrofunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> tp_getattro;

        [NativeTypeName("setattrofunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*, int> tp_setattro;

        public PyBufferProcs* tp_as_buffer;

        [NativeTypeName("unsigned long")]
        public uint tp_flags;

        [NativeTypeName("const char *")]
        public sbyte* tp_doc;

        [NativeTypeName("traverseproc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, delegate* unmanaged[Cdecl]<_PyObject*, void*, int>, void*, int> tp_traverse;

        [NativeTypeName("inquiry")]
        public delegate* unmanaged[Cdecl]<_PyObject*, int> tp_clear;

        [NativeTypeName("richcmpfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, int, _PyObject*> tp_richcompare;

        [NativeTypeName("Py_ssize_t")]
        public long tp_weaklistoffset;

        [NativeTypeName("getiterfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> tp_iter;

        [NativeTypeName("iternextfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*> tp_iternext;

        [NativeTypeName("struct PyMethodDef *")]
        public PyMethodDef* tp_methods;

        [NativeTypeName("struct PyMemberDef *")]
        public PyMemberDef* tp_members;

        [NativeTypeName("struct PyGetSetDef *")]
        public PyGetSetDef* tp_getset;

        [NativeTypeName("struct _typeobject *")]
        public _PyTypeObject* tp_base;

        [NativeTypeName("PyObject *")]
        public _PyObject* tp_dict;

        [NativeTypeName("descrgetfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*, _PyObject*> tp_descr_get;

        [NativeTypeName("descrsetfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*, int> tp_descr_set;

        [NativeTypeName("Py_ssize_t")]
        public long tp_dictoffset;

        [NativeTypeName("initproc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*, int> tp_init;

        [NativeTypeName("allocfunc")]
        public delegate* unmanaged[Cdecl]<_PyTypeObject*, long, _PyObject*> tp_alloc;

        [NativeTypeName("newfunc")]
        public delegate* unmanaged[Cdecl]<_PyTypeObject*, _PyObject*, _PyObject*, _PyObject*> tp_new;

        [NativeTypeName("freefunc")]
        public delegate* unmanaged[Cdecl]<void*, void> tp_free;

        [NativeTypeName("inquiry")]
        public delegate* unmanaged[Cdecl]<_PyObject*, int> tp_is_gc;

        [NativeTypeName("PyObject *")]
        public _PyObject* tp_bases;

        [NativeTypeName("PyObject *")]
        public _PyObject* tp_mro;

        [NativeTypeName("PyObject *")]
        public _PyObject* tp_cache;

        [NativeTypeName("PyObject *")]
        public _PyObject* tp_subclasses;

        [NativeTypeName("PyObject *")]
        public _PyObject* tp_weaklist;

        [NativeTypeName("destructor")]
        public delegate* unmanaged[Cdecl]<_PyObject*, void> tp_del;

        [NativeTypeName("unsigned int")]
        public uint tp_version_tag;

        [NativeTypeName("destructor")]
        public delegate* unmanaged[Cdecl]<_PyObject*, void> tp_finalize;

        [NativeTypeName("vectorcallfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject**, nuint, _PyObject*, _PyObject*> tp_vectorcall;
    }

    public unsafe partial struct _heaptypeobject
    {
        [NativeTypeName("PyTypeObject")]
        public _PyTypeObject ht_type;

        public PyAsyncMethods as_async;

        public PyNumberMethods as_number;

        public PyMappingMethods as_mapping;

        public PySequenceMethods as_sequence;

        public PyBufferProcs as_buffer;

        [NativeTypeName("PyObject *")]
        public _PyObject* ht_name;

        [NativeTypeName("PyObject *")]
        public _PyObject* ht_slots;

        [NativeTypeName("PyObject *")]
        public _PyObject* ht_qualname;

        [NativeTypeName("struct _dictkeysobject *")]
        public _dictkeysobject* ht_cached_keys;

        [NativeTypeName("PyObject *")]
        public _PyObject* ht_module;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Py_HashSecret_t
    {
        [FieldOffset(0)]
        [NativeTypeName("unsigned char[24]")]
        public _uc_e__FixedBuffer uc;

        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_pyhash_L59_C5")]
        public _fnv_e__Struct fnv;

        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_pyhash_L64_C5")]
        public _siphash_e__Struct siphash;

        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_pyhash_L69_C5")]
        public _djbx33a_e__Struct djbx33a;

        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_pyhash_L73_C5")]
        public _expat_e__Struct expat;

        public partial struct _fnv_e__Struct
        {
            [NativeTypeName("Py_hash_t")]
            public long prefix;

            [NativeTypeName("Py_hash_t")]
            public long suffix;
        }

        public partial struct _siphash_e__Struct
        {
            [NativeTypeName("uint64_t")]
            public ulong k0;

            [NativeTypeName("uint64_t")]
            public ulong k1;
        }

        public partial struct _djbx33a_e__Struct
        {
            [NativeTypeName("unsigned char[16]")]
            public _padding_e__FixedBuffer padding;

            [NativeTypeName("Py_hash_t")]
            public long suffix;

            [InlineArray(16)]
            public partial struct _padding_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public partial struct _expat_e__Struct
        {
            [NativeTypeName("unsigned char[16]")]
            public _padding_e__FixedBuffer padding;

            [NativeTypeName("Py_hash_t")]
            public long hashsalt;

            [InlineArray(16)]
            public partial struct _padding_e__FixedBuffer
            {
                public byte e0;
            }
        }

        [InlineArray(24)]
        public partial struct _uc_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct PyHash_FuncDef
    {
        [NativeTypeName("Py_hash_t (*const)(const void *, Py_ssize_t)")]
        public delegate* unmanaged[Cdecl]<void*, long, long> hash;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const int")]
        public int hash_bits;

        [NativeTypeName("const int")]
        public int seed_bits;
    }

    public partial struct PyBytesObject
    {
        public PyVarObject ob_base;

        [NativeTypeName("Py_hash_t")]
        public long ob_shash;

        [NativeTypeName("char[1]")]
        public _ob_sval_e__FixedBuffer ob_sval;

        public partial struct _ob_sval_e__FixedBuffer
        {
            public sbyte e0;

            [UnscopedRef]
            public ref sbyte this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref Unsafe.Add(ref e0, index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<sbyte> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
        }
    }

    public unsafe partial struct _PyBytesWriter
    {
        [NativeTypeName("PyObject *")]
        public _PyObject* buffer;

        [NativeTypeName("Py_ssize_t")]
        public long allocated;

        [NativeTypeName("Py_ssize_t")]
        public long min_size;

        public int use_bytearray;

        public int overallocate;

        public int use_small_buffer;

        [NativeTypeName("char[512]")]
        public _small_buffer_e__FixedBuffer small_buffer;

        [InlineArray(512)]
        public partial struct _small_buffer_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct PyASCIIObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("Py_ssize_t")]
        public long length;

        [NativeTypeName("Py_hash_t")]
        public long hash;

        [NativeTypeName("__AnonymousRecord_unicodeobject_L162_C5")]
        public _state_e__Struct state;

        [NativeTypeName("wchar_t *")]
        public ushort* wstr;

        public partial struct _state_e__Struct
        {
            public uint _bitfield;

            [NativeTypeName("unsigned int : 2")]
            public uint interned
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                readonly get
                {
                    return _bitfield & 0x3u;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                set
                {
                    _bitfield = (_bitfield & ~0x3u) | (value & 0x3u);
                }
            }

            [NativeTypeName("unsigned int : 3")]
            public uint kind
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                readonly get
                {
                    return (_bitfield >> 2) & 0x7u;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                set
                {
                    _bitfield = (_bitfield & ~(0x7u << 2)) | ((value & 0x7u) << 2);
                }
            }

            [NativeTypeName("unsigned int : 1")]
            public uint compact
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                readonly get
                {
                    return (_bitfield >> 5) & 0x1u;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                set
                {
                    _bitfield = (_bitfield & ~(0x1u << 5)) | ((value & 0x1u) << 5);
                }
            }

            [NativeTypeName("unsigned int : 1")]
            public uint ascii
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                readonly get
                {
                    return (_bitfield >> 6) & 0x1u;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                set
                {
                    _bitfield = (_bitfield & ~(0x1u << 6)) | ((value & 0x1u) << 6);
                }
            }

            [NativeTypeName("unsigned int : 1")]
            public uint ready
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                readonly get
                {
                    return (_bitfield >> 7) & 0x1u;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                set
                {
                    _bitfield = (_bitfield & ~(0x1u << 7)) | ((value & 0x1u) << 7);
                }
            }

            [NativeTypeName("unsigned int : 24")]
            public uint Anonymous
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                readonly get
                {
                    return (_bitfield >> 8) & 0xFFFFFFu;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                set
                {
                    _bitfield = (_bitfield & ~(0xFFFFFFu << 8)) | ((value & 0xFFFFFFu) << 8);
                }
            }
        }
    }

    public unsafe partial struct PyCompactUnicodeObject
    {
        public PyASCIIObject _base;

        [NativeTypeName("Py_ssize_t")]
        public long utf8_length;

        [NativeTypeName("char *")]
        public sbyte* utf8;

        [NativeTypeName("Py_ssize_t")]
        public long wstr_length;
    }

    public partial struct PyUnicodeObject
    {
        public PyCompactUnicodeObject _base;

        [NativeTypeName("__AnonymousRecord_unicodeobject_L238_C5")]
        public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _data_e__Union
        {
            [FieldOffset(0)]
            public void* any;

            [FieldOffset(0)]
            [NativeTypeName("Py_UCS1 *")]
            public byte* latin1;

            [FieldOffset(0)]
            [NativeTypeName("Py_UCS2 *")]
            public ushort* ucs2;

            [FieldOffset(0)]
            [NativeTypeName("Py_UCS4 *")]
            public uint* ucs4;
        }
    }

    public enum PyUnicode_Kind
    {
        PyUnicode_WCHAR_KIND = 0,
        PyUnicode_1BYTE_KIND = 1,
        PyUnicode_2BYTE_KIND = 2,
        PyUnicode_4BYTE_KIND = 4,
    }

    public unsafe partial struct _PyUnicodeWriter
    {
        [NativeTypeName("PyObject *")]
        public _PyObject* buffer;

        public void* data;

        [NativeTypeName("enum PyUnicode_Kind")]
        public PyUnicode_Kind kind;

        [NativeTypeName("Py_UCS4")]
        public uint maxchar;

        [NativeTypeName("Py_ssize_t")]
        public long size;

        [NativeTypeName("Py_ssize_t")]
        public long pos;

        [NativeTypeName("Py_ssize_t")]
        public long min_length;

        [NativeTypeName("Py_UCS4")]
        public uint min_char;

        [NativeTypeName("unsigned char")]
        public byte overallocate;

        [NativeTypeName("unsigned char")]
        public byte @readonly;
    }

    public partial struct _longobject
    {
        public PyVarObject ob_base;

        [NativeTypeName("digit[1]")]
        public _ob_digit_e__FixedBuffer ob_digit;

        public partial struct _ob_digit_e__FixedBuffer
        {
            public uint e0;

            [UnscopedRef]
            public ref uint this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref Unsafe.Add(ref e0, index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<uint> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
        }
    }

    public partial struct PyFloatObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        public double ob_fval;
    }

    public partial struct Py_complex
    {
        public double real;

        public double imag;
    }

    public partial struct PyComplexObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        public Py_complex cval;
    }

    public partial struct _PyManagedBufferObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        public int flags;

        [NativeTypeName("Py_ssize_t")]
        public long exports;

        [NativeTypeName("Py_buffer")]
        public _PyBufferInfo master;
    }

    public unsafe partial struct PyMemoryViewObject
    {
        public PyVarObject ob_base;

        public _PyManagedBufferObject* mbuf;

        [NativeTypeName("Py_hash_t")]
        public long hash;

        public int flags;

        [NativeTypeName("Py_ssize_t")]
        public long exports;

        [NativeTypeName("Py_buffer")]
        public _PyBufferInfo view;

        [NativeTypeName("PyObject *")]
        public _PyObject* weakreflist;

        [NativeTypeName("Py_ssize_t[1]")]
        public _ob_array_e__FixedBuffer ob_array;

        public partial struct _ob_array_e__FixedBuffer
        {
            public long e0;

            [UnscopedRef]
            public ref long this[int index]
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return ref Unsafe.Add(ref e0, index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [UnscopedRef]
            public Span<long> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
        }
    }

    public unsafe partial struct PyDictObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("Py_ssize_t")]
        public long ma_used;

        [NativeTypeName("uint64_t")]
        public ulong ma_version_tag;

        [NativeTypeName("PyDictKeysObject *")]
        public _dictkeysobject* ma_keys;

        [NativeTypeName("PyObject **")]
        public _PyObject** ma_values;
    }

    public unsafe partial struct _PyDictViewObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        public PyDictObject* dv_dict;
    }

    public unsafe partial struct _PySetEntry
    {
        [NativeTypeName("PyObject *")]
        public _PyObject* key;

        [NativeTypeName("Py_hash_t")]
        public long hash;
    }

    public unsafe partial struct PySetObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("Py_ssize_t")]
        public long fill;

        [NativeTypeName("Py_ssize_t")]
        public long used;

        [NativeTypeName("Py_ssize_t")]
        public long mask;

        [NativeTypeName("setentry *")]
        public _PySetEntry* table;

        [NativeTypeName("Py_hash_t")]
        public long hash;

        [NativeTypeName("Py_ssize_t")]
        public long finger;

        [NativeTypeName("setentry[8]")]
        public _smalltable_e__FixedBuffer smalltable;

        [NativeTypeName("PyObject *")]
        public _PyObject* weakreflist;

        [InlineArray(8)]
        public partial struct _smalltable_e__FixedBuffer
        {
            public _PySetEntry e0;
        }
    }

    public unsafe partial struct PyMethodDef
    {
        [NativeTypeName("const char *")]
        public sbyte* ml_name;

        [NativeTypeName("PyCFunction")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> ml_meth;

        public int ml_flags;

        [NativeTypeName("const char *")]
        public sbyte* ml_doc;
    }

    public unsafe partial struct PyModuleDef_Base
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("PyObject *(*)(void)")]
        public delegate* unmanaged[Cdecl]<_PyObject*> m_init;

        [NativeTypeName("Py_ssize_t")]
        public long m_index;

        [NativeTypeName("PyObject *")]
        public _PyObject* m_copy;
    }

    public unsafe partial struct PyModuleDef_Slot
    {
        public int slot;

        public void* value;
    }

    public unsafe partial struct PyModuleDef
    {
        public PyModuleDef_Base m_base;

        [NativeTypeName("const char *")]
        public sbyte* m_name;

        [NativeTypeName("const char *")]
        public sbyte* m_doc;

        [NativeTypeName("Py_ssize_t")]
        public long m_size;

        public PyMethodDef* m_methods;

        [NativeTypeName("struct PyModuleDef_Slot *")]
        public PyModuleDef_Slot* m_slots;

        [NativeTypeName("traverseproc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, delegate* unmanaged[Cdecl]<_PyObject*, void*, int>, void*, int> m_traverse;

        [NativeTypeName("inquiry")]
        public delegate* unmanaged[Cdecl]<_PyObject*, int> m_clear;

        [NativeTypeName("freefunc")]
        public delegate* unmanaged[Cdecl]<void*, void> m_free;
    }

    public unsafe partial struct PyFrameConstructor
    {
        [NativeTypeName("PyObject *")]
        public _PyObject* fc_globals;

        [NativeTypeName("PyObject *")]
        public _PyObject* fc_builtins;

        [NativeTypeName("PyObject *")]
        public _PyObject* fc_name;

        [NativeTypeName("PyObject *")]
        public _PyObject* fc_qualname;

        [NativeTypeName("PyObject *")]
        public _PyObject* fc_code;

        [NativeTypeName("PyObject *")]
        public _PyObject* fc_defaults;

        [NativeTypeName("PyObject *")]
        public _PyObject* fc_kwdefaults;

        [NativeTypeName("PyObject *")]
        public _PyObject* fc_closure;
    }

    public unsafe partial struct PyFunctionObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_globals;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_builtins;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_name;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_qualname;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_code;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_defaults;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_kwdefaults;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_closure;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_doc;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_dict;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_weakreflist;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_module;

        [NativeTypeName("PyObject *")]
        public _PyObject* func_annotations;

        [NativeTypeName("vectorcallfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject**, nuint, _PyObject*, _PyObject*> vectorcall;
    }

    public unsafe partial struct PyMethodObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("PyObject *")]
        public _PyObject* im_func;

        [NativeTypeName("PyObject *")]
        public _PyObject* im_self;

        [NativeTypeName("PyObject *")]
        public _PyObject* im_weakreflist;

        [NativeTypeName("vectorcallfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject**, nuint, _PyObject*, _PyObject*> vectorcall;
    }

    public unsafe partial struct PyInstanceMethodObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("PyObject *")]
        public _PyObject* func;
    }

    public unsafe partial struct PyCodeObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        public int co_argcount;

        public int co_posonlyargcount;

        public int co_kwonlyargcount;

        public int co_nlocals;

        public int co_stacksize;

        public int co_flags;

        public int co_firstlineno;

        [NativeTypeName("PyObject *")]
        public _PyObject* co_code;

        [NativeTypeName("PyObject *")]
        public _PyObject* co_consts;

        [NativeTypeName("PyObject *")]
        public _PyObject* co_names;

        [NativeTypeName("PyObject *")]
        public _PyObject* co_varnames;

        [NativeTypeName("PyObject *")]
        public _PyObject* co_freevars;

        [NativeTypeName("PyObject *")]
        public _PyObject* co_cellvars;

        [NativeTypeName("Py_ssize_t *")]
        public long* co_cell2arg;

        [NativeTypeName("PyObject *")]
        public _PyObject* co_filename;

        [NativeTypeName("PyObject *")]
        public _PyObject* co_name;

        [NativeTypeName("PyObject *")]
        public _PyObject* co_linetable;

        public void* co_zombieframe;

        [NativeTypeName("PyObject *")]
        public _PyObject* co_weakreflist;

        public void* co_extra;

        [NativeTypeName("unsigned char *")]
        public byte* co_opcache_map;

        public _PyOpcache* co_opcache;

        public int co_opcache_flag;

        [NativeTypeName("unsigned char")]
        public byte co_opcache_size;
    }

    public unsafe partial struct _opaque
    {
        public int computed_line;

        [NativeTypeName("const char *")]
        public sbyte* lo_next;

        [NativeTypeName("const char *")]
        public sbyte* limit;
    }

    public partial struct _line_offsets
    {
        public int ar_start;

        public int ar_end;

        public int ar_line;

        [NativeTypeName("struct _opaque")]
        public _opaque opaque;
    }

    public unsafe partial struct PySliceObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("PyObject *")]
        public _PyObject* start;

        [NativeTypeName("PyObject *")]
        public _PyObject* stop;

        [NativeTypeName("PyObject *")]
        public _PyObject* step;
    }

    public unsafe partial struct PyCellObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("PyObject *")]
        public _PyObject* ob_ref;
    }

    public unsafe partial struct PyStatus
    {
        [NativeTypeName("__AnonymousEnum_initconfig_L11_C5")]
        public int _type;

        [NativeTypeName("const char *")]
        public sbyte* func;

        [NativeTypeName("const char *")]
        public sbyte* err_msg;

        public int exitcode;

        public const int _PyStatus_TYPE_OK = 0;
        public const int _PyStatus_TYPE_ERROR = 1;
        public const int _PyStatus_TYPE_EXIT = 2;
    }

    public unsafe partial struct PyWideStringList
    {
        [NativeTypeName("Py_ssize_t")]
        public long length;

        [NativeTypeName("wchar_t **")]
        public ushort** items;
    }

    public partial struct PyPreConfig
    {
        public int _config_init;

        public int parse_argv;

        public int isolated;

        public int use_environment;

        public int configure_locale;

        public int coerce_c_locale;

        public int coerce_c_locale_warn;

        public int legacy_windows_fs_encoding;

        public int utf8_mode;

        public int dev_mode;

        public int allocator;
    }

    public unsafe partial struct PyConfig
    {
        public int _config_init;

        public int isolated;

        public int use_environment;

        public int dev_mode;

        public int install_signal_handlers;

        public int use_hash_seed;

        [NativeTypeName("unsigned long")]
        public uint hash_seed;

        public int faulthandler;

        public int tracemalloc;

        public int import_time;

        public int show_ref_count;

        public int dump_refs;

        public int malloc_stats;

        [NativeTypeName("wchar_t *")]
        public ushort* filesystem_encoding;

        [NativeTypeName("wchar_t *")]
        public ushort* filesystem_errors;

        [NativeTypeName("wchar_t *")]
        public ushort* pycache_prefix;

        public int parse_argv;

        public PyWideStringList orig_argv;

        public PyWideStringList argv;

        public PyWideStringList xoptions;

        public PyWideStringList warnoptions;

        public int site_import;

        public int bytes_warning;

        public int warn_default_encoding;

        public int inspect;

        public int interactive;

        public int optimization_level;

        public int parser_debug;

        public int write_bytecode;

        public int verbose;

        public int quiet;

        public int user_site_directory;

        public int configure_c_stdio;

        public int buffered_stdio;

        [NativeTypeName("wchar_t *")]
        public ushort* stdio_encoding;

        [NativeTypeName("wchar_t *")]
        public ushort* stdio_errors;

        public int legacy_windows_stdio;

        [NativeTypeName("wchar_t *")]
        public ushort* check_hash_pycs_mode;

        public int pathconfig_warnings;

        [NativeTypeName("wchar_t *")]
        public ushort* program_name;

        [NativeTypeName("wchar_t *")]
        public ushort* pythonpath_env;

        [NativeTypeName("wchar_t *")]
        public ushort* home;

        [NativeTypeName("wchar_t *")]
        public ushort* platlibdir;

        public int module_search_paths_set;

        public PyWideStringList module_search_paths;

        [NativeTypeName("wchar_t *")]
        public ushort* executable;

        [NativeTypeName("wchar_t *")]
        public ushort* base_executable;

        [NativeTypeName("wchar_t *")]
        public ushort* prefix;

        [NativeTypeName("wchar_t *")]
        public ushort* base_prefix;

        [NativeTypeName("wchar_t *")]
        public ushort* exec_prefix;

        [NativeTypeName("wchar_t *")]
        public ushort* base_exec_prefix;

        public int skip_source_first_line;

        [NativeTypeName("wchar_t *")]
        public ushort* run_command;

        [NativeTypeName("wchar_t *")]
        public ushort* run_module;

        [NativeTypeName("wchar_t *")]
        public ushort* run_filename;

        public int _install_importlib;

        public int _init_main;

        public int _isolated_interpreter;
    }

    public enum PyGILState_STATE
    {
        PyGILState_LOCKED,
        PyGILState_UNLOCKED,
    }

    public unsafe partial struct _cframe
    {
        public int use_tracing;

        [NativeTypeName("struct _cframe *")]
        public _cframe* previous;
    }

    public unsafe partial struct _err_stackitem
    {
        [NativeTypeName("PyObject *")]
        public _PyObject* exc_type;

        [NativeTypeName("PyObject *")]
        public _PyObject* exc_value;

        [NativeTypeName("PyObject *")]
        public _PyObject* exc_traceback;

        [NativeTypeName("struct _err_stackitem *")]
        public _err_stackitem* previous_item;
    }

    public unsafe partial struct _PyThreadState
    {
        [NativeTypeName("struct _ts *")]
        public _PyThreadState* prev;

        [NativeTypeName("struct _ts *")]
        public _PyThreadState* next;

        [NativeTypeName("PyInterpreterState *")]
        public _PyInterpreterState* interp;

        [NativeTypeName("PyFrameObject *")]
        public _frame* frame;

        public int recursion_depth;

        public int recursion_headroom;

        public int stackcheck_counter;

        public int tracing;

        [NativeTypeName("CFrame *")]
        public _cframe* cframe;

        [NativeTypeName("Py_tracefunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _frame*, int, _PyObject*, int> c_profilefunc;

        [NativeTypeName("Py_tracefunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _frame*, int, _PyObject*, int> c_tracefunc;

        [NativeTypeName("PyObject *")]
        public _PyObject* c_profileobj;

        [NativeTypeName("PyObject *")]
        public _PyObject* c_traceobj;

        [NativeTypeName("PyObject *")]
        public _PyObject* curexc_type;

        [NativeTypeName("PyObject *")]
        public _PyObject* curexc_value;

        [NativeTypeName("PyObject *")]
        public _PyObject* curexc_traceback;

        [NativeTypeName("_PyErr_StackItem")]
        public _err_stackitem exc_state;

        [NativeTypeName("_PyErr_StackItem *")]
        public _err_stackitem* exc_info;

        [NativeTypeName("PyObject *")]
        public _PyObject* dict;

        public int gilstate_counter;

        [NativeTypeName("PyObject *")]
        public _PyObject* async_exc;

        [NativeTypeName("unsigned long")]
        public uint thread_id;

        public int trash_delete_nesting;

        [NativeTypeName("PyObject *")]
        public _PyObject* trash_delete_later;

        [NativeTypeName("void (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void> on_delete;

        public void* on_delete_data;

        public int coroutine_origin_tracking_depth;

        [NativeTypeName("PyObject *")]
        public _PyObject* async_gen_firstiter;

        [NativeTypeName("PyObject *")]
        public _PyObject* async_gen_finalizer;

        [NativeTypeName("PyObject *")]
        public _PyObject* context;

        [NativeTypeName("uint64_t")]
        public ulong context_ver;

        [NativeTypeName("uint64_t")]
        public ulong id;

        [NativeTypeName("CFrame")]
        public _cframe root_cframe;
    }

    public unsafe partial struct _xid
    {
        public void* data;

        [NativeTypeName("PyObject *")]
        public _PyObject* obj;

        [NativeTypeName("int64_t")]
        public long interp;

        [NativeTypeName("PyObject *(*)(struct _xid *)")]
        public delegate* unmanaged[Cdecl]<_xid*, _PyObject*> new_object;

        [NativeTypeName("void (*)(void *)")]
        public delegate* unmanaged[Cdecl]<void*, void> free;
    }

    public unsafe partial struct PyGenObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("PyFrameObject *")]
        public _frame* gi_frame;

        [NativeTypeName("PyObject *")]
        public _PyObject* gi_code;

        [NativeTypeName("PyObject *")]
        public _PyObject* gi_weakreflist;

        [NativeTypeName("PyObject *")]
        public _PyObject* gi_name;

        [NativeTypeName("PyObject *")]
        public _PyObject* gi_qualname;

        [NativeTypeName("_PyErr_StackItem")]
        public _err_stackitem gi_exc_state;
    }

    public unsafe partial struct PyCoroObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("PyFrameObject *")]
        public _frame* cr_frame;

        [NativeTypeName("PyObject *")]
        public _PyObject* cr_code;

        [NativeTypeName("PyObject *")]
        public _PyObject* cr_weakreflist;

        [NativeTypeName("PyObject *")]
        public _PyObject* cr_name;

        [NativeTypeName("PyObject *")]
        public _PyObject* cr_qualname;

        [NativeTypeName("_PyErr_StackItem")]
        public _err_stackitem cr_exc_state;

        [NativeTypeName("PyObject *")]
        public _PyObject* cr_origin;
    }

    public unsafe partial struct PyAsyncGenObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("PyFrameObject *")]
        public _frame* ag_frame;

        [NativeTypeName("PyObject *")]
        public _PyObject* ag_code;

        [NativeTypeName("PyObject *")]
        public _PyObject* ag_weakreflist;

        [NativeTypeName("PyObject *")]
        public _PyObject* ag_name;

        [NativeTypeName("PyObject *")]
        public _PyObject* ag_qualname;

        [NativeTypeName("_PyErr_StackItem")]
        public _err_stackitem ag_exc_state;

        [NativeTypeName("PyObject *")]
        public _PyObject* ag_finalizer;

        public int ag_hooks_inited;

        public int ag_closed;

        public int ag_running_async;
    }

    public unsafe partial struct PyGetSetDef
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("getter")]
        public delegate* unmanaged[Cdecl]<_PyObject*, void*, _PyObject*> get;

        [NativeTypeName("setter")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, void*, int> set;

        [NativeTypeName("const char *")]
        public sbyte* doc;

        public void* closure;
    }

    public unsafe partial struct _PyWrapperBase
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        public int offset;

        public void* function;

        [NativeTypeName("wrapperfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, void*, _PyObject*> wrapper;

        [NativeTypeName("const char *")]
        public sbyte* doc;

        public int flags;

        [NativeTypeName("PyObject *")]
        public _PyObject* name_strobj;
    }

    public unsafe partial struct PyDescrObject
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("PyTypeObject *")]
        public _PyTypeObject* d_type;

        [NativeTypeName("PyObject *")]
        public _PyObject* d_name;

        [NativeTypeName("PyObject *")]
        public _PyObject* d_qualname;
    }

    public unsafe partial struct PyMethodDescrObject
    {
        public PyDescrObject d_common;

        public PyMethodDef* d_method;

        [NativeTypeName("vectorcallfunc")]
        public delegate* unmanaged[Cdecl]<_PyObject*, _PyObject**, nuint, _PyObject*, _PyObject*> vectorcall;
    }

    public unsafe partial struct PyMemberDescrObject
    {
        public PyDescrObject d_common;

        [NativeTypeName("struct PyMemberDef *")]
        public PyMemberDef* d_member;
    }

    public unsafe partial struct PyGetSetDescrObject
    {
        public PyDescrObject d_common;

        public PyGetSetDef* d_getset;
    }

    public unsafe partial struct PyWrapperDescrObject
    {
        public PyDescrObject d_common;

        [NativeTypeName("struct wrapperbase *")]
        public _PyWrapperBase* d_base;

        public void* d_wrapped;
    }

    public unsafe partial struct _PyWeakReference
    {
        [NativeTypeName("PyObject")]
        public _PyObject ob_base;

        [NativeTypeName("PyObject *")]
        public _PyObject* wr_object;

        [NativeTypeName("PyObject *")]
        public _PyObject* wr_callback;

        [NativeTypeName("Py_hash_t")]
        public long hash;

        [NativeTypeName("PyWeakReference *")]
        public _PyWeakReference* wr_prev;

        [NativeTypeName("PyWeakReference *")]
        public _PyWeakReference* wr_next;
    }

    public unsafe partial struct PyStructSequence_Field
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* doc;
    }

    public unsafe partial struct PyStructSequence_Desc
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* doc;

        [NativeTypeName("struct PyStructSequence_Field *")]
        public PyStructSequence_Field* fields;

        public int n_in_sequence;
    }

    public enum PyLockStatus
    {
        PY_LOCK_FAILURE = 0,
        PY_LOCK_ACQUIRED = 1,
        PY_LOCK_INTR,
    }

    public partial struct _Py_tss_t
    {
        public int _is_initialized;

        [NativeTypeName("unsigned long")]
        public uint _key;
    }

    public partial struct PyCompilerFlags
    {
        public int cf_flags;

        public int cf_feature_version;
    }

    public partial struct PyFutureFeatures
    {
        public int ff_features;

        public int ff_lineno;
    }

    public static unsafe partial class Methods
    {
        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* PyMem_Malloc([NativeTypeName("size_t")] nuint size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* PyMem_Calloc([NativeTypeName("size_t")] nuint nelem, [NativeTypeName("size_t")] nuint elsize);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* PyMem_Realloc(void* ptr, [NativeTypeName("size_t")] nuint new_size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyMem_Free(void* ptr);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_Is([NativeTypeName("PyObject *")] _PyObject* x, [NativeTypeName("PyObject *")] _PyObject* y);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyType_FromSpec(PyType_Spec* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyType_FromSpecWithBases(PyType_Spec* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* PyType_GetSlot([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, int param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyType_FromModuleAndSpec([NativeTypeName("PyObject *")] _PyObject* param0, PyType_Spec* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyType_GetModule([NativeTypeName("struct _typeobject *")] _PyTypeObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* PyType_GetModuleState([NativeTypeName("struct _typeobject *")] _PyTypeObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyType_IsSubtype([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, [NativeTypeName("PyTypeObject *")] _PyTypeObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned long")]
        public static extern uint PyType_GetFlags([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyType_Ready([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyType_GenericAlloc([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyType_GenericNew([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint PyType_ClearCache();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyType_Modified([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_Repr([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_Str([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_ASCII([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_Bytes([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_RichCompare([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, int param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_RichCompareBool([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, int param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_GetAttrString([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("const char *")] sbyte* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_SetAttrString([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("const char *")] sbyte* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_HasAttrString([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("const char *")] sbyte* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_GetAttr([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_SetAttr([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_HasAttr([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_SelfIter([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_GenericGetAttr([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_GenericSetAttr([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_GenericSetDict([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, void* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_hash_t")]
        public static extern long PyObject_Hash([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_hash_t")]
        public static extern long PyObject_HashNotImplemented([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_IsTrue([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_Not([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyCallable_Check([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyObject_ClearWeakRefs([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_Dir([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_ReprEnter([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_ReprLeave([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _Py_Dealloc([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_IncRef([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_DecRef([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _Py_IncRef([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _Py_DecRef([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* Py_NewRef([NativeTypeName("PyObject *")] _PyObject* obj);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* Py_XNewRef([NativeTypeName("PyObject *")] _PyObject* obj);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_IsNone([NativeTypeName("PyObject *")] _PyObject* x);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _Py_NewReference([NativeTypeName("PyObject *")] _PyObject* op);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* _PyType_Name([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyType_Lookup([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyType_LookupId([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, _Py_Identifier* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyObject_LookupSpecial([NativeTypeName("PyObject *")] _PyObject* param0, _Py_Identifier* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyTypeObject *")]
        public static extern _PyTypeObject* _PyType_CalculateMetaclass([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyType_GetDocFromInternalDoc([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("const char *")] sbyte* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyType_GetTextSignatureFromInternalDoc([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("const char *")] sbyte* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyType_GetModuleByDef([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, [NativeTypeName("struct PyModuleDef *")] PyModuleDef* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_Print([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("FILE *")] _iobuf* param1, int param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _Py_BreakPoint();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyObject_Dump([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyObject_IsFreed([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyObject_IsAbstract([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyObject_GetAttrId([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("struct _Py_Identifier *")] _Py_Identifier* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyObject_SetAttrId([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("struct _Py_Identifier *")] _Py_Identifier* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyObject_LookupAttr([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject **")] _PyObject** param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyObject_LookupAttrId([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("struct _Py_Identifier *")] _Py_Identifier* param1, [NativeTypeName("PyObject **")] _PyObject** param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyObject_GetMethod([NativeTypeName("PyObject *")] _PyObject* obj, [NativeTypeName("PyObject *")] _PyObject* name, [NativeTypeName("PyObject **")] _PyObject** method);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject **")]
        public static extern _PyObject** _PyObject_GetDictPtr([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyObject_NextNotImplemented([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyObject_CallFinalizer([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_CallFinalizerFromDealloc([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyObject_GenericGetAttrWithDict([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2, int param3);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyObject_GenericSetAttrWithDict([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2, [NativeTypeName("PyObject *")] _PyObject* param3);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyObject_FunctionStr([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyDebugAllocatorStats([NativeTypeName("FILE *")] _iobuf* @out, [NativeTypeName("const char *")] sbyte* block_name, int num_blocks, [NativeTypeName("size_t")] nuint sizeof_block);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyObject_DebugTypeStats([NativeTypeName("FILE *")] _iobuf* @out);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyObject_AssertFailed([NativeTypeName("PyObject *")] _PyObject* obj, [NativeTypeName("const char *")] sbyte* expr, [NativeTypeName("const char *")] sbyte* msg, [NativeTypeName("const char *")] sbyte* file, int line, [NativeTypeName("const char *")] sbyte* function);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyObject_CheckConsistency([NativeTypeName("PyObject *")] _PyObject* op, int check_content);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyTrash_deposit_object([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyTrash_destroy_chain();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyTrash_thread_deposit_object([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyTrash_thread_destroy_chain();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyTrash_begin([NativeTypeName("struct _ts *")] _PyThreadState* tstate, [NativeTypeName("PyObject *")] _PyObject* op);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyTrash_end([NativeTypeName("struct _ts *")] _PyThreadState* tstate);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyTrash_cond([NativeTypeName("PyObject *")] _PyObject* op, [NativeTypeName("destructor")] delegate* unmanaged[Cdecl]<_PyObject*, void> dealloc);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_hash_t")]
        public static extern long _Py_HashDouble([NativeTypeName("PyObject *")] _PyObject* param0, double param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_hash_t")]
        public static extern long _Py_HashPointer([NativeTypeName("const void *")] void* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_hash_t")]
        public static extern long _Py_HashPointerRaw([NativeTypeName("const void *")] void* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_hash_t")]
        public static extern long _Py_HashBytes([NativeTypeName("const void *")] void* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyHash_FuncDef* PyHash_GetFuncDef();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyByteArray_FromObject([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyByteArray_Concat([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyByteArray_FromStringAndSize([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyByteArray_Size([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* PyByteArray_AsString([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyByteArray_Resize([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyBytes_FromStringAndSize([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyBytes_FromString([NativeTypeName("const char *")] sbyte* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyBytes_FromObject([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyBytes_FromFormatV([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("va_list")] sbyte* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyBytes_Size([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* PyBytes_AsString([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyBytes_Repr([NativeTypeName("PyObject *")] _PyObject* param0, int param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyBytes_Concat([NativeTypeName("PyObject **")] _PyObject** param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyBytes_ConcatAndDel([NativeTypeName("PyObject **")] _PyObject** param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyBytes_DecodeEscape([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("Py_ssize_t")] long param1, [NativeTypeName("const char *")] sbyte* param2, [NativeTypeName("Py_ssize_t")] long param3, [NativeTypeName("const char *")] sbyte* param4);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyBytes_AsStringAndSize([NativeTypeName("PyObject *")] _PyObject* obj, [NativeTypeName("char **")] sbyte** s, [NativeTypeName("Py_ssize_t *")] long* len);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyBytes_Resize([NativeTypeName("PyObject **")] _PyObject** param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyBytes_FormatEx([NativeTypeName("const char *")] sbyte* format, [NativeTypeName("Py_ssize_t")] long format_len, [NativeTypeName("PyObject *")] _PyObject* args, int use_bytearray);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyBytes_FromHex([NativeTypeName("PyObject *")] _PyObject* @string, int use_bytearray);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyBytes_DecodeEscape([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("Py_ssize_t")] long param1, [NativeTypeName("const char *")] sbyte* param2, [NativeTypeName("const char **")] sbyte** param3);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyBytes_Join([NativeTypeName("PyObject *")] _PyObject* sep, [NativeTypeName("PyObject *")] _PyObject* x);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyBytesWriter_Init(_PyBytesWriter* writer);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyBytesWriter_Finish(_PyBytesWriter* writer, void* str);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyBytesWriter_Dealloc(_PyBytesWriter* writer);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* _PyBytesWriter_Alloc(_PyBytesWriter* writer, [NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* _PyBytesWriter_Prepare(_PyBytesWriter* writer, void* str, [NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* _PyBytesWriter_Resize(_PyBytesWriter* writer, void* str, [NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* _PyBytesWriter_WriteBytes(_PyBytesWriter* writer, void* str, [NativeTypeName("const void *")] void* bytes, [NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_FromStringAndSize([NativeTypeName("const char *")] sbyte* u, [NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_FromString([NativeTypeName("const char *")] sbyte* u);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_Substring([NativeTypeName("PyObject *")] _PyObject* str, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_UCS4 *")]
        public static extern uint* PyUnicode_AsUCS4([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("Py_UCS4 *")] uint* buffer, [NativeTypeName("Py_ssize_t")] long buflen, int copy_null);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_UCS4 *")]
        public static extern uint* PyUnicode_AsUCS4Copy([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyUnicode_GetLength([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        [Obsolete]
        public static extern long PyUnicode_GetSize([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_UCS4")]
        public static extern uint PyUnicode_ReadChar([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("Py_ssize_t")] long index);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicode_WriteChar([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("Py_ssize_t")] long index, [NativeTypeName("Py_UCS4")] uint character);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicode_Resize([NativeTypeName("PyObject **")] _PyObject** unicode, [NativeTypeName("Py_ssize_t")] long length);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_FromEncodedObject([NativeTypeName("PyObject *")] _PyObject* obj, [NativeTypeName("const char *")] sbyte* encoding, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_FromObject([NativeTypeName("PyObject *")] _PyObject* obj);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_FromFormatV([NativeTypeName("const char *")] sbyte* format, [NativeTypeName("va_list")] sbyte* vargs);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyUnicode_InternInPlace([NativeTypeName("PyObject **")] _PyObject** param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_InternFromString([NativeTypeName("const char *")] sbyte* u);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void PyUnicode_InternImmortal([NativeTypeName("PyObject **")] _PyObject** param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_FromWideChar([NativeTypeName("const wchar_t *")] ushort* w, [NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyUnicode_AsWideChar([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("wchar_t *")] ushort* w, [NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("wchar_t *")]
        public static extern ushort* PyUnicode_AsWideCharString([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("Py_ssize_t *")] long* size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_FromOrdinal(int ordinal);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* PyUnicode_GetDefaultEncoding();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_Decode([NativeTypeName("const char *")] sbyte* s, [NativeTypeName("Py_ssize_t")] long size, [NativeTypeName("const char *")] sbyte* encoding, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_AsDecodedObject([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("const char *")] sbyte* encoding, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_AsDecodedUnicode([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("const char *")] sbyte* encoding, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_AsEncodedObject([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("const char *")] sbyte* encoding, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_AsEncodedString([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("const char *")] sbyte* encoding, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_AsEncodedUnicode([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("const char *")] sbyte* encoding, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_BuildEncodingMap([NativeTypeName("PyObject *")] _PyObject* @string);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeUTF7([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeUTF7Stateful([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, [NativeTypeName("Py_ssize_t *")] long* consumed);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeUTF8([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeUTF8Stateful([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, [NativeTypeName("Py_ssize_t *")] long* consumed);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_AsUTF8String([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* PyUnicode_AsUTF8AndSize([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("Py_ssize_t *")] long* size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeUTF32([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, int* byteorder);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeUTF32Stateful([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, int* byteorder, [NativeTypeName("Py_ssize_t *")] long* consumed);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_AsUTF32String([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeUTF16([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, int* byteorder);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeUTF16Stateful([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, int* byteorder, [NativeTypeName("Py_ssize_t *")] long* consumed);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_AsUTF16String([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeUnicodeEscape([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_AsUnicodeEscapeString([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeRawUnicodeEscape([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_AsRawUnicodeEscapeString([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeLatin1([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_AsLatin1String([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeASCII([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_AsASCIIString([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeCharmap([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("PyObject *")] _PyObject* mapping, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_AsCharmapString([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("PyObject *")] _PyObject* mapping);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeMBCS([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeMBCSStateful([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, [NativeTypeName("Py_ssize_t *")] long* consumed);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeCodePageStateful(int code_page, [NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, [NativeTypeName("Py_ssize_t *")] long* consumed);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_AsMBCSString([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_EncodeCodePage(int code_page, [NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeLocaleAndSize([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("Py_ssize_t")] long len, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeLocale([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_EncodeLocale([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicode_FSConverter([NativeTypeName("PyObject *")] _PyObject* param0, void* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicode_FSDecoder([NativeTypeName("PyObject *")] _PyObject* param0, void* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeFSDefault([NativeTypeName("const char *")] sbyte* s);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_DecodeFSDefaultAndSize([NativeTypeName("const char *")] sbyte* s, [NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_EncodeFSDefault([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_Concat([NativeTypeName("PyObject *")] _PyObject* left, [NativeTypeName("PyObject *")] _PyObject* right);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyUnicode_Append([NativeTypeName("PyObject **")] _PyObject** pleft, [NativeTypeName("PyObject *")] _PyObject* right);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyUnicode_AppendAndDel([NativeTypeName("PyObject **")] _PyObject** pleft, [NativeTypeName("PyObject *")] _PyObject* right);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_Split([NativeTypeName("PyObject *")] _PyObject* s, [NativeTypeName("PyObject *")] _PyObject* sep, [NativeTypeName("Py_ssize_t")] long maxsplit);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_Splitlines([NativeTypeName("PyObject *")] _PyObject* s, int keepends);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_Partition([NativeTypeName("PyObject *")] _PyObject* s, [NativeTypeName("PyObject *")] _PyObject* sep);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_RPartition([NativeTypeName("PyObject *")] _PyObject* s, [NativeTypeName("PyObject *")] _PyObject* sep);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_RSplit([NativeTypeName("PyObject *")] _PyObject* s, [NativeTypeName("PyObject *")] _PyObject* sep, [NativeTypeName("Py_ssize_t")] long maxsplit);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_Translate([NativeTypeName("PyObject *")] _PyObject* str, [NativeTypeName("PyObject *")] _PyObject* table, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_Join([NativeTypeName("PyObject *")] _PyObject* separator, [NativeTypeName("PyObject *")] _PyObject* seq);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyUnicode_Tailmatch([NativeTypeName("PyObject *")] _PyObject* str, [NativeTypeName("PyObject *")] _PyObject* substr, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end, int direction);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyUnicode_Find([NativeTypeName("PyObject *")] _PyObject* str, [NativeTypeName("PyObject *")] _PyObject* substr, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end, int direction);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyUnicode_FindChar([NativeTypeName("PyObject *")] _PyObject* str, [NativeTypeName("Py_UCS4")] uint ch, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end, int direction);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyUnicode_Count([NativeTypeName("PyObject *")] _PyObject* str, [NativeTypeName("PyObject *")] _PyObject* substr, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_Replace([NativeTypeName("PyObject *")] _PyObject* str, [NativeTypeName("PyObject *")] _PyObject* substr, [NativeTypeName("PyObject *")] _PyObject* replstr, [NativeTypeName("Py_ssize_t")] long maxcount);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicode_Compare([NativeTypeName("PyObject *")] _PyObject* left, [NativeTypeName("PyObject *")] _PyObject* right);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicode_CompareWithASCIIString([NativeTypeName("PyObject *")] _PyObject* left, [NativeTypeName("const char *")] sbyte* right);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_RichCompare([NativeTypeName("PyObject *")] _PyObject* left, [NativeTypeName("PyObject *")] _PyObject* right, int op);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_Format([NativeTypeName("PyObject *")] _PyObject* format, [NativeTypeName("PyObject *")] _PyObject* args);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicode_Contains([NativeTypeName("PyObject *")] _PyObject* container, [NativeTypeName("PyObject *")] _PyObject* element);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicode_IsIdentifier([NativeTypeName("PyObject *")] _PyObject* s);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_CheckConsistency([NativeTypeName("PyObject *")] _PyObject* op, int check_content);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_New([NativeTypeName("Py_ssize_t")] long size, [NativeTypeName("Py_UCS4")] uint maxchar);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_Ready([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_Copy([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyUnicode_CopyCharacters([NativeTypeName("PyObject *")] _PyObject* to, [NativeTypeName("Py_ssize_t")] long to_start, [NativeTypeName("PyObject *")] _PyObject* from, [NativeTypeName("Py_ssize_t")] long from_start, [NativeTypeName("Py_ssize_t")] long how_many);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyUnicode_FastCopyCharacters([NativeTypeName("PyObject *")] _PyObject* to, [NativeTypeName("Py_ssize_t")] long to_start, [NativeTypeName("PyObject *")] _PyObject* from, [NativeTypeName("Py_ssize_t")] long from_start, [NativeTypeName("Py_ssize_t")] long how_many);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyUnicode_Fill([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("Py_UCS4")] uint fill_char);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyUnicode_FastFill([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("Py_UCS4")] uint fill_char);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_FromUnicode([NativeTypeName("const Py_UNICODE *")] ushort* u, [NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicode_FromKindAndData(int kind, [NativeTypeName("const void *")] void* buffer, [NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_FromASCII([NativeTypeName("const char *")] sbyte* buffer, [NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_UCS4")]
        public static extern uint _PyUnicode_FindMaxChar([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_UNICODE *")]
        [Obsolete]
        public static extern ushort* PyUnicode_AsUnicode([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const Py_UNICODE *")]
        public static extern ushort* _PyUnicode_AsUnicode([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_UNICODE *")]
        [Obsolete]
        public static extern ushort* PyUnicode_AsUnicodeAndSize([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("Py_ssize_t *")] long* size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyUnicodeWriter_Init(_PyUnicodeWriter* writer);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicodeWriter_PrepareInternal(_PyUnicodeWriter* writer, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("Py_UCS4")] uint maxchar);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicodeWriter_PrepareKindInternal(_PyUnicodeWriter* writer, [NativeTypeName("enum PyUnicode_Kind")] PyUnicode_Kind kind);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicodeWriter_WriteChar(_PyUnicodeWriter* writer, [NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicodeWriter_WriteStr(_PyUnicodeWriter* writer, [NativeTypeName("PyObject *")] _PyObject* str);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicodeWriter_WriteSubstring(_PyUnicodeWriter* writer, [NativeTypeName("PyObject *")] _PyObject* str, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicodeWriter_WriteASCIIString(_PyUnicodeWriter* writer, [NativeTypeName("const char *")] sbyte* str, [NativeTypeName("Py_ssize_t")] long len);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicodeWriter_WriteLatin1String(_PyUnicodeWriter* writer, [NativeTypeName("const char *")] sbyte* str, [NativeTypeName("Py_ssize_t")] long len);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicodeWriter_Finish(_PyUnicodeWriter* writer);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyUnicodeWriter_Dealloc(_PyUnicodeWriter* writer);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_FormatAdvancedWriter(_PyUnicodeWriter* writer, [NativeTypeName("PyObject *")] _PyObject* obj, [NativeTypeName("PyObject *")] _PyObject* format_spec, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* PyUnicode_AsUTF8([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_Encode([NativeTypeName("const Py_UNICODE *")] ushort* s, [NativeTypeName("Py_ssize_t")] long size, [NativeTypeName("const char *")] sbyte* encoding, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_EncodeUTF7([NativeTypeName("const Py_UNICODE *")] ushort* data, [NativeTypeName("Py_ssize_t")] long length, int base64SetO, int base64WhiteSpace, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_EncodeUTF7([NativeTypeName("PyObject *")] _PyObject* unicode, int base64SetO, int base64WhiteSpace, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_AsUTF8String([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_EncodeUTF8([NativeTypeName("const Py_UNICODE *")] ushort* data, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_EncodeUTF32([NativeTypeName("const Py_UNICODE *")] ushort* data, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, int byteorder);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_EncodeUTF32([NativeTypeName("PyObject *")] _PyObject* @object, [NativeTypeName("const char *")] sbyte* errors, int byteorder);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_EncodeUTF16([NativeTypeName("const Py_UNICODE *")] ushort* data, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, int byteorder);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_EncodeUTF16([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("const char *")] sbyte* errors, int byteorder);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_DecodeUnicodeEscapeStateful([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, [NativeTypeName("Py_ssize_t *")] long* consumed);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_DecodeUnicodeEscapeInternal([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, [NativeTypeName("Py_ssize_t *")] long* consumed, [NativeTypeName("const char **")] sbyte** first_invalid_escape);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_EncodeUnicodeEscape([NativeTypeName("const Py_UNICODE *")] ushort* data, [NativeTypeName("Py_ssize_t")] long length);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_EncodeRawUnicodeEscape([NativeTypeName("const Py_UNICODE *")] ushort* data, [NativeTypeName("Py_ssize_t")] long length);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_DecodeRawUnicodeEscapeStateful([NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors, [NativeTypeName("Py_ssize_t *")] long* consumed);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_AsLatin1String([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_EncodeLatin1([NativeTypeName("const Py_UNICODE *")] ushort* data, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_AsASCIIString([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_EncodeASCII([NativeTypeName("const Py_UNICODE *")] ushort* data, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_EncodeCharmap([NativeTypeName("const Py_UNICODE *")] ushort* data, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("PyObject *")] _PyObject* mapping, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_EncodeCharmap([NativeTypeName("PyObject *")] _PyObject* unicode, [NativeTypeName("PyObject *")] _PyObject* mapping, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_TranslateCharmap([NativeTypeName("const Py_UNICODE *")] ushort* data, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("PyObject *")] _PyObject* table, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_EncodeMBCS([NativeTypeName("const Py_UNICODE *")] ushort* data, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int PyUnicode_EncodeDecimal([NativeTypeName("Py_UNICODE *")] ushort* s, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("char *")] sbyte* output, [NativeTypeName("const char *")] sbyte* errors);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyUnicode_TransformDecimalToASCII([NativeTypeName("Py_UNICODE *")] ushort* s, [NativeTypeName("Py_ssize_t")] long length);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_TransformDecimalAndSpaceToASCII([NativeTypeName("PyObject *")] _PyObject* unicode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_JoinArray([NativeTypeName("PyObject *")] _PyObject* separator, [NativeTypeName("PyObject *const *")] _PyObject** items, [NativeTypeName("Py_ssize_t")] long seqlen);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_EqualToASCIIId([NativeTypeName("PyObject *")] _PyObject* left, _Py_Identifier* right);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_EqualToASCIIString([NativeTypeName("PyObject *")] _PyObject* left, [NativeTypeName("const char *")] sbyte* right);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_XStrip([NativeTypeName("PyObject *")] _PyObject* self, int striptype, [NativeTypeName("PyObject *")] _PyObject* sepobj);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long _PyUnicode_InsertThousandsGrouping(_PyUnicodeWriter* writer, [NativeTypeName("Py_ssize_t")] long n_buffer, [NativeTypeName("PyObject *")] _PyObject* digits, [NativeTypeName("Py_ssize_t")] long d_pos, [NativeTypeName("Py_ssize_t")] long n_digits, [NativeTypeName("Py_ssize_t")] long min_width, [NativeTypeName("const char *")] sbyte* grouping, [NativeTypeName("PyObject *")] _PyObject* thousands_sep, [NativeTypeName("Py_UCS4 *")] uint* maxchar);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsLowercase([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsUppercase([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsTitlecase([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsXidStart([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsXidContinue([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsWhitespace([NativeTypeName("const Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsLinebreak([NativeTypeName("const Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_UCS4")]
        public static extern uint _PyUnicode_ToLowercase([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_UCS4")]
        public static extern uint _PyUnicode_ToUppercase([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_UCS4")]
        [Obsolete]
        public static extern uint _PyUnicode_ToTitlecase([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_ToLowerFull([NativeTypeName("Py_UCS4")] uint ch, [NativeTypeName("Py_UCS4 *")] uint* res);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_ToTitleFull([NativeTypeName("Py_UCS4")] uint ch, [NativeTypeName("Py_UCS4 *")] uint* res);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_ToUpperFull([NativeTypeName("Py_UCS4")] uint ch, [NativeTypeName("Py_UCS4 *")] uint* res);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_ToFoldedFull([NativeTypeName("Py_UCS4")] uint ch, [NativeTypeName("Py_UCS4 *")] uint* res);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsCaseIgnorable([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsCased([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_ToDecimalDigit([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_ToDigit([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double _PyUnicode_ToNumeric([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsDecimalDigit([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsDigit([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsNumeric([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsPrintable([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_IsAlpha([NativeTypeName("Py_UCS4")] uint ch);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_FormatLong([NativeTypeName("PyObject *")] _PyObject* param0, int param1, int param2, int param3);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyUnicode_FromId(_Py_Identifier* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_EQ([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_WideCharString_Converter([NativeTypeName("PyObject *")] _PyObject* param0, void* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyUnicode_WideCharString_Opt_Converter([NativeTypeName("PyObject *")] _PyObject* param0, void* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long _PyUnicode_ScanIdentifier([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyLong_FromLong([NativeTypeName("long")] int param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyLong_FromUnsignedLong([NativeTypeName("unsigned long")] uint param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyLong_FromSize_t([NativeTypeName("size_t")] nuint param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyLong_FromSsize_t([NativeTypeName("Py_ssize_t")] long param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyLong_FromDouble(double param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("long")]
        public static extern int PyLong_AsLong([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("long")]
        public static extern int PyLong_AsLongAndOverflow([NativeTypeName("PyObject *")] _PyObject* param0, int* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyLong_AsSsize_t([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint PyLong_AsSize_t([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned long")]
        public static extern uint PyLong_AsUnsignedLong([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned long")]
        public static extern uint PyLong_AsUnsignedLongMask([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyLong_AsInt([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyLong_GetInfo();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyLong_UnsignedShort_Converter([NativeTypeName("PyObject *")] _PyObject* param0, void* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyLong_UnsignedInt_Converter([NativeTypeName("PyObject *")] _PyObject* param0, void* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyLong_UnsignedLong_Converter([NativeTypeName("PyObject *")] _PyObject* param0, void* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyLong_UnsignedLongLong_Converter([NativeTypeName("PyObject *")] _PyObject* param0, void* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyLong_Size_t_Converter([NativeTypeName("PyObject *")] _PyObject* param0, void* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double _PyLong_Frexp([NativeTypeName("PyLongObject *")] _longobject* a, [NativeTypeName("Py_ssize_t *")] long* e);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double PyLong_AsDouble([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyLong_FromVoidPtr(void* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* PyLong_AsVoidPtr([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyLong_FromLongLong([NativeTypeName("long long")] long param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyLong_FromUnsignedLongLong([NativeTypeName("unsigned long long")] ulong param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("long long")]
        public static extern long PyLong_AsLongLong([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong PyLong_AsUnsignedLongLong([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong PyLong_AsUnsignedLongLongMask([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("long long")]
        public static extern long PyLong_AsLongLongAndOverflow([NativeTypeName("PyObject *")] _PyObject* param0, int* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyLong_FromString([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("char **")] sbyte** param1, int param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyLong_FromUnicodeObject([NativeTypeName("PyObject *")] _PyObject* u, int @base);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyLong_FromBytes([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("Py_ssize_t")] long param1, int param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyLong_Sign([NativeTypeName("PyObject *")] _PyObject* v);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint _PyLong_NumBits([NativeTypeName("PyObject *")] _PyObject* v);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyLong_DivmodNear([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyLong_FromByteArray([NativeTypeName("const unsigned char *")] byte* bytes, [NativeTypeName("size_t")] nuint n, int little_endian, int is_signed);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyLong_AsByteArray([NativeTypeName("PyLongObject *")] _longobject* v, [NativeTypeName("unsigned char *")] byte* bytes, [NativeTypeName("size_t")] nuint n, int little_endian, int is_signed);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyLong_Format([NativeTypeName("PyObject *")] _PyObject* obj, int @base);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyLong_FormatWriter(_PyUnicodeWriter* writer, [NativeTypeName("PyObject *")] _PyObject* obj, int @base, int alternate);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* _PyLong_FormatBytesWriter(_PyBytesWriter* writer, [NativeTypeName("char *")] sbyte* str, [NativeTypeName("PyObject *")] _PyObject* obj, int @base, int alternate);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyLong_FormatAdvancedWriter(_PyUnicodeWriter* writer, [NativeTypeName("PyObject *")] _PyObject* obj, [NativeTypeName("PyObject *")] _PyObject* format_spec, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned long")]
        public static extern uint PyOS_strtoul([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("char **")] sbyte** param1, int param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("long")]
        public static extern int PyOS_strtol([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("char **")] sbyte** param1, int param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyLong_GCD([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyLong_Rshift([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("size_t")] nuint param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyLong_Lshift([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("size_t")] nuint param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyLongObject *")]
        public static extern _longobject* _PyLong_New([NativeTypeName("Py_ssize_t")] long param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyLong_Copy([NativeTypeName("PyLongObject *")] _longobject* src);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_IsTrue([NativeTypeName("PyObject *")] _PyObject* x);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_IsFalse([NativeTypeName("PyObject *")] _PyObject* x);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyBool_FromLong([NativeTypeName("long")] int param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double PyFloat_GetMax();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double PyFloat_GetMin();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFloat_GetInfo();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFloat_FromString([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFloat_FromDouble(double param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double PyFloat_AsDouble([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyFloat_Pack2(double x, [NativeTypeName("unsigned char *")] byte* p, int le);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyFloat_Pack4(double x, [NativeTypeName("unsigned char *")] byte* p, int le);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyFloat_Pack8(double x, [NativeTypeName("unsigned char *")] byte* p, int le);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double _PyFloat_Unpack2([NativeTypeName("const unsigned char *")] byte* p, int le);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double _PyFloat_Unpack4([NativeTypeName("const unsigned char *")] byte* p, int le);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double _PyFloat_Unpack8([NativeTypeName("const unsigned char *")] byte* p, int le);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyFloat_DebugMallocStats([NativeTypeName("FILE *")] _iobuf* @out);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyFloat_FormatAdvancedWriter(_PyUnicodeWriter* writer, [NativeTypeName("PyObject *")] _PyObject* obj, [NativeTypeName("PyObject *")] _PyObject* format_spec, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Py_complex _Py_c_sum(Py_complex param0, Py_complex param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Py_complex _Py_c_diff(Py_complex param0, Py_complex param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Py_complex _Py_c_neg(Py_complex param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Py_complex _Py_c_prod(Py_complex param0, Py_complex param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Py_complex _Py_c_quot(Py_complex param0, Py_complex param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Py_complex _Py_c_pow(Py_complex param0, Py_complex param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double _Py_c_abs(Py_complex param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyComplex_FromCComplex(Py_complex param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyComplex_FromDoubles(double real, double imag);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double PyComplex_RealAsDouble([NativeTypeName("PyObject *")] _PyObject* op);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double PyComplex_ImagAsDouble([NativeTypeName("PyObject *")] _PyObject* op);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Py_complex PyComplex_AsCComplex([NativeTypeName("PyObject *")] _PyObject* op);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyComplex_FormatAdvancedWriter(_PyUnicodeWriter* writer, [NativeTypeName("PyObject *")] _PyObject* obj, [NativeTypeName("PyObject *")] _PyObject* format_spec, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyMemoryView_FromObject([NativeTypeName("PyObject *")] _PyObject* @base);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyMemoryView_FromMemory([NativeTypeName("char *")] sbyte* mem, [NativeTypeName("Py_ssize_t")] long size, int flags);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyMemoryView_FromBuffer([NativeTypeName("Py_buffer *")] _PyBufferInfo* info);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyMemoryView_GetContiguous([NativeTypeName("PyObject *")] _PyObject* @base, int buffertype, [NativeTypeName("char")] sbyte order);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyTuple_New([NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyTuple_Size([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyTuple_GetItem([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyTuple_SetItem([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyTuple_GetSlice([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1, [NativeTypeName("Py_ssize_t")] long param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyList_New([NativeTypeName("Py_ssize_t")] long size);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyList_Size([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyList_GetItem([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyList_SetItem([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyList_Insert([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyList_Append([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyList_GetSlice([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1, [NativeTypeName("Py_ssize_t")] long param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyList_SetSlice([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1, [NativeTypeName("Py_ssize_t")] long param2, [NativeTypeName("PyObject *")] _PyObject* param3);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyList_Sort([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyList_Reverse([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyList_AsTuple([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDict_New();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDict_GetItem([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDict_GetItemWithError([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyDict_SetItem([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* key, [NativeTypeName("PyObject *")] _PyObject* item);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyDict_DelItem([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyDict_Clear([NativeTypeName("PyObject *")] _PyObject* mp);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyDict_Next([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("Py_ssize_t *")] long* pos, [NativeTypeName("PyObject **")] _PyObject** key, [NativeTypeName("PyObject **")] _PyObject** value);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDict_Keys([NativeTypeName("PyObject *")] _PyObject* mp);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDict_Values([NativeTypeName("PyObject *")] _PyObject* mp);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDict_Items([NativeTypeName("PyObject *")] _PyObject* mp);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyDict_Size([NativeTypeName("PyObject *")] _PyObject* mp);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDict_Copy([NativeTypeName("PyObject *")] _PyObject* mp);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyDict_Contains([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyDict_Update([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* other);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyDict_Merge([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* other, int @override);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyDict_MergeFromSeq2([NativeTypeName("PyObject *")] _PyObject* d, [NativeTypeName("PyObject *")] _PyObject* seq2, int @override);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDict_GetItemString([NativeTypeName("PyObject *")] _PyObject* dp, [NativeTypeName("const char *")] sbyte* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyDict_SetItemString([NativeTypeName("PyObject *")] _PyObject* dp, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("PyObject *")] _PyObject* item);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyDict_DelItemString([NativeTypeName("PyObject *")] _PyObject* dp, [NativeTypeName("const char *")] sbyte* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_GenericGetDict([NativeTypeName("PyObject *")] _PyObject* param0, void* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyDict_GetItem_KnownHash([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* key, [NativeTypeName("Py_hash_t")] long hash);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyDict_GetItemIdWithError([NativeTypeName("PyObject *")] _PyObject* dp, [NativeTypeName("struct _Py_Identifier *")] _Py_Identifier* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyDict_GetItemStringWithError([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("const char *")] sbyte* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDict_SetDefault([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* key, [NativeTypeName("PyObject *")] _PyObject* defaultobj);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyDict_SetItem_KnownHash([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* key, [NativeTypeName("PyObject *")] _PyObject* item, [NativeTypeName("Py_hash_t")] long hash);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyDict_DelItem_KnownHash([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* key, [NativeTypeName("Py_hash_t")] long hash);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyDict_DelItemIf([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* key, [NativeTypeName("int (*)(PyObject *)")] delegate* unmanaged[Cdecl]<_PyObject*, int> predicate);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyDict_Next([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("Py_ssize_t *")] long* pos, [NativeTypeName("PyObject **")] _PyObject** key, [NativeTypeName("PyObject **")] _PyObject** value, [NativeTypeName("Py_hash_t *")] long* hash);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyDict_Contains_KnownHash([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("Py_hash_t")] long param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyDict_ContainsId([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("struct _Py_Identifier *")] _Py_Identifier* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyDict_NewPresized([NativeTypeName("Py_ssize_t")] long minused);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyDict_MaybeUntrack([NativeTypeName("PyObject *")] _PyObject* mp);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyDict_HasOnlyStringKeys([NativeTypeName("PyObject *")] _PyObject* mp);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long _PyDict_SizeOf(PyDictObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyDict_Pop([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyDict_MergeEx([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("PyObject *")] _PyObject* other, int @override);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyDict_SetItemId([NativeTypeName("PyObject *")] _PyObject* dp, [NativeTypeName("struct _Py_Identifier *")] _Py_Identifier* key, [NativeTypeName("PyObject *")] _PyObject* item);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyDict_DelItemId([NativeTypeName("PyObject *")] _PyObject* mp, [NativeTypeName("struct _Py_Identifier *")] _Py_Identifier* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyDict_DebugMallocStats([NativeTypeName("FILE *")] _iobuf* @out);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyDictView_New([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyTypeObject *")] _PyTypeObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyDictView_Intersect([NativeTypeName("PyObject *")] _PyObject* self, [NativeTypeName("PyObject *")] _PyObject* other);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PySet_NextEntry([NativeTypeName("PyObject *")] _PyObject* set, [NativeTypeName("Py_ssize_t *")] long* pos, [NativeTypeName("PyObject **")] _PyObject** key, [NativeTypeName("Py_hash_t *")] long* hash);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PySet_Update([NativeTypeName("PyObject *")] _PyObject* set, [NativeTypeName("PyObject *")] _PyObject* iterable);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySet_New([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFrozenSet_New([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySet_Add([NativeTypeName("PyObject *")] _PyObject* set, [NativeTypeName("PyObject *")] _PyObject* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySet_Clear([NativeTypeName("PyObject *")] _PyObject* set);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySet_Contains([NativeTypeName("PyObject *")] _PyObject* anyset, [NativeTypeName("PyObject *")] _PyObject* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySet_Discard([NativeTypeName("PyObject *")] _PyObject* set, [NativeTypeName("PyObject *")] _PyObject* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySet_Pop([NativeTypeName("PyObject *")] _PyObject* set);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PySet_Size([NativeTypeName("PyObject *")] _PyObject* anyset);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyCFunction")]
        public static extern delegate* unmanaged[Cdecl]<_PyObject*, _PyObject*, _PyObject*> PyCFunction_GetFunction([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyCFunction_GetSelf([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyCFunction_GetFlags([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyCFunction_Call([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyCFunction_New(PyMethodDef* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyCFunction_NewEx(PyMethodDef* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyCMethod_New(PyMethodDef* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2, [NativeTypeName("PyTypeObject *")] _PyTypeObject* param3);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyModule_NewObject([NativeTypeName("PyObject *")] _PyObject* name);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyModule_New([NativeTypeName("const char *")] sbyte* name);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyModule_GetDict([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyModule_GetNameObject([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* PyModule_GetName([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        [Obsolete]
        public static extern sbyte* PyModule_GetFilename([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyModule_GetFilenameObject([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyModule_Clear([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyModule_ClearDict([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyModuleSpec_IsInitializing([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct PyModuleDef *")]
        public static extern PyModuleDef* PyModule_GetDef([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* PyModule_GetState([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyModuleDef_Init([NativeTypeName("struct PyModuleDef *")] PyModuleDef* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFunction_New([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFunction_NewWithQualName([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFunction_GetCode([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFunction_GetGlobals([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFunction_GetModule([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFunction_GetDefaults([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyFunction_SetDefaults([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFunction_GetKwDefaults([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyFunction_SetKwDefaults([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFunction_GetClosure([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyFunction_SetClosure([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFunction_GetAnnotations([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyFunction_SetAnnotations([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyFunction_Vectorcall([NativeTypeName("PyObject *")] _PyObject* func, [NativeTypeName("PyObject *const *")] _PyObject** stack, [NativeTypeName("size_t")] nuint nargsf, [NativeTypeName("PyObject *")] _PyObject* kwnames);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyClassMethod_New([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyStaticMethod_New([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyMethod_New([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyMethod_Function([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyMethod_Self([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyInstanceMethod_New([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyInstanceMethod_Function([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFile_FromFd(int param0, [NativeTypeName("const char *")] sbyte* param1, [NativeTypeName("const char *")] sbyte* param2, int param3, [NativeTypeName("const char *")] sbyte* param4, [NativeTypeName("const char *")] sbyte* param5, [NativeTypeName("const char *")] sbyte* param6, int param7);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyFile_GetLine([NativeTypeName("PyObject *")] _PyObject* param0, int param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyFile_WriteObject([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, int param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyFile_WriteString([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_AsFileDescriptor([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyCodeObject* PyCode_New(int param0, int param1, int param2, int param3, int param4, [NativeTypeName("PyObject *")] _PyObject* param5, [NativeTypeName("PyObject *")] _PyObject* param6, [NativeTypeName("PyObject *")] _PyObject* param7, [NativeTypeName("PyObject *")] _PyObject* param8, [NativeTypeName("PyObject *")] _PyObject* param9, [NativeTypeName("PyObject *")] _PyObject* param10, [NativeTypeName("PyObject *")] _PyObject* param11, [NativeTypeName("PyObject *")] _PyObject* param12, int param13, [NativeTypeName("PyObject *")] _PyObject* param14);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyCodeObject* PyCode_NewWithPosOnlyArgs(int param0, int param1, int param2, int param3, int param4, int param5, [NativeTypeName("PyObject *")] _PyObject* param6, [NativeTypeName("PyObject *")] _PyObject* param7, [NativeTypeName("PyObject *")] _PyObject* param8, [NativeTypeName("PyObject *")] _PyObject* param9, [NativeTypeName("PyObject *")] _PyObject* param10, [NativeTypeName("PyObject *")] _PyObject* param11, [NativeTypeName("PyObject *")] _PyObject* param12, [NativeTypeName("PyObject *")] _PyObject* param13, int param14, [NativeTypeName("PyObject *")] _PyObject* param15);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyCodeObject* PyCode_NewEmpty([NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("const char *")] sbyte* funcname, int firstlineno);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyCode_Addr2Line(PyCodeObject* param0, int param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyCode_CheckLineNumber(int lasti, [NativeTypeName("PyCodeAddressRange *")] _line_offsets* bounds);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyCode_ConstantKey([NativeTypeName("PyObject *")] _PyObject* obj);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyCode_Optimize([NativeTypeName("PyObject *")] _PyObject* code, [NativeTypeName("PyObject *")] _PyObject* consts, [NativeTypeName("PyObject *")] _PyObject* names, [NativeTypeName("PyObject *")] _PyObject* lnotab);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyCode_GetExtra([NativeTypeName("PyObject *")] _PyObject* code, [NativeTypeName("Py_ssize_t")] long index, void** extra);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyCode_SetExtra([NativeTypeName("PyObject *")] _PyObject* code, [NativeTypeName("Py_ssize_t")] long index, void* extra);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyFrame_GetLineNumber([NativeTypeName("PyFrameObject *")] _frame* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyCodeObject* PyFrame_GetCode([NativeTypeName("PyFrameObject *")] _frame* frame);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySlice_New([NativeTypeName("PyObject *")] _PyObject* start, [NativeTypeName("PyObject *")] _PyObject* stop, [NativeTypeName("PyObject *")] _PyObject* step);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PySlice_FromIndices([NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long stop);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PySlice_GetLongIndices(PySliceObject* self, [NativeTypeName("PyObject *")] _PyObject* length, [NativeTypeName("PyObject **")] _PyObject** start_ptr, [NativeTypeName("PyObject **")] _PyObject** stop_ptr, [NativeTypeName("PyObject **")] _PyObject** step_ptr);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySlice_GetIndices([NativeTypeName("PyObject *")] _PyObject* r, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("Py_ssize_t *")] long* start, [NativeTypeName("Py_ssize_t *")] long* stop, [NativeTypeName("Py_ssize_t *")] long* step);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int PySlice_GetIndicesEx([NativeTypeName("PyObject *")] _PyObject* r, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("Py_ssize_t *")] long* start, [NativeTypeName("Py_ssize_t *")] long* stop, [NativeTypeName("Py_ssize_t *")] long* step, [NativeTypeName("Py_ssize_t *")] long* slicelength);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySlice_Unpack([NativeTypeName("PyObject *")] _PyObject* slice, [NativeTypeName("Py_ssize_t *")] long* start, [NativeTypeName("Py_ssize_t *")] long* stop, [NativeTypeName("Py_ssize_t *")] long* step);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PySlice_AdjustIndices([NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("Py_ssize_t *")] long* start, [NativeTypeName("Py_ssize_t *")] long* stop, [NativeTypeName("Py_ssize_t")] long step);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyCell_New([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyCell_Get([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyCell_Set([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySeqIter_New([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyCallIter_New([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyStatus_Ok();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyStatus_Error([NativeTypeName("const char *")] sbyte* err_msg);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyStatus_NoMemory();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyStatus_Exit(int exitcode);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyStatus_IsError(PyStatus err);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyStatus_IsExit(PyStatus err);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyStatus_Exception(PyStatus err);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyWideStringList_Append(PyWideStringList* list, [NativeTypeName("const wchar_t *")] ushort* item);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyWideStringList_Insert(PyWideStringList* list, [NativeTypeName("Py_ssize_t")] long index, [NativeTypeName("const wchar_t *")] ushort* item);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyPreConfig_InitPythonConfig(PyPreConfig* config);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyPreConfig_InitIsolatedConfig(PyPreConfig* config);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyConfig_InitPythonConfig(PyConfig* config);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyConfig_InitIsolatedConfig(PyConfig* config);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyConfig_Clear(PyConfig* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyConfig_SetString(PyConfig* config, [NativeTypeName("wchar_t **")] ushort** config_str, [NativeTypeName("const wchar_t *")] ushort* str);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyConfig_SetBytesString(PyConfig* config, [NativeTypeName("wchar_t **")] ushort** config_str, [NativeTypeName("const char *")] sbyte* str);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyConfig_Read(PyConfig* config);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyConfig_SetBytesArgv(PyConfig* config, [NativeTypeName("Py_ssize_t")] long argc, [NativeTypeName("char *const *")] sbyte** argv);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyConfig_SetArgv(PyConfig* config, [NativeTypeName("Py_ssize_t")] long argc, [NativeTypeName("wchar_t *const *")] ushort** argv);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyStatus PyConfig_SetWideStringList(PyConfig* config, PyWideStringList* list, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("wchar_t **")] ushort** items);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_GetArgcArgv(int* argc, [NativeTypeName("wchar_t ***")] ushort*** argv);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyInterpreterState *")]
        public static extern _PyInterpreterState* PyInterpreterState_New();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyInterpreterState_Clear([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyInterpreterState_Delete([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyInterpreterState *")]
        public static extern _PyInterpreterState* PyInterpreterState_Get();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyInterpreterState_GetDict([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int64_t")]
        public static extern long PyInterpreterState_GetID([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyState_AddModule([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("struct PyModuleDef *")] PyModuleDef* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyState_RemoveModule([NativeTypeName("struct PyModuleDef *")] PyModuleDef* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyState_FindModule([NativeTypeName("struct PyModuleDef *")] PyModuleDef* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyThreadState *")]
        public static extern _PyThreadState* PyThreadState_New([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyThreadState_Clear([NativeTypeName("PyThreadState *")] _PyThreadState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyThreadState_Delete([NativeTypeName("PyThreadState *")] _PyThreadState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyThreadState *")]
        public static extern _PyThreadState* PyThreadState_Get();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyThreadState *")]
        public static extern _PyThreadState* PyThreadState_Swap([NativeTypeName("PyThreadState *")] _PyThreadState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyThreadState_GetDict();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyThreadState_SetAsyncExc([NativeTypeName("unsigned long")] uint param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyInterpreterState *")]
        public static extern _PyInterpreterState* PyThreadState_GetInterpreter([NativeTypeName("PyThreadState *")] _PyThreadState* tstate);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyFrameObject *")]
        public static extern _frame* PyThreadState_GetFrame([NativeTypeName("PyThreadState *")] _PyThreadState* tstate);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong PyThreadState_GetID([NativeTypeName("PyThreadState *")] _PyThreadState* tstate);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyGILState_STATE PyGILState_Ensure();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyGILState_Release(PyGILState_STATE param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyThreadState *")]
        public static extern _PyThreadState* PyGILState_GetThisThreadState();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyInterpreterState_RequiresIDRef([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyInterpreterState_RequireIDRef([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* param0, int param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyInterpreterState_GetMainModule([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyThreadState *")]
        public static extern _PyThreadState* _PyThreadState_Prealloc([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyThreadState *")]
        public static extern _PyThreadState* _PyThreadState_UncheckedGet();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyThreadState_GetDict([NativeTypeName("PyThreadState *")] _PyThreadState* tstate);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyGILState_Check();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyInterpreterState *")]
        public static extern _PyInterpreterState* _PyGILState_GetInterpreterStateUnsafe();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyThread_CurrentFrames();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyThread_CurrentExceptions();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyInterpreterState *")]
        public static extern _PyInterpreterState* PyInterpreterState_Main();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyInterpreterState *")]
        public static extern _PyInterpreterState* PyInterpreterState_Head();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyInterpreterState *")]
        public static extern _PyInterpreterState* PyInterpreterState_Next([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyThreadState *")]
        public static extern _PyThreadState* PyInterpreterState_ThreadHead([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyThreadState *")]
        public static extern _PyThreadState* PyThreadState_Next([NativeTypeName("PyThreadState *")] _PyThreadState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyThreadState_DeleteCurrent();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("_PyFrameEvalFunction")]
        public static extern delegate* unmanaged[Cdecl]<_PyThreadState*, _frame*, int, _PyObject*> _PyInterpreterState_GetEvalFrameFunc([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* interp);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyInterpreterState_SetEvalFrameFunc([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* interp, [NativeTypeName("_PyFrameEvalFunction")] delegate* unmanaged[Cdecl]<_PyThreadState*, _frame*, int, _PyObject*> eval_frame);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const PyConfig *")]
        public static extern PyConfig* _PyInterpreterState_GetConfig([NativeTypeName("PyInterpreterState *")] _PyInterpreterState* interp);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyInterpreterState_GetConfigCopy([NativeTypeName("struct PyConfig *")] PyConfig* config);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyInterpreterState_SetConfig([NativeTypeName("const struct PyConfig *")] PyConfig* config);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const PyConfig *")]
        public static extern PyConfig* _Py_GetConfig();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyObject_GetCrossInterpreterData([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("_PyCrossInterpreterData *")] _xid* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyCrossInterpreterData_NewObject([NativeTypeName("_PyCrossInterpreterData *")] _xid* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyCrossInterpreterData_Release([NativeTypeName("_PyCrossInterpreterData *")] _xid* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyObject_CheckCrossInterpreterData([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyCrossInterpreterData_RegisterClass([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, [NativeTypeName("crossinterpdatafunc")] delegate* unmanaged[Cdecl]<_PyObject*, _xid*, int> param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("crossinterpdatafunc")]
        public static extern delegate* unmanaged[Cdecl]<_PyObject*, _xid*, int> _PyCrossInterpreterData_Lookup([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_CallNoArgs([NativeTypeName("PyObject *")] _PyObject* func);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_Call([NativeTypeName("PyObject *")] _PyObject* callable, [NativeTypeName("PyObject *")] _PyObject* args, [NativeTypeName("PyObject *")] _PyObject* kwargs);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_CallObject([NativeTypeName("PyObject *")] _PyObject* callable, [NativeTypeName("PyObject *")] _PyObject* args);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_Type([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyObject_Size([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_GetItem([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("PyObject *")] _PyObject* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_SetItem([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("PyObject *")] _PyObject* key, [NativeTypeName("PyObject *")] _PyObject* v);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_DelItemString([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("const char *")] sbyte* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_DelItem([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("PyObject *")] _PyObject* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int PyObject_AsCharBuffer([NativeTypeName("PyObject *")] _PyObject* obj, [NativeTypeName("const char **")] sbyte** buffer, [NativeTypeName("Py_ssize_t *")] long* buffer_len);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int PyObject_CheckReadBuffer([NativeTypeName("PyObject *")] _PyObject* obj);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int PyObject_AsReadBuffer([NativeTypeName("PyObject *")] _PyObject* obj, [NativeTypeName("const void **")] void** buffer, [NativeTypeName("Py_ssize_t *")] long* buffer_len);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int PyObject_AsWriteBuffer([NativeTypeName("PyObject *")] _PyObject* obj, void** buffer, [NativeTypeName("Py_ssize_t *")] long* buffer_len);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_Format([NativeTypeName("PyObject *")] _PyObject* obj, [NativeTypeName("PyObject *")] _PyObject* format_spec);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_GetIter([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyObject_GetAIter([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyIter_Check([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyAIter_Check([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyIter_Next([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PySendResult PyIter_Send([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject **")] _PyObject** param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyNumber_Check([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Add([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Subtract([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Multiply([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_MatrixMultiply([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_FloorDivide([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_TrueDivide([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Remainder([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Divmod([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Power([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2, [NativeTypeName("PyObject *")] _PyObject* o3);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Negative([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Positive([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Absolute([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Invert([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Lshift([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Rshift([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_And([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Xor([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Or([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyIndex_Check([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Index([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyNumber_AsSsize_t([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("PyObject *")] _PyObject* exc);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Long([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_Float([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceAdd([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceSubtract([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceMultiply([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceMatrixMultiply([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceFloorDivide([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceTrueDivide([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceRemainder([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlacePower([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2, [NativeTypeName("PyObject *")] _PyObject* o3);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceLshift([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceRshift([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceAnd([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceXor([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_InPlaceOr([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyNumber_ToBase([NativeTypeName("PyObject *")] _PyObject* n, int @base);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySequence_Check([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PySequence_Size([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySequence_Concat([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySequence_Repeat([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("Py_ssize_t")] long count);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySequence_GetItem([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("Py_ssize_t")] long i);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySequence_GetSlice([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("Py_ssize_t")] long i1, [NativeTypeName("Py_ssize_t")] long i2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySequence_SetItem([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("Py_ssize_t")] long i, [NativeTypeName("PyObject *")] _PyObject* v);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySequence_DelItem([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("Py_ssize_t")] long i);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySequence_SetSlice([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("Py_ssize_t")] long i1, [NativeTypeName("Py_ssize_t")] long i2, [NativeTypeName("PyObject *")] _PyObject* v);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySequence_DelSlice([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("Py_ssize_t")] long i1, [NativeTypeName("Py_ssize_t")] long i2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySequence_Tuple([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySequence_List([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySequence_Fast([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("const char *")] sbyte* m);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PySequence_Count([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("PyObject *")] _PyObject* value);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySequence_Contains([NativeTypeName("PyObject *")] _PyObject* seq, [NativeTypeName("PyObject *")] _PyObject* ob);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PySequence_Index([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("PyObject *")] _PyObject* value);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySequence_InPlaceConcat([NativeTypeName("PyObject *")] _PyObject* o1, [NativeTypeName("PyObject *")] _PyObject* o2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySequence_InPlaceRepeat([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("Py_ssize_t")] long count);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyMapping_Check([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long PyMapping_Size([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyMapping_HasKeyString([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("const char *")] sbyte* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyMapping_HasKey([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("PyObject *")] _PyObject* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyMapping_Keys([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyMapping_Values([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyMapping_Items([NativeTypeName("PyObject *")] _PyObject* o);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyMapping_GetItemString([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("const char *")] sbyte* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyMapping_SetItemString([NativeTypeName("PyObject *")] _PyObject* o, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("PyObject *")] _PyObject* value);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_IsInstance([NativeTypeName("PyObject *")] _PyObject* @object, [NativeTypeName("PyObject *")] _PyObject* typeorclass);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyObject_IsSubclass([NativeTypeName("PyObject *")] _PyObject* @object, [NativeTypeName("PyObject *")] _PyObject* typeorclass);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyGen_New([NativeTypeName("PyFrameObject *")] _frame* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyGen_NewWithQualName([NativeTypeName("PyFrameObject *")] _frame* param0, [NativeTypeName("PyObject *")] _PyObject* name, [NativeTypeName("PyObject *")] _PyObject* qualname);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyGen_SetStopIterationValue([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyGen_FetchStopIterationValue([NativeTypeName("PyObject **")] _PyObject** param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyGen_Finalize([NativeTypeName("PyObject *")] _PyObject* self);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyCoro_New([NativeTypeName("PyFrameObject *")] _frame* param0, [NativeTypeName("PyObject *")] _PyObject* name, [NativeTypeName("PyObject *")] _PyObject* qualname);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyAsyncGen_New([NativeTypeName("PyFrameObject *")] _frame* param0, [NativeTypeName("PyObject *")] _PyObject* name, [NativeTypeName("PyObject *")] _PyObject* qualname);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDescr_NewMethod([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, PyMethodDef* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDescr_NewClassMethod([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, PyMethodDef* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDescr_NewMember([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, [NativeTypeName("struct PyMemberDef *")] PyMemberDef* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDescr_NewGetSet([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, [NativeTypeName("struct PyGetSetDef *")] PyGetSetDef* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDescr_NewWrapper([NativeTypeName("PyTypeObject *")] _PyTypeObject* param0, [NativeTypeName("struct wrapperbase *")] _PyWrapperBase* param1, void* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyDescr_IsData([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyDictProxy_New([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyWrapper_New([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* Py_GenericAlias([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyWarnings_Init();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyErr_WarnEx([NativeTypeName("PyObject *")] _PyObject* category, [NativeTypeName("const char *")] sbyte* message, [NativeTypeName("Py_ssize_t")] long stack_level);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyErr_WarnExplicitObject([NativeTypeName("PyObject *")] _PyObject* category, [NativeTypeName("PyObject *")] _PyObject* message, [NativeTypeName("PyObject *")] _PyObject* filename, int lineno, [NativeTypeName("PyObject *")] _PyObject* module, [NativeTypeName("PyObject *")] _PyObject* registry);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyErr_WarnExplicit([NativeTypeName("PyObject *")] _PyObject* category, [NativeTypeName("const char *")] sbyte* message, [NativeTypeName("const char *")] sbyte* filename, int lineno, [NativeTypeName("const char *")] sbyte* module, [NativeTypeName("PyObject *")] _PyObject* registry);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyWeakref_NewRef([NativeTypeName("PyObject *")] _PyObject* ob, [NativeTypeName("PyObject *")] _PyObject* callback);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyWeakref_NewProxy([NativeTypeName("PyObject *")] _PyObject* ob, [NativeTypeName("PyObject *")] _PyObject* callback);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyWeakref_GetObject([NativeTypeName("PyObject *")] _PyObject* @ref);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_ssize_t")]
        public static extern long _PyWeakref_GetWeakrefCount([NativeTypeName("PyWeakReference *")] _PyWeakReference* head);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyWeakref_ClearRef([NativeTypeName("PyWeakReference *")] _PyWeakReference* self);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyStructSequence_InitType([NativeTypeName("PyTypeObject *")] _PyTypeObject* type, PyStructSequence_Desc* desc);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyStructSequence_InitType2([NativeTypeName("PyTypeObject *")] _PyTypeObject* type, PyStructSequence_Desc* desc);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyTypeObject *")]
        public static extern _PyTypeObject* PyStructSequence_NewType(PyStructSequence_Desc* desc);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyStructSequence_New([NativeTypeName("PyTypeObject *")] _PyTypeObject* type);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyStructSequence_SetItem([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyStructSequence_GetItem([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyNamespace_New([NativeTypeName("PyObject *")] _PyObject* kwds);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_SetNone([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_SetObject([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_SetString([NativeTypeName("PyObject *")] _PyObject* exception, [NativeTypeName("const char *")] sbyte* @string);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_Occurred();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_Clear();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_Fetch([NativeTypeName("PyObject **")] _PyObject** param0, [NativeTypeName("PyObject **")] _PyObject** param1, [NativeTypeName("PyObject **")] _PyObject** param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_Restore([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_GetExcInfo([NativeTypeName("PyObject **")] _PyObject** param0, [NativeTypeName("PyObject **")] _PyObject** param1, [NativeTypeName("PyObject **")] _PyObject** param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_SetExcInfo([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_FatalError([NativeTypeName("const char *")] sbyte* message);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyErr_GivenExceptionMatches([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyErr_ExceptionMatches([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_NormalizeException([NativeTypeName("PyObject **")] _PyObject** param0, [NativeTypeName("PyObject **")] _PyObject** param1, [NativeTypeName("PyObject **")] _PyObject** param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyException_SetTraceback([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyException_GetTraceback([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyException_GetCause([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyException_SetCause([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyException_GetContext([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyException_SetContext([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* PyExceptionClass_Name([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyErr_BadArgument();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_NoMemory();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetFromErrno([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetFromErrnoWithFilenameObject([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetFromErrnoWithFilenameObjects([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetFromErrnoWithFilename([NativeTypeName("PyObject *")] _PyObject* exc, [NativeTypeName("const char *")] sbyte* filename);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_FormatV([NativeTypeName("PyObject *")] _PyObject* exception, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("va_list")] sbyte* vargs);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetFromWindowsErrWithFilename(int ierr, [NativeTypeName("const char *")] sbyte* filename);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetFromWindowsErr(int param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetExcFromWindowsErrWithFilenameObject([NativeTypeName("PyObject *")] _PyObject* param0, int param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetExcFromWindowsErrWithFilenameObjects([NativeTypeName("PyObject *")] _PyObject* param0, int param1, [NativeTypeName("PyObject *")] _PyObject* param2, [NativeTypeName("PyObject *")] _PyObject* param3);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetExcFromWindowsErrWithFilename([NativeTypeName("PyObject *")] _PyObject* exc, int ierr, [NativeTypeName("const char *")] sbyte* filename);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetExcFromWindowsErr([NativeTypeName("PyObject *")] _PyObject* param0, int param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetImportErrorSubclass([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2, [NativeTypeName("PyObject *")] _PyObject* param3);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_SetImportError([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_BadInternalCall();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void _PyErr_BadInternalCall([NativeTypeName("const char *")] sbyte* filename, int lineno);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_NewException([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("PyObject *")] _PyObject* @base, [NativeTypeName("PyObject *")] _PyObject* dict);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_NewExceptionWithDoc([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("const char *")] sbyte* doc, [NativeTypeName("PyObject *")] _PyObject* @base, [NativeTypeName("PyObject *")] _PyObject* dict);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_WriteUnraisable([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyErr_CheckSignals();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_SetInterrupt();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyErr_SetInterruptEx(int signum);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_SyntaxLocation([NativeTypeName("const char *")] sbyte* filename, int lineno);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_SyntaxLocationEx([NativeTypeName("const char *")] sbyte* filename, int lineno, int col_offset);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyErr_ProgramText([NativeTypeName("const char *")] sbyte* filename, int lineno);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicodeDecodeError_Create([NativeTypeName("const char *")] sbyte* encoding, [NativeTypeName("const char *")] sbyte* @object, [NativeTypeName("Py_ssize_t")] long length, [NativeTypeName("Py_ssize_t")] long start, [NativeTypeName("Py_ssize_t")] long end, [NativeTypeName("const char *")] sbyte* reason);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicodeEncodeError_GetEncoding([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicodeDecodeError_GetEncoding([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicodeEncodeError_GetObject([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicodeDecodeError_GetObject([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicodeTranslateError_GetObject([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeEncodeError_GetStart([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t *")] long* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeDecodeError_GetStart([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t *")] long* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeTranslateError_GetStart([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t *")] long* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeEncodeError_SetStart([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeDecodeError_SetStart([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeTranslateError_SetStart([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeEncodeError_GetEnd([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t *")] long* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeDecodeError_GetEnd([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t *")] long* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeTranslateError_GetEnd([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t *")] long* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeEncodeError_SetEnd([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeDecodeError_SetEnd([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeTranslateError_SetEnd([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("Py_ssize_t")] long param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicodeEncodeError_GetReason([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicodeDecodeError_GetReason([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyUnicodeTranslateError_GetReason([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeEncodeError_SetReason([NativeTypeName("PyObject *")] _PyObject* exc, [NativeTypeName("const char *")] sbyte* reason);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeDecodeError_SetReason([NativeTypeName("PyObject *")] _PyObject* exc, [NativeTypeName("const char *")] sbyte* reason);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyUnicodeTranslateError_SetReason([NativeTypeName("PyObject *")] _PyObject* exc, [NativeTypeName("const char *")] sbyte* reason);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyOS_vsnprintf([NativeTypeName("char *")] sbyte* str, [NativeTypeName("size_t")] nuint size, [NativeTypeName("const char *")] sbyte* format, [NativeTypeName("va_list")] sbyte* va);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyThread_init_thread();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned long")]
        public static extern uint PyThread_start_new_thread([NativeTypeName("void (*)(void *)")] delegate* unmanaged[Cdecl]<void*, void> param0, void* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyThread_exit_thread();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned long")]
        public static extern uint PyThread_get_thread_ident();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned long")]
        public static extern uint PyThread_get_thread_native_id();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyThread_type_lock")]
        public static extern void* PyThread_allocate_lock();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyThread_free_lock([NativeTypeName("PyThread_type_lock")] void* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyThread_acquire_lock([NativeTypeName("PyThread_type_lock")] void* param0, int param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern PyLockStatus PyThread_acquire_lock_timed([NativeTypeName("PyThread_type_lock")] void* param0, [NativeTypeName("long long")] long microseconds, int intr_flag);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyThread_release_lock([NativeTypeName("PyThread_type_lock")] void* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint PyThread_get_stacksize();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyThread_set_stacksize([NativeTypeName("size_t")] nuint param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyThread_GetInfo();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int PyThread_create_key();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void PyThread_delete_key(int key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int PyThread_set_key_value(int key, void* value);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void* PyThread_get_key_value(int key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void PyThread_delete_key_value(int key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void PyThread_ReInitTLS();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Py_tss_t *")]
        public static extern _Py_tss_t* PyThread_tss_alloc();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyThread_tss_free([NativeTypeName("Py_tss_t *")] _Py_tss_t* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyThread_tss_is_created([NativeTypeName("Py_tss_t *")] _Py_tss_t* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyThread_tss_create([NativeTypeName("Py_tss_t *")] _Py_tss_t* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyThread_tss_delete([NativeTypeName("Py_tss_t *")] _Py_tss_t* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyThread_tss_set([NativeTypeName("Py_tss_t *")] _Py_tss_t* key, void* value);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* PyThread_tss_get([NativeTypeName("Py_tss_t *")] _Py_tss_t* key);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyContext_New();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyContext_Copy([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyContext_CopyCurrent();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyContext_Enter([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyContext_Exit([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyContextVar_New([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("PyObject *")] _PyObject* default_value);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyContextVar_Get([NativeTypeName("PyObject *")] _PyObject* var, [NativeTypeName("PyObject *")] _PyObject* default_value, [NativeTypeName("PyObject **")] _PyObject** value);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyContextVar_Set([NativeTypeName("PyObject *")] _PyObject* var, [NativeTypeName("PyObject *")] _PyObject* value);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyContextVar_Reset([NativeTypeName("PyObject *")] _PyObject* var, [NativeTypeName("PyObject *")] _PyObject* token);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyContext_NewHamtForTests();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyCompile_OpcodeStackEffect(int opcode, int oparg);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyCompile_OpcodeStackEffectWithJump(int opcode, int oparg, int jump);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* Py_CompileString([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("const char *")] sbyte* param1, int param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_Print();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_PrintEx(int param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyErr_Display([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_SimpleStringFlags([NativeTypeName("const char *")] sbyte* param0, PyCompilerFlags* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyRun_SimpleFileObject([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("PyObject *")] _PyObject* filename, int closeit, PyCompilerFlags* flags);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_AnyFileExFlags([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("const char *")] sbyte* filename, int closeit, PyCompilerFlags* flags);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyRun_AnyFileObject([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("PyObject *")] _PyObject* filename, int closeit, PyCompilerFlags* flags);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_SimpleFileExFlags([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("const char *")] sbyte* filename, int closeit, PyCompilerFlags* flags);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_InteractiveOneFlags([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("const char *")] sbyte* filename, PyCompilerFlags* flags);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_InteractiveOneObject([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("PyObject *")] _PyObject* filename, PyCompilerFlags* flags);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_InteractiveLoopFlags([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("const char *")] sbyte* filename, PyCompilerFlags* flags);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _PyRun_InteractiveLoopObject([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("PyObject *")] _PyObject* filename, PyCompilerFlags* flags);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyRun_StringFlags([NativeTypeName("const char *")] sbyte* param0, int param1, [NativeTypeName("PyObject *")] _PyObject* param2, [NativeTypeName("PyObject *")] _PyObject* param3, PyCompilerFlags* param4);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyRun_FileExFlags([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("const char *")] sbyte* filename, int start, [NativeTypeName("PyObject *")] _PyObject* globals, [NativeTypeName("PyObject *")] _PyObject* locals, int closeit, PyCompilerFlags* flags);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* Py_CompileStringExFlags([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("const char *")] sbyte* filename, int start, PyCompilerFlags* flags, int optimize);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* Py_CompileStringObject([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("PyObject *")] _PyObject* filename, int start, PyCompilerFlags* flags, int optimize);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* _Py_SourceAsString([NativeTypeName("PyObject *")] _PyObject* cmd, [NativeTypeName("const char *")] sbyte* funcname, [NativeTypeName("const char *")] sbyte* what, PyCompilerFlags* cf, [NativeTypeName("PyObject **")] _PyObject** cmd_copy);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyRun_String([NativeTypeName("const char *")] sbyte* str, int s, [NativeTypeName("PyObject *")] _PyObject* g, [NativeTypeName("PyObject *")] _PyObject* l);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_AnyFile([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("const char *")] sbyte* name);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_AnyFileEx([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("const char *")] sbyte* name, int closeit);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_AnyFileFlags([NativeTypeName("FILE *")] _iobuf* param0, [NativeTypeName("const char *")] sbyte* param1, PyCompilerFlags* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_SimpleString([NativeTypeName("const char *")] sbyte* s);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_SimpleFile([NativeTypeName("FILE *")] _iobuf* f, [NativeTypeName("const char *")] sbyte* p);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_SimpleFileEx([NativeTypeName("FILE *")] _iobuf* f, [NativeTypeName("const char *")] sbyte* p, int c);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_InteractiveOne([NativeTypeName("FILE *")] _iobuf* f, [NativeTypeName("const char *")] sbyte* p);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyRun_InteractiveLoop([NativeTypeName("FILE *")] _iobuf* f, [NativeTypeName("const char *")] sbyte* p);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyRun_File([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("const char *")] sbyte* p, int s, [NativeTypeName("PyObject *")] _PyObject* g, [NativeTypeName("PyObject *")] _PyObject* l);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyRun_FileEx([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("const char *")] sbyte* p, int s, [NativeTypeName("PyObject *")] _PyObject* g, [NativeTypeName("PyObject *")] _PyObject* l, int c);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyRun_FileFlags([NativeTypeName("FILE *")] _iobuf* fp, [NativeTypeName("const char *")] sbyte* p, int s, [NativeTypeName("PyObject *")] _PyObject* g, [NativeTypeName("PyObject *")] _PyObject* l, PyCompilerFlags* flags);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* PyOS_Readline([NativeTypeName("FILE *")] _iobuf* param0, [NativeTypeName("FILE *")] _iobuf* param1, [NativeTypeName("const char *")] sbyte* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_Initialize();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_InitializeEx(int param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_Finalize();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_FinalizeEx();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_IsInitialized();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyThreadState *")]
        public static extern _PyThreadState* Py_NewInterpreter();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_EndInterpreter([NativeTypeName("PyThreadState *")] _PyThreadState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_AtExit([NativeTypeName("void (*)(void)")] delegate* unmanaged[Cdecl]<void> func);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_Exit(int param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_Main(int argc, [NativeTypeName("wchar_t **")] ushort** argv);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_BytesMain(int argc, [NativeTypeName("char **")] sbyte** argv);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_SetProgramName([NativeTypeName("const wchar_t *")] ushort* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("wchar_t *")]
        public static extern ushort* Py_GetProgramName();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_SetPythonHome([NativeTypeName("const wchar_t *")] ushort* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("wchar_t *")]
        public static extern ushort* Py_GetPythonHome();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("wchar_t *")]
        public static extern ushort* Py_GetProgramFullPath();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("wchar_t *")]
        public static extern ushort* Py_GetPrefix();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("wchar_t *")]
        public static extern ushort* Py_GetExecPrefix();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("wchar_t *")]
        public static extern ushort* Py_GetPath();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_SetPath([NativeTypeName("const wchar_t *")] ushort* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* Py_GetVersion();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* Py_GetPlatform();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* Py_GetCopyright();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* Py_GetCompiler();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* Py_GetBuildInfo();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyOS_sighandler_t")]
        public static extern delegate* unmanaged[Cdecl]<int, void> PyOS_getsig(int param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyOS_sighandler_t")]
        public static extern delegate* unmanaged[Cdecl]<int, void> PyOS_setsig(int param0, [NativeTypeName("PyOS_sighandler_t")] delegate* unmanaged[Cdecl]<int, void> param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        [Obsolete]
        public static extern _PyObject* PyEval_CallObjectWithKeywords([NativeTypeName("PyObject *")] _PyObject* callable, [NativeTypeName("PyObject *")] _PyObject* args, [NativeTypeName("PyObject *")] _PyObject* kwargs);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyEval_GetBuiltins();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyEval_GetGlobals();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyEval_GetLocals();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyFrameObject *")]
        public static extern _frame* PyEval_GetFrame();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_AddPendingCall([NativeTypeName("int (*)(void *)")] delegate* unmanaged[Cdecl]<void*, int> func, void* arg);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_MakePendingCalls();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_SetRecursionLimit(int param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_GetRecursionLimit();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Py_EnterRecursiveCall([NativeTypeName("const char *")] sbyte* where);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Py_LeaveRecursiveCall();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* PyEval_GetFuncName([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* PyEval_GetFuncDesc([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyEval_EvalFrame([NativeTypeName("PyFrameObject *")] _frame* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyEval_EvalFrameEx([NativeTypeName("PyFrameObject *")] _frame* f, int exc);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyThreadState *")]
        public static extern _PyThreadState* PyEval_SaveThread();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyEval_RestoreThread([NativeTypeName("PyThreadState *")] _PyThreadState* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int PyEval_ThreadsInitialized();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void PyEval_InitThreads();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void PyEval_AcquireLock();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void PyEval_ReleaseLock();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyEval_AcquireThread([NativeTypeName("PyThreadState *")] _PyThreadState* tstate);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PyEval_ReleaseThread([NativeTypeName("PyThreadState *")] _PyThreadState* tstate);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySys_GetObject([NativeTypeName("const char *")] sbyte* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySys_SetObject([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("PyObject *")] _PyObject* param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PySys_SetArgv(int param0, [NativeTypeName("wchar_t **")] ushort** param1);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PySys_SetArgvEx(int param0, [NativeTypeName("wchar_t **")] ushort** param1, int param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PySys_SetPath([NativeTypeName("const wchar_t *")] ushort* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PySys_ResetWarnOptions();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PySys_AddWarnOption([NativeTypeName("const wchar_t *")] ushort* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PySys_AddWarnOptionUnicode([NativeTypeName("PyObject *")] _PyObject* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PySys_HasWarnOptions();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PySys_AddXOption([NativeTypeName("const wchar_t *")] ushort* param0);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PySys_GetXOptions();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("long")]
        public static extern int PyImport_GetMagicNumber();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* PyImport_GetMagicTag();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_ExecCodeModule([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("PyObject *")] _PyObject* co);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_ExecCodeModuleEx([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("PyObject *")] _PyObject* co, [NativeTypeName("const char *")] sbyte* pathname);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_ExecCodeModuleWithPathnames([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("PyObject *")] _PyObject* co, [NativeTypeName("const char *")] sbyte* pathname, [NativeTypeName("const char *")] sbyte* cpathname);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_ExecCodeModuleObject([NativeTypeName("PyObject *")] _PyObject* name, [NativeTypeName("PyObject *")] _PyObject* co, [NativeTypeName("PyObject *")] _PyObject* pathname, [NativeTypeName("PyObject *")] _PyObject* cpathname);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_GetModuleDict();

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_GetModule([NativeTypeName("PyObject *")] _PyObject* name);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_AddModuleObject([NativeTypeName("PyObject *")] _PyObject* name);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_AddModule([NativeTypeName("const char *")] sbyte* name);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_ImportModule([NativeTypeName("const char *")] sbyte* name);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_ImportModuleNoBlock([NativeTypeName("const char *")] sbyte* name);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_ImportModuleLevel([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("PyObject *")] _PyObject* globals, [NativeTypeName("PyObject *")] _PyObject* locals, [NativeTypeName("PyObject *")] _PyObject* fromlist, int level);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_ImportModuleLevelObject([NativeTypeName("PyObject *")] _PyObject* name, [NativeTypeName("PyObject *")] _PyObject* globals, [NativeTypeName("PyObject *")] _PyObject* locals, [NativeTypeName("PyObject *")] _PyObject* fromlist, int level);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_GetImporter([NativeTypeName("PyObject *")] _PyObject* path);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_Import([NativeTypeName("PyObject *")] _PyObject* name);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyImport_ReloadModule([NativeTypeName("PyObject *")] _PyObject* m);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyImport_ImportFrozenModuleObject([NativeTypeName("PyObject *")] _PyObject* name);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyImport_ImportFrozenModule([NativeTypeName("const char *")] sbyte* name);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyImport_AppendInittab([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("PyObject *(*)(void)")] delegate* unmanaged[Cdecl]<_PyObject*> initfunc);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyEval_EvalCode([NativeTypeName("PyObject *")] _PyObject* param0, [NativeTypeName("PyObject *")] _PyObject* param1, [NativeTypeName("PyObject *")] _PyObject* param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* PyEval_EvalCodeEx([NativeTypeName("PyObject *")] _PyObject* co, [NativeTypeName("PyObject *")] _PyObject* globals, [NativeTypeName("PyObject *")] _PyObject* locals, [NativeTypeName("PyObject *const *")] _PyObject** args, int argc, [NativeTypeName("PyObject *const *")] _PyObject** kwds, int kwdc, [NativeTypeName("PyObject *const *")] _PyObject** defs, int defc, [NativeTypeName("PyObject *")] _PyObject* kwdefs, [NativeTypeName("PyObject *")] _PyObject* closure);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _PyEval_CallTracing([NativeTypeName("PyObject *")] _PyObject* func, [NativeTypeName("PyObject *")] _PyObject* args);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double PyOS_string_to_double([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("char **")] sbyte** endptr, [NativeTypeName("PyObject *")] _PyObject* overflow_exception);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* PyOS_double_to_string(double val, [NativeTypeName("char")] sbyte format_code, int precision, int flags, int* type);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("PyObject *")]
        public static extern _PyObject* _Py_string_to_number_with_underscores([NativeTypeName("const char *")] sbyte* str, [NativeTypeName("Py_ssize_t")] long len, [NativeTypeName("const char *")] sbyte* what, [NativeTypeName("PyObject *")] _PyObject* obj, void* arg, [NativeTypeName("PyObject *(*)(const char *, Py_ssize_t, void *)")] delegate* unmanaged[Cdecl]<sbyte*, long, void*, _PyObject*> innerfunc);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double _Py_parse_inf_or_nan([NativeTypeName("const char *")] sbyte* p, [NativeTypeName("char **")] sbyte** endptr);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyOS_mystrnicmp([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("const char *")] sbyte* param1, [NativeTypeName("Py_ssize_t")] long param2);

        [DllImport("python310", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PyOS_mystricmp([NativeTypeName("const char *")] sbyte* param0, [NativeTypeName("const char *")] sbyte* param1);

        [NativeTypeName("#define HAVE_LONG_LONG 1")]
        public const int HAVE_LONG_LONG = 1;

        [NativeTypeName("#define PYLONG_BITS_IN_DIGIT 30")]
        public const int PYLONG_BITS_IN_DIGIT = 30;

        [NativeTypeName("#define SIZEOF_PY_HASH_T SIZEOF_SIZE_T")]
        public const int SIZEOF_PY_HASH_T = 8;

        [NativeTypeName("#define SIZEOF_PY_UHASH_T SIZEOF_SIZE_T")]
        public const int SIZEOF_PY_UHASH_T = 8;

        [NativeTypeName("#define PY_SIZE_MAX SIZE_MAX")]
        public const ulong PY_SIZE_MAX = 0xffffffffffffffffUL;

        [NativeTypeName("#define PY_FORMAT_SIZE_T \"z\"")]
        public static ReadOnlySpan<byte> PY_FORMAT_SIZE_T => "z"u8;

        [NativeTypeName("#define S_IFLNK 0120000")]
        public const int S_IFLNK = 0120000;

        [NativeTypeName("#define PY_BIG_ENDIAN 0")]
        public const int PY_BIG_ENDIAN = 0;

        [NativeTypeName("#define PY_LITTLE_ENDIAN 1")]
        public const int PY_LITTLE_ENDIAN = 1;

        [NativeTypeName("#define PY_DWORD_MAX 4294967295U")]
        public const uint PY_DWORD_MAX = 4294967295U;

        [NativeTypeName("#define Py_MATH_PI 3.14159265358979323846")]
        public const double Py_MATH_PI = 3.14159265358979323846;

        [NativeTypeName("#define Py_MATH_E 2.7182818284590452354")]
        public const double Py_MATH_E = 2.7182818284590452354;

        [NativeTypeName("#define Py_HUGE_VAL HUGE_VAL")]
        public const double Py_HUGE_VAL = ((double)((float)(1e+300)));

        [NativeTypeName("#define Py_NAN (Py_HUGE_VAL * 0.)")]
        public const double Py_NAN = (((double)((float)(1e+300))) * 0.0);

        [NativeTypeName("#define PyMem_Del PyMem_Free")]
        public static delegate*<void*, void> PyMem_Del => &PyMem_Free;

        [NativeTypeName("#define PyMem_DEL PyMem_Free")]
        public static delegate*<void*, void> PyMem_DEL => &PyMem_Free;

        [NativeTypeName("#define Py_INVALID_SIZE (Py_ssize_t)-1")]
        public const long Py_INVALID_SIZE = (long)(-1);

        [NativeTypeName("#define Py_PRINT_RAW 1")]
        public const int Py_PRINT_RAW = 1;

        [NativeTypeName("#define Py_TPFLAGS_SEQUENCE (1 << 5)")]
        public const int Py_TPFLAGS_SEQUENCE = (1 << 5);

        [NativeTypeName("#define Py_TPFLAGS_MAPPING (1 << 6)")]
        public const int Py_TPFLAGS_MAPPING = (1 << 6);

        [NativeTypeName("#define Py_TPFLAGS_DISALLOW_INSTANTIATION (1UL << 7)")]
        public const uint Py_TPFLAGS_DISALLOW_INSTANTIATION = (1U << 7);

        [NativeTypeName("#define Py_TPFLAGS_IMMUTABLETYPE (1UL << 8)")]
        public const uint Py_TPFLAGS_IMMUTABLETYPE = (1U << 8);

        [NativeTypeName("#define Py_TPFLAGS_HEAPTYPE (1UL << 9)")]
        public const uint Py_TPFLAGS_HEAPTYPE = (1U << 9);

        [NativeTypeName("#define Py_TPFLAGS_BASETYPE (1UL << 10)")]
        public const uint Py_TPFLAGS_BASETYPE = (1U << 10);

        [NativeTypeName("#define Py_TPFLAGS_HAVE_VECTORCALL (1UL << 11)")]
        public const uint Py_TPFLAGS_HAVE_VECTORCALL = (1U << 11);

        [NativeTypeName("#define _Py_TPFLAGS_HAVE_VECTORCALL Py_TPFLAGS_HAVE_VECTORCALL")]
        public const uint _Py_TPFLAGS_HAVE_VECTORCALL = (1U << 11);

        [NativeTypeName("#define Py_TPFLAGS_READY (1UL << 12)")]
        public const uint Py_TPFLAGS_READY = (1U << 12);

        [NativeTypeName("#define Py_TPFLAGS_READYING (1UL << 13)")]
        public const uint Py_TPFLAGS_READYING = (1U << 13);

        [NativeTypeName("#define Py_TPFLAGS_HAVE_GC (1UL << 14)")]
        public const uint Py_TPFLAGS_HAVE_GC = (1U << 14);

        [NativeTypeName("#define Py_TPFLAGS_HAVE_STACKLESS_EXTENSION 0")]
        public const int Py_TPFLAGS_HAVE_STACKLESS_EXTENSION = 0;

        [NativeTypeName("#define Py_TPFLAGS_METHOD_DESCRIPTOR (1UL << 17)")]
        public const uint Py_TPFLAGS_METHOD_DESCRIPTOR = (1U << 17);

        [NativeTypeName("#define Py_TPFLAGS_VALID_VERSION_TAG (1UL << 19)")]
        public const uint Py_TPFLAGS_VALID_VERSION_TAG = (1U << 19);

        [NativeTypeName("#define Py_TPFLAGS_IS_ABSTRACT (1UL << 20)")]
        public const uint Py_TPFLAGS_IS_ABSTRACT = (1U << 20);

        [NativeTypeName("#define _Py_TPFLAGS_MATCH_SELF (1UL << 22)")]
        public const uint _Py_TPFLAGS_MATCH_SELF = (1U << 22);

        [NativeTypeName("#define Py_TPFLAGS_LONG_SUBCLASS (1UL << 24)")]
        public const uint Py_TPFLAGS_LONG_SUBCLASS = (1U << 24);

        [NativeTypeName("#define Py_TPFLAGS_LIST_SUBCLASS (1UL << 25)")]
        public const uint Py_TPFLAGS_LIST_SUBCLASS = (1U << 25);

        [NativeTypeName("#define Py_TPFLAGS_TUPLE_SUBCLASS (1UL << 26)")]
        public const uint Py_TPFLAGS_TUPLE_SUBCLASS = (1U << 26);

        [NativeTypeName("#define Py_TPFLAGS_BYTES_SUBCLASS (1UL << 27)")]
        public const uint Py_TPFLAGS_BYTES_SUBCLASS = (1U << 27);

        [NativeTypeName("#define Py_TPFLAGS_UNICODE_SUBCLASS (1UL << 28)")]
        public const uint Py_TPFLAGS_UNICODE_SUBCLASS = (1U << 28);

        [NativeTypeName("#define Py_TPFLAGS_DICT_SUBCLASS (1UL << 29)")]
        public const uint Py_TPFLAGS_DICT_SUBCLASS = (1U << 29);

        [NativeTypeName("#define Py_TPFLAGS_BASE_EXC_SUBCLASS (1UL << 30)")]
        public const uint Py_TPFLAGS_BASE_EXC_SUBCLASS = (1U << 30);

        [NativeTypeName("#define Py_TPFLAGS_TYPE_SUBCLASS (1UL << 31)")]
        public const uint Py_TPFLAGS_TYPE_SUBCLASS = (1U << 31);

        [NativeTypeName("#define Py_TPFLAGS_DEFAULT ( \\\r\n                 Py_TPFLAGS_HAVE_STACKLESS_EXTENSION | \\\r\n                0)")]
        public const int Py_TPFLAGS_DEFAULT = (0 | 0);

        [NativeTypeName("#define Py_TPFLAGS_HAVE_FINALIZE (1UL << 0)")]
        public const uint Py_TPFLAGS_HAVE_FINALIZE = (1U << 0);

        [NativeTypeName("#define Py_TPFLAGS_HAVE_VERSION_TAG (1UL << 18)")]
        public const uint Py_TPFLAGS_HAVE_VERSION_TAG = (1U << 18);

        [NativeTypeName("#define Py_LT 0")]
        public const int Py_LT = 0;

        [NativeTypeName("#define Py_LE 1")]
        public const int Py_LE = 1;

        [NativeTypeName("#define Py_EQ 2")]
        public const int Py_EQ = 2;

        [NativeTypeName("#define Py_NE 3")]
        public const int Py_NE = 3;

        [NativeTypeName("#define Py_GT 4")]
        public const int Py_GT = 4;

        [NativeTypeName("#define Py_GE 5")]
        public const int Py_GE = 5;

        [NativeTypeName("#define PyBUF_MAX_NDIM 64")]
        public const int PyBUF_MAX_NDIM = 64;

        [NativeTypeName("#define PyBUF_SIMPLE 0")]
        public const int PyBUF_SIMPLE = 0;

        [NativeTypeName("#define PyBUF_WRITABLE 0x0001")]
        public const int PyBUF_WRITABLE = 0x0001;

        [NativeTypeName("#define PyBUF_WRITEABLE PyBUF_WRITABLE")]
        public const int PyBUF_WRITEABLE = 0x0001;

        [NativeTypeName("#define PyBUF_FORMAT 0x0004")]
        public const int PyBUF_FORMAT = 0x0004;

        [NativeTypeName("#define PyBUF_ND 0x0008")]
        public const int PyBUF_ND = 0x0008;

        [NativeTypeName("#define PyBUF_STRIDES (0x0010 | PyBUF_ND)")]
        public const int PyBUF_STRIDES = (0x0010 | 0x0008);

        [NativeTypeName("#define PyBUF_C_CONTIGUOUS (0x0020 | PyBUF_STRIDES)")]
        public const int PyBUF_C_CONTIGUOUS = (0x0020 | (0x0010 | 0x0008));

        [NativeTypeName("#define PyBUF_F_CONTIGUOUS (0x0040 | PyBUF_STRIDES)")]
        public const int PyBUF_F_CONTIGUOUS = (0x0040 | (0x0010 | 0x0008));

        [NativeTypeName("#define PyBUF_ANY_CONTIGUOUS (0x0080 | PyBUF_STRIDES)")]
        public const int PyBUF_ANY_CONTIGUOUS = (0x0080 | (0x0010 | 0x0008));

        [NativeTypeName("#define PyBUF_INDIRECT (0x0100 | PyBUF_STRIDES)")]
        public const int PyBUF_INDIRECT = (0x0100 | (0x0010 | 0x0008));

        [NativeTypeName("#define PyBUF_CONTIG (PyBUF_ND | PyBUF_WRITABLE)")]
        public const int PyBUF_CONTIG = (0x0008 | 0x0001);

        [NativeTypeName("#define PyBUF_CONTIG_RO (PyBUF_ND)")]
        public const int PyBUF_CONTIG_RO = (0x0008);

        [NativeTypeName("#define PyBUF_STRIDED (PyBUF_STRIDES | PyBUF_WRITABLE)")]
        public const int PyBUF_STRIDED = ((0x0010 | 0x0008) | 0x0001);

        [NativeTypeName("#define PyBUF_STRIDED_RO (PyBUF_STRIDES)")]
        public const int PyBUF_STRIDED_RO = ((0x0010 | 0x0008));

        [NativeTypeName("#define PyBUF_RECORDS (PyBUF_STRIDES | PyBUF_WRITABLE | PyBUF_FORMAT)")]
        public const int PyBUF_RECORDS = ((0x0010 | 0x0008) | 0x0001 | 0x0004);

        [NativeTypeName("#define PyBUF_RECORDS_RO (PyBUF_STRIDES | PyBUF_FORMAT)")]
        public const int PyBUF_RECORDS_RO = ((0x0010 | 0x0008) | 0x0004);

        [NativeTypeName("#define PyBUF_FULL (PyBUF_INDIRECT | PyBUF_WRITABLE | PyBUF_FORMAT)")]
        public const int PyBUF_FULL = ((0x0100 | (0x0010 | 0x0008)) | 0x0001 | 0x0004);

        [NativeTypeName("#define PyBUF_FULL_RO (PyBUF_INDIRECT | PyBUF_FORMAT)")]
        public const int PyBUF_FULL_RO = ((0x0100 | (0x0010 | 0x0008)) | 0x0004);

        [NativeTypeName("#define PyBUF_READ 0x100")]
        public const int PyBUF_READ = 0x100;

        [NativeTypeName("#define PyBUF_WRITE 0x200")]
        public const int PyBUF_WRITE = 0x200;

        [NativeTypeName("#define PyTrash_UNWIND_LEVEL 50")]
        public const int PyTrash_UNWIND_LEVEL = 50;

        [NativeTypeName("#define _PyHASH_MULTIPLIER 1000003UL")]
        public const uint _PyHASH_MULTIPLIER = 1000003U;

        [NativeTypeName("#define _PyHASH_BITS 61")]
        public const int _PyHASH_BITS = 61;

        [NativeTypeName("#define _PyHASH_INF 314159")]
        public const int _PyHASH_INF = 314159;

        [NativeTypeName("#define _PyHASH_IMAG _PyHASH_MULTIPLIER")]
        public const uint _PyHASH_IMAG = 1000003U;

        [NativeTypeName("#define Py_HASH_CUTOFF 0")]
        public const int Py_HASH_CUTOFF = 0;

        [NativeTypeName("#define Py_HASH_EXTERNAL 0")]
        public const int Py_HASH_EXTERNAL = 0;

        [NativeTypeName("#define Py_HASH_SIPHASH24 1")]
        public const int Py_HASH_SIPHASH24 = 1;

        [NativeTypeName("#define Py_HASH_FNV 2")]
        public const int Py_HASH_FNV = 2;

        [NativeTypeName("#define Py_HASH_ALGORITHM Py_HASH_SIPHASH24")]
        public const int Py_HASH_ALGORITHM = 1;

        [NativeTypeName("#define Py_UNICODE_SIZE SIZEOF_WCHAR_T")]
        public const int Py_UNICODE_SIZE = 2;

        [NativeTypeName("#define Py_UNICODE_REPLACEMENT_CHARACTER ((Py_UCS4) 0xFFFD)")]
        public const uint Py_UNICODE_REPLACEMENT_CHARACTER = ((uint)(0xFFFD));

        [NativeTypeName("#define USE_UNICODE_WCHAR_CACHE 1")]
        public const int USE_UNICODE_WCHAR_CACHE = 1;

        [NativeTypeName("#define SSTATE_NOT_INTERNED 0")]
        public const int SSTATE_NOT_INTERNED = 0;

        [NativeTypeName("#define SSTATE_INTERNED_MORTAL 1")]
        public const int SSTATE_INTERNED_MORTAL = 1;

        [NativeTypeName("#define SSTATE_INTERNED_IMMORTAL 2")]
        public const int SSTATE_INTERNED_IMMORTAL = 2;

        [NativeTypeName("#define _PyUnicode_AsString PyUnicode_AsUTF8")]
        public static delegate*<_PyObject*, sbyte*> _PyUnicode_AsString => &PyUnicode_AsUTF8;

        [NativeTypeName("#define _Py_PARSE_PID \"i\"")]
        public static ReadOnlySpan<byte> _Py_PARSE_PID => "i"u8;

        [NativeTypeName("#define PyLong_FromPid PyLong_FromLong")]
        public static delegate*<int, _PyObject*> PyLong_FromPid => &PyLong_FromLong;

        [NativeTypeName("#define PyLong_AsPid PyLong_AsLong")]
        public static delegate*<_PyObject*, int> PyLong_AsPid => &PyLong_AsLong;

        [NativeTypeName("#define _Py_PARSE_INTPTR \"L\"")]
        public static ReadOnlySpan<byte> _Py_PARSE_INTPTR => "L"u8;

        [NativeTypeName("#define _Py_PARSE_UINTPTR \"K\"")]
        public static ReadOnlySpan<byte> _Py_PARSE_UINTPTR => "K"u8;

        [NativeTypeName("#define PyLong_SHIFT 30")]
        public const int PyLong_SHIFT = 30;

        [NativeTypeName("#define _PyLong_DECIMAL_SHIFT 9")]
        public const int _PyLong_DECIMAL_SHIFT = 9;

        [NativeTypeName("#define _PyLong_DECIMAL_BASE ((digit)1000000000)")]
        public const uint _PyLong_DECIMAL_BASE = ((uint)(1000000000));

        [NativeTypeName("#define PyLong_BASE ((digit)1 << PyLong_SHIFT)")]
        public const uint PyLong_BASE = ((uint)(1) << 30);

        [NativeTypeName("#define PyLong_MASK ((digit)(PyLong_BASE - 1))")]
        public const uint PyLong_MASK = ((uint)(((uint)(1) << 30) - 1));

        [NativeTypeName("#define _Py_MANAGED_BUFFER_RELEASED 0x001")]
        public const int _Py_MANAGED_BUFFER_RELEASED = 0x001;

        [NativeTypeName("#define _Py_MANAGED_BUFFER_FREE_FORMAT 0x002")]
        public const int _Py_MANAGED_BUFFER_FREE_FORMAT = 0x002;

        [NativeTypeName("#define _Py_MEMORYVIEW_RELEASED 0x001")]
        public const int _Py_MEMORYVIEW_RELEASED = 0x001;

        [NativeTypeName("#define _Py_MEMORYVIEW_C 0x002")]
        public const int _Py_MEMORYVIEW_C = 0x002;

        [NativeTypeName("#define _Py_MEMORYVIEW_FORTRAN 0x004")]
        public const int _Py_MEMORYVIEW_FORTRAN = 0x004;

        [NativeTypeName("#define _Py_MEMORYVIEW_SCALAR 0x008")]
        public const int _Py_MEMORYVIEW_SCALAR = 0x008;

        [NativeTypeName("#define _Py_MEMORYVIEW_PIL 0x010")]
        public const int _Py_MEMORYVIEW_PIL = 0x010;

        [NativeTypeName("#define PySet_MINSIZE 8")]
        public const int PySet_MINSIZE = 8;

        [NativeTypeName("#define METH_VARARGS 0x0001")]
        public const int METH_VARARGS = 0x0001;

        [NativeTypeName("#define METH_KEYWORDS 0x0002")]
        public const int METH_KEYWORDS = 0x0002;

        [NativeTypeName("#define METH_NOARGS 0x0004")]
        public const int METH_NOARGS = 0x0004;

        [NativeTypeName("#define METH_O 0x0008")]
        public const int METH_O = 0x0008;

        [NativeTypeName("#define METH_CLASS 0x0010")]
        public const int METH_CLASS = 0x0010;

        [NativeTypeName("#define METH_STATIC 0x0020")]
        public const int METH_STATIC = 0x0020;

        [NativeTypeName("#define METH_COEXIST 0x0040")]
        public const int METH_COEXIST = 0x0040;

        [NativeTypeName("#define METH_FASTCALL 0x0080")]
        public const int METH_FASTCALL = 0x0080;

        [NativeTypeName("#define METH_STACKLESS 0x0000")]
        public const int METH_STACKLESS = 0x0000;

        [NativeTypeName("#define METH_METHOD 0x0200")]
        public const int METH_METHOD = 0x0200;

        [NativeTypeName("#define Py_mod_create 1")]
        public const int Py_mod_create = 1;

        [NativeTypeName("#define Py_mod_exec 2")]
        public const int Py_mod_exec = 2;

        [NativeTypeName("#define _Py_mod_LAST_SLOT 2")]
        public const int _Py_mod_LAST_SLOT = 2;

        [NativeTypeName("#define PY_STDIOTEXTMODE \"b\"")]
        public static ReadOnlySpan<byte> PY_STDIOTEXTMODE => "b"u8;

        [NativeTypeName("#define CO_OPTIMIZED 0x0001")]
        public const int CO_OPTIMIZED = 0x0001;

        [NativeTypeName("#define CO_NEWLOCALS 0x0002")]
        public const int CO_NEWLOCALS = 0x0002;

        [NativeTypeName("#define CO_VARARGS 0x0004")]
        public const int CO_VARARGS = 0x0004;

        [NativeTypeName("#define CO_VARKEYWORDS 0x0008")]
        public const int CO_VARKEYWORDS = 0x0008;

        [NativeTypeName("#define CO_NESTED 0x0010")]
        public const int CO_NESTED = 0x0010;

        [NativeTypeName("#define CO_GENERATOR 0x0020")]
        public const int CO_GENERATOR = 0x0020;

        [NativeTypeName("#define CO_NOFREE 0x0040")]
        public const int CO_NOFREE = 0x0040;

        [NativeTypeName("#define CO_COROUTINE 0x0080")]
        public const int CO_COROUTINE = 0x0080;

        [NativeTypeName("#define CO_ITERABLE_COROUTINE 0x0100")]
        public const int CO_ITERABLE_COROUTINE = 0x0100;

        [NativeTypeName("#define CO_ASYNC_GENERATOR 0x0200")]
        public const int CO_ASYNC_GENERATOR = 0x0200;

        [NativeTypeName("#define CO_FUTURE_DIVISION 0x20000")]
        public const int CO_FUTURE_DIVISION = 0x20000;

        [NativeTypeName("#define CO_FUTURE_ABSOLUTE_IMPORT 0x40000")]
        public const int CO_FUTURE_ABSOLUTE_IMPORT = 0x40000;

        [NativeTypeName("#define CO_FUTURE_WITH_STATEMENT 0x80000")]
        public const int CO_FUTURE_WITH_STATEMENT = 0x80000;

        [NativeTypeName("#define CO_FUTURE_PRINT_FUNCTION 0x100000")]
        public const int CO_FUTURE_PRINT_FUNCTION = 0x100000;

        [NativeTypeName("#define CO_FUTURE_UNICODE_LITERALS 0x200000")]
        public const int CO_FUTURE_UNICODE_LITERALS = 0x200000;

        [NativeTypeName("#define CO_FUTURE_BARRY_AS_BDFL 0x400000")]
        public const int CO_FUTURE_BARRY_AS_BDFL = 0x400000;

        [NativeTypeName("#define CO_FUTURE_GENERATOR_STOP 0x800000")]
        public const int CO_FUTURE_GENERATOR_STOP = 0x800000;

        [NativeTypeName("#define CO_FUTURE_ANNOTATIONS 0x1000000")]
        public const int CO_FUTURE_ANNOTATIONS = 0x1000000;

        [NativeTypeName("#define CO_CELL_NOT_AN_ARG (-1)")]
        public const int CO_CELL_NOT_AN_ARG = (-1);

        [NativeTypeName("#define CO_MAXBLOCKS 20")]
        public const int CO_MAXBLOCKS = 20;

        [NativeTypeName("#define MAX_CO_EXTRA_USERS 255")]
        public const int MAX_CO_EXTRA_USERS = 255;

        [NativeTypeName("#define PyTrace_CALL 0")]
        public const int PyTrace_CALL = 0;

        [NativeTypeName("#define PyTrace_EXCEPTION 1")]
        public const int PyTrace_EXCEPTION = 1;

        [NativeTypeName("#define PyTrace_LINE 2")]
        public const int PyTrace_LINE = 2;

        [NativeTypeName("#define PyTrace_RETURN 3")]
        public const int PyTrace_RETURN = 3;

        [NativeTypeName("#define PyTrace_C_CALL 4")]
        public const int PyTrace_C_CALL = 4;

        [NativeTypeName("#define PyTrace_C_EXCEPTION 5")]
        public const int PyTrace_C_EXCEPTION = 5;

        [NativeTypeName("#define PyTrace_C_RETURN 6")]
        public const int PyTrace_C_RETURN = 6;

        [NativeTypeName("#define PyTrace_OPCODE 7")]
        public const int PyTrace_OPCODE = 7;

        [NativeTypeName("#define _PyInterpreterState_Get PyInterpreterState_Get")]
        public static delegate*<_PyInterpreterState*> _PyInterpreterState_Get => &PyInterpreterState_Get;

        [NativeTypeName("#define PyWrapperFlag_KEYWORDS 1")]
        public const int PyWrapperFlag_KEYWORDS = 1;

        [NativeTypeName("#define PYTHREAD_INVALID_THREAD_ID ((unsigned long)-1)")]
        public const uint PYTHREAD_INVALID_THREAD_ID = unchecked((uint)(-1));

        [NativeTypeName("#define WAIT_LOCK 1")]
        public const int WAIT_LOCK = 1;

        [NativeTypeName("#define NOWAIT_LOCK 0")]
        public const int NOWAIT_LOCK = 0;

        [NativeTypeName("#define PY_TIMEOUT_MAX (0xFFFFFFFFLL * 1000)")]
        public const long PY_TIMEOUT_MAX = (0xFFFFFFFFL * 1000);

        [NativeTypeName("#define PyCF_MASK (CO_FUTURE_DIVISION | CO_FUTURE_ABSOLUTE_IMPORT | \\\r\n                   CO_FUTURE_WITH_STATEMENT | CO_FUTURE_PRINT_FUNCTION | \\\r\n                   CO_FUTURE_UNICODE_LITERALS | CO_FUTURE_BARRY_AS_BDFL | \\\r\n                   CO_FUTURE_GENERATOR_STOP | CO_FUTURE_ANNOTATIONS)")]
        public const int PyCF_MASK = (0x20000 | 0x40000 | 0x80000 | 0x100000 | 0x200000 | 0x400000 | 0x800000 | 0x1000000);

        [NativeTypeName("#define PyCF_MASK_OBSOLETE (CO_NESTED)")]
        public const int PyCF_MASK_OBSOLETE = (0x0010);

        [NativeTypeName("#define PyCF_SOURCE_IS_UTF8 0x0100")]
        public const int PyCF_SOURCE_IS_UTF8 = 0x0100;

        [NativeTypeName("#define PyCF_DONT_IMPLY_DEDENT 0x0200")]
        public const int PyCF_DONT_IMPLY_DEDENT = 0x0200;

        [NativeTypeName("#define PyCF_ONLY_AST 0x0400")]
        public const int PyCF_ONLY_AST = 0x0400;

        [NativeTypeName("#define PyCF_IGNORE_COOKIE 0x0800")]
        public const int PyCF_IGNORE_COOKIE = 0x0800;

        [NativeTypeName("#define PyCF_TYPE_COMMENTS 0x1000")]
        public const int PyCF_TYPE_COMMENTS = 0x1000;

        [NativeTypeName("#define PyCF_ALLOW_TOP_LEVEL_AWAIT 0x2000")]
        public const int PyCF_ALLOW_TOP_LEVEL_AWAIT = 0x2000;

        [NativeTypeName("#define PyCF_ALLOW_INCOMPLETE_INPUT 0x4000")]
        public const int PyCF_ALLOW_INCOMPLETE_INPUT = 0x4000;

        [NativeTypeName("#define PyCF_COMPILE_MASK (PyCF_ONLY_AST | PyCF_ALLOW_TOP_LEVEL_AWAIT | \\\r\n                           PyCF_TYPE_COMMENTS | PyCF_DONT_IMPLY_DEDENT | \\\r\n                           PyCF_ALLOW_INCOMPLETE_INPUT)")]
        public const int PyCF_COMPILE_MASK = (0x0400 | 0x2000 | 0x1000 | 0x0200 | 0x4000);

        [NativeTypeName("#define FUTURE_NESTED_SCOPES \"nested_scopes\"")]
        public static ReadOnlySpan<byte> FUTURE_NESTED_SCOPES => "nested_scopes"u8;

        [NativeTypeName("#define FUTURE_GENERATORS \"generators\"")]
        public static ReadOnlySpan<byte> FUTURE_GENERATORS => "generators"u8;

        [NativeTypeName("#define FUTURE_DIVISION \"division\"")]
        public static ReadOnlySpan<byte> FUTURE_DIVISION => "division"u8;

        [NativeTypeName("#define FUTURE_ABSOLUTE_IMPORT \"absolute_import\"")]
        public static ReadOnlySpan<byte> FUTURE_ABSOLUTE_IMPORT => "absolute_import"u8;

        [NativeTypeName("#define FUTURE_WITH_STATEMENT \"with_statement\"")]
        public static ReadOnlySpan<byte> FUTURE_WITH_STATEMENT => "with_statement"u8;

        [NativeTypeName("#define FUTURE_PRINT_FUNCTION \"print_function\"")]
        public static ReadOnlySpan<byte> FUTURE_PRINT_FUNCTION => "print_function"u8;

        [NativeTypeName("#define FUTURE_UNICODE_LITERALS \"unicode_literals\"")]
        public static ReadOnlySpan<byte> FUTURE_UNICODE_LITERALS => "unicode_literals"u8;

        [NativeTypeName("#define FUTURE_BARRY_AS_BDFL \"barry_as_FLUFL\"")]
        public static ReadOnlySpan<byte> FUTURE_BARRY_AS_BDFL => "barry_as_FLUFL"u8;

        [NativeTypeName("#define FUTURE_GENERATOR_STOP \"generator_stop\"")]
        public static ReadOnlySpan<byte> FUTURE_GENERATOR_STOP => "generator_stop"u8;

        [NativeTypeName("#define FUTURE_ANNOTATIONS \"annotations\"")]
        public static ReadOnlySpan<byte> FUTURE_ANNOTATIONS => "annotations"u8;

        [NativeTypeName("#define PY_INVALID_STACK_EFFECT INT_MAX")]
        public const int PY_INVALID_STACK_EFFECT = 2147483647;

        [NativeTypeName("#define PYOS_STACK_MARGIN 2048")]
        public const int PYOS_STACK_MARGIN = 2048;

        [NativeTypeName("#define FVC_MASK 0x3")]
        public const int FVC_MASK = 0x3;

        [NativeTypeName("#define FVC_NONE 0x0")]
        public const int FVC_NONE = 0x0;

        [NativeTypeName("#define FVC_STR 0x1")]
        public const int FVC_STR = 0x1;

        [NativeTypeName("#define FVC_REPR 0x2")]
        public const int FVC_REPR = 0x2;

        [NativeTypeName("#define FVC_ASCII 0x3")]
        public const int FVC_ASCII = 0x3;

        [NativeTypeName("#define FVS_MASK 0x4")]
        public const int FVS_MASK = 0x4;

        [NativeTypeName("#define FVS_HAVE_SPEC 0x4")]
        public const int FVS_HAVE_SPEC = 0x4;

        [NativeTypeName("#define Py_DTSF_SIGN 0x01")]
        public const int Py_DTSF_SIGN = 0x01;

        [NativeTypeName("#define Py_DTSF_ADD_DOT_0 0x02")]
        public const int Py_DTSF_ADD_DOT_0 = 0x02;

        [NativeTypeName("#define Py_DTSF_ALT 0x04")]
        public const int Py_DTSF_ALT = 0x04;

        [NativeTypeName("#define Py_DTST_FINITE 0")]
        public const int Py_DTST_FINITE = 0;

        [NativeTypeName("#define Py_DTST_INFINITE 1")]
        public const int Py_DTST_INFINITE = 1;

        [NativeTypeName("#define Py_DTST_NAN 2")]
        public const int Py_DTST_NAN = 2;
    }
}
