using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Scissors.Test.Unit
{
	[TestFixture]
    public class TwoDimensionalArrayIterationTests
    {
		[Test]
		public void Cells_WithEnumerableOfStrings_ReturnsCellsInOrderLrTb()
		{
			var strings = new List<string> {"ab", "cd"};

			var cells = strings.Cells().ToList();

			Assert.That(cells[0], Is.EqualTo('a'));
			Assert.That(cells[1], Is.EqualTo('b'));
			Assert.That(cells[2], Is.EqualTo('c'));
			Assert.That(cells[3], Is.EqualTo('d'));
		}

		[Test]
		public void Cells_With2dArray_ReturnsElementsInOrderLrTb()
		{
			var ints = new int[2, 2];
			ints[0, 0] = 1;
			ints[0, 1] = 2;
			ints[1, 0] = 3;
			ints[1, 1] = 4;

			var cells = ints.Cells().ToList();

			Assert.That(cells[0], Is.EqualTo(1));
			Assert.That(cells[1], Is.EqualTo(2));
			Assert.That(cells[2], Is.EqualTo(3));
			Assert.That(cells[3], Is.EqualTo(4));
		}

		[Test]
		public void Positions_With2dArray_ReturnsElementsInOrderLrTbAsPositions()
		{
			var ints = new int[2, 2];
			ints[0, 0] = 1;
			ints[0, 1] = 2;
			ints[1, 0] = 3;
			ints[1, 1] = 4;

			var cells = ints.Positions().ToList();

			Assert.That(cells[0], Is.EqualTo(new Position<int>(1, 0, 0)));
			Assert.That(cells[1], Is.EqualTo(new Position<int>(2, 1, 0)));
			Assert.That(cells[2], Is.EqualTo(new Position<int>(3, 0, 1)));
			Assert.That(cells[3], Is.EqualTo(new Position<int>(4, 1, 1)));
		}

		[Test]
		public void Columns_With2dArray_ReturnsListOfColumns()
		{
			var ints = new int[2, 2];
			ints[0, 0] = 1;
			ints[0, 1] = 2;
			ints[1, 0] = 3;
			ints[1, 1] = 4;

			var cells = ints.Columns().ToList();

			Assert.That(cells.First().ToList()[0], Is.EqualTo(1));
			Assert.That(cells.First().ToList()[1], Is.EqualTo(3));
		}
    }
}
