using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace CalcConsole
{
	public class CalcMain
	{
		static void Main(string[] args) {
			Prompter p = new Prompter();
			Resolver r = new Resolver();

			while (true) {
				List<char> input = p.Prompt("Enter expression: ");
				double result = r.Resolve(input);
				Console.WriteLine($"Answer: {result}");
			}
			
		}
	}
}
