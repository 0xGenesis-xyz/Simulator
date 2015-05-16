using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Disassembler
    {
        Dictionary<string, string> reg=new Dictionary<string,string>();

        public Disassembler()
        {
            initReg();
        }
        
        public string converting(string machineCodes)
        {
            string assemblyCodes="";
            string[] instructions=machineCodes.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string instruction in instructions)
            {
                assemblyCodes+=convertingIR(instruction);
                assemblyCodes+=Environment.NewLine;
            }
            return assemblyCodes;
        }

        public string convertingIR(string IR)
        {
            string assemblyCode="";
            switch (IR.Substring(0, 6))
            {
                case "000000": assemblyCode = Rtype(IR); break;
                case "100011": assemblyCode = "lw " + Offsettype(IR); break;
                case "101011": assemblyCode = "sw " + Offsettype(IR); break;
                case "000010": assemblyCode = "j " + Jtype(IR); break;
                case "000011": assemblyCode = "jal " + Jtype(IR); break;
                default: break;
            }
            return assemblyCode;
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
            reg.Add("00000", "$zero");
            reg.Add("00001", "$at");
            reg.Add("00010", "$v0");
            reg.Add("00011", "$v1");
            reg.Add("00100", "$a0");
            reg.Add("00101", "$a1");
            reg.Add("00110", "$a2");
            reg.Add("00111", "$a3");
            reg.Add("01000", "$t0");
            reg.Add("01001", "$t1");
            reg.Add("01010", "$t2");
            reg.Add("01011", "$t3");
            reg.Add("01100", "$t4");
            reg.Add("01101", "$t5");
            reg.Add("01110", "$t6");
            reg.Add("01111", "$t7");
            reg.Add("10000", "$s0");
            reg.Add("10001", "$s1");
            reg.Add("10010", "$s2");
            reg.Add("10011", "$s3");
            reg.Add("10100", "$s4");
            reg.Add("10101", "$s5");
            reg.Add("10110", "$s6");
            reg.Add("10111", "$s7");
            reg.Add("11000", "$t8");
            reg.Add("11001", "$t9");
            reg.Add("11010", "$k0");
            reg.Add("11011", "$k1");
            reg.Add("11100", "$gp");
            reg.Add("11101", "$sp");
            reg.Add("11110", "$fp");
            reg.Add("11111", "$ra");
        }
    }
}
