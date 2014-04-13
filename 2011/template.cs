using System;
using System.Collections.Generic;
using System.IO;


namespace Magicka
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
					string[] inputStr = reader.ReadLine().Split(' ');
					int N = Convert.ToInt32(inputStr[0]);
					long K = Convert.ToInt64(inputStr[1]);

					WL("Case #{0}: {1}", currentTestIndex + 1, CheckBitsAreSetTo1(K, N) ? "ON" : "OFF");
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
