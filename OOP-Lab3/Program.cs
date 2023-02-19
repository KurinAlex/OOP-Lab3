namespace OOP_Lab3
{
	public class Program
	{
		static void Main(string[] args)
		{
			Vector vec = new(15, 6);
			Console.WriteLine(vec);

			vec.Normalize();
			Console.WriteLine(vec);
			Console.WriteLine(vec.Length);

			Console.ReadLine();
		}
	}
}