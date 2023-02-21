namespace OOP_Lab3
{
	public class Vector : IEquatable<Vector>, IComparable<Vector>
	{
		// vector coordinates
		private readonly double[] _coordinates;

		// vector dimention
		private readonly int _dimention;

		// constructors
		public Vector(int dimention) : this(dimention, 0.0) { }
		public Vector(int dimention, double val) : this(dimention, Enumerable.Repeat(val, dimention).ToArray()) { }
		public Vector(int dimention, params double[] coordinates)
		{
			if (coordinates.Length != dimention)
			{
				throw new ArgumentException("Coordinates number isn't equal to specified dimention",
					nameof(coordinates));
			}

			_coordinates = new double[dimention];
			coordinates.CopyTo(_coordinates, 0);

			_dimention = dimention;
		}

		// coordinates get/set properties
		public double this[int i]
		{
			get => _coordinates[i];
			set => _coordinates[i] = value;
		}

		// dimention getter
		public int Dimention => _dimention;

		// length getter
		public double Length => GetLength();

		// method for vector normalization
		private double GetLength() => Math.Sqrt(_coordinates.Sum(c => c * c));
		public void Normalize()
		{
			double length = GetLength();
			for (int i = 0; i < _dimention; i++)
			{
				_coordinates[i] /= length;
			}
		}

		// overriden Object virtual methods
		public override bool Equals(object? obj) => obj is Vector other && Equals(other);
		public override int GetHashCode()
		{
			HashCode hash = new();
			Array.ForEach(_coordinates, c => hash.Add(c));
			return hash.ToHashCode();
		}
		public override string ToString() => $"({string.Join("; ", _coordinates)})";

		// compare methods
		public int CompareTo(Vector? other) => Length.CompareTo(other?.Length);
		public bool Equals(Vector? other) => other is not null && _coordinates.SequenceEqual(other._coordinates);

		// static comparison operators
		public static bool operator ==(Vector left, Vector right) => left.Equals(right);
		public static bool operator !=(Vector left, Vector right) => !(left == right);
		public static bool operator <(Vector left, Vector right) => left.CompareTo(right) < 0;
		public static bool operator <=(Vector left, Vector right) => left.CompareTo(right) <= 0;
		public static bool operator >(Vector left, Vector right) => left.CompareTo(right) > 0;
		public static bool operator >=(Vector left, Vector right) => left.CompareTo(right) >= 0;
	}
}
