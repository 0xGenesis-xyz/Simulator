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
        public Form1()
        {
            InitializeComponent();
        }

        private void assemblingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembler assembler=new Assembler();
            string[] instructions=textBoxAssemblyCode.Text.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            textBoxMachineCode.Text="";
            foreach (string instruction in instructions)
            {
                textBoxMachineCode.Text+=assembler.converting(instruction);
                textBoxMachineCode.Text+=Environment.NewLine;
            }
        }

        private void disassemblingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disassembler disassembler=new Disassembler();
            string[] instructions=textBoxMachineCode.Text.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            textBoxAssemblyCode.Text="";
            foreach (string instruction in instructions)
            {
                textBoxAssemblyCode.Text+=disassembler.converting(instruction);
                textBoxAssemblyCode.Text+=Environment.NewLine;
            }
        }
    }
}
