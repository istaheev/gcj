using System;
using System.Collections.Generic;


namespace ProblemB
{
	class Program
	{
		static void Main()
		{
			int testsCount = StringToNumbers(Console.ReadLine(), 1)[0];
			for (int testIndex = 0; testIndex < testsCount; testIndex++)
			{
				int[] parameters = StringToNumbers(Console.ReadLine(), 4);
				int N = parameters[0];
				int K = parameters[1];
				int B = parameters[2];
				int T = parameters[3];

				int[] positions = StringToNumbers(Console.ReadLine(), N);
				int[] speeds = StringToNumbers(Console.ReadLine(), N);

				int rest = K;
				int swaps = 0;
				int slowChicks = 0;

				for (int i = N - 1; i >= 0; i-- )
				{
					if (rest == 0)
						break;

					if ((double)(B - positions[i]) / (double)speeds[i] <= T)
					{
						rest--;
						swaps += slowChicks;
					}
					else
					{
						slowChicks++;
					}
				}

				Console.WriteLine("Case #{0}: {1}", testIndex + 1, rest > 0 ? "IMPOSSIBLE" : swaps.ToString());
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
