using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace GameLauncher
{
	public partial class MainForm : Form
	{
		private readonly ResourceManager _resources;
		private readonly GameUpdater _gameUpdater;
		private bool _isReadyForUpdate;

		private struct Resolution
		{
			public string Width { get; set; }
			public string Height { get; set; }
			private const string PrefixWidth = "-screen-width";
			private const string PrefixHeight = "-screen-height";


			public Resolution(string width, string height)
			{
				Width = width;
				Height = height;
			}

			public override string ToString()
			{
				return $"{PrefixWidth} {Width} {PrefixHeight} {Height} ";
			}
		}

		private Resolution _resolutionCommand;
		private string _qualityCommand;
		private string _fullscreenCommand;
		private string _apiNameCommand;
		private string _windowModeCommand;

		public MainForm()
		{
			InitializeComponent();
			_resources = new ResourceManager();
			_resolutionCommand = new Resolution();
			_gameUpdater = new GameUpdater(this, _resources);
			_isReadyForUpdate = false;
			versionLabel.Text = $@"Version: {_resources.Info.GameVersion}";
		}

		private void playButton_Click(object sender, EventArgs e)
		{
			if (!_resources.HasCorrectGamePath)
			{
				using ErrorForm error = new ErrorForm();
				error.ShowDialog(this);
			}
			else
			{
				ParseResolutionString();
				ParseFullscreenString();
				ParseQualityString();
				ParseWindowModeString();
				ParseApiString();
				StartProcess();
			}
		}

		private void ParseResolutionString()
		{
			string text = resolutionBox.Text;
			string[] resolution = text.Split('x');
			for (int i = 0; i < resolution.Length; i++)
			{
				resolution[i] = resolution[i].Trim();
			}

			_resolutionCommand.Width = resolution[0];
			_resolutionCommand.Height = resolution[1];
		}

		private void ParseQualityString()
		{
			_qualityCommand = qualityBox.Text == "Auto"
				? string.Empty
				: $"-screen-quality {qualityBox.Text.ToLower()} ";
		}

		private void ParseFullscreenString()
		{
			var temp = fullscreenBox.Checked ? 1 : 0;
			_fullscreenCommand = $"-screen-fullscreen {temp} ";
		}

		private void ParseWindowModeString()
		{
			_windowModeCommand = $"-window-mode {windowModeBox.Text.ToLower()} ";
		}

		private void ParseApiString()
		{
			List<RadioButton> list = new List<RadioButton>(
				new RadioButton[] {automaticApiButton, vulcanApiButton, dx11ApiButton, dx12ApiButton, openglApiButton});
			string temp = string.Empty;
			foreach (var button in list)
			{
				if (button.Checked)
				{
					temp = button.Text switch
					{
						"Automatic" => string.Empty,
						"Vulkan" => "-force-vulkan ",
						"DirectX 11" => "-force-d3d11 ",
						"DirectX 12" => "-force-d3d12 ",
						"OpenGL" =>
							// ReSharper disable once StringLiteralTypo
							"-force-glcore ",
						_ => string.Empty
					};
					break;
				}
			}

			_apiNameCommand = temp;
		}

		private void StartProcess()
		{
			ProcessStartInfo startInfo = new ProcessStartInfo(_resources.Info.GameExePath)
				{Arguments = CombineArguments()};
			Process.Start(startInfo);
			Close();
		}

		private string CombineArguments()
		{
			return
				$"{_apiNameCommand}{_resolutionCommand}{_fullscreenCommand}{_qualityCommand}{_windowModeCommand}";
		}

		private void checkUpdateButton_Click(object sender, EventArgs eventArgs)
		{
			if (!_isReadyForUpdate)
			{
				if (!_gameUpdater.CheckForUpdates().Item1)
				{
					SetUpdated();
				}
				else
				{
					SetNotUpdated();
				}
			}
			else
			{
				_gameUpdater.CheckAndUpdate();
				checkUpdateButton.Enabled = false;
				playButton.Enabled = false;
			}
		}

		public void ChangeText()
		{
			SetUpdated();
		}

		private void SetUpdated()
		{
			versionLabel.Text = $@"Version: {_resources.Info.GameVersion}";
			updateLabel.Text = "Your game is up to date";
			updateLabel.ForeColor = Color.Green;
			checkUpdateButton.Text = "Check for updates";
			_isReadyForUpdate = false;
			checkUpdateButton.Enabled = true;
			playButton.Enabled = true;
		}

		private void SetNotUpdated()
		{
			updateLabel.Text = "Your game is outdated";
			updateLabel.ForeColor = Color.Red;
			checkUpdateButton.Text = "Update";
			_isReadyForUpdate = true;
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			checkUpdateButton_Click(null, null);
		}
	}
}