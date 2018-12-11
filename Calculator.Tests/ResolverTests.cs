using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests
{
	public class ResolverTests
	{
		[Fact]
		public void ResolveValidTest() {
			Resolver resolver = new Resolver();

			// 1 - 21 * 3 + 100 * 0.5
			List<char> expression = new List<char>() {
				'1', '-', '2', '1', '*', '3', '+', '1', '0', '0', '*', '0', '.', '5'
			};

			double actual = resolver.Resolve(expression);
			double expected = -12;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveNullTest() {
			Resolver resolver = new Resolver();

			double actual = resolver.Resolve(null);
			double expected = 0;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveOpLastTest() {
			Resolver resolver = new Resolver();

			// 1 - 21 * 3 + 100
			List<char> expression = new List<char>() {
				'1', '-', '2', '1', '*', '3', '+', '1', '0', '0', '*'
			};

			double actual = resolver.Resolve(expression);
			double expected = 38;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveOneOpenBracket() {
			Resolver resolver = new Resolver();

			// 1 - 2(1 * 3 + 100 * 0.5)
			List<char> expression = new List<char>() {
				'1', '-', '2', '(', '1', '*', '3', '+', '1', '0', '0', '*', '0', '.', '5'
			};

			double actual = resolver.Resolve(expression);
			double expected = -105;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveOneCloseBracket() {
			Resolver resolver = new Resolver();

			// 1 - 21 * 3 + 100) * 0.5
			List<char> expression = new List<char>() {
				'1', '-', '2', '1', '*', '3', '+', '1', '0', '0', ')', '*', '0', '.', '5'
			};

			double actual = resolver.Resolve(expression);
			double expected = 19;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveValidBrackets() {
			Resolver resolver = new Resolver();

			// (1 - 21) * 3 + 100 * 0.5
			List<char> expression = new List<char>() {
				'(', '1', '-', '2', '1', ')', '*', '3', '+', '1', '0', '0', '*', '0', '.', '5'
			};

			double actual = resolver.Resolve(expression);
			double expected = -10;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveWhitespaces() {
			Resolver resolver = new Resolver();

			// 1 - 21 * 3 + 100 * 0.5
			List<char> expression = new List<char>() {
				' ', '1', '-', '2', '1', ' ', '*', '3', '+', '1', '0', '0', '*', '0', '.', '5'
			};

			double actual = resolver.Resolve(expression);
			double expected = -12;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveEmptyList() {
			Resolver resolver = new Resolver();

			// (1 - 21) * 3 + 100 * 0.5
			List<char> expression = new List<char>();

			double actual = resolver.Resolve(expression);
			double expected = 0;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveSingleNum() {
			Resolver resolver = new Resolver();

			// (100
			List<char> expression = new List<char>() {
				'(', '1', '0', '0'
			};

			double actual = resolver.Resolve(expression);
			double expected = 100;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveNegativeDecimal() {
			Resolver resolver = new Resolver();

			// -0.5*-2
			List<char> expression = new List<char>() {
				'-', '0', '.', '5', '*', '-', '2'
			};

			double actual = resolver.Resolve(expression);
			double expected = 1;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveNegativeBrackets() {
			Resolver resolver = new Resolver();

			// -(5+5)
			List<char> expression = new List<char>() {
				'-', '(', '5', '+', '5', ')'
			};

			double actual = resolver.Resolve(expression);
			double expected = -10;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveNegativeMultipleDigitNumber() {
			Resolver resolver = new Resolver();

			// -111-19
			List<char> expression = new List<char>() {
				'-', '1', '1', '1', '-', '1', '9'
			};

			double actual = resolver.Resolve(expression);
			double expected = -130;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveDecimal() {
			Resolver resolver = new Resolver();

			// 0.005+1
			List<char> expression = new List<char>() {
				'0', '.', '0', '0', '5', '+', '1'
			};

			double actual = resolver.Resolve(expression);
			double expected = 1.005;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveMultipleBracketGroups() {
			Resolver resolver = new Resolver();

			// (1+2)*(3+4)
			List<char> expression = new List<char>() {
				'(', '1', '+', '2', ')', '*', '(', '3', '+', '4', ')'
			};

			double actual = resolver.Resolve(expression);
			double expected = 21;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolvePositivePower() {
			Resolver resolver = new Resolver();

			// 3^2^2
			List<char> expression = new List<char>() {
				'3', '^', '2', '^', '2'
			};

			double actual = resolver.Resolve(expression);
			double expected = 81;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveNegativePower() {
			Resolver resolver = new Resolver();

			// 3^-2
			List<char> expression = new List<char>() {
				'3', '^', '-', '2',
			};

			double actual = resolver.Resolve(expression);
			double expected = Math.Pow(3,-2);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ResolveLeadingZeros() {
			Resolver resolver = new Resolver();

			// 00.1
			List<char> expression = new List<char>() {
				'0', '0', '.', '1',
			};

			double actual = resolver.Resolve(expression);
			double expected = 0.1;

			Assert.Equal(expected, actual);
		}
	}
}