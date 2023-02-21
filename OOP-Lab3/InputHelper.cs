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

		// gets input for coordinates of vector with specified dimention
		public static Vector InputVector(int dimention, string name = "vector")
		{
			Console.WriteLine($"Enter {name} coordinates:");
			var coordinates = new double[dimention];
			for (int i = 0; i < dimention; i++)
			{
				coordinates[i] = InputDouble($"{i + 1} coordinate");
			}
			return new(dimention, coordinates);
		}

		// gets input for dimention and coordinates of vector
		public static Vector InputVector(string name = "vector")
		{
			int dimention = InputInt32("vector dimention", dim => dim > 0);
			return InputVector(dimention, name);
		}
	}
}
