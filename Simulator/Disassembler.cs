using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Disassembler
    {
        Dictionary<string, string> reg;

        public Disassembler()
        {
            initReg();
        }

        public string converting(string IR)
        {
            string ins="";
            switch (IR.Substring(0, 6))
            {
                case "000000": ins = Rtype(IR); break;
                case "100011": ins = "lw " + Offsettype(IR); break;
                case "101011": ins = "sw " + Offsettype(IR); break;
                case "000010": ins = "j " + Jtype(IR); break;
                case "000011": ins = "jal " + Jtype(IR); break;
                default: break;
            }
            return ins;
        }

        private string Rtype(string IR)
        {
            string op="";
            switch (IR.Substring(26, 6))
            {
                case "100000": op = "add"; break;
                case "100010": op = "sub"; break;
                case "101010": op = "slt"; break;
                default: break;
            }
            return op + " " + reg[IR.Substring(6, 5)] + "," + reg[IR.Substring(11, 5)] + "," + reg[IR.Substring(16, 5)];
        }

        private string Offsettype(string IR)
        {
            return reg[IR.Substring(6, 5)] + "," + Convert.ToString(getImm(IR.Substring(16, 16))) + "(" + reg[IR.Substring(11, 5)] + ")";
        }

        private string Jtype(string IR)
        {
            return Convert.ToString(getImm(IR.Substring(6, 26)));
        }

        private int getImm(string imm)
        {
            int mul = 1, num = 0;
            for (int i = imm.Length - 1; i > 0; i--)
            {
                switch (imm[i])
                {
                    case '1': num += mul; break;
                    case '0': break;
                }
                mul *= 2;
            }
            if (imm[0] == '1')
                num -= mul;
            return num;
        }

        private void initReg()
        {
            reg.Add("10000", "$s0");
            reg.Add("10001", "$s1");
            reg.Add("10010", "$s2");
            reg.Add("10011", "$s3");
            reg.Add("10100", "$s4");
            reg.Add("10101", "$s5");
            reg.Add("10110", "$s6");
            reg.Add("10111", "$s7");
        }
    }
}
