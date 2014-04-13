using System;
using System.Collections.Generic;
using System.IO;


public class SnapperChain
{
	public static void Main()
	{
		//const string Input = @"C:\Work\Personal\GoogleJam_2010\Snapper Chain\input.txt";
		const string Input = @"input.txt";
		
		using(StreamReader reader = File.OpenText(Input))
		{
			int testsCount = Convert.ToInt32(reader.ReadLine());
			
			for( int currentTestIndex=0; currentTestIndex<testsCount; currentTestIndex++)
			{
				string[] inputStr = reader.ReadLine().Split(' ');
				int N = Convert.ToInt32(inputStr[0]);
				long K = Convert.ToInt64(inputStr[1]);
				
				WL("Case #{0}: {1}", currentTestIndex+1, CheckBitsAreSetTo1(K, N) ? "ON" : "OFF");
				//WL("N: {0}; K: {1}; Result: {2}", N, K, CheckBitsAreSetTo1(K, N));
			}
		}
	}
	
	
	private static bool CheckBitsAreSetTo1(long number, int bitsCount)
	{
		for( ; bitsCount > 0; bitsCount--, number /= 2 )
		{
			if( number % 2 == 0)
				return false;
		}
		
		return true;
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