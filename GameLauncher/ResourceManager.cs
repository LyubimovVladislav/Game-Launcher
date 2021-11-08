using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GameLauncher
{
	public class ResourceManager
	{
		private readonly string _programName;
		private readonly string _rootPath;
		public string ExePath { get; }

		public bool HasCorrectGamePath { get; }

		private string _gameFileName;


		public ResourceManager()
		{
			_rootPath = Directory.GetCurrentDirectory();
			_programName = Assembly.GetExecutingAssembly().Location;
			HasCorrectGamePath = false;
			if (!AssignExeFile()) return;
			HasCorrectGamePath = true;
			ExePath = Path.Combine(_rootPath, _gameFileName);
		}


		private bool AssignExeFile()
		{
			string[] fileEntries = Directory.GetFiles(_rootPath);
			foreach (string fileName in fileEntries)
			{
				if (fileName.Equals(_programName) ||
				    Regex.IsMatch(fileName,".*UnityCrashHandler64[.]exe$"))
					continue;
				if (Regex.IsMatch(fileName, ".+[.]exe$"))
				{
					_gameFileName = fileName;
					return true;
				}
			}

			return false;
		}
	}
}