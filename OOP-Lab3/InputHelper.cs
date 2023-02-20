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

		// gets input for variable of type double
		public static double InputDouble(string name)
		{
			return Input<double>(name, double.TryParse);
		}

		// gets input for vector coordinates
		public static Vector InputVector(string name = "vector")
		{
			Console.WriteLine($"Enter {name} coordinates:");
			double x = InputDouble("x");
			double y = InputDouble("y");
			return new(x, y);
		}
	}
}
