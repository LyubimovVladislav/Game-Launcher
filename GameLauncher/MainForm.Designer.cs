namespace GameLauncher
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.openglApiButton = new System.Windows.Forms.RadioButton();
			this.dx12ApiButton = new System.Windows.Forms.RadioButton();
			this.dx11ApiButton = new System.Windows.Forms.RadioButton();
			this.vulcanApiButton = new System.Windows.Forms.RadioButton();
			this.automaticApiButton = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.windowModeBox = new System.Windows.Forms.ComboBox();
			this.fullscreenBox = new System.Windows.Forms.CheckBox();
			this.qualityBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.resolutionBox = new System.Windows.Forms.ComboBox();
			this.playButton = new System.Windows.Forms.Button();
			this.checkUpdateButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.openglApiButton);
			this.groupBox1.Controls.Add(this.dx12ApiButton);
			this.groupBox1.Controls.Add(this.dx11ApiButton);
			this.groupBox1.Controls.Add(this.vulcanApiButton);
			this.groupBox1.Controls.Add(this.automaticApiButton);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(193, 183);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Graphical API";
			// 
			// openglApiButton
			// 
			this.openglApiButton.Location = new System.Drawing.Point(46, 142);
			this.openglApiButton.Name = "openglApiButton";
			this.openglApiButton.Size = new System.Drawing.Size(104, 24);
			this.openglApiButton.TabIndex = 4;
			this.openglApiButton.Text = "OpenGL";
			this.openglApiButton.UseVisualStyleBackColor = true;
			// 
			// dx12ApiButton
			// 
			this.dx12ApiButton.Location = new System.Drawing.Point(46, 112);
			this.dx12ApiButton.Name = "dx12ApiButton";
			this.dx12ApiButton.Size = new System.Drawing.Size(104, 24);
			this.dx12ApiButton.TabIndex = 3;
			this.dx12ApiButton.Text = "DirectX 12";
			this.dx12ApiButton.UseVisualStyleBackColor = true;
			// 
			// dx11ApiButton
			// 
			this.dx11ApiButton.Location = new System.Drawing.Point(46, 82);
			this.dx11ApiButton.Name = "dx11ApiButton";
			this.dx11ApiButton.Size = new System.Drawing.Size(104, 24);
			this.dx11ApiButton.TabIndex = 2;
			this.dx11ApiButton.Text = "DirectX 11";
			this.dx11ApiButton.UseVisualStyleBackColor = true;
			// 
			// vulcanApiButton
			// 
			this.vulcanApiButton.Location = new System.Drawing.Point(46, 52);
			this.vulcanApiButton.Name = "vulcanApiButton";
			this.vulcanApiButton.Size = new System.Drawing.Size(104, 24);
			this.vulcanApiButton.TabIndex = 1;
			this.vulcanApiButton.Text = "Vulkan";
			this.vulcanApiButton.UseVisualStyleBackColor = true;
			// 
			// automaticApiButton
			// 
			this.automaticApiButton.Checked = true;
			this.automaticApiButton.Location = new System.Drawing.Point(46, 22);
			this.automaticApiButton.Name = "automaticApiButton";
			this.automaticApiButton.Size = new System.Drawing.Size(104, 24);
			this.automaticApiButton.TabIndex = 0;
			this.automaticApiButton.TabStop = true;
			this.automaticApiButton.Text = "Automatic";
			this.automaticApiButton.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.windowModeBox);
			this.groupBox2.Controls.Add(this.fullscreenBox);
			this.groupBox2.Controls.Add(this.qualityBox);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.resolutionBox);
			this.groupBox2.Location = new System.Drawing.Point(215, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(204, 183);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Video Settings";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 81);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 21);
			this.label5.TabIndex = 7;
			this.label5.Text = "Window Mode";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// windowModeBox
			// 
			this.windowModeBox.FormattingEnabled = true;
			this.windowModeBox.Items.AddRange(new object[] {"Exclusive", "Borderless"});
			this.windowModeBox.Location = new System.Drawing.Point(97, 82);
			this.windowModeBox.Name = "windowModeBox";
			this.windowModeBox.Size = new System.Drawing.Size(101, 21);
			this.windowModeBox.TabIndex = 6;
			this.windowModeBox.Text = "Exclusive";
			// 
			// fullscreenBox
			// 
			this.fullscreenBox.Checked = true;
			this.fullscreenBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fullscreenBox.Location = new System.Drawing.Point(51, 142);
			this.fullscreenBox.Name = "fullscreenBox";
			this.fullscreenBox.Size = new System.Drawing.Size(104, 24);
			this.fullscreenBox.TabIndex = 5;
			this.fullscreenBox.Text = "Fullscreen";
			this.fullscreenBox.UseVisualStyleBackColor = true;
			// 
			// qualityBox
			// 
			this.qualityBox.FormattingEnabled = true;
			this.qualityBox.Items.AddRange(new object[] {"Auto", "Low", "Medium", "High"});
			this.qualityBox.Location = new System.Drawing.Point(97, 51);
			this.qualityBox.Name = "qualityBox";
			this.qualityBox.Size = new System.Drawing.Size(101, 21);
			this.qualityBox.TabIndex = 4;
			this.qualityBox.Text = "Auto";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 21);
			this.label2.TabIndex = 2;
			this.label2.Text = "Quality";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Resolution";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// resolutionBox
			// 
			this.resolutionBox.FormattingEnabled = true;
			this.resolutionBox.Items.AddRange(new object[] {"4096 x 3072", "3840 x 2160", "2560 x 1440", "1920 x 1080", "1280 x 720", "854 x 480", "640 x 360", "426 x 240"});
			this.resolutionBox.Location = new System.Drawing.Point(97, 22);
			this.resolutionBox.Name = "resolutionBox";
			this.resolutionBox.Size = new System.Drawing.Size(101, 21);
			this.resolutionBox.TabIndex = 0;
			this.resolutionBox.Text = "1920 x 1080";
			// 
			// playButton
			// 
			this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
			this.playButton.Location = new System.Drawing.Point(130, 325);
			this.playButton.Name = "playButton";
			this.playButton.Size = new System.Drawing.Size(143, 37);
			this.playButton.TabIndex = 2;
			this.playButton.Text = "Play";
			this.playButton.UseVisualStyleBackColor = true;
			this.playButton.Click += new System.EventHandler(this.playButton_Click);
			// 
			// checkUpdateButton
			// 
			this.checkUpdateButton.Location = new System.Drawing.Point(314, 280);
			this.checkUpdateButton.Name = "checkUpdateButton";
			this.checkUpdateButton.Size = new System.Drawing.Size(113, 30);
			this.checkUpdateButton.TabIndex = 3;
			this.checkUpdateButton.Text = "Check for updates";
			this.checkUpdateButton.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(287, 341);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(140, 21);
			this.label3.TabIndex = 4;
			this.label3.Text = "Game version: x.xx(a)";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.Green;
			this.label4.Location = new System.Drawing.Point(306, 313);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 28);
			this.label4.TabIndex = 5;
			this.label4.Text = "Your game is up to date";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 371);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.checkUpdateButton);
			this.Controls.Add(this.playButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Launcher";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.Label label5;

		private System.Windows.Forms.ComboBox windowModeBox;

		private System.Windows.Forms.CheckBox fullscreenBox;
		private System.Windows.Forms.Button playButton;
		private System.Windows.Forms.Button checkUpdateButton;
		private System.Windows.Forms.Label label4;

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox resolutionBox;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.ComboBox qualityBox;

		private System.Windows.Forms.RadioButton openglApiButton;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton automaticApiButton;
		private System.Windows.Forms.RadioButton vulcanApiButton;
		private System.Windows.Forms.RadioButton dx11ApiButton;
		private System.Windows.Forms.RadioButton dx12ApiButton;

		#endregion
	}
}