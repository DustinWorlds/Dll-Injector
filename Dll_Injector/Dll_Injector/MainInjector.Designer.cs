namespace Dll_Injector
{
    partial class MainInjector
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Inject_Button = new Button();
            TargetProcess = new TextBox();
            DLL_Folder = new ListBox();
            Select_Button = new Button();
            Import_Button = new Button();
            Remove_Button = new Button();
            label1 = new Label();
            label2 = new Label();
            ProcessList = new ListBox();
            UpdateProcessList = new Button();
            SuspendLayout();
            // 
            // Inject_Button
            // 
            Inject_Button.Location = new Point(174, 214);
            Inject_Button.Name = "Inject_Button";
            Inject_Button.Size = new Size(75, 23);
            Inject_Button.TabIndex = 0;
            Inject_Button.Text = "Inject";
            Inject_Button.UseVisualStyleBackColor = true;
            Inject_Button.Click += Inject_Button_Click;
            // 
            // TargetProcess
            // 
            TargetProcess.Location = new Point(93, 34);
            TargetProcess.Name = "TargetProcess";
            TargetProcess.Size = new Size(237, 23);
            TargetProcess.TabIndex = 1;
            TargetProcess.TextChanged += TargetProcess_TextChanged;
            // 
            // DLL_Folder
            // 
            DLL_Folder.FormattingEnabled = true;
            DLL_Folder.ItemHeight = 15;
            DLL_Folder.Location = new Point(12, 84);
            DLL_Folder.Name = "DLL_Folder";
            DLL_Folder.ScrollAlwaysVisible = true;
            DLL_Folder.Size = new Size(318, 124);
            DLL_Folder.TabIndex = 2;
            // 
            // Select_Button
            // 
            Select_Button.Location = new Point(369, 33);
            Select_Button.Name = "Select_Button";
            Select_Button.Size = new Size(75, 23);
            Select_Button.TabIndex = 3;
            Select_Button.Text = "Select";
            Select_Button.UseVisualStyleBackColor = true;
            Select_Button.Click += Select_Button_Click;
            // 
            // Import_Button
            // 
            Import_Button.Location = new Point(93, 214);
            Import_Button.Name = "Import_Button";
            Import_Button.Size = new Size(75, 23);
            Import_Button.TabIndex = 4;
            Import_Button.Text = "Import";
            Import_Button.UseVisualStyleBackColor = true;
            Import_Button.Click += Import_Button_Click;
            // 
            // Remove_Button
            // 
            Remove_Button.Location = new Point(12, 214);
            Remove_Button.Name = "Remove_Button";
            Remove_Button.Size = new Size(75, 23);
            Remove_Button.TabIndex = 5;
            Remove_Button.Text = "Remove";
            Remove_Button.UseVisualStyleBackColor = true;
            Remove_Button.Click += Remove_Button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(167, 16);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 7;
            label1.Text = "Target Process";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 66);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 8;
            label2.Text = "DLL Folder";
            // 
            // ProcessList
            // 
            ProcessList.FormattingEnabled = true;
            ProcessList.ItemHeight = 15;
            ProcessList.Location = new Point(336, 84);
            ProcessList.Name = "ProcessList";
            ProcessList.Size = new Size(141, 124);
            ProcessList.TabIndex = 9;
            // 
            // UpdateProcessList
            // 
            UpdateProcessList.Location = new Point(402, 214);
            UpdateProcessList.Name = "UpdateProcessList";
            UpdateProcessList.Size = new Size(75, 23);
            UpdateProcessList.TabIndex = 10;
            UpdateProcessList.Text = "Update";
            UpdateProcessList.UseVisualStyleBackColor = true;
            UpdateProcessList.Click += UpdateProcessList_Click;
            // 
            // MainInjector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 251);
            Controls.Add(UpdateProcessList);
            Controls.Add(ProcessList);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Remove_Button);
            Controls.Add(Import_Button);
            Controls.Add(Select_Button);
            Controls.Add(DLL_Folder);
            Controls.Add(TargetProcess);
            Controls.Add(Inject_Button);
            Name = "MainInjector";
            Text = "Dll Injector v1.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Inject_Button;
        private TextBox TargetProcess;
        private ListBox DLL_Folder;
        private Button Select_Button;
        private Button Import_Button;
        private Button Remove_Button;
        private Label label1;
        private Label label2;
        private ListBox ProcessList;
        private Button UpdateProcessList;
    }
}
