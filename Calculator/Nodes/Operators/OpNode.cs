using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public abstract class OpNode : Node
	{
		public OpNode(string value) : base(value) { }
		public abstract double Calculate(double x1, double x2);
	}
}
