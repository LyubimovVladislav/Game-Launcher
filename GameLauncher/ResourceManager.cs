using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


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
			string gameLink, versionLink;
			try
			{
				gameLink = GetGameLink();
				versionLink = GetVersionLink();
			}
			catch (WebException e)
			{
				Task.Run(async () =>
				{
					await Task.Delay(1000);
					return MessageBox.Show($@"{e.Message}");
				});
				gameLink = null;
				versionLink = null;
			}

			var gameVersion = ReadGameVersion(gameVersionPath);
			Info = new GameInfo(gameZipPath, gameVersionPath, gameExePath, gameLink, versionLink,
				gameFileName, gameVersion);
		}

		private Version ReadGameVersion(string gameVersionPath)
		{
			return File.Exists(gameVersionPath) ? new Version(File.ReadAllText(gameVersionPath)) : new Version(0, 0);
		}

		private static string GetVersionLink()
		{
			var url = new Uri("https://cloud-api.yandex.net/v1/disk/public/resources/download?public_key=" +
			                  WebUtility.UrlEncode("https://disk.yandex.ru/d/jMnHiBK-scdCbw"));

			using WebClient webClient = new WebClient();
			var result = webClient.DownloadString(url).Split('"');
			return result[3];
		}

		private static string GetGameLink()
		{
			var url = new Uri("https://cloud-api.yandex.net/v1/disk/public/resources/download?public_key=" +
			                  WebUtility.UrlEncode("https://disk.yandex.ru/d/pF2MwO9dAL5fTA"));

			using WebClient webClient = new WebClient();
			var result = webClient.DownloadString(url).Split('"');
			return result[3];
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