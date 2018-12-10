using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public abstract class Node
	{
		public string Value { get; private set; }

		public Node(string value) {
			Value = value;
		}
		//void Draw();
	}
}
