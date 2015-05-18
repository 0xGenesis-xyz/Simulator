using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Simulator
{
    public partial class Form1 : Form
    {
        static TextBox[] textBoxRegs=new TextBox[32];
        static TextBox textBoxMem=new TextBox();
        static int[] memory=new int[128];
        int newPC, oldPC;
        int totalNum;
        static string[] lines;
        string[] recovery;
        Debugger debugger;
        
        public Form1()
        {
            InitializeComponent();
            
            foreach (Control textbox in this.Controls)
            {
//                Debug.WriteLine(string.Format("controls: {0}", textbox.Name));
                if (textbox.Name.IndexOf("textBoxR") != -1)
                {
                    textBoxRegs[Convert.ToInt16(textbox.Name.Substring(8,2))] = (TextBox)textbox;
                    Debug.WriteLine(string.Format("textBoxRegs {0}: {1}", textbox.Name, textBoxRegs[Convert.ToInt16(textbox.Name.Substring(8))].Text));
                }
                if (textbox.Name=="textBoxMemory")
                    textBoxMem=(TextBox)textbox;
            }
            Debug.WriteLine(string.Format("controls end"));
            for (int i=0;i<128;i++)
            {
                memory[i]=0;
                textBoxMem.Text += "0x" + (i * 4).ToString("X4") + "  " + Convert.ToString(0).PadLeft(32, '0') + Environment.NewLine;
            }
            lines = textBoxMem.Lines;
        }

        private void assemblingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembler assembler=new Assembler();
            textBoxMachineCode.Text=assembler.converting(richTextBoxAssemblyCode.Text);
        }

        private void disassemblingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disassembler disassembler=new Disassembler();
            richTextBoxAssemblyCode.Text = disassembler.converting(textBoxMachineCode.Text);
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count=0;
            totalNum = richTextBoxAssemblyCode.Text.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries).Length;
            debugger = new Debugger(richTextBoxAssemblyCode.Text);
            Debug.WriteLine(string.Format("start running"));
            while (debugger.stepinto() < totalNum) 
                Debug.WriteLine(string.Format("step into: {0}", count++));
            Debug.WriteLine(string.Format("stop running"));
        }

        private void stepIntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oldPC = newPC;
            newPC=debugger.stepinto();
            if (newPC > totalNum - 1)
            {
                newPC = oldPC;
                stopToolStripMenuItem_Click(null, null);
            }
            else
            {
                Debug.WriteLine(string.Format("step into: {0}", newPC));
 //               recovery.CopyTo(lines, 0);
 //               string index = richTextBoxAssemblyCode.Lines[PC].PadRight(37) + "<--";
 //               lines[PC] = index;
 //               richTextBoxAssemblyCode.Lines = lines;
                richTextBoxAssemblyCode.Select(richTextBoxAssemblyCode.GetFirstCharIndexFromLine(newPC), richTextBoxAssemblyCode.Lines[newPC].Length);
                richTextBoxAssemblyCode.SelectionBackColor = Color.LightBlue;
                richTextBoxAssemblyCode.Select(richTextBoxAssemblyCode.GetFirstCharIndexFromLine(oldPC), richTextBoxAssemblyCode.Lines[oldPC].Length);
                richTextBoxAssemblyCode.SelectionBackColor = Color.White;
                richTextBoxAssemblyCode.Select(0, 0);
//                oldPC = newPC;
            }
        }
        
        private void startDebuggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Start debugging...");
            startDebuggingToolStripMenuItem.Enabled = false;
            stepIntoToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = true;

            debugger = new Debugger(richTextBoxAssemblyCode.Text);
            recovery = richTextBoxAssemblyCode.Lines;
//            lines = richTextBoxAssemblyCode.Lines;
//            totalNum = richTextBoxAssemblyCode.Text.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length;
            totalNum = richTextBoxAssemblyCode.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            richTextBoxAssemblyCode.ReadOnly = true;
            Debug.WriteLine(string.Format("total Num: {0}", totalNum));
//            Debug.WriteLine(string.Format("text: {0}", recovery[3]));

//            string index = richTextBoxAssemblyCode.Lines[0].PadRight(37) + "<--";
//            Debug.WriteLine(string.Format("index0: xxxx{0}xxxx", index));
//            lines[0] = index;
//            richTextBoxAssemblyCode.Lines = lines;
//            richTextBoxAssemblyCode.Lines[0] = richTextBoxAssemblyCode.Lines[0].Remove(richTextBoxAssemblyCode.Lines[0].Length-1).PadRight(45)+'\n';
            richTextBoxAssemblyCode.Select(richTextBoxAssemblyCode.GetFirstCharIndexFromLine(0), richTextBoxAssemblyCode.Lines[0].Length);
            richTextBoxAssemblyCode.SelectionBackColor = Color.LightBlue;
            richTextBoxAssemblyCode.Select(0, 0);
            //textBoxAssemblyCode.Lines[0]=new String(index.ToCharArray());
            Debug.WriteLine(string.Format("index0: xxxx{0}xxxx", richTextBoxAssemblyCode.Lines[0]));
            newPC=0;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
//            richTextBoxAssemblyCode.Lines = recovery;
            richTextBoxAssemblyCode.Select(richTextBoxAssemblyCode.GetFirstCharIndexFromLine(newPC), richTextBoxAssemblyCode.Lines[newPC].Length);
            richTextBoxAssemblyCode.SelectionBackColor = Color.White;
            richTextBoxAssemblyCode.Select(0, 0);
            richTextBoxAssemblyCode.ReadOnly = false;
            startDebuggingToolStripMenuItem.Enabled = true;
            stepIntoToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog openFile = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile.DefaultExt = "*.txt";
            openFile.Filter = "TXT Files|*.txt";

            // Determine whether the user selected a file from the OpenFileDialog.
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                richTextBoxAssemblyCode.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile.DefaultExt = "*.txt";
            saveFile.Filter = "TXT Files|*.txt";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                richTextBoxAssemblyCode.SaveFile(saveFile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxAssemblyCode.Clear();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine if last operation can be undone in text box.   
            if (richTextBoxAssemblyCode.CanUndo == true)
            {
                // Undo the last operation.
                richTextBoxAssemblyCode.Undo();
                // Clear the undo buffer to prevent last action from being redone.
                richTextBoxAssemblyCode.ClearUndo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ensure that text is currently selected in the text box.   
            if (richTextBoxAssemblyCode.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                richTextBoxAssemblyCode.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ensure that text is selected in the text box.   
            if (richTextBoxAssemblyCode.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                richTextBoxAssemblyCode.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine if there is any text in the Clipboard to paste into the text box.
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (richTextBoxAssemblyCode.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        richTextBoxAssemblyCode.SelectionStart = richTextBoxAssemblyCode.SelectionStart + richTextBoxAssemblyCode.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                richTextBoxAssemblyCode.Paste();
            }
        }

        public static int fetchReg(int reg)
        {
            return Convert.ToInt32(textBoxRegs[reg].Text);
        }
        
        public static int fetchMem(int mem)
        {
            return memory[mem];
        }
        
        public static void updateReg(int reg, int value)
        {
            textBoxRegs[reg].Text=Convert.ToString(value);
        }
        
        public static void updateMem(int addr, int value)
        {
            memory[addr]=value;

            String memAddr = "0x" + (addr * 4).ToString("X4");
            String newline=memAddr+"  "+Convert.ToString(value, 2).PadLeft(32, '0');
            lines[addr] = newline;
            textBoxMem.Lines=lines;
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form helpForm = new help();
            helpForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutForm = new about();
            aboutForm.Show();
        }
    }
}
