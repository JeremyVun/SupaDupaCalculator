using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public static class NodeFac
	{
		public static Node Create(char c) {
			switch (c) {
				case '+': return new AddOp();
				case '-': return new SubOp();
				case '*': return new MulOp();
				case '/': return new DivOp();
				case '%': return new ModOp();
				case '^': return new PowOp();
				case '(':
				case ')':
					return new BracketNode(new string(new char[] { c } ));
				default: return new NullOp();
			}
		}
	}
}
