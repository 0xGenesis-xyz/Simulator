namespace Simulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bUILDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assemblingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disassemblingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEBUGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDebuggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepIntoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxAssemblyCode = new System.Windows.Forms.TextBox();
            this.textBoxMachineCode = new System.Windows.Forms.TextBox();
            this.textBoxR03 = new System.Windows.Forms.TextBox();
            this.labelR03 = new System.Windows.Forms.Label();
            this.labelR02 = new System.Windows.Forms.Label();
            this.textBoxR02 = new System.Windows.Forms.TextBox();
            this.labelR01 = new System.Windows.Forms.Label();
            this.textBoxR01 = new System.Windows.Forms.TextBox();
            this.labelR00 = new System.Windows.Forms.Label();
            this.textBoxR00 = new System.Windows.Forms.TextBox();
            this.labelAssemblyCode = new System.Windows.Forms.Label();
            this.labelMachineCode = new System.Windows.Forms.Label();
            this.labelR04 = new System.Windows.Forms.Label();
            this.textBoxR04 = new System.Windows.Forms.TextBox();
            this.labelR05 = new System.Windows.Forms.Label();
            this.textBoxR05 = new System.Windows.Forms.TextBox();
            this.labelR06 = new System.Windows.Forms.Label();
            this.textBoxR06 = new System.Windows.Forms.TextBox();
            this.labelR07 = new System.Windows.Forms.Label();
            this.textBoxR07 = new System.Windows.Forms.TextBox();
            this.labelR08 = new System.Windows.Forms.Label();
            this.textBoxR08 = new System.Windows.Forms.TextBox();
            this.labelR09 = new System.Windows.Forms.Label();
            this.textBoxR09 = new System.Windows.Forms.TextBox();
            this.labelR10 = new System.Windows.Forms.Label();
            this.textBoxR10 = new System.Windows.Forms.TextBox();
            this.labelR11 = new System.Windows.Forms.Label();
            this.textBoxR11 = new System.Windows.Forms.TextBox();
            this.labelR12 = new System.Windows.Forms.Label();
            this.textBoxR12 = new System.Windows.Forms.TextBox();
            this.labelR13 = new System.Windows.Forms.Label();
            this.textBoxR13 = new System.Windows.Forms.TextBox();
            this.labelR14 = new System.Windows.Forms.Label();
            this.textBoxR14 = new System.Windows.Forms.TextBox();
            this.labelR15 = new System.Windows.Forms.Label();
            this.textBoxR15 = new System.Windows.Forms.TextBox();
            this.groupBoxRegs = new System.Windows.Forms.GroupBox();
            this.textBoxMemory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.eDITToolStripMenuItem,
            this.bUILDToolStripMenuItem,
            this.dEBUGToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(43, 21);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.eDITToolStripMenuItem.Text = "EDIT";
            // 
            // bUILDToolStripMenuItem
            // 
            this.bUILDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assemblingToolStripMenuItem,
            this.disassemblingToolStripMenuItem});
            this.bUILDToolStripMenuItem.Name = "bUILDToolStripMenuItem";
            this.bUILDToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.bUILDToolStripMenuItem.Text = "BUILD";
            // 
            // assemblingToolStripMenuItem
            // 
            this.assemblingToolStripMenuItem.Name = "assemblingToolStripMenuItem";
            this.assemblingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.assemblingToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.assemblingToolStripMenuItem.Text = "Assembling";
            this.assemblingToolStripMenuItem.Click += new System.EventHandler(this.assemblingToolStripMenuItem_Click);
            // 
            // disassemblingToolStripMenuItem
            // 
            this.disassemblingToolStripMenuItem.Name = "disassemblingToolStripMenuItem";
            this.disassemblingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.disassemblingToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.disassemblingToolStripMenuItem.Text = "Disassembling";
            this.disassemblingToolStripMenuItem.Click += new System.EventHandler(this.disassemblingToolStripMenuItem_Click);
            // 
            // dEBUGToolStripMenuItem
            // 
            this.dEBUGToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.startDebuggingToolStripMenuItem,
            this.stepIntoToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.dEBUGToolStripMenuItem.Name = "dEBUGToolStripMenuItem";
            this.dEBUGToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.dEBUGToolStripMenuItem.Size = new System.Drawing.Size(62, 21);
            this.dEBUGToolStripMenuItem.Text = "DEBUG";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.runToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // startDebuggingToolStripMenuItem
            // 
            this.startDebuggingToolStripMenuItem.Name = "startDebuggingToolStripMenuItem";
            this.startDebuggingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.startDebuggingToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.startDebuggingToolStripMenuItem.Text = "Start Debugging";
            this.startDebuggingToolStripMenuItem.Click += new System.EventHandler(this.startDebuggingToolStripMenuItem_Click);
            // 
            // stepIntoToolStripMenuItem
            // 
            this.stepIntoToolStripMenuItem.Name = "stepIntoToolStripMenuItem";
            this.stepIntoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.stepIntoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.stepIntoToolStripMenuItem.Text = "Step Into";
            this.stepIntoToolStripMenuItem.Click += new System.EventHandler(this.stepIntoToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(49, 21);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // textBoxAssemblyCode
            // 
            this.textBoxAssemblyCode.Location = new System.Drawing.Point(23, 51);
            this.textBoxAssemblyCode.Multiline = true;
            this.textBoxAssemblyCode.Name = "textBoxAssemblyCode";
            this.textBoxAssemblyCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAssemblyCode.Size = new System.Drawing.Size(300, 400);
            this.textBoxAssemblyCode.TabIndex = 1;
            // 
            // textBoxMachineCode
            // 
            this.textBoxMachineCode.Location = new System.Drawing.Point(349, 51);
            this.textBoxMachineCode.Multiline = true;
            this.textBoxMachineCode.Name = "textBoxMachineCode";
            this.textBoxMachineCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMachineCode.Size = new System.Drawing.Size(300, 400);
            this.textBoxMachineCode.TabIndex = 2;
            // 
            // textBoxR03
            // 
            this.textBoxR03.Location = new System.Drawing.Point(73, 562);
            this.textBoxR03.Name = "textBoxR03";
            this.textBoxR03.Size = new System.Drawing.Size(109, 21);
            this.textBoxR03.TabIndex = 5;
            // 
            // labelR03
            // 
            this.labelR03.AutoSize = true;
            this.labelR03.Location = new System.Drawing.Point(31, 567);
            this.labelR03.Name = "labelR03";
            this.labelR03.Size = new System.Drawing.Size(35, 12);
            this.labelR03.TabIndex = 6;
            this.labelR03.Text = "$s3 =";
            // 
            // labelR02
            // 
            this.labelR02.AutoSize = true;
            this.labelR02.Location = new System.Drawing.Point(31, 540);
            this.labelR02.Name = "labelR02";
            this.labelR02.Size = new System.Drawing.Size(35, 12);
            this.labelR02.TabIndex = 8;
            this.labelR02.Text = "$s2 =";
            // 
            // textBoxR02
            // 
            this.textBoxR02.Location = new System.Drawing.Point(73, 535);
            this.textBoxR02.Name = "textBoxR02";
            this.textBoxR02.Size = new System.Drawing.Size(109, 21);
            this.textBoxR02.TabIndex = 7;
            // 
            // labelR01
            // 
            this.labelR01.AutoSize = true;
            this.labelR01.Location = new System.Drawing.Point(31, 513);
            this.labelR01.Name = "labelR01";
            this.labelR01.Size = new System.Drawing.Size(35, 12);
            this.labelR01.TabIndex = 10;
            this.labelR01.Text = "$s1 =";
            // 
            // textBoxR01
            // 
            this.textBoxR01.Location = new System.Drawing.Point(73, 508);
            this.textBoxR01.Name = "textBoxR01";
            this.textBoxR01.Size = new System.Drawing.Size(109, 21);
            this.textBoxR01.TabIndex = 9;
            // 
            // labelR00
            // 
            this.labelR00.AutoSize = true;
            this.labelR00.Location = new System.Drawing.Point(31, 486);
            this.labelR00.Name = "labelR00";
            this.labelR00.Size = new System.Drawing.Size(35, 12);
            this.labelR00.TabIndex = 12;
            this.labelR00.Text = "$s0 =";
            // 
            // textBoxR00
            // 
            this.textBoxR00.Location = new System.Drawing.Point(73, 481);
            this.textBoxR00.Name = "textBoxR00";
            this.textBoxR00.Size = new System.Drawing.Size(109, 21);
            this.textBoxR00.TabIndex = 11;
            this.textBoxR00.Text = "123456";
            // 
            // labelAssemblyCode
            // 
            this.labelAssemblyCode.AutoSize = true;
            this.labelAssemblyCode.Location = new System.Drawing.Point(118, 34);
            this.labelAssemblyCode.Name = "labelAssemblyCode";
            this.labelAssemblyCode.Size = new System.Drawing.Size(83, 12);
            this.labelAssemblyCode.TabIndex = 13;
            this.labelAssemblyCode.Text = "Assembly Code";
            // 
            // labelMachineCode
            // 
            this.labelMachineCode.AutoSize = true;
            this.labelMachineCode.Location = new System.Drawing.Point(458, 34);
            this.labelMachineCode.Name = "labelMachineCode";
            this.labelMachineCode.Size = new System.Drawing.Size(77, 12);
            this.labelMachineCode.TabIndex = 14;
            this.labelMachineCode.Text = "Machine Code";
            // 
            // labelR04
            // 
            this.labelR04.AutoSize = true;
            this.labelR04.Location = new System.Drawing.Point(209, 486);
            this.labelR04.Name = "labelR04";
            this.labelR04.Size = new System.Drawing.Size(35, 12);
            this.labelR04.TabIndex = 22;
            this.labelR04.Text = "$s4 =";
            // 
            // textBoxR04
            // 
            this.textBoxR04.Location = new System.Drawing.Point(251, 481);
            this.textBoxR04.Name = "textBoxR04";
            this.textBoxR04.Size = new System.Drawing.Size(109, 21);
            this.textBoxR04.TabIndex = 21;
            // 
            // labelR05
            // 
            this.labelR05.AutoSize = true;
            this.labelR05.Location = new System.Drawing.Point(209, 513);
            this.labelR05.Name = "labelR05";
            this.labelR05.Size = new System.Drawing.Size(35, 12);
            this.labelR05.TabIndex = 20;
            this.labelR05.Text = "$s5 =";
            // 
            // textBoxR05
            // 
            this.textBoxR05.Location = new System.Drawing.Point(251, 508);
            this.textBoxR05.Name = "textBoxR05";
            this.textBoxR05.Size = new System.Drawing.Size(109, 21);
            this.textBoxR05.TabIndex = 19;
            // 
            // labelR06
            // 
            this.labelR06.AutoSize = true;
            this.labelR06.Location = new System.Drawing.Point(209, 540);
            this.labelR06.Name = "labelR06";
            this.labelR06.Size = new System.Drawing.Size(35, 12);
            this.labelR06.TabIndex = 18;
            this.labelR06.Text = "$s6 =";
            // 
            // textBoxR06
            // 
            this.textBoxR06.Location = new System.Drawing.Point(251, 535);
            this.textBoxR06.Name = "textBoxR06";
            this.textBoxR06.Size = new System.Drawing.Size(109, 21);
            this.textBoxR06.TabIndex = 17;
            // 
            // labelR07
            // 
            this.labelR07.AutoSize = true;
            this.labelR07.Location = new System.Drawing.Point(209, 567);
            this.labelR07.Name = "labelR07";
            this.labelR07.Size = new System.Drawing.Size(35, 12);
            this.labelR07.TabIndex = 16;
            this.labelR07.Text = "$s7 =";
            // 
            // textBoxR07
            // 
            this.textBoxR07.Location = new System.Drawing.Point(251, 562);
            this.textBoxR07.Name = "textBoxR07";
            this.textBoxR07.Size = new System.Drawing.Size(109, 21);
            this.textBoxR07.TabIndex = 15;
            // 
            // labelR08
            // 
            this.labelR08.AutoSize = true;
            this.labelR08.Location = new System.Drawing.Point(384, 486);
            this.labelR08.Name = "labelR08";
            this.labelR08.Size = new System.Drawing.Size(35, 12);
            this.labelR08.TabIndex = 30;
            this.labelR08.Text = "$s0 =";
            // 
            // textBoxR08
            // 
            this.textBoxR08.Location = new System.Drawing.Point(426, 481);
            this.textBoxR08.Name = "textBoxR08";
            this.textBoxR08.Size = new System.Drawing.Size(109, 21);
            this.textBoxR08.TabIndex = 29;
            // 
            // labelR09
            // 
            this.labelR09.AutoSize = true;
            this.labelR09.Location = new System.Drawing.Point(384, 513);
            this.labelR09.Name = "labelR09";
            this.labelR09.Size = new System.Drawing.Size(35, 12);
            this.labelR09.TabIndex = 28;
            this.labelR09.Text = "$s1 =";
            // 
            // textBoxR09
            // 
            this.textBoxR09.Location = new System.Drawing.Point(426, 508);
            this.textBoxR09.Name = "textBoxR09";
            this.textBoxR09.Size = new System.Drawing.Size(109, 21);
            this.textBoxR09.TabIndex = 27;
            // 
            // labelR10
            // 
            this.labelR10.AutoSize = true;
            this.labelR10.Location = new System.Drawing.Point(384, 540);
            this.labelR10.Name = "labelR10";
            this.labelR10.Size = new System.Drawing.Size(35, 12);
            this.labelR10.TabIndex = 26;
            this.labelR10.Text = "$s2 =";
            // 
            // textBoxR10
            // 
            this.textBoxR10.Location = new System.Drawing.Point(426, 535);
            this.textBoxR10.Name = "textBoxR10";
            this.textBoxR10.Size = new System.Drawing.Size(109, 21);
            this.textBoxR10.TabIndex = 25;
            // 
            // labelR11
            // 
            this.labelR11.AutoSize = true;
            this.labelR11.Location = new System.Drawing.Point(384, 567);
            this.labelR11.Name = "labelR11";
            this.labelR11.Size = new System.Drawing.Size(35, 12);
            this.labelR11.TabIndex = 24;
            this.labelR11.Text = "$s3 =";
            // 
            // textBoxR11
            // 
            this.textBoxR11.Location = new System.Drawing.Point(426, 562);
            this.textBoxR11.Name = "textBoxR11";
            this.textBoxR11.Size = new System.Drawing.Size(109, 21);
            this.textBoxR11.TabIndex = 23;
            // 
            // labelR12
            // 
            this.labelR12.AutoSize = true;
            this.labelR12.Location = new System.Drawing.Point(562, 486);
            this.labelR12.Name = "labelR12";
            this.labelR12.Size = new System.Drawing.Size(35, 12);
            this.labelR12.TabIndex = 38;
            this.labelR12.Text = "$s0 =";
            // 
            // textBoxR12
            // 
            this.textBoxR12.Location = new System.Drawing.Point(604, 481);
            this.textBoxR12.Name = "textBoxR12";
            this.textBoxR12.Size = new System.Drawing.Size(109, 21);
            this.textBoxR12.TabIndex = 37;
            // 
            // labelR13
            // 
            this.labelR13.AutoSize = true;
            this.labelR13.Location = new System.Drawing.Point(562, 513);
            this.labelR13.Name = "labelR13";
            this.labelR13.Size = new System.Drawing.Size(35, 12);
            this.labelR13.TabIndex = 36;
            this.labelR13.Text = "$s1 =";
            // 
            // textBoxR13
            // 
            this.textBoxR13.Location = new System.Drawing.Point(604, 508);
            this.textBoxR13.Name = "textBoxR13";
            this.textBoxR13.Size = new System.Drawing.Size(109, 21);
            this.textBoxR13.TabIndex = 35;
            // 
            // labelR14
            // 
            this.labelR14.AutoSize = true;
            this.labelR14.Location = new System.Drawing.Point(562, 540);
            this.labelR14.Name = "labelR14";
            this.labelR14.Size = new System.Drawing.Size(35, 12);
            this.labelR14.TabIndex = 34;
            this.labelR14.Text = "$s2 =";
            // 
            // textBoxR14
            // 
            this.textBoxR14.Location = new System.Drawing.Point(604, 535);
            this.textBoxR14.Name = "textBoxR14";
            this.textBoxR14.Size = new System.Drawing.Size(109, 21);
            this.textBoxR14.TabIndex = 33;
            // 
            // labelR15
            // 
            this.labelR15.AutoSize = true;
            this.labelR15.Location = new System.Drawing.Point(562, 567);
            this.labelR15.Name = "labelR15";
            this.labelR15.Size = new System.Drawing.Size(35, 12);
            this.labelR15.TabIndex = 32;
            this.labelR15.Text = "$s3 =";
            // 
            // textBoxR15
            // 
            this.textBoxR15.Location = new System.Drawing.Point(604, 562);
            this.textBoxR15.Name = "textBoxR15";
            this.textBoxR15.Size = new System.Drawing.Size(109, 21);
            this.textBoxR15.TabIndex = 31;
            // 
            // groupBoxRegs
            // 
            this.groupBoxRegs.Location = new System.Drawing.Point(8, 462);
            this.groupBoxRegs.Name = "groupBoxRegs";
            this.groupBoxRegs.Size = new System.Drawing.Size(719, 129);
            this.groupBoxRegs.TabIndex = 43;
            this.groupBoxRegs.TabStop = false;
            this.groupBoxRegs.Text = "Register File";
            // 
            // textBoxMemory
            // 
            this.textBoxMemory.Location = new System.Drawing.Point(678, 51);
            this.textBoxMemory.Multiline = true;
            this.textBoxMemory.Name = "textBoxMemory";
            this.textBoxMemory.ReadOnly = true;
            this.textBoxMemory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMemory.Size = new System.Drawing.Size(254, 400);
            this.textBoxMemory.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(787, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "Memory";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 601);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMemory);
            this.Controls.Add(this.labelR12);
            this.Controls.Add(this.textBoxR12);
            this.Controls.Add(this.labelR13);
            this.Controls.Add(this.textBoxR13);
            this.Controls.Add(this.labelR14);
            this.Controls.Add(this.textBoxR14);
            this.Controls.Add(this.labelR15);
            this.Controls.Add(this.textBoxR15);
            this.Controls.Add(this.labelR08);
            this.Controls.Add(this.textBoxR08);
            this.Controls.Add(this.labelR09);
            this.Controls.Add(this.textBoxR09);
            this.Controls.Add(this.labelR10);
            this.Controls.Add(this.textBoxR10);
            this.Controls.Add(this.labelR11);
            this.Controls.Add(this.textBoxR11);
            this.Controls.Add(this.labelR04);
            this.Controls.Add(this.textBoxR04);
            this.Controls.Add(this.labelR05);
            this.Controls.Add(this.textBoxR05);
            this.Controls.Add(this.labelR06);
            this.Controls.Add(this.textBoxR06);
            this.Controls.Add(this.labelR07);
            this.Controls.Add(this.textBoxR07);
            this.Controls.Add(this.labelMachineCode);
            this.Controls.Add(this.labelAssemblyCode);
            this.Controls.Add(this.labelR00);
            this.Controls.Add(this.textBoxR00);
            this.Controls.Add(this.labelR01);
            this.Controls.Add(this.textBoxR01);
            this.Controls.Add(this.labelR02);
            this.Controls.Add(this.textBoxR02);
            this.Controls.Add(this.labelR03);
            this.Controls.Add(this.textBoxR03);
            this.Controls.Add(this.textBoxMachineCode);
            this.Controls.Add(this.textBoxAssemblyCode);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBoxRegs);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Simulator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxAssemblyCode;
        private System.Windows.Forms.TextBox textBoxMachineCode;
        private System.Windows.Forms.TextBox textBoxR03;
        private System.Windows.Forms.Label labelR03;
        private System.Windows.Forms.Label labelR02;
        private System.Windows.Forms.TextBox textBoxR02;
        private System.Windows.Forms.Label labelR01;
        private System.Windows.Forms.TextBox textBoxR01;
        private System.Windows.Forms.Label labelR00;
        private System.Windows.Forms.TextBox textBoxR00;
        private System.Windows.Forms.Label labelAssemblyCode;
        private System.Windows.Forms.Label labelMachineCode;
        private System.Windows.Forms.Label labelR04;
        private System.Windows.Forms.TextBox textBoxR04;
        private System.Windows.Forms.Label labelR05;
        private System.Windows.Forms.TextBox textBoxR05;
        private System.Windows.Forms.Label labelR06;
        private System.Windows.Forms.TextBox textBoxR06;
        private System.Windows.Forms.Label labelR07;
        private System.Windows.Forms.TextBox textBoxR07;
        private System.Windows.Forms.Label labelR08;
        private System.Windows.Forms.TextBox textBoxR08;
        private System.Windows.Forms.Label labelR09;
        private System.Windows.Forms.TextBox textBoxR09;
        private System.Windows.Forms.Label labelR10;
        private System.Windows.Forms.TextBox textBoxR10;
        private System.Windows.Forms.Label labelR11;
        private System.Windows.Forms.TextBox textBoxR11;
        private System.Windows.Forms.Label labelR12;
        private System.Windows.Forms.TextBox textBoxR12;
        private System.Windows.Forms.Label labelR13;
        private System.Windows.Forms.TextBox textBoxR13;
        private System.Windows.Forms.Label labelR14;
        private System.Windows.Forms.TextBox textBoxR14;
        private System.Windows.Forms.Label labelR15;
        private System.Windows.Forms.TextBox textBoxR15;
        private System.Windows.Forms.ToolStripMenuItem bUILDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assemblingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disassemblingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEBUGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepIntoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDebuggingToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxRegs;
        private System.Windows.Forms.TextBox textBoxMemory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
    }
}

