namespace OOP_Lab3
{
	public class Program
	{
		static void TestConstructors()
		{
			// creating empty vector
			Console.WriteLine("Empty vector:");
			var emptyVec = Vector.Empty;
			Console.WriteLine(emptyVec);
			Console.WriteLine();

			// getting input for dimension
			int dimension = InputHelper.InputInt32("vectors dimension", dim => dim > 0);
			Console.WriteLine();

			// creating vector filled with zeros
			Console.WriteLine("Vector filled with zeros:");
			var zeroVec = new Vector(dimension);
			Console.WriteLine(zeroVec);
			Console.WriteLine();

			// creating vector filled with specified value
			Console.WriteLine("Vector filled with specified value:");
			double value = InputHelper.InputDouble("value to fill array");
			var oneValueVec = new Vector(dimension, value);
			Console.WriteLine("Result:");
			Console.WriteLine(oneValueVec);
			Console.WriteLine();

			// creating vector filled with an array of values
			Console.WriteLine("Vector filled with an array of values:");
			var vec = InputHelper.InputVector(dimension);
			Console.WriteLine("Result:");
			Console.WriteLine(vec);
		}

		static void TestCoordinates()
		{
			// getting input for vector
			var vec = InputHelper.InputVector();
			Console.WriteLine();

			// printing vector coordinates before changes
			Console.WriteLine("Vector coordinates before changes:");
			Console.WriteLine(vec);
			Console.WriteLine();

			// getting input for new value of x coordinate and setting it
			Console.WriteLine("Enter new vector coordinates:");
			for (int i = 0; i < vec.Dimension; i++)
			{
				vec[i] = InputHelper.InputDouble($"new {i + 1} coordinate");
			}
			Console.WriteLine();

			// printing vector coordinates after changes
			Console.WriteLine("Vector coordinates after changes:");
			Console.WriteLine(vec);
		}

		static void TestLength()
		{
			// getting input for vector
			var vec = InputHelper.InputVector();
			Console.WriteLine();

			// printing vector length and square root of squared vector coordinates sum for comparison
			double trueLength = Math.Sqrt(Enumerable.Range(0, vec.Dimension).Select(i => vec[i] * vec[i]).Sum());
			Console.WriteLine($"Vector length: {vec.Length}");
			Console.WriteLine($"True length:   {trueLength}");
		}

		static void TestNormalization()
		{
			// getting input for vector
			var vec = InputHelper.InputVector();
			Console.WriteLine();

			// printing vector coordinates before normalization
			Console.WriteLine("Before normalization:");
			Console.WriteLine($"- coordinates: {vec}");
			Console.WriteLine($"- length: {vec.Length}");
			Console.WriteLine();

			// normalizing a vector
			vec.Normalize();

			// printing vector coordinates after normalization
			Console.WriteLine("After normalization:");
			Console.WriteLine($"- coordinates: {vec}");
			Console.WriteLine($"- length: {vec.Length}");
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
			// initializing bool variable for detecting if exit from program is needed
			bool needExit = false;

			// initializing actions map
			Dictionary<char, (string Description, Action Action)> actions = new()
			{
				['1'] = ("test constructors functionality", TestConstructors),
				['2'] = ("test coordinates access functionality", TestCoordinates),
				['3'] = ("test computing length functionality", TestLength),
				['4'] = ("test normalization functionality", TestNormalization),
				['5'] = ("test comparison functionality", TestComparison),
				['e'] = ("exit", () => needExit = true)
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

				// exitting from main loop if exit is needed
				if (needExit)
				{
					break;
				}

				// waiting for pressing any key and clear console
				Console.Write("Press any key to continue...");
				Console.ReadLine();
				Console.Clear();
			}
		}
	}
}