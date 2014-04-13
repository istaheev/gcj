using System;
using System.Collections.Generic;


namespace ProblemC
{
	class Program
	{
		static void Main()
		{
			int testsCount = StringToNumbers(Console.ReadLine(), 1)[0];
			for (int testIndex = 0; testIndex < testsCount; testIndex++)
			{
				int[] data = StringToNumbers(Console.ReadLine(), 3);
				int L = data[0];
				int P = data[1];
				int C = data[2];

				double distance = Log(P, C) - Log(L, C);
				if (distance < 1)
					distance = 1;
				int tries = (int)Math.Ceiling(Log(Math.Round(distance,5), 2));

				Console.WriteLine("Case #{0}: {1}", testIndex + 1, tries);
			}
		}


		static double Log(double a, double exp)
		{
			return Math.Log10(a) / Math.Log10(exp);
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
