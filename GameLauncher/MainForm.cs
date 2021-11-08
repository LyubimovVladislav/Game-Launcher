using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace GameLauncher
{
	public partial class MainForm : Form
	{
		private readonly ResourceManager _resources;

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

			public new string ToString()
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
			ProcessStartInfo startInfo = new ProcessStartInfo(_resources.ExePath) {Arguments = CombineArguments()};
			Process.Start(startInfo);
			Close();
		}

		private string CombineArguments()
		{
			return
				$"{_apiNameCommand}{_resolutionCommand.ToString()}{_fullscreenCommand}{_qualityCommand}{_windowModeCommand}";
		}
	}
}