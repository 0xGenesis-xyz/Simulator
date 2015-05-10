using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Simulator
{
	public delegate int FetchRegEventHandler(int reg);
	public delegate int FetchMemEventHandler(int addr);
	public delegate void UpdateRegEventHandler(int reg, int value);
	public delegate void UpdateMemEventHandler(int addr, int value);
	
	public class Debugger
	{
		Scanner scanner;
		int PC;
		int value;
		FetchRegEventHandler fetchReg=new FetchRegEventHandler(Form1.fetchReg);
		FetchMemEventHandler fetchMem=new FetchMemEventHandler(Form1.fetchMem);
		UpdateRegEventHandler updateReg=new UpdateRegEventHandler(Form1.updateReg);
		UpdateMemEventHandler updateMem=new UpdateMemEventHandler(Form1.updateMem);

		public int stepinto()
		{
			switch (scanner.IR[PC].op)
			{
				case "add":
					ADD();
					PC++;
					break;
                case "sub":
                    SUB();
                    PC++;
                    break;
                case "addi":
                    ADDI();
                    PC++;
                    break;
                case "lw":
                    LW();
                    PC++;
                    break;
                case "sw":
                    SW();
                    PC++;
                    break;
                case "and":
                    AND();
                    PC++;
                    break;
                case "or":
                    OR();
                    PC++;
                    break;
                case "nor":
                    NOR();
                    PC++;
                    break;
                case "andi":
                    ANDI();
                    PC++;
                    break;
                case "ori":
                    ORI();
                    PC++;
                    break;
                case "sll":
                    SLL();
                    PC++;
                    break;
                case "srl":
                    SRL();
                    PC++;
                    break;
                case "beq":
                    BEQ();
                    PC++;
                    break;
                case "bne":
                    BNE();
                    PC++;
                    break;
                case "slt":
                    SLT();
                    PC++;
                    break;
                case "sltu":
                    SLTU();
                    PC++;
                    break;
                case "slti":
                    SLTI();
                    PC++;
                    break;
                case "sltiu":
                    SLTIU();
                    PC++;
                    break;
                case "j":
                    J();
                    PC++;
                    break;
                case "jr":
                    JR();
                    PC++;
                    break;
                case "jal":
                    JAL();
                    PC++;
                    break;
                case "abs":
                    ABS();
                    PC++;
                    break;
                case "b":
                    B();
                    PC++;
                    break;
                case "beqz":
                    BEQZ();
                    PC++;
                    break;
                case "bge":
                    BGE();
                    PC++;
                    break;
                case "bgeu":
                    BGEU();
                    PC++;
                    break;
                case "bgt":
                    BGT();
                    PC++;
                    break;
                case "bgtu":
                    BGTU();
                    PC++;
                    break;
                case "ble":
                    BLE();
                    PC++;
                    break;
                case "bleu":
                    BLEU();
                    PC++;
                    break;
                case "blt":
                    BLTU();
                    PC++;
                    break;
                case "bnez":
                    BNEZ();
                    PC++;
                    break;
                case "la":
                    LA();
                    PC++;
                    break;
                case "move":
                    MOVE();
                    PC++;
                    break;
                case "mulo":
                    MULO();
                    PC++;
                    break;
                case "mulou":
                    MULOU();
                    PC++;
                    break;
                case "neg":
                    NEG();
                    PC++;
                    break;
                case "negu":
                    NEGU();
                    PC++;
                    break;
                case "nop":
                    NOP();
                    PC++;
                    break;
                case "not":
                    NOT();
                    PC++;
                    break;
                case "rem":
                    REM();
                    PC++;
                    break;
                case "remu":
                    REMU();
                    PC++;
                    break;
                case "rol":
                    ROL();
                    PC++;
                    break;
                case "ror":
                    ROR();
                    PC++;
                    break;
                case "sge":
                    SGE();
                    PC++;
                    break;
                case "sgeu":
                    SGEU();
                    PC++;
                    break;
                case "sgt":
                    SGT();
                    PC++;
                    break;
                case "sgtu":
                    SGTU();
                    PC++;
                    break;
                case "sle":
                    SLE();
                    PC++;
                    break;
                case "sleu":
                    SLEU();
                    PC++;
                    break;
                case "sne":
                    SNE();
                    PC++;
                    break;
                case "seq":
                    SEQ();
                    PC++;
                    break;
                default: break;
			}
//            PC++;
			return PC;
		}

		public Debugger(string assemblyCodes)
		{
			PC=0;
            scanner = new Scanner();
			scanner.scanning(assemblyCodes);
            for (int i = 0; i < scanner.IR.Length; i++)
                Debug.WriteLine(string.Format("op: {0} rs: {1} rt: {2} rd: {3} imme: {4} addr: {5} loc: {6}", scanner.IR[i].op, scanner.IR[i].rs, scanner.IR[i].rt, scanner.IR[i].rd, scanner.IR[i].imme, scanner.IR[i].addr, scanner.IR[i].loc));
		}
		
		private void ADD()
		{
			int rtValue=fetchReg(scanner.IR[PC].rt);
			int rsValue=fetchReg(scanner.IR[PC].rs);
			updateReg(scanner.IR[PC].rd, rtValue+rsValue);
		}
        private void SUB()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, rsValue - rtValue);
        }
        private void ADDI()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int immeValue = scanner.IR[PC].imme;
            updateReg(scanner.IR[PC].rt, rsValue + immeValue);
        }
        private void LW()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int immeValue = scanner.IR[PC].imme;
            int memValue = fetchMem(immeValue + rsValue);
            updateReg(scanner.IR[PC].rt, memValue);
        }
        private void SW()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int immeValue = scanner.IR[PC].imme;
            updateMem(rsValue + immeValue, rtValue);
        }   
        private void AND()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, rtValue & rsValue);
        }
        private void OR()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, rtValue | rsValue);
        }
        private void NOR()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, ~ (rtValue | rsValue));
        }
        private void ANDI()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int immeValue = scanner.IR[PC].imme;
            updateReg(scanner.IR[PC].rt, rsValue & immeValue);
        }
        private void ORI()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int immeValue = scanner.IR[PC].imme;
            updateReg(scanner.IR[PC].rt, rsValue | immeValue);
        }
        private void SLL()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint immeValue = (ushort)scanner.IR[PC].imme;
            uint a;
            for (uint i = 0; i < immeValue; i++)
            {
                rtValue /= 2;
            }
                updateReg(scanner.IR[PC].rd, (int)rtValue );
        }
        private void SRL()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int immeValue = scanner.IR[PC].imme;
            updateReg(scanner.IR[PC].rd, rtValue << immeValue);
        }
        private void BEQ()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rtValue == rsValue) PC = locValue - 1;
        }
        private void BNE()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rtValue != rsValue) PC = locValue - 1;
        }
        private void SLT()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            if(rsValue < rtValue) 
                updateReg(scanner.IR[PC].rd, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
        private void SLTU()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            if (rsValue < rtValue)
                updateReg(scanner.IR[PC].rd, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
        private void SLTI()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int immeValue = scanner.IR[PC].imme;
            if (rsValue < immeValue)
                updateReg(scanner.IR[PC].rt, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
        private void SLTIU()
        {
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            uint immeValue = (ushort)scanner.IR[PC].imme;
            if (rsValue < immeValue)
                updateReg(scanner.IR[PC].rt, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
        private void J()
        {
            int locValue = scanner.IR[PC].loc;
            PC = locValue - 1;
        }
        private void JR()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            PC = (rsValue / 4) - 1;
        }
        private void JAL()
        {
            int addrValue = scanner.IR[PC].addr;
            updateReg(31, PC * 4 + 4);
            PC = (addrValue / 4) - 1;
        }
        private void ABS()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            if (rsValue < 0)
                rsValue = -rsValue;
            updateReg(scanner.IR[PC].rd, rsValue);            
        }
        private void B()
        {
            int locValue = scanner.IR[PC].loc;
            PC = locValue - 1;
        }
        private void BEQZ()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rsValue == 0) PC = locValue + 1;
        }
        private void BGE()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rsValue >= rtValue) PC = locValue - 1;
        }
        private void BGEU()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rtValue >= rsValue) PC = locValue - 1;
        }
        private void BGT()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rsValue > rtValue) PC = locValue - 1;
        }
        private void BGTU()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rtValue > rsValue) PC = locValue - 1;
        }
        private void BLE()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rsValue <= rtValue) PC = locValue - 1;
        }
        private void BLEU()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rsValue <= rtValue) PC = locValue - 1;
        }
        private void BLT()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rsValue < rtValue) PC = locValue - 1;
        }
        private void BLTU()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rsValue < rtValue) PC = locValue - 1;
        }
        private void BNEZ()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int locValue = scanner.IR[PC].loc;
            if (rsValue != 0) PC = locValue - 1;
        }
        private void LA()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            int immeValue = fetchReg(scanner.IR[PC].imme);
            updateReg(scanner.IR[PC].rd, rsValue + immeValue);
        }
        private void MOVE()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, rsValue);
        }
        private void MULO()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, rsValue * rtValue);
        }
        private void MULOU()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, (int)(rsValue * rtValue));
        }
        private void NEG()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, -rsValue);
        }
        private void NEGU() //no overflow tag, which is same to NEG
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, -rsValue);
        }
        private void NOP()
        {
            int zeroValue = fetchReg(0);
            updateReg(0, 0 >> 0);
        }
        private void NOT()
        {
            int rsValue = fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, ~rsValue);
        }
        private void REM()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, rsValue % rtValue);
        }
        private void REMU()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            updateReg(scanner.IR[PC].rd, (int)(rsValue % rtValue));
        }
        private void ROL()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            uint rdValue = 0;
            for (uint i = 0; i < rtValue; i++)
            {
                rdValue *= 2;
                if (rsValue < 0)
                    rdValue += 1;
                else
                    rdValue += 0;
                rsValue *= 2;

            }
            rdValue += rsValue;
            updateReg(scanner.IR[PC].rd, (int)rdValue );
        }
        private void ROR()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            uint rdValue = 0;
            for (uint i = 0; i < rtValue; i++)
            {
                rdValue /= 2;
                if (rsValue % 2 == 1)
                    rdValue += 0x80000000;
                else
                    rdValue += 0;
                rsValue /= 2;

            }
            rdValue += rsValue;
            updateReg(scanner.IR[PC].rd, (int)rdValue);
        }
        private void SGE()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            if (rsValue >= rtValue)
                updateReg(scanner.IR[PC].rd, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
        private void SGEU()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            if (rsValue >= rtValue)
                updateReg(scanner.IR[PC].rd, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
        private void SGT()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            if (rsValue > rtValue)
                updateReg(scanner.IR[PC].rd, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
        private void SGTU()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            if (rsValue > rtValue)
                updateReg(scanner.IR[PC].rd, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
        private void SLE()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            if (rsValue <= rtValue)
                updateReg(scanner.IR[PC].rd, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
        private void SLEU()
        {
            uint rtValue = (uint)fetchReg(scanner.IR[PC].rt);
            uint rsValue = (uint)fetchReg(scanner.IR[PC].rs);
            if (rsValue <= rtValue)
                updateReg(scanner.IR[PC].rd, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
        private void SNE()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            if (rsValue != rtValue)
                updateReg(scanner.IR[PC].rd, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
        private void SEQ()
        {
            int rtValue = fetchReg(scanner.IR[PC].rt);
            int rsValue = fetchReg(scanner.IR[PC].rs);
            if (rsValue == rtValue)
                updateReg(scanner.IR[PC].rd, 1);
            else
                updateReg(scanner.IR[PC].rd, 0);
        }
	}
}