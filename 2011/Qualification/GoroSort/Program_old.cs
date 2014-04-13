using System;
using System.Collections.Generic;
using System.IO;


namespace GoroSort
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
					int[] sorted = new int[N];
					for (int i = 0; i < N; i++)
					{
						pieces[i] = Convert.ToInt32(inputStr[i]);
						sorted[i] = pieces[i];
					}

					Array.Sort(sorted);

					int perm = 0;
					for (int i = 0; i < pieces.Length; i++)
						if (pieces[i] != sorted[i])
							perm++;
					WL("Case #{0}: {1:F6}", currentTestIndex + 1, perm);
					continue;

					for (int i = 1; i < N; i++)
					{
						if (pieces[i - 1] == i)
							continue;

						for (int k = 0; k < N; k++)
							if (pieces[k] == i)
							{
								int tmp = pieces[k];
								pieces[k] = pieces[i - 1];
								pieces[i - 1] = tmp;
								break;
							}
						perm++;
					}

					WL("Case #{0}: {1:F6}", currentTestIndex + 1, perm * 2);
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
