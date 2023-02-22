namespace OOP_Lab3
{
	public class Vector : IEquatable<Vector>, IComparable<Vector>
	{
		// vector coordinates
		private readonly double[] _coordinates;
		// vector dimension
		private readonly int _dimension;

		// creates vector of specified dimension, filled with zeros
		public Vector(int dimension) : this(dimension, 0.0) { }
		// creates vector of specified dimension, filled with specified value
		public Vector(int dimension, double val) : this(dimension, Enumerable.Repeat(val, dimension).ToArray()) { }
		// creates vector of specified dimension, filled with specified array of values
		public Vector(int dimension, params double[] coordinates)
		{
			if (dimension <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(dimension), "dimension must be a positive integer");
			}

			if (coordinates.Length != dimension)
			{
				throw new ArgumentException("Coordinates number isn't equal to specified dimension",
					nameof(coordinates));
			}

			_coordinates = new double[dimension];
			coordinates.CopyTo(_coordinates, 0);

			_dimension = dimension;
		}

		// coordinates get/set indexer
		public double this[int i]
		{
			get => _coordinates[i];
			set => _coordinates[i] = value;
		}

		// dimension getter
		public int Dimension => _dimension;
		// length getter
		public double Length => GetLength();

		// computes vector length
		private double GetLength() => Math.Sqrt(_coordinates.Sum(c => c * c));
		// normalizes vector
		public void Normalize()
		{
			double length = GetLength();
			for (int i = 0; i < _dimension; i++)
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
