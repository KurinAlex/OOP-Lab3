namespace OOP_Lab3
{
	public class Vector : IEquatable<Vector>, IComparable<Vector>
	{
		// vector coordinates
		private double _x;
		private double _y;

		// constructors
		public Vector() : this(0.0, 0.0) { }
		public Vector(double x, double y) => (_x, _y) = (x, y);

		// coordinates get/set properties
		public double X
		{
			get => _x;
			set => _x = value;
		}
		public double Y
		{
			get => _y;
			set => _y = value;
		}

		// length getter
		public double Length => Math.Sqrt(_x * _x + _y * _y);

		// static zero vector getter
		public static Vector Zero => new();

		// method for vector normalization
		public void Normalize() => (_x, _y) = (_x / Length, _y / Length);

		// overriden Object virtual methods
		public override bool Equals(object? obj) => obj is Vector other && Equals(other);
		public override int GetHashCode() => HashCode.Combine(_x, _y);
		public override string ToString() => $"({_x}; {_y})";

		// compare methods
		public bool Equals(Vector? other) => _x == other?._x && _y == other._y;
		public int CompareTo(Vector? other) => Length.CompareTo(other?.Length);

		// static comparison operators
		public static bool operator ==(Vector left, Vector right) => left.Equals(right);
		public static bool operator !=(Vector left, Vector right) => !(left == right);
		public static bool operator <(Vector left, Vector right) => left.CompareTo(right) < 0;
		public static bool operator <=(Vector left, Vector right) => left.CompareTo(right) <= 0;
		public static bool operator >(Vector left, Vector right) => left.CompareTo(right) > 0;
		public static bool operator >=(Vector left, Vector right) => left.CompareTo(right) >= 0;
	}
}
