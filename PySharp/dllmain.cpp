// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"

#define PYSHARPAPI __declspec(dllexport) HRESULT _stdcall
#define PYSHARPAPI_(t) __declspec(dllexport) t _stdcall

EXTERN_C_START

PYSHARPAPI PySharp_Initialize(const wchar_t* programName, const wchar_t* home, const wchar_t* path);

PYSHARPAPI PySharp_Run(const char* code, int32_t* result);

PYSHARPAPI PySharp_Import(const char* fileName, PyObject** result);

PYSHARPAPI PySharp_Dispose(PyObject* module);

PYSHARPAPI PySharp_GetAttrString(PyObject* obj, const char* name, PyObject** result);

PYSHARPAPI PySharp_CreateTuple(int size, PyObject** result);

PYSHARPAPI PySharp_SetItem(PyObject* tuple, int index, PyObject* value);

PYSHARPAPI PySharp_Call(PyObject* callable, PyObject* args, PyObject** result);

PYSHARPAPI_(PyTypeObject*) PySharp_GetType(PyObject* obj);

PYSHARPAPI_(const char*) PySharp_GetTypeName(PyTypeObject* type);

PYSHARPAPI_(PyObject*) PySharp_GetTypeModule(PyTypeObject* type);

PYSHARPAPI PySharp_UnicodeGetLength(PyObject* obj, size_t* length);

PYSHARPAPI PySharp_UnicodeAsWideChar(PyObject* obj, wchar_t* buffer, size_t length);

EXTERN_C_END

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}


PYSHARPAPI PySharp_Initialize(const wchar_t* programName, const wchar_t* home, const wchar_t* path)
{
    if (programName != nullptr)
    {
        Py_SetProgramName(programName);
    }
    if (home != nullptr)
    {
        Py_SetPythonHome(home);
    }
    if (path != nullptr)
    {
        Py_SetPath(path);
    }
    Py_InitializeEx(1);

    return S_OK;
}

PYSHARPAPI PySharp_Run(const char* code, int32_t* result)
{
    *result = PyRun_SimpleString(code);
    return S_OK;
}

PYSHARPAPI PySharp_Import(const char* fileName, PyObject** result)
{
    auto name = PyUnicode_DecodeFSDefault(fileName);
    auto module = PyImport_Import(name);
    Py_DECREF(name);
    *result = module;
    if (module == nullptr)
    {
        if (PyErr_Occurred())
        {
            PyErr_Print();
        }
        return E_FAIL;
    }
    return S_OK;
}

PYSHARPAPI PySharp_GetAttrString(PyObject* obj, const char* name, PyObject** result)
{
    if (obj == nullptr)
    {
        return E_FAIL;
    }
    if (name == nullptr)
    {
        return E_FAIL;
    }

    PyObject* attr = PyObject_GetAttrString(obj, name);
    if (attr == nullptr)
    {
        if (PyErr_Occurred())
        {
            PyErr_Print();
        }
        return E_FAIL;
    }
    *result = attr;
    return S_OK;
}


PYSHARPAPI PySharp_Dispose(PyObject* module)
{
    if (module == nullptr)
    {
        return E_FAIL;
    }
    Py_DECREF(module);
    return S_OK;
}

PYSHARPAPI PySharp_CreateTuple(int size, PyObject** result)
{
    PyObject* tuple = PyTuple_New(size);
    if (tuple == nullptr)
    {
        *result = nullptr;
        return E_FAIL;
    }
    *result = tuple;
    return S_OK;
}

PYSHARPAPI PySharp_SetItem(PyObject* tuple, int index, PyObject* value)
{
    if (tuple == nullptr)
    {
        return E_FAIL;
    }
    PyTuple_SetItem(tuple, index, value);
    return S_OK;
}

PYSHARPAPI PySharp_Call(PyObject* callable, PyObject* args, PyObject** result)
{
    if (callable == nullptr)
    {
        return E_FAIL;
    }
    *result = PyObject_CallObject(callable, args);
    return S_OK;
}

PYSHARPAPI_(PyTypeObject*) PySharp_GetType(PyObject* obj)
{
    return Py_TYPE(obj);
}


PYSHARPAPI_(const char *) PySharp_GetTypeName(PyTypeObject* type)
{
    return type->tp_name;
}

PYSHARPAPI_(PyObject*) PySharp_GetTypeModule(PyTypeObject* type)
{
    return PyType_GetModule(type);
}

PYSHARPAPI PySharp_UnicodeGetLength(PyObject* obj, size_t* length)
{
    if (obj == nullptr)
    {
        return E_FAIL;
    }
    if (!PyUnicode_Check(obj))
    {
        return E_FAIL;
    }
    *length = PyUnicode_GetLength(obj);
    return S_OK;
}

PYSHARPAPI PySharp_UnicodeAsWideChar(PyObject* obj, wchar_t* buffer, size_t length)
{
    if (obj == nullptr)
    {
        return E_FAIL;
    }
    if (!PyUnicode_Check(obj))
    {
        return E_FAIL;
    }
    auto size = PyUnicode_AsWideChar(obj, buffer, length);
    if (size < 0)
    {
        return E_FAIL;
    }
    return S_OK;
}