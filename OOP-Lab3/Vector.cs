namespace OOP_Lab3
{
	public class Vector : IComparable<Vector>
	{
		private double _x;
		private double _y;

		public static Vector Zero => new();

		public Vector() : this(0.0, 0.0) { }
		public Vector(double x, double y) => (_x, _y) = (x, y);

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
		public double Length => Math.Sqrt(_x * _x + _y * _y);

		public void Normalize() => (_x, _y) = (_x / Length, _y / Length);
		public int CompareTo(Vector? other) => Length.CompareTo(other?.Length);
		public override string ToString() => $"({_x}, {_y})";
	}
}
