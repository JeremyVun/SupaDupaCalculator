using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public class ModOp : OpNode
	{
		public ModOp() : base("%") { }

		public override double Calculate(double x1, double x2) {
			return x1 % x2;
		}
	}
}
