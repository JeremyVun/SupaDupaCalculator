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
	}
}