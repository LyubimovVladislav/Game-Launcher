using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace GameLauncher
{
	public class ResourceManager
	{
		private string ProgramName { get; }
		public string RootPath { get; }

		public class GameInfo
		{
			public Version GameVersion { get; set; }
			public string GameFileName { get; }
			public string GameZipPath { get; }
			public string GameVersionPath { get; }
			public string GameExePath { get; }
			public string GameLink { get; }
			public string VersionLink { get; }

			public GameInfo(string gameZipPath, string gameVersionPath, string gameExePath,
				string gameLink, string versionLink, string gameFileName, Version gameVersion)
			{
				GameZipPath = gameZipPath;
				GameVersionPath = gameVersionPath;
				GameExePath = gameExePath;
				GameLink = gameLink;
				VersionLink = versionLink;
				GameFileName = gameFileName;
				GameVersion = gameVersion;
			}
		}

		public GameInfo Info { get; }

		public bool HasCorrectGamePath { get; }

		public ResourceManager()
		{
			RootPath = Directory.GetCurrentDirectory();
			ProgramName = Assembly.GetExecutingAssembly().Location;
			var gameVersionPath = Path.Combine(RootPath, "Version");
			var gameFileName = AssignExeFile();
			HasCorrectGamePath = gameFileName != null;
			var gameExePath = Path.Combine(RootPath, gameFileName ?? string.Empty);
			var gameZipPath = Path.Combine(RootPath, "GamePackage");
			var gameLink = GetGameLink();
			var versionLink = GetVersionLink();
			var gameVersion = ReadGameVersion(gameVersionPath);
			Info = new GameInfo(gameZipPath, gameVersionPath, gameExePath, gameLink, versionLink,
				gameFileName, gameVersion);
		}

		private Version ReadGameVersion(string gameVersionPath)
		{
			return File.Exists(gameVersionPath) ? 
				new Version(File.ReadAllText(gameVersionPath)) : new Version(0, 0);
		}

		private static string GetVersionLink()
		{
			return "https://drive.google.com/uc?export=download&id=1_kepCiUOhnzD9MUOklCPk7Crxw5hCLrU";
		}

		private static string GetGameLink()
		{
			return "https://drive.google.com/uc?export=download&id=1w-fDi9--5NWRr4uYE4L8R28iiPO1jWQ7";
		}

		private string AssignExeFile()
		{
			string[] fileEntries = Directory.GetFiles(RootPath);
			foreach (string fileName in fileEntries)
			{
				if (fileName.Equals(ProgramName) ||
				    Regex.IsMatch(fileName, ".*UnityCrashHandler64[.]exe$"))
					continue;
				if (Regex.IsMatch(fileName, ".+[.]exe$"))
				{
					return fileName;
				}
			}

			return null;
		}
	}
}