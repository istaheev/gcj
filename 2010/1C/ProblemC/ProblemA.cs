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
				int count = StringToNumbers(Console.ReadLine(), 1)[0];
				
				List<int[]> wires = new List<int[]>();

				for( int i=0; i<count; i++)
				{
					int[] data = StringToNumbers(Console.ReadLine(), 2);
					wires.Add(data);
				}

				wires.Sort(delegate(int[] a, int[] b)
						   {
							   return a[0].CompareTo(b[0]);
						   });

				//for( int i=0; i<count; i++)
				//{
				//    Console.WriteLine("{0} - {1}", wires[i][0], wires[i][1]);
				//}

				int intersections = 0;

				for( int i=0; i<count-1; i++)
				{
					for( int k=i+1; k<count; k++)
					{
						if (wires[k][1] < wires[i][1])
							intersections++;
					}
				}

				Console.WriteLine("Case #{0}: {1}", testIndex + 1, intersections);
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
