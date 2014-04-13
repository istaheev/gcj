using System;
using System.Collections.Generic;


namespace ProblemC
{
	class Program
	{
		static void Main(string[] args)
		{
			int testsCount = StringToNumbers(Console.ReadLine(), 1)[0];
			for (int testIndex = 0; testIndex < testsCount; testIndex++)
			{
				int n = StringToNumbers(Console.ReadLine(), 1)[0];
				Console.WriteLine("Case #{0}: {1}", testIndex + 1, result);
			}
		}


		static int[] StringToNumbers(string s, int count)
		{
			int[] result = new int[count];
			string[] parts = s.Split(' ');
			for (int i = 0; i < count; i++)
				result[i] = Convert.ToInt32(parts[i]);
			return result;
		}
	}
}
