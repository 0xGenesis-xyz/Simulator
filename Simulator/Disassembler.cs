using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Disassembler
    {
        private Dictionary<string, string> reg=new Dictionary<string,string>();
        private Dictionary<string, string> opFunc = new Dictionary<string, string>();

        public Disassembler()
        {
            initReg();
            initOpFunc();
        }

        public string converting(string machineCodes)
        {
            List<string> assemblyCodes = new List<string>();
            string[] instructions=machineCodes.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string instruction in instructions)
            {
                assemblyCodes.Add(convertingIR(instruction));
                //assemblyCodes+=Environment.NewLine;
            }
            return string.Join(Environment.NewLine, assemblyCodes.ToArray());
        }

        public string convertingIR(string IR)
        {
            switch (opFunc[IR.Substring(0, 6)])
            {
                case "sll":    // R
                    return Rtype(IR);
                case "addi":
                case "andi":
                case "ori":
                case "beq":
                case "bne":
                case "slti":
                case "sltiu":
                    return Itype(IR);
                case "lw":
                case "sw":
                    return LStype(IR);
                case "j":
                case "jal":
                    return Jtype(IR);
                default:
                    return "";
            }
        }

        private string Rtype(string IR)
        {
            string op = opFunc[IR.Substring(26, 6)];
            switch (op)
            {
                case "j":    // srl
                    op = "srl";
                    goto case "sll";
                case "sll":
                    return op + " " + reg[IR.Substring(16, 5)] + ","
                        + reg[IR.Substring(11, 5)] + ","
                        + Convert.ToString(Convert.ToInt32(IR.Substring(21, 5), 2));
                case "addi":    // jr
                    return "jr " + reg[IR.Substring(6, 5)];
                case "sw":    // sltu
                    op = "sltu";
                    goto default;
                default:
                    return op + " " + reg[IR.Substring(16, 5)] + "," + reg[IR.Substring(6, 5)] + ","
                        + reg[IR.Substring(11, 5)];
            }
        }

        private string Itype(string IR)
        {
            string op = opFunc[IR.Substring(0, 6)];
            return op + " " + reg[IR.Substring(11, 5)] + "," + reg[IR.Substring(6, 5)] + ","
                + Convert.ToString(getImm(IR.Substring(16, 16)));
        }

        private string LStype(string IR)
        {
            string op = opFunc[IR.Substring(0, 6)];
            return op + " " + reg[IR.Substring(11, 5)] + ","
                + Convert.ToString(getImm(IR.Substring(16, 16)))
                + "(" + reg[IR.Substring(6, 5)] + ")";
        }

        private string Jtype(string IR)
        {
            return opFunc[IR.Substring(0, 6)] + " " + Convert.ToString(getImm(IR.Substring(6, 26)));
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

        private void initOpFunc()
        {
            opFunc["100000"] = "add";
            opFunc["100010"] = "sub";
            opFunc["100011"] = "lw";
            opFunc["100100"] = "and";
            opFunc["100101"] = "or";
            opFunc["100111"] = "nor";
            opFunc["001100"] = "andi";
            opFunc["001101"] = "ori";
            //opFunc["000000"] = "R";
            opFunc["000000"] = "sll";    // can be either opcode of R or func of sll
            opFunc["000100"] = "beq";
            opFunc["000101"] = "bne";
            opFunc["101010"] = "slt";
            //opFunc["101011"] = "sltu";
            opFunc["101011"] = "sw";    // can be either opcode of sw or func of sltu
            opFunc["001010"] = "slti";
            opFunc["001011"] = "sltiu";
            //opFunc["000010"] = "srl";
            opFunc["000010"] = "j";    // can be either opcode of j or func of srl
            //opFunc["001000"] = "jr";
            opFunc["001000"] = "addi";    // can be either opcode of jr or func of addi
            opFunc["000011"] = "jal";
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

    public class DisassemblerTest
    {
        public static void test()
        {
            Disassembler dasm = new Disassembler();
            string example = "00000001000100000000100000101011\n00010000000000011111111111111110\n10101110010100010000000001100100\n00100010001100000000001111101000\n00001011111111111111111111111011";
            System.Console.WriteLine(dasm.converting(example));
        }
    }
}
