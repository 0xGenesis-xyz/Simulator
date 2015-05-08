using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator
{
    public partial class Form1 : Form
    {
        static TextBox[] textBoxRegs=new TextBox[32];
        static TextBox textBoxMem=new TextBox();
        static int[] memory=new int[128];
        int oldPC;
        string[] recovery;
        Debugger debugger;
        
        public Form1()
        {
            InitializeComponent();
            
            foreach (Control textbox in this.Controls)
            {
                if (textbox.Name.IndexOf("textBoxR")!=-1)
                    textBoxRegs[Convert.ToInt16(textbox.Name.Substring(8))]=(TextBox)textbox;
                if (textbox.Name=="textBoxMemory")
                    textBoxMem=(TextBox)textbox;
            }
            for (int i=0;i<128;i++)
            {
                memory[i]=0;
                updateMem(i, 0);
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

        private void stepIntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PC=debugger.stepinto();
            textBoxAssemblyCode.Lines[oldPC]=new String(recovery[oldPC].ToCharArray());
            string index=textBoxAssemblyCode.Lines[PC].PadRight(37)+"<--";
            textBoxAssemblyCode.Lines[PC]=new String(index.ToCharArray());
            oldPC=PC;
        }
        
        private void startDebuggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debugger=new Debugger(textBoxAssemblyCode.Text);
            recovery=textBoxAssemblyCode.Text.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            textBoxAssemblyCode.ReadOnly=true;
            string index=textBoxAssemblyCode.Lines[0].PadRight(37)+"<--";
            textBoxAssemblyCode.Lines[0]=new String(index.ToCharArray());
            oldPC=0;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i=0;i<recovery.Count();i++)
                textBoxAssemblyCode.Lines[i]=new String(recovery[i].ToCharArray());
            textBoxAssemblyCode.ReadOnly=false;
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
