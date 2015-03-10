using System;
using System.Collections.Generic;

namespace Scissors
{
	public class Position
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}

		protected bool Equals(Position other)
		{
			return X == other.X && Y == other.Y;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X*397) ^ Y;
			}
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (!new List<Type> {obj.GetType(), obj.GetType().BaseType}.Contains(GetType())) return false;

			return Equals((Position) obj);
		}
	}

	public class Position<TItem> : Position
	{
		public TItem Item { get; set; }

		public Position(TItem item, int x, int y)
			: base(x, y)
		{
			Item = item;
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		protected bool Equals(Position<TItem> other)
		{
			return base.Equals(other) && EqualityComparer<TItem>.Default.Equals(Item, other.Item);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (base.GetHashCode()*397) ^ EqualityComparer<TItem>.Default.GetHashCode(Item);
			}
		}
	}
}