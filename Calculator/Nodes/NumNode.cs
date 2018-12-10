using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public class NumNode : Node
	{
		public double Num { get; private set; }

		public NumNode(double n) : base(n.ToString()) {
			Num = n;
		}
	}
}
