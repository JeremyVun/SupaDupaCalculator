using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public static class OpPrecedence
	{
		public static string[] prio1 = new string[3] { "*", "/", "%" };
		public static string[] prio2 = new string[2] { "+", "-" };
	}
}
