using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BotTrust
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

					int bluePos = 1;
					int orangePos = 1;

					string prevMove = "A";
					int prevTime = 0;

					int totalTime = 0;

					for(int i=0; i<N; i++)
					{
						string robot = inputStr[i * 2 + 1];
						int pos = Convert.ToInt32(inputStr[i * 2 + 2]);

						int prevPos = robot == "O" ? orangePos : bluePos;

						if (robot == prevMove)
						{
							int time = abs(pos - prevPos) + 1;
							prevTime += time;
							totalTime += time;
						}
						else
						{
							int estTime = abs(pos - prevPos);
							int extra = estTime - prevTime;
							if (extra < 0)
								extra = 0;
							extra += 1;
							prevTime = extra;
							totalTime += extra;
							prevMove = robot;
						}

						if (robot == "O")
							orangePos = pos;
						else
							bluePos = pos;
					}

					WL("Case #{0}: {1}", currentTestIndex + 1, totalTime);
				}
			}
		}

		static int abs(int a)
		{
			return a < 0 ? -a : a;
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
