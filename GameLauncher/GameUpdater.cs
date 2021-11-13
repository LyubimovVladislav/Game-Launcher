using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLauncher
{
	public delegate void DownloadCompletedHandler(object source, EventArgs e);
	public class GameUpdater
	{
		private readonly ResourceManager.GameInfo _gameInfo;
		private readonly string _rootPath;
		public event DownloadCompletedHandler DownloadCompleted;

		public GameUpdater(ResourceManager resourceManager)
		{
			_gameInfo = resourceManager.Info;
			_rootPath = resourceManager.RootPath;
		}

		public async void UpdateIfPresent()
		{
			var onlineVersion = await CheckForUpdates();
			if (onlineVersion != null)
				DownloadGameFiles(onlineVersion);
		}

		public async Task<Version> CheckForUpdates()
		{
			try
			{
				WebClient webClient = new WebClient();
				string versionString = await webClient.DownloadStringTaskAsync(new Uri(_gameInfo.VersionLink));
				Version onlineVersion = new Version(versionString);
				return onlineVersion.CompareTo(_gameInfo.GameVersion) == 1 ? onlineVersion : null;
			}
			catch (Exception ex) when (ex is ArgumentNullException or WebException or NotSupportedException)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}


		private void DownloadGameFiles(Version onlineVersion)
		{
			try
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFileCompleted += OnGameDownloadCompleted;
				webClient.DownloadFileAsync(new Uri(_gameInfo.GameLink), _gameInfo.GameZipPath, onlineVersion);
			}
			catch (Exception ex) when (ex is ArgumentNullException or WebException or InvalidOperationException)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void OnGameDownloadCompleted(object sender, AsyncCompletedEventArgs args)
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
				DownloadCompleted?.Invoke(this,EventArgs.Empty);
				File.WriteAllText(_gameInfo.GameVersionPath, onlineVersion);
			} // Relocate all the catches into MainForm? Hadn't find a way to do that
			catch (InvalidDataException)
			{
				MessageBox.Show("Update server error. Game archive is in wrong format.");
			}
		}
	}
}