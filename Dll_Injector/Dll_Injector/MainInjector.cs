using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Threading;
using System.Security.Permissions;
using System.Security.Principal;



namespace Dll_Injector
{
    public partial class MainInjector : Form
    {

        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }


        [DllImport("kernel32.dll", SetLastError = true)]

        public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool IsWow64Process2(IntPtr process, out ushort processMachine, out ushort nativeMachine);

        
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;

        public MainInjector()
        {
            InitializeComponent();
            DisplayDllFiles();

        }

        private void LoadProcesses()
        {
            Process[] processes = Process.GetProcesses();
            ProcessList.Items.Clear();
            foreach (var process in processes)
            {
                ProcessList.Items.Add(process.ProcessName);
            }
        }

        private void DisplayDllFiles()
        {
            string targetDirectory = Application.StartupPath;
            string[] dllFiles = Directory.GetFiles(targetDirectory, "*.dll");

            DLL_Folder.Items.Clear();
            foreach (string dllFile in dllFiles)
            {
                DLL_Folder.Items.Add(Path.GetFileName(dllFile));
            }
        }

        private void Inject_Button_Click(object sender, EventArgs e)
        {
            if (ProcessList.SelectedItem == null || DLL_Folder.SelectedItem == null)
            {
                MessageBox.Show("Please select a process and a DLL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dllPath = Path.Combine(Application.StartupPath, DLL_Folder.SelectedItem.ToString());
            if (!File.Exists(dllPath))
            {
                MessageBox.Show("\r\nDLL file was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string TargetName = ProcessList.SelectedItem.ToString();
            

            if (TargetName == null)
            {
                MessageBox.Show("Target process was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UIntPtr bytesWritten;

            Process TargetProcess = Process.GetProcessesByName(TargetName)[0];


            IntPtr hProcess = OpenProcess(ProcessAccessFlags.All, false, TargetProcess.Id);

            
            IntPtr loadLibAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            
            IntPtr allocatedMemoryAddr = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

            
            WriteProcessMemory(hProcess, allocatedMemoryAddr, Encoding.Default.GetBytes(dllPath), (uint)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);

            
            CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibAddr, allocatedMemoryAddr, 0, IntPtr.Zero);
        }

        private void UpdateProcessList_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void Select_Button_Click(object sender, EventArgs e)
        {
            if (ProcessList.SelectedItem != null)
            {
                TargetProcess.Text = ProcessList.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please select a process from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Import_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DLL Data (*.dll)|*.dll|Alle Dateien (*.*)|*.*",
                Title = "DLL:"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDllPath = openFileDialog.FileName;
                string targetDirectory = Application.StartupPath;
                string targetDllPath = Path.Combine(targetDirectory, Path.GetFileName(selectedDllPath));

                try
                {
                    File.Copy(selectedDllPath, targetDllPath, overwrite: true);
                    MessageBox.Show("DLL Succesfully imported", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayDllFiles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying DLL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Remove_Button_Click(object sender, EventArgs e)
        {
            if (DLL_Folder.SelectedItem != null)
            {
                string selectedDllName = DLL_Folder.SelectedItem.ToString();
                string dllPathToRemove = Path.Combine(Application.StartupPath, selectedDllName);

                try
                {
                    if (File.Exists(dllPathToRemove))
                    {
                        File.Delete(dllPathToRemove);
                        MessageBox.Show("\r\nDLL removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayDllFiles();
                    }
                    else
                    {
                        MessageBox.Show("The selected DLL does not exist in the target folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing DLL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a DLL from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TargetProcess_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
