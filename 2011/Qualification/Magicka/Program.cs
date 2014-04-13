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
					int i;
					Dictionary<KeyValuePair<char,char>,char> complements = new Dictionary<KeyValuePair<char, char>, char>();
					Dictionary<KeyValuePair<char, char>, bool> opposites = new Dictionary<KeyValuePair<char, char>, bool>();
					List<char> result = new List<char>();

					string[] parts = reader.ReadLine().Split(' ');

					int numComplements = Convert.ToInt32(parts[0]);
					for (i = 1; i <= numComplements; i++)
					{
						char c1 = parts[i][0];
						char c2 = parts[i][1];
						char c3 = parts[i][2];
						complements.Add(new KeyValuePair<char, char>(c1, c2), c3);
						if (c1 != c2)
							complements.Add(new KeyValuePair<char, char>(c2, c1), c3);
					}

					int numOpposites = Convert.ToInt32(parts[i++]);
					for (int k = 0; k < numOpposites; k++, i++ )
					{
						char c1 = parts[i][0];
						char c2 = parts[i][1];
						opposites.Add(new KeyValuePair<char, char>(c1, c2), true);
						opposites.Add(new KeyValuePair<char, char>(c2, c1), true);
					}

					int strLen = Convert.ToInt32(parts[i++]);

					for (int k = 0; k < strLen; k++ )
					{
						char c = parts[i][k];

						if( result.Count > 0)
						{
							int lastIndex = result.Count - 1;
							char lastChar = result[lastIndex];

							char tmp;
							if (complements.TryGetValue(new KeyValuePair<char, char>(lastChar, c), out tmp))
							{
								result[lastIndex] = tmp;
								continue;
							}

							for (int n = 0; n < result.Count; n++)
							{
								bool b;
								if (opposites.TryGetValue(new KeyValuePair<char, char>(result[n], c), out b))
								{
									result.Clear();
									break;
								}
							}

							if (result.Count == 0)
								continue;
						}

						result.Add(c);
					}
					
					string[] r = new string[result.Count];
					for (int m = 0; m < r.Length; m++)
						r[m] = result[m].ToString();

					WL("Case #{0}: {1}", currentTestIndex + 1, "[" + string.Join(", ", r) + "]");
				}
			}
		}

	
		static int map(char c)
		{
			switch(c)
			{
			case 'Q':
				return 1 << 1;
			case 'W':
				return 1 << 2;
			case 'E':
				return 1 << 3;
			case 'R':
				return 1 << 4;
			case 'A':
				return 1 << 5;
			case 'S':
				return 1 << 6;
			case 'D':
				return 1 << 7;
			case 'F':
				return 1 << 8;
			default:
				return 0;
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
