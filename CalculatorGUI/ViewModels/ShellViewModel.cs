using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorGUI.Models;
using Calculator;

namespace CalculatorGUI.ViewModels
{
    public class ShellViewModel : Screen
	{
		private Resolver resolver = new Resolver();

		private List<char> expression = new List<char>() { '0' };
		private bool isAnswer = false;
		private string answer;

		public string Expression {
			get {
				if (isAnswer)
					return answer;
				else {
					string result = String.Concat(expression.Where(c => true));
					return result;
				}
			}
		}

		public void Button_Click(char c) {
			if (expression.Count > 0 && expression[0] == '0') {
				expression.RemoveAt(0);
			}
			isAnswer = false;
			expression.Add(c);
			NotifyOfPropertyChange(() => Expression);
		}

		public void Clear() {
			expression.Clear();
			answer = "0";
			NotifyOfPropertyChange(() => Expression);
		}

		public void ClearLast() {
			answer = "0";

			if (expression.Count > 0)
				expression.RemoveAt(expression.Count - 1);

			NotifyOfPropertyChange(() => Expression);
		}

		public void Resolve() {
			if (isAnswer)
				return;

			isAnswer = true;
			answer = resolver.Resolve(expression).ToString();
			expression.Clear();
			NotifyOfPropertyChange(() => Expression);
		}
	}
}
