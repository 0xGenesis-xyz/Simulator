using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator
{
	public struct IS
	{
		public string op;
		public byte rs,rt,rd;
		public short imme;
		public int addr;							//the number fill in the "address" part of machine code	
		public int loc;								//next location that PC should go to.
	}

	public class Scanner
	{
		public IS[] IR;
		private string[] instructions;
        Dictionary<string, byte> reg = new Dictionary<string, byte>();		//const
		Dictionary<string, int> label = new Dictionary<string, int>();
		
		List<string>[] SplitCode;
		
		private void AssignReg()
		{
		    reg["$zero"]=0;
			reg["$at"]=1;
			reg["$v0"]=2;
			reg["$v1"]=3;
			reg["$a0"]=4;
			reg["$a1"]=5;
			reg["$a2"]=6;
			reg["$a3"]=7;
			reg["$t0"]=8;
			reg["$t1"]=9;
			reg["$t2"]=10;
			reg["$t3"]=11;
			reg["$t4"]=12;
			reg["$t5"]=13;
			reg["$t6"]=14;
			reg["$t7"]=15;
			reg["$s0"]=16;
			reg["$s1"]=17;
			reg["$s2"]=18;
			reg["$s3"]=19;
			reg["$s4"]=20;
			reg["$s5"]=21;
			reg["$s6"]=22;
			reg["$s7"]=23;
			reg["$t8"]=24;
			reg["$t9"]=25;
			reg["$k0"]=26;
			reg["$k1"]=27;
			reg["$gp"]=28;
			reg["$sp"]=29;
			reg["$fp"]=30;
			reg["$ra"]=31;
		}

		private int validChar(char c)
		{
			if(c==' ') return 0;
    		if(c=='(') return 0;
    		if(c==')') return 0;
    		if(c==')') return 0;
    		if(c=='\n') return 0;
    		if(c==',') return 0;
    		if(c=='+') return 1;
    		if(c=='-') return 1;
    		if(c=='*') return 1;
    		if(c=='/') return 1;                                                                                                                                                             
    		if('0'<=c && c<='9') return 1;
    		if('a'<=c && c<= 'z') return 1;
    		if(c=='$') return 1;
    		if(c==':') return 3;
    		return 2;
		}
		
		int stoi(string s)
		{
		    int flag=1;//1-- +  2-- - 3-- * 4-- /
		    int ans=0;
		    int tmp=0;
		    foreach(char c in s)
		    {
		        if((c<='9')&&(c>='0'))
		        {
		            tmp*=10;
		            tmp+=c-'0';
		        } else {                                                                                                                                                                     
		            switch(flag)
		            {   
		                case 1:ans+=tmp; break;
		                case 2:ans-=tmp; break;
		                case 3:ans*=tmp; break;
		                case 4:ans/=tmp; break;
		            }
		            switch(c)
		            {   
		                case '+':flag=1;break;
		                case '-':flag=2;break;
		                case '*':flag=3;break;
		                case '/':flag=4;break;
		                default:throw new Exception("Compile Error! Wrong expression!");
		            }
		        }
		    }
		    switch(flag)
		    {   
		        case 1:ans+=tmp; break;
		        case 2:ans-=tmp; break;
		        case 3:ans*=tmp; break;
		        case 4:ans/=tmp; break;
		    }
		    return ans;
		}
		
		private List<string>SplitString(int loc,string Code)
		{
			List<string> ans=new List<string>();
			for(int i=0;i<Code.Length;)
			{
				while((i<Code.Length)&&(validChar(Code[i])==0)) i++;
				if(i==Code.Length) return ans;
				string s="";
				while((i<Code.Length)&&(validChar(Code[i])==1)) s=s+Code[i++];
				if((i<Code.Length)&&(validChar(Code[i])==3))
				{
					label[s]=loc;
					i++;
				} else ans.Add(s);
                if (i == Code.Length) break;
				if(validChar(Code[i])==2) throw new Exception("Compile Error!Invalid Code.");
			}
			return ans;
		}
		
		private IS Transform(ref List<string> lis,int next)
		{
			IS ans=new IS();
			ans.op=lis[0];
			ans.loc=ans.addr=next;
			switch(ans.op)
			{
				case "add":
				case "and":
				case "or":
				case "nor":
				case "slt":
				case "sltu":
				case "mulo":
				case "mulou":
				case "rem":
				case "remu":
				case "rol":
				case "ror":
				case "sge":
				case "sgeu":
				case "sgt":
				case "sgtu":
				case "sle":
				case "sleu":
				case "sne":
				case "seq":
				case "sub":ans.rd=reg[lis[1]];ans.rs=reg[lis[2]];ans.rt=reg[lis[3]];break;
				case "lw":
				case "sw":ans.rt=reg[lis[1]];ans.imme=(short)stoi(lis[2]);ans.rs=reg[lis[3]];break;
				case "addi":
				case "andi":
				case "ori":
				case "slti":
				case "sltiu":ans.rt=reg[lis[1]];ans.rs=reg[lis[2]];ans.imme=(short)stoi(lis[3]);break;
                case "mode":
				case "neg":
				case "negu":
				case "not":
				case "abs":ans.rd=reg[lis[1]];ans.rs=reg[lis[2]];break;
				case "sll":
                case "srl": ans.rd = reg[lis[1]]; ans.rt = reg[lis[2]]; ans.imme = (short)((stoi(lis[3]) << 6)&0x7ff); break;
				case "beq":
				case "bge":
				case "bgeu":
				case "bgt":
				case "bgtu":
				case "ble":
				case "bleu":
				case "blt":
				case "bltu":
				case "bne":ans.rs=reg[lis[1]];ans.rt=reg[lis[2]];ans.loc=ans.imme=(short)label[lis[3]];break;
				case "jal":
				case "b":
				case "j":ans.loc=label[lis[1]];break;
				case "jr":ans.rs=reg[lis[1]]; break;
				case "bnez":
				case "beqz":ans.rs=reg[lis[1]];ans.loc=label[lis[2]];break;
				case "nop":break;
			}
			ans.addr=ans.loc;
			return ans;
		}

		public void scanning(string assemblyCodes)
		{
			instructions=assemblyCodes.ToLower().Split(new string[]{"\n"}, StringSplitOptions.RemoveEmptyEntries);
			IR=new IS[instructions.Length];
			SplitCode=new List<string>[instructions.Length];
			int k=0;
			foreach(string s in instructions)
			{
				SplitCode[k]=SplitString(k,s);
				k++;
			}
			for(k=0;k<SplitCode.Length;k++)
				IR[k]=Transform(ref SplitCode[k],k+1);
		}

		public Scanner(string assemblyCodes)
		{
			AssignReg();
			scanning(assemblyCodes);
		}
		
		public Scanner()
		{
			AssignReg();
		}
	}
}
