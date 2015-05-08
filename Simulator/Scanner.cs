using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator
{
	public struct IS
	{
		public string op;
		public byte rs,rt,rd;
		short imme;
		int addr;							//the line number to goto
	}

	public class Scanner
	{
		public readonly IS[] IR;
		Dictionary<string, int> reg;		//const
		Dictionary<string, int> label;

		public void scanning(string assemblyCodes)
		{
			string[] instructions=assemblyCodes.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}