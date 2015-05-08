using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				default: break;
			}
			
			return PC;
		}

		public Debugger(string assemblyCodes)
		{
			PC=0;
			scanner.scanning(assemblyCodes);
		}
		
		private void ADD()
		{
			int rtValue=fetchReg(scanner.IR[PC].rt);
			int rdValue=fetchReg(scanner.IR[PC].rd);
			updateReg(scanner.IR[PC].rs, rtValue+rdValue);
		}
	}
}