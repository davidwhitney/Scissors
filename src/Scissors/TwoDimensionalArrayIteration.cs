using System;
using System.Collections.Generic;
using System.Linq;

namespace Scissors
{
	public static class TwoDimensionalArrayIteration
    {
		public static IEnumerable<T> Cells<T>(this T[,] items)
	    {
		    return items.IterateOver((x, y) => items[y, x]);
	    }

		public static IEnumerable<Position<T>> Positions<T>(this T[,] items)
	    {
		    return items.IterateOver((x, y) => new Position<T>(items[y, x], x, y));
		}

		private static IEnumerable<TReturnType> IterateOver<T,TReturnType>(this T[,] items, Func<int,int,TReturnType> then)
	    {
			for (var y = 0; y <= items.GetUpperBound(0); y++)
			{
				for (var x = 0; x <= items.GetUpperBound(1); x++)
				{
					yield return then(x, y);
				}
			}		    
	    }

		public static IEnumerable<char> Cells(this List<string> strings)
		{
			return strings.SelectMany(row => row);
		}

		public static IEnumerable<Position<char>> Positions(this string[] items)
		{
			for (var y = 0; y < items.Length; y++)
			{
				var row = items[y];
				for (var x = 0; x < row.Length; x++)
				{
					yield return new Position<char>(row[x], x, y);
				}
			}
		}

		public static IEnumerable<Position<char>> Neighbours(this string[] items, Position source)
		{
			var candidates = new List<Position>
			{
				new Position(source.X - 1, source.Y - 1),
				new Position(source.X, source.Y - 1),
				new Position(source.X + 1, source.Y - 1),
				new Position(source.X - 1, source.Y),
				new Position(source.X + 1, source.Y),
				new Position(source.X - 1, source.Y + 1),
				new Position(source.X, source.Y + 1),
				new Position(source.X + 1, source.Y + 1)
			};

			candidates.RemoveAll(position => position.X < 0 || position.X >= items.First().Length - 1);
			candidates.RemoveAll(position => position.Y < 0 || position.Y >= items.Length - 1);
			return candidates.Select(position => new Position<char>(items[position.Y][position.X], position.X, position.Y));
		}

	    public static IEnumerable<IEnumerable<T>> Columns<T>(this T[,] items)
	    {
			for (var x = 0; x <= items.GetUpperBound(1); x++)
			{
				var row = new List<T>();
				for (var y = 0; y <= items.GetUpperBound(0); y++)
				{
					row.Add(items[y,x]);
				}

				yield return row;

			}
	    }
    }
}
