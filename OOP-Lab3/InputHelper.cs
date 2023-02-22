namespace OOP_Lab3
{
	public static class InputHelper
	{
		// represents the method, that tries to convert string to certain type 
		public delegate bool TryParseHandler<T>(string? s, out T res);

		// gets input from user until input will be correct and pass all the conditions
		public static T Input<T>(string name, TryParseHandler<T> tryParse, params Predicate<T>[] conditions)
		{
			T res;
			string? input;
			do
			{
				Console.Write($"Enter {name}: ");
				input = Console.ReadLine();
			} while (!tryParse(input, out res) || !conditions.All(c => c(res)));
			return res;
		}

		// gets input for variable of type 32-bit int
		public static int InputInt32(string name, params Predicate<int>[] conditions)
			=> Input(name, int.TryParse, conditions);

		// gets input for variable of type double
		public static double InputDouble(string name) => Input<double>(name, double.TryParse);

		// gets input for coordinates of vector with specified dimension
		public static Vector InputVector(int dimension, string name = "vector")
		{
			Console.WriteLine($"Enter {name} coordinates:");
			var coordinates = new double[dimension];
			for (int i = 0; i < dimension; i++)
			{
				coordinates[i] = InputDouble($"{i + 1} coordinate");
			}
			return new(dimension, coordinates);
		}

		// gets input for dimension and coordinates of vector
		public static Vector InputVector(string name = "vector")
		{
			int dimension = InputInt32("vector dimension", dim => dim > 0);
			return InputVector(dimension, name);
		}
	}
}
