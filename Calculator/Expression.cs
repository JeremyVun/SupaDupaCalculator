using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public class Expression
	{
		public List<char> expression { get; private set; }

		public Expression() {
			expression = new List<char>();
		}

		public void AddChar(char c) {
			expression.Add(c);
		}

		public void RemoveLastChar() {
			expression.RemoveAt(expression.Count - 1);
		}

		public void Reset() {
			expression.Clear();
		}
	}
}
