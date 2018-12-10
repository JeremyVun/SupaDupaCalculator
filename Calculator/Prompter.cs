using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	public class Prompter
	{
		public List<char> Prompt(string prompt) {
			Console.WriteLine(prompt);
			Console.Write("> ");

			bool isReading = true;
			List<char> result = new List<char>();

			while (isReading) {
				var key = Console.ReadKey().KeyChar;

				if (key == '\r')
					isReading = false;
				if (key == '\b') {
					if (result.Count > 0)
						result.RemoveAt(result.Count - 1);
				}
					
				else result.Add(key);
			}

			Console.WriteLine();
			return result;
		}
	}
}
