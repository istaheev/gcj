using System;
using System.Collections.Generic;
using System.IO;


namespace HouseOfKittens
{
	class Program
	{
		List<int[]> split(List<int> vertices, List<int> ul, List<int> vl)
		{
			if (ul.Count == 0)
			{
				List<int[]> r = new List<int[]>();
				r.Add(vertices.ToArray());
				return r;
			}

			int u = ul[0];
			int v = vl[0];
			if (v < u)
			{
				u = vl[0];
				v = ul[0];
			}

			List<int> right = new List<int>();
			List<int> left = new List<int>();

			right.Add(u);
			right.Add(v);

			for( int i=0; i<vertices.Count; i++)
			{
				if( vertices[i] <= u || vertices[i] >= v)
					left.Add(vertices[i]);
				if (vertices[i] >= u || vertices[i] <= v)
					right.Add(vertices[i]);
			}

			ul.RemoveAt(0);
			vl.RemoveAt(0);
			return split(left, ul, vl).AddRange(split(right, ul, vl));
		}


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
					long M = Convert.ToInt32(inputStr[1]);

					int[] u = new int[M];
					int[] v = new int[M];

					// begin coord
					inputStr = reader.ReadLine().Split(' ');
					for (int i = 0; i < M; i++)
						u[i] = Convert.ToInt32(inputStr[i]);

					// end coord
					inputStr = reader.ReadLine().Split(' ');
					for (int i = 0; i < M; i++)
						v[i] = Convert.ToInt32(inputStr[i]);

					for (int i = 0; i < u.Length; i++ )
					{
						if( u[i] > v[i])
						{
							int t = u[i];
							u[i] = v[i];
							v[i] = t;
						}
					}
					

					WL("Case #{0}: {1}", currentTestIndex + 1, true);
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
