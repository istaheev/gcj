using System;
using System.Collections.Generic;
using System.IO;


namespace RPI
{
	class Program
	{
		static double calc_wp(string table, int throwOut)
		{
			int total = 0;
			int won = 0;

			for (int i = 0; i < table.Length; i++)
			{
				if (i == throwOut)
					continue;

				char c = table[i];
				if (c != '.')
					total++;
				if (c == '1')
					won++;
			}

			return (double)won / total;
		}


		static void Main(string[] args)
		{
			const string Input = @"input.txt";

			using (StreamReader reader = File.OpenText(Input))
			{
				int testsCount = Convert.ToInt32(reader.ReadLine());

				for (int currentTestIndex = 0; currentTestIndex < testsCount; currentTestIndex++)
				{
					int N = Convert.ToInt32(reader.ReadLine());

					string[] teams = new string[N];
					for (int i = 0; i < N; i++)
					{
						teams[i] = reader.ReadLine();
					}

					double[] wp = new double[N];
					for (int i = 0; i < N; i++ )
						wp[i] = calc_wp(teams[i], N+1);

					double[] owp = new double[N];
					for (int i = 0; i < N; i++ )
					{
						double sum = 0;
						int cnt = 0;

						for(int k=0; k<N; k++)
						{
							char c = teams[i][k];
							if( c!= '.')
							{
								sum += calc_wp(teams[k], i);
								cnt++;
							}
						}

						owp[i] = sum / cnt;
					}

					double[] oowp = new double[N];
					for (int i = 0; i < N; i++)
					{
						double sum = 0;
						int cnt = 0;

						for (int k = 0; k < N; k++)
						{
							char c = teams[i][k];
							if (c != '.')
							{
								sum += owp[k];
								cnt++;
							}
						}

						oowp[i] = sum / cnt;
					}


					WL("Case #{0}:", currentTestIndex + 1);
					for (int i = 0; i < N; i++)
						WL("{0:R}", 0.25*wp[i] + 0.5*owp[i] + 0.25*oowp[i]);
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
