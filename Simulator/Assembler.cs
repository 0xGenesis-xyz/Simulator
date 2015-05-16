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
        Scanner scanner;
        private Dictionary<string, byte> opFunc = new Dictionary<string, byte>();

        public Assembler()
        {
            //initReg();
            initOpFunc();
            scanner = new Scanner();
        }

        public string converting(string assemblyCodes)
        {
            List<string> machineCodes = new List<string>();
            scanner.scanning(assemblyCodes);

            foreach (IS ins in scanner.IR)
            {
                machineCodes.Add(convertingIR(ins));
            }
            return string.Join(Environment.NewLine, machineCodes.ToArray());
        }

        public string convertingIR(IS ins)
        {
            switch (ins.op)
            {
                case "add":
                case "sub":
                case "and":
                case "or":
                case "nor":
                case "slt":
                case "sltu":
                    return Rtype(ins);
                case "sll":
                case "srl":
                    return Sfttype(ins);
                case "addi":
                case "andi":
                case "ori":
                case "slti":
                case "sltiu":
                case "lw":
                case "sw":
                    return Itype(ins);
                case "j":
                case "jal":
                    return Jtype(ins);
                case "jr":
                    return "000000" + getReg(ins.rs) + "000000000000000001000";
                default:
                    return "";
            }
        }

        private string Rtype(IS ins)
        {
            // ins format: "INS   rd, rs, rt"
            // binary format: "OP RS RT RD SFT FUNC"
            return "000000" + getReg(ins.rs) + getReg(ins.rt) + getReg(ins.rd)
                + "00000" + getOpFunc(ins.op);
        }

        private string Itype(IS ins)
        {
            // regsAndImm format: "INS   rt, rs, imm"
            // binary format: "OP RS RT IMM"
            return getOpFunc(ins.op) + getReg(ins.rs) + getReg(ins.rt) + getBinary(ins.imme);
        }

        private string Sfttype(IS ins)
        {
            return "00000000000" + getReg(ins.rt) + getReg(ins.rd) + getReg((byte)ins.imme)
                + getOpFunc(ins.op);
        }

        private string Jtype(IS ins)
        {
            return getOpFunc(ins.op) + getAddr(ins.loc);
        }

        private string getBinary(short imm)
        {
            char sign = (imm < 0) ? '1' : '0';
            string bin = Convert.ToString(imm, 2);
            Debug.WriteLine(string.Format("bin: {0}", bin));
            return bin.PadLeft(16, sign);
        }

        private string getAddr(int loc)
        {
            char sign = (loc < 0) ? '1' : '0';
            string bin = Convert.ToString(loc, 2);
            return bin.PadLeft(26, sign);
        }

        private string getReg(byte reg)
        {
            return Convert.ToString(reg, 2).PadLeft(5, '0');
        }

        private string getOpFunc(string opOrFunc)
        {
            return Convert.ToString(opFunc[opOrFunc], 2).PadLeft(6, '0');
        }

        private void initOpFunc()
        {
            opFunc["add"] = 0x20;
            opFunc["sub"] = 0x22;
            opFunc["addi"] = 0x08;
            opFunc["lw"] = 0x23;
            opFunc["sw"] = 0x2B;
            opFunc["and"] = 0x24;
            opFunc["or"] = 0x25;
            opFunc["nor"] = 0x27;
            opFunc["andi"] = 0x0C;
            opFunc["ori"] = 0x0D;
            opFunc["sll"] = 0x00;
            opFunc["srl"] = 0x02;
            opFunc["beq"] = 0x04;
            opFunc["bne"] = 0x05;
            opFunc["slt"] = 0x2A;
            opFunc["sltu"] = 0x2B;
            opFunc["slti"] = 0x0A;
            opFunc["sltiu"] = 0x0B;
            opFunc["j"] = 0x02;
            opFunc["jr"] = 0x08;
            opFunc["jal"] = 0x03;
        }
    }

    public class AssemblerTest
    {
        public static void test()
        {
            string example = "srl $s0,$t0,4\nlw $s1, 123($s2)\nsw $s1, -1($s2)";
            Assembler asm = new Assembler();
            System.Console.WriteLine(asm.converting(example));
        }
    }
}
