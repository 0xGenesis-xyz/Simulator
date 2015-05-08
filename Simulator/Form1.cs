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
        static int[] memory=new int[128];
        Debugger debugger;
        
        public Form1()
        {
            InitializeComponent();
            
            foreach (Control textbox in this.Controls)
                if (textbox.Name.IndexOf("textBoxR")!=-1)
                    textBoxRegs[Convert.ToInt16(textbox.Name.Substring(8))]=(TextBox)textbox;
            for (int i=0;i<128;i++)
                memory[i]=0;
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
            textBoxMemory.Text="0x"+addr.ToString("X4")+"  "+Convert.ToString(value, 2);
        }
    }
}
