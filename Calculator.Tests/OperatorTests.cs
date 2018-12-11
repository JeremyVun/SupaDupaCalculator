using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using Xunit;

namespace Calculator.Tests
{
    public class OperatorTests
    {
		[Fact]
		public void AddTest() {
			Node op = NodeFac.Create('+');
			double actual = ((OpNode)op).Calculate(4, 2);
			double expected = 6;

			Assert.Equal(actual, expected);
		}

		[Fact]
		public void PowTest() {
			Node op = NodeFac.Create('^');
			double actual = ((OpNode)op).Calculate(3, 2);
			double expected = 9;

			Assert.Equal(actual, expected);
		}

		[Fact]
		public void SubtractTest() {
			Node op = NodeFac.Create('-');
			double actual = ((OpNode)op).Calculate(4, 2);
			double expected = 2;

			Assert.Equal(actual, expected);
		}

		[Fact]
		public void MultiplyTest() {
			Node op = NodeFac.Create('*');
			double actual = ((OpNode)op).Calculate(4, 2);
			double expected = 8;

			Assert.Equal(actual, expected);
		}

		[Fact]
		public void DivideTest() {
			Node op = NodeFac.Create('/');
			double actual = ((OpNode)op).Calculate(6, 2);
			double expected = 3;

			Assert.Equal(actual, expected);
		}

		[Fact]
		public void NullOpTest() {
			Node op = NodeFac.Create('a');
			double actual = ((OpNode)op).Calculate(6, 2);
			double expected = 0;

			Assert.Equal(actual, expected);
		}

		[Fact]
		public void ModOpTest() {
			Node op = NodeFac.Create('%');
			double actual = ((OpNode)op).Calculate(3, 2);
			double expected = 1;

			Assert.Equal(actual, expected);
		}
	}
}
