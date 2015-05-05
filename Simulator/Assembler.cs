using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Simulator
{
    class Assembler
    {
        Dictionary<string, string> reg=new Dictionary<string,string>();

        public Assembler()
        {
            initReg();
        }

        public string converting(string IR)
		{
			string machineCode="";
			string[] split=IR.Split(' ');
			switch (split[0])
			{
				case "add": machineCode="000000"+Rtype(split[1])+"00000100000"; break;
				case "sub": machineCode="000000"+Rtype(split[1])+"00000100010"; break;
				case "slt": machineCode="000000"+Rtype(split[1])+"00000101010"; break;
                case "lw": machineCode = "100011" + Offsettype(split[1]); break;
                case "sw": machineCode = "101011" + Offsettype(split[1]); break;
				default: break;
			}
            return machineCode;
		}
		
		private string Rtype(string _regs)
		{
			string[] regs=_regs.Split(',');
            return reg[regs[0]]+reg[regs[1]]+reg[regs[2]];
		}

        private string Offsettype(string regsAndimm)
        {
            regsAndimm = regsAndimm.Replace('(', ',');
            regsAndimm = regsAndimm.TrimEnd(')');
            string[] regs = regsAndimm.Split(',');
            return reg[regs[0]]+reg[regs[2]]+getBinary(Convert.ToInt16(regs[1]));
        }

        private string getBinary(short imm)
        {
            char sign = (imm < 0) ? '1' : '0';
            string bin = Convert.ToString(imm, 2);
            Debug.WriteLine(string.Format("bin: {0}", bin));
            return bin.PadLeft(16, sign);
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
