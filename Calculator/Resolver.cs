using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Resolver
    {
		public double Resolve(List<char> rawExp) {
			//guards
			if (rawExp == null)
				return 0;
			rawExp.RemoveAll(x => Char.IsWhiteSpace(x));
			if (rawExp.Count == 0)
				return 0;

			//start and end trims
			while (!Char.IsNumber(rawExp[0]) && rawExp[0] != '(' && rawExp[0] != '-') {
				rawExp.RemoveAt(0);
				if (rawExp.Count == 0)
					return 0;
			}
			while(!Char.IsNumber(rawExp[rawExp.Count-1]) && rawExp[rawExp.Count - 1] != ')') {
				rawExp.RemoveAt(rawExp.Count - 1);
				if (rawExp.Count == 0)
					return 0;
			}

			//collate numbers
			List<Node> exp = Numberfy(rawExp);
			exp = ResolveBodmas(exp);
			if (exp == null || exp.Count == 0)
				return 0;
			else return ((NumNode)exp[0]).Num;
		}

		private List<Node> Numberfy(List<char> exp) {
			List<Node> result = new List<Node>();
			double n = 0;
			int floating = 0;
			bool numInBuffer = false;

			for (int i = 0; i < exp.Count; i++) {
				if (Char.IsNumber(exp[i])) {
					numInBuffer = true;
					if (floating > 0) {
						n = n + Char.GetNumericValue(exp[i]) / (Math.Pow(10, floating));
						floating++;
					}
					else if (i != 0 && exp[i-1] == '-') {
						n = Char.GetNumericValue(exp[i]) * -1;
						if (i - 2 >= 0 && Char.IsNumber(exp[i - 2]))
							result[result.Count - 1] = NodeFac.Create('+');
						else result.RemoveAt(result.Count - 1);
					}
					else if (i != 0 && exp[i - 1] == '+') {
						n = Char.GetNumericValue(exp[i]);
						if (!Char.IsNumber(exp[i - 2]))
							result.RemoveAt(result.Count -1);
					}
					else {
						n = n * 10 + Char.GetNumericValue(exp[i]);
					}

					if (i == exp.Count - 1)
						result.Add(new NumNode(n));
				}
				else if (exp[i] == '.') {
					floating = 1;
				}
				else {
					if (numInBuffer) {
						result.Add(new NumNode(n));
						n = 0;
						numInBuffer = false;
						floating = 0;
					}
					Node node = NodeFac.Create(exp[i]);

					if (node.Value == "(" && i != 0 && Char.IsNumber(exp[i-1])) {
						result.Add(NodeFac.Create('*'));
					}
					else if (node.Value == ")" && !Char.IsNumber(exp[i-1]) && exp[i-1] != ')' && exp[i-1] != '(') {
						continue;
					}
					result.Add(node);
				}
			}

			return result;
		}

		private List<Node> ResolveBodmas(List<Node> exp) {
			//guard
			if (exp.Count == 0)
				return exp;

			//remove any bracket/symbol
			while (!(exp[0] is NumNode) && exp[0].Value != "(") {
				exp.RemoveAt(0);
				if (exp.Count == 0)
					return exp;
			}

			exp = ResolveBrackets(exp);
			exp = ResolveOps(exp);

			return exp;
		}

		private List<Node> ResolveOps(List<Node> exp) {
			exp = ResolveOp(exp, OpPrecedence.prio1);
			exp = ResolveOp(exp, OpPrecedence.prio2);
			exp = ResolveOp(exp, OpPrecedence.prio3);

			return exp;
		}

		private List<Node> ResolveBrackets(List<Node> exp) {
			//break condition
			int begin = exp.FindIndex(x => x.Value == "(");
			int end = exp.FindIndex(x => x.Value == ")");
			List<Node> result;

			if (begin == -1 && end == -1)
				return exp;
			else if (begin == -1 || begin > end && end != -1) {
				List<Node> inner = ResolveOps(exp.GetRange(0, end));

				result = new List<Node>();
				result.AddRange(inner);
				result.AddRange(exp.GetRange(end + 1, exp.Count - end - 1));
				return result;
			}

			var left = exp.GetRange(0, begin);
			var right = ResolveBodmas(exp.GetRange(begin+1, exp.Count - begin-1));

			result = new List<Node>();
			result.AddRange(left);
			result.AddRange(right);
			result = ResolveBodmas(result);
			return result;
		}

		private List<Node> ResolveOp(List<Node> exp, params string[] ops) {
			//break condition
			int i = exp.FindIndex(x => x is OpNode && ops.Contains(x.Value));
			if (i == -1)
				return exp;
			else if (i == exp.Count - 1) {
				exp.RemoveAt(i);
				return exp;
			}

			OpNode opNode = (OpNode)exp[i];
			int j = 1;
			Node Prev = exp[i - j];
			Node Next = exp[i + j];

			if (Prev is NumNode && Next is NumNode) {
				NumNode numNode = new NumNode(opNode.Calculate(((NumNode)exp[i - 1]).Num, ((NumNode)exp[i + 1]).Num));
				exp[i] = numNode;

				exp.RemoveAt(i + 1);
				exp.RemoveAt(i - 1);

				return ResolveOp(exp, ops);
			}
			else return exp;
		}
	}
}