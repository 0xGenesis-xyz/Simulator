using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    class Assembler
    {
        Dictionary<string, string> reg;

        public Assembler()
        {
            initReg();
        }

        public string converting(string IR)
		{
			string ins="";
			string[] split=IR.Split(' ');
			switch (split[0])
			{
				case "add": ins="000000"+Rtype(split[1])+"00000100000"; break;
				case "sub": ins="000000"+Rtype(split[1])+"00000100010"; break;
				case "slt": ins="000000"+Rtype(split[1])+"00000101010"; break;
				case "lw": ins=""; break;
				case "sw": ins=""; break;
				default: break;
			}
            return ins;
		}
		
		private string Rtype(string _regs)
		{
			string[] regs=_regs.Split(',');
            return reg[regs[2]]+reg[regs[0]]+reg[regs[1]];
		}
		
		private string Offset(string regsAndimm)
        {
            regsAndimm = regsAndimm.Replace('(', ',');
            regsAndimm = regsAndimm.TrimEnd(')');
            string[] regs = regsAndimm.Split(',');
            return reg[regs[2]]+reg[regs[0]]+getBinary(Convert.ToInt32(regs[1]));
        }

        private string getBinary(int imm)
        {
            string bin = Convert.ToString(imm, 2);
            return bin.PadLeft(16, bin[0]);
        }

        private void initReg()
        {
            reg.Add("$s0", "10000");
            reg.Add("$s1", "10001");
            reg.Add("$s2", "10010");
            reg.Add("$s3", "10011");
            reg.Add("$s4", "10100");
            reg.Add("$s5", "10101");
            reg.Add("$s6", "10110");
            reg.Add("$s7", "10111");
        }
    }
}
