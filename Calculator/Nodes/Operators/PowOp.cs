using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public class PowOp : OpNode
	{
		public PowOp() : base("^") {
		}

		public override double Calculate(double x1, double x2) {
			return Math.Pow(x1, x2);
		}
	}
}
