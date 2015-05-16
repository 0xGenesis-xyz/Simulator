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
        int oldPC;
        int totalNum;
        string[] lines;
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
        }

        private void assemblingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembler assembler=new Assembler();
            textBoxMachineCode.Text=assembler.converting(textBoxAssemblyCode.Text);
        }

        private void disassemblingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disassembler disassembler=new Disassembler();
            textBoxAssemblyCode.Text=disassembler.converting(textBoxMachineCode.Text);
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            totalNum = textBoxAssemblyCode.Text.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length;
            debugger = new Debugger(textBoxAssemblyCode.Text);
            while (debugger.stepinto() < totalNum) ;
        }

        private void stepIntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PC=debugger.stepinto();
            if (PC>totalNum-1)
                stopToolStripMenuItem_Click(null, null);
            else
            {
                Debug.WriteLine(string.Format("step into: {0}", PC));
                recovery.CopyTo(lines, 0);
                string index = textBoxAssemblyCode.Lines[PC].PadRight(37) + "<--";
                lines[PC] = index;
                textBoxAssemblyCode.Lines = lines;
                oldPC = PC;
            }
        }
        
        private void startDebuggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Start debugging...");
            startDebuggingToolStripMenuItem.Enabled = false;
            stepIntoToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = true;

            debugger=new Debugger(textBoxAssemblyCode.Text);
            recovery=textBoxAssemblyCode.Lines;
            lines = textBoxAssemblyCode.Lines;
            totalNum = textBoxAssemblyCode.Text.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length;
            textBoxAssemblyCode.ReadOnly=true;

            string index=textBoxAssemblyCode.Lines[0].PadRight(37)+"<--";
            Debug.WriteLine(string.Format("index0: xxxx{0}xxxx", index));
            lines[0] = index;
            textBoxAssemblyCode.Lines = lines;
            //textBoxAssemblyCode.Lines[0]=new String(index.ToCharArray());
            Debug.WriteLine(string.Format("index0: xxxx{0}xxxx", textBoxAssemblyCode.Lines[0]));
            oldPC=0;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxAssemblyCode.Lines=recovery;
            textBoxAssemblyCode.ReadOnly=false;
            startDebuggingToolStripMenuItem.Enabled = true;
            stepIntoToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
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
            String newline=memAddr+"  "+Convert.ToString(value, 2).PadLeft(32, '0')+Environment.NewLine;
            textBoxMem.Lines[addr]=new String(newline.ToCharArray());
        }
    }
}
