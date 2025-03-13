# DLL Injector (C# Windows)
A Windows-based DLL injector written in C#. This tool allows users to inject DLL files into running processes using Windows API functions. The program provides a graphical user interface (GUI) for selecting processes and DLLs for injection.

#Features
Process Selection: List and select running processes for DLL injection.
DLL Management: Import, display, and remove DLL files within the application.
Remote Thread Injection: Uses Windows API (OpenProcess, VirtualAllocEx, WriteProcessMemory, and CreateRemoteThread) to inject DLLs.
User-Friendly GUI: Simple and intuitive interface for easy operation.
# Requirements
Windows OS
.NET Framework or .NET Core
Administrator privileges for process access
# Installation & Usage
Compile the project using Visual Studio or another C# IDE.
Run the application as Administrator.
Select a target process from the list.
Choose a DLL to inject.
Click "Inject" to load the DLL into the process.
⚠ Note: Unauthorized DLL injection can be illegal or harmful. Use this tool only for ethical and educational purposes.

![alt text](https://github.com/DustinWorlds/Dll-Injector/blob/main/Dll%20Injector%20Gif.gif)
