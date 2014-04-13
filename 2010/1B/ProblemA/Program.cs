using System;
using System.Collections.Generic;


namespace ProblemA
{
	class Directory
	{
		public string Name;
		public DirList SubDirs;
	}


	class DirList : List<Directory>
	{
		public Directory FindDirectory(string dir)
		{
			for (int i = 0, count = Count; i < count; i++)
				if (this[i].Name == dir)
					return this[i];
			return null;
		}
	}


	class Program
	{
		static void Main()
		{
			int testsCount = StringToNumbers(Console.ReadLine(), 1)[0];
			for (int testIndex = 0; testIndex < testsCount; testIndex++)
			{
				int[] counts = StringToNumbers(Console.ReadLine(), 2);

				string[] existingDirs = new string[counts[0]];
				string[] neededDirs = new string[counts[1]];

				for (int i = 0; i < existingDirs.Length; i++)
					existingDirs[i] = Console.ReadLine();
				for (int i = 0; i < neededDirs.Length; i++)
					neededDirs[i] = Console.ReadLine();

				int result = Solve(existingDirs, neededDirs);

				Console.WriteLine("Case #{0}: {1}", testIndex+1, result);
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


		static int Solve(string[] existingDirs, string[] neededDirs)
		{
			DirList root = new DirList();

			foreach(string dir in existingDirs)
			{
				DirList dirTree = root;

				string[] dirParts = dir.Split('/');
				for (int i = 1; i < dirParts.Length; i++)
				{
					Directory subDir;
					LookupSubDir(dirTree, dirParts[i], out subDir);
					dirTree = subDir.SubDirs;
				}
			}

			int creations = 0;

			foreach(string dir in neededDirs)
			{
				DirList dirTree = root;

				string[] dirParts = dir.Split('/');
				for (int i = 1; i < dirParts.Length; i++)
				{
					Directory subDir;
					creations += LookupSubDir(dirTree, dirParts[i], out subDir);
					dirTree = subDir.SubDirs;
				}
			}

			return creations;
		}


		static int LookupSubDir(DirList dirList, string subDirName, out Directory subDir)
		{
			subDir = dirList.FindDirectory(subDirName);
			if (subDir == null)
			{
				subDir = new Directory();
				subDir.Name = subDirName;
				subDir.SubDirs = new DirList();
				dirList.Add(subDir);
				return 1;
			}

			return 0;
		}
	}
}
