namespace OOP_Lab3
{
	public class Program
	{
		static void TestCoordinates()
		{
			// getting input for vector
			var vec = InputHelper.InputVector();
			Console.WriteLine();

			// printing vector coordinates before changes
			Console.WriteLine("Vector coordinates before changes:");
			Console.WriteLine($"- X: {vec.X}");
			Console.WriteLine($"- Y: {vec.Y}");
			Console.WriteLine();

			// getting input for new value of x coordinate and setting it
			double x = InputHelper.InputDouble("new x");
			vec.X = x;

			// getting input for new value of y coordinate and setting it
			double y = InputHelper.InputDouble("new y");
			vec.Y = y;

			// printing vector coordinates after changes
			Console.WriteLine();
			Console.WriteLine("Vector coordinates after changes:");
			Console.WriteLine($"- X: {vec.X}");
			Console.WriteLine($"- Y: {vec.Y}");
		}

		static void TestLength()
		{
			// getting input for vector
			var vec = InputHelper.InputVector();
			Console.WriteLine();

			// printing vector length and square root of squared vector coordinates sum for comparison
			Console.WriteLine($"Vector length:   {vec.Length}");
			Console.WriteLine($"Sqrt(x^2 + y^2): {Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y)}");
		}

		static void TestNormalization()
		{
			// getting input for vector
			var vec = InputHelper.InputVector();
			Console.WriteLine();

			// printing vector coordinates before normalization
			Console.WriteLine("Before normalization:");
			Console.WriteLine($"- coordinates: {vec}");
			Console.WriteLine($"- length:      {vec.Length}");
			Console.WriteLine();

			// normalizing a vector
			vec.Normalize();

			// printing vector coordinates after normalization
			Console.WriteLine("After normalization:");
			Console.WriteLine($"- coordinates: {vec}");
			Console.WriteLine($"- length:      {vec.Length}");
		}

		static void TestComparison()
		{
			// getting input for vector 1
			var vec1 = InputHelper.InputVector("vector 1");
			Console.WriteLine();

			// getting input for vector 2
			var vec2 = InputHelper.InputVector("vector 2");
			Console.WriteLine();

			// printing vectors 1 and 2 data
			Console.WriteLine($"vec1: {vec1}");
			Console.WriteLine($"vec2: {vec2}");
			Console.WriteLine();
			Console.WriteLine($"vec1 length: {vec1.Length}");
			Console.WriteLine($"vec2 length: {vec2.Length}");
			Console.WriteLine();

			// printing results of different comparing operations between vectors 1 and 2
			Console.WriteLine($"vec1 == vec2: {vec1 == vec2}");
			Console.WriteLine($"vec1 != vec2: {vec1 != vec2}");
			Console.WriteLine($"vec1 >  vec2: {vec1 > vec2}");
			Console.WriteLine($"vec1 >= vec2: {vec1 >= vec2}");
			Console.WriteLine($"vec1 <  vec2: {vec1 < vec2}");
			Console.WriteLine($"vec1 <= vec2: {vec1 <= vec2}");
		}

		static void Main(string[] args)
		{
			//initializing actions map
			Dictionary<char, (string Description, Action Action)> actions = new()
			{
				['1'] = ("test coordinates access functionality", TestCoordinates),
				['2'] = ("test computing length functionality", TestLength),
				['3'] = ("test normalization functionality", TestNormalization),
				['4'] = ("test comparison functionality", TestComparison),
				['e'] = ("exit", () => Environment.Exit(0))
			};

			// infinite asking for input
			while (true)
			{
				// printing all available action choises
				foreach (var action in actions)
				{
					Console.WriteLine($"Enter {action.Key} to {action.Value.Description}.");
				}
				Console.WriteLine();

				// getting input for choise
				char c = InputHelper.Input<char>("your choice", char.TryParse, c => actions.ContainsKey(c));
				Console.WriteLine();
				Console.WriteLine();

				// starting chosen action
				actions[c].Action();
				Console.WriteLine();
				Console.WriteLine();

				// waiting for pressing any key and clear console
				Console.Write("Press any key to continue...");
				Console.ReadLine();
				Console.Clear();
			}
		}
	}
}