#include<Windows.h>
#include "pch.h"


extern "C" __declspec(dllexport) bool WINAPI DllMain(HINSTANCE hInstDll, DWORD fdwReason, LPVOID lpvReserved)
{
    switch (fdwReason)
    {
    case DLL_PROCESS_ATTACH:
    {
        MessageBox(NULL, L"Injection Succesfully!", L"From Dll", MB_OK);
        break;
    }

    case DLL_PROCESS_DETACH:

        break;

    case DLL_THREAD_ATTACH:

        break;

    case DLL_THREAD_DETACH:

        break;
    }
    return true;
}