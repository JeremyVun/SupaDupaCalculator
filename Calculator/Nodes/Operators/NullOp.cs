using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public class NullOp : OpNode
	{
		public NullOp() : base("null") {
		}

		public override double Calculate(double x1, double x2) {
			return 0;
		}
	}
}
