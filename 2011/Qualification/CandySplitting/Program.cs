using System;
using System.Collections.Generic;
using System.IO;


namespace CandySplitting
{
	class Program
	{
		static void Main(string[] args)
		{
			const string Input = @"input.txt";

			using (StreamReader reader = File.OpenText(Input))
			{
				int testsCount = Convert.ToInt32(reader.ReadLine());

				for (int currentTestIndex = 0; currentTestIndex < testsCount; currentTestIndex++)
				{
					int N = Convert.ToInt32(reader.ReadLine());

					string[] inputStr = reader.ReadLine().Split(' ');
					int[] pieces = new int[N];
					for (int i = 0; i < N; i++)
						pieces[i] = Convert.ToInt32(inputStr[i]);

					int xsum = pieces[0];
					for (int i = 1; i < N; i++)
						xsum ^= pieces[i];

					int sum = 0;
					if( xsum == 0)
					{
						int min = pieces[1];
						for (int i = 0; i < N; i++)
						{
							sum += pieces[i];
							if (pieces[i] < min)
								min = pieces[i];
						}
						sum -= min;
						WL("Case #{0}: {1}", currentTestIndex + 1, sum);
					}
					else
						WL("Case #{0}: {1}", currentTestIndex + 1, "NO");
				}
			}
		}

	
		#region Helper methods

		private static void WL(object text, params object[] args)
		{
			Console.WriteLine(text.ToString(), args);
		}

		private static void RL()
		{
			Console.ReadLine();
		}

		private static void Break()
		{
			System.Diagnostics.Debugger.Break();
		}

		#endregion
	}
}
