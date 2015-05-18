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
                Debug.WriteLine(string.Format("op: {0}", ins.op));
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
                case "beq":
                case "bne":
                case "lw":
                case "sw":
                    return Itype(ins);
                case "j":
                case "jal":
                    return Jtype(ins);
                case "jr":
                    return "000000" + getReg(ins.rs) + "000000000000000001000";

                case "sge":
                case "sgeu":
                case "sle":
                case "sleu":
                case "sne":
                case "seq": return sgleq(ins);

                case "sgt":
                case "sgtu":
                case "move":
                case "neg":
                case "negu":
                case "not": return pseudoR(ins);
                case "nop": return nop(ins);

                case "bgeu":
                case "bgt":
                case "bgtu":
                case "ble":
                case "bleu":
                case "blt":
                case "bltu": return bgleq(ins);

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
            return getOpFunc(ins.op) + getAddr(ins.addr);
        }

        private string getBinary(short imm)
        {
            char sign = (imm < 0) ? '1' : '0';
            string bin = Convert.ToString(imm, 2);
            Debug.WriteLine(string.Format("bin: {0}", bin));
            return bin.PadLeft(16, sign);
        }

        private string getAddr(int addr)
        {
            string bin = Convert.ToString(addr, 2).Substring(6, 26);
            return bin;
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

        private string sgleq(IS ins)
        {
            IS[] pse = new IS[4];
            pse[0].op = "bne"; pse[0].rs = ins.rt; pse[0].rt = ins.rs; pse[0].imme = 12;
            pse[1].op = "ori"; pse[1].rs = ins.rd; pse[1].rt = 0; pse[1].imme = 1;
            pse[2].op = "beq"; pse[2].rs = 0; pse[2].rt = 0; pse[2].imme = 8;

            string pse3 = "";
            switch (ins.op)
            {
                case "sge": pse[3].op = "slt"; pse[3].rd = ins.rd; pse[3].rs = ins.rt; pse[3].rt = ins.rs; goto case "Rtype";
                case "sgeu": pse[3].op = "sltu"; pse[3].rd = ins.rd; pse[3].rs = ins.rt; pse[3].rt = ins.rs; goto case "Rtype";
                case "sle": pse[3].op = "slt"; pse[3].rd = ins.rd; pse[3].rs = ins.rs; pse[3].rt = ins.rt; goto case "Rtype";
                case "sleu": pse[3].op = "sltu"; pse[3].rd = ins.rd; pse[3].rs = ins.rs; pse[3].rt = ins.rt; goto case "Rtype";
                case "Rtype": pse3 = Rtype(pse[3]); break;
                case "sne": pse[3].op = "ori"; pse[3].rs = ins.rd; pse[3].rt = 0; pse[3].imme = 0; goto case "Itype";
                case "seq": pse[3].op = "ori"; pse[3].rs = ins.rd; pse[3].rt = 0; pse[3].imme = 1; goto case "Itype";
                case "Itype": pse3 = Itype(pse[3]); break;
                default: break;
            }

            return String.Format("{0}\n{1}\n{2}\n{3}",
                                 Itype(pse[0]), Itype(pse[1]), Itype(pse[2]), pse3);
        }

        private string pseudoR(IS ins)
        {
            IS pse = new IS();
            switch (ins.op)
            {
                case "sgt": pse.op = "slt"; pse.rd = ins.rd; pse.rs = ins.rt; pse.rt = ins.rs; break;
                case "sgtu": pse.op = "sltu"; pse.rd = ins.rd; pse.rs = ins.rt; pse.rt = ins.rs; break;
                case "move": pse.op = "add"; pse.rd = ins.rd; pse.rs = ins.rs; pse.rt = 0; break;
                case "neg": pse.op = "sub"; pse.rd = ins.rd; pse.rs = 0; pse.rt = ins.rs; break;
                case "negu": pse.op = "subu"; pse.rd = ins.rd; pse.rs = 0; pse.rt = ins.rt; break;
                case "not": pse.op = "nor"; pse.rd = ins.rd; pse.rs = ins.rs; pse.rt = 0; break;
                default: break;
            }
            return Rtype(pse);
        }

        private string bgleq(IS ins)
        {
            IS[] pse = new IS[2];
            switch (ins.op)
            {
                case "bge": pse[0].op = "slt"; pse[0].rd = 1; pse[0].rs = ins.rs; pse[0].rt = ins.rt; goto case "beq";
                case "bgeu": pse[0].op = "slut"; pse[0].rd = 1; pse[0].rs = ins.rs; pse[0].rt = ins.rt; goto case "beq";
                case "ble": pse[0].op = "slt"; pse[0].rd = 1; pse[0].rs = ins.rt; pse[0].rt = ins.rs; goto case "beq";
                case "bleu": pse[0].op = "sltu"; pse[0].rd = 1; pse[0].rs = ins.rt; pse[0].rt = ins.rs; goto case "beq";
                case "beq": pse[1].op = "beq"; break;
                case "blt": pse[0].op = "slt"; pse[0].rd = 1; pse[0].rs = ins.rs; pse[0].rt = ins.rt; goto case "bne";
                case "bltu": pse[0].op = "sltu"; pse[0].rd = 1; pse[0].rs = ins.rs; pse[0].rt = ins.rt; goto case "bne";
                case "bgt": pse[0].op = "slt"; pse[0].rd = 1; pse[0].rs = ins.rt; pse[0].rt = ins.rs; goto case "bne";
                case "bgtu": pse[0].op = "slut"; pse[0].rd = 1; pse[0].rs = ins.rt; pse[0].rt = ins.rs; goto case "bne";
                case "bne": pse[1].op = "bne"; break;
                default: break;
            }
            pse[1].rs = 0; pse[1].rt = 1; pse[1].imme = ins.imme;
            return String.Format("{0}\n{1}", Rtype(pse[0]), Itype(pse[1]));
        }

        private string nop(IS ins)
        {
            IS pse = new IS();
            pse.op = "sll"; pse.rd = 0; pse.rt = 0; pse.imme = 0;
            return Sfttype(pse);
        }
    }

    public class AssemblerTest
    {
        public static void test()
        {
            string example = "test: bleu $s0,$t0,test\naddi $s0,$s1,1000002\nj test";
            Assembler asm = new Assembler();
            System.Console.WriteLine(asm.converting(example));
        }
    }
}
