using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.Windows.Forms;

namespace GameLauncher
{
	public class GameUpdater
	{
		private readonly ResourceManager.GameInfo _gameInfo;
		private readonly string _rootPath;
		private readonly MainForm _parent;

		public GameUpdater(MainForm parent, ResourceManager resourceManager)
		{
			_parent = parent;
			_gameInfo = resourceManager.Info;
			_rootPath = resourceManager.RootPath;
		}

		public bool CheckAndUpdate()
		{
			var (flag, onlineVersion) = CheckForUpdates();
			if (flag)
				DownloadGameFiles(onlineVersion);
			return flag;
		}

		public (bool, Version) CheckForUpdates()
		{
			try
			{
				WebClient webClient = new WebClient();
				Version onlineVersion = new Version(webClient.DownloadString(_gameInfo.VersionLink));

				return (onlineVersion.CompareTo(_gameInfo.GameVersion) == 1, onlineVersion);
			}
			catch (Exception ex) when (ex is ArgumentNullException or WebException or NotSupportedException)
			{
				MessageBox.Show(ex.Message);
				return (false, new Version(0, 0));
			}
		}

		private void DownloadGameFiles(Version onlineVersion)
		{
			try
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFileCompleted += OnDownloadCompleted;
				webClient.DownloadFileAsync(new Uri(_gameInfo.GameLink), _gameInfo.GameZipPath, onlineVersion);
			}
			catch (Exception ex) when (ex is ArgumentNullException or WebException or InvalidOperationException)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void OnDownloadCompleted(object sender, AsyncCompletedEventArgs args)
		{
			try
			{
				string onlineVersion = args.UserState.ToString();
				using (ZipArchive archive = new ZipArchive(new FileStream(_gameInfo.GameZipPath, FileMode.Open)))
				{
					archive.ExtractToDirectory(_rootPath, true);
				}

				File.Delete(_gameInfo.GameZipPath);
				_gameInfo.GameVersion = new Version(onlineVersion);
				_parent.ChangeText();
				File.WriteAllText(_gameInfo.GameVersionPath, onlineVersion);
			} // Relocate all the catches into MainForm? Hadn't find a way to do that
			catch (InvalidDataException ex)
			{
				MessageBox.Show("Update server error. Game archive is in wrong format.");
			}
		}
	}
}