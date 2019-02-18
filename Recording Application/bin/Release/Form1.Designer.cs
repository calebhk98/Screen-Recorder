namespace Recording_Application {
	partial class RecordScreen {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.CaptureBtn = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.RecordBtn = new System.Windows.Forms.Button();
			this.StopBtn = new System.Windows.Forms.Button();
			this.SettingButton = new System.Windows.Forms.Button();
			this.Settings = new System.Windows.Forms.SplitContainer();
			this.SettingsExtBtn = new System.Windows.Forms.Button();
			this.MicSounds = new System.Windows.Forms.CheckBox();
			this.ComputerSounds = new System.Windows.Forms.CheckBox();
			this.ScreenshotsName = new System.Windows.Forms.TextBox();
			this.saveFile = new System.Windows.Forms.Label();
			this.SaveLocation = new System.Windows.Forms.Button();
			this.PreviewSecondsText = new System.Windows.Forms.Label();
			this.PreviewSeconds = new System.Windows.Forms.NumericUpDown();
			this.AutoMinimize = new System.Windows.Forms.CheckBox();
			this.Countdown = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Settings)).BeginInit();
			this.Settings.Panel1.SuspendLayout();
			this.Settings.Panel2.SuspendLayout();
			this.Settings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PreviewSeconds)).BeginInit();
			this.SuspendLayout();
			// 
			// CaptureBtn
			// 
			this.CaptureBtn.Location = new System.Drawing.Point(13, 5);
			this.CaptureBtn.Name = "CaptureBtn";
			this.CaptureBtn.Size = new System.Drawing.Size(75, 41);
			this.CaptureBtn.TabIndex = 0;
			this.CaptureBtn.Text = "Screen Shot";
			this.CaptureBtn.UseVisualStyleBackColor = true;
			this.CaptureBtn.Click += new System.EventHandler(this.CaptureBtn_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(94, 5);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(486, 343);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 1;
			this.pictureBox.TabStop = false;
			// 
			// RecordBtn
			// 
			this.RecordBtn.Location = new System.Drawing.Point(13, 52);
			this.RecordBtn.Name = "RecordBtn";
			this.RecordBtn.Size = new System.Drawing.Size(75, 41);
			this.RecordBtn.TabIndex = 2;
			this.RecordBtn.Text = "Record";
			this.RecordBtn.UseVisualStyleBackColor = true;
			this.RecordBtn.Click += new System.EventHandler(this.RecordBtn_Click);
			// 
			// StopBtn
			// 
			this.StopBtn.Location = new System.Drawing.Point(12, 99);
			this.StopBtn.Name = "StopBtn";
			this.StopBtn.Size = new System.Drawing.Size(75, 41);
			this.StopBtn.TabIndex = 3;
			this.StopBtn.Text = "Stop Recording";
			this.StopBtn.UseVisualStyleBackColor = true;
			this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
			// 
			// SettingButton
			// 
			this.SettingButton.Location = new System.Drawing.Point(13, 147);
			this.SettingButton.Name = "SettingButton";
			this.SettingButton.Size = new System.Drawing.Size(75, 41);
			this.SettingButton.TabIndex = 4;
			this.SettingButton.Text = "Settings";
			this.SettingButton.UseVisualStyleBackColor = true;
			this.SettingButton.Click += new System.EventHandler(this.SettingBtn_Click);
			// 
			// Settings
			// 
			this.Settings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Settings.Enabled = false;
			this.Settings.Location = new System.Drawing.Point(0, 0);
			this.Settings.Name = "Settings";
			// 
			// Settings.Panel1
			// 
			this.Settings.Panel1.Controls.Add(this.SettingsExtBtn);
			// 
			// Settings.Panel2
			// 
			this.Settings.Panel2.AutoScroll = true;
			this.Settings.Panel2.Controls.Add(this.MicSounds);
			this.Settings.Panel2.Controls.Add(this.ComputerSounds);
			this.Settings.Panel2.Controls.Add(this.ScreenshotsName);
			this.Settings.Panel2.Controls.Add(this.saveFile);
			this.Settings.Panel2.Controls.Add(this.SaveLocation);
			this.Settings.Panel2.Controls.Add(this.PreviewSecondsText);
			this.Settings.Panel2.Controls.Add(this.PreviewSeconds);
			this.Settings.Panel2.Controls.Add(this.AutoMinimize);
			this.Settings.Panel2.Controls.Add(this.Countdown);
			this.Settings.Panel2.Controls.Add(this.label1);
			this.Settings.Size = new System.Drawing.Size(592, 368);
			this.Settings.SplitterDistance = 84;
			this.Settings.TabIndex = 5;
			this.Settings.Visible = false;
			// 
			// SettingsExtBtn
			// 
			this.SettingsExtBtn.Location = new System.Drawing.Point(6, 5);
			this.SettingsExtBtn.Name = "SettingsExtBtn";
			this.SettingsExtBtn.Size = new System.Drawing.Size(75, 23);
			this.SettingsExtBtn.TabIndex = 0;
			this.SettingsExtBtn.Text = "Exit";
			this.SettingsExtBtn.UseVisualStyleBackColor = true;
			this.SettingsExtBtn.Click += new System.EventHandler(this.SettingsExtBtn_Click);
			// 
			// MicSounds
			// 
			this.MicSounds.AutoSize = true;
			this.MicSounds.Checked = true;
			this.MicSounds.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MicSounds.Location = new System.Drawing.Point(21, 180);
			this.MicSounds.Name = "MicSounds";
			this.MicSounds.Size = new System.Drawing.Size(127, 17);
			this.MicSounds.TabIndex = 9;
			this.MicSounds.Text = "Sounds from the mics";
			this.MicSounds.UseVisualStyleBackColor = true;
			// 
			// ComputerSounds
			// 
			this.ComputerSounds.AutoSize = true;
			this.ComputerSounds.Checked = true;
			this.ComputerSounds.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ComputerSounds.Location = new System.Drawing.Point(21, 156);
			this.ComputerSounds.Name = "ComputerSounds";
			this.ComputerSounds.Size = new System.Drawing.Size(110, 17);
			this.ComputerSounds.TabIndex = 8;
			this.ComputerSounds.Text = "Computer Sounds";
			this.ComputerSounds.UseVisualStyleBackColor = true;
			// 
			// ScreenshotsName
			// 
			this.ScreenshotsName.Location = new System.Drawing.Point(21, 129);
			this.ScreenshotsName.MaxLength = 30;
			this.ScreenshotsName.Name = "ScreenshotsName";
			this.ScreenshotsName.Size = new System.Drawing.Size(100, 20);
			this.ScreenshotsName.TabIndex = 7;
			this.ScreenshotsName.Text = "ScreenShot";
			this.ScreenshotsName.TextChanged += new System.EventHandler(this.ScreenshotsName_TextChanged);
			// 
			// saveFile
			// 
			this.saveFile.AutoSize = true;
			this.saveFile.Location = new System.Drawing.Point(110, 104);
			this.saveFile.Name = "saveFile";
			this.saveFile.Size = new System.Drawing.Size(123, 13);
			this.saveFile.TabIndex = 6;
			this.saveFile.Text = "Error, should not see this";
			// 
			// SaveLocation
			// 
			this.SaveLocation.Location = new System.Drawing.Point(21, 99);
			this.SaveLocation.Name = "SaveLocation";
			this.SaveLocation.Size = new System.Drawing.Size(75, 23);
			this.SaveLocation.TabIndex = 5;
			this.SaveLocation.Text = "Save Location";
			this.SaveLocation.UseVisualStyleBackColor = true;
			this.SaveLocation.Click += new System.EventHandler(this.SaveLocation_Click);
			// 
			// PreviewSecondsText
			// 
			this.PreviewSecondsText.AutoSize = true;
			this.PreviewSecondsText.Location = new System.Drawing.Point(56, 75);
			this.PreviewSecondsText.Name = "PreviewSecondsText";
			this.PreviewSecondsText.Size = new System.Drawing.Size(89, 13);
			this.PreviewSecondsText.TabIndex = 4;
			this.PreviewSecondsText.Text = "Seconds preview";
			// 
			// PreviewSeconds
			// 
			this.PreviewSeconds.Location = new System.Drawing.Point(21, 72);
			this.PreviewSeconds.Name = "PreviewSeconds";
			this.PreviewSeconds.Size = new System.Drawing.Size(29, 20);
			this.PreviewSeconds.TabIndex = 3;
			this.PreviewSeconds.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// AutoMinimize
			// 
			this.AutoMinimize.AutoSize = true;
			this.AutoMinimize.Checked = true;
			this.AutoMinimize.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AutoMinimize.Location = new System.Drawing.Point(21, 52);
			this.AutoMinimize.Name = "AutoMinimize";
			this.AutoMinimize.Size = new System.Drawing.Size(91, 17);
			this.AutoMinimize.TabIndex = 2;
			this.AutoMinimize.Text = "Auto Minimize";
			this.AutoMinimize.UseVisualStyleBackColor = true;
			// 
			// Countdown
			// 
			this.Countdown.AutoSize = true;
			this.Countdown.Location = new System.Drawing.Point(21, 28);
			this.Countdown.Name = "Countdown";
			this.Countdown.Size = new System.Drawing.Size(80, 17);
			this.Countdown.TabIndex = 1;
			this.Countdown.Text = "Countdown";
			this.Countdown.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(195, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Video Recording";
			// 
			// RecordScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 368);
			this.Controls.Add(this.Settings);
			this.Controls.Add(this.SettingButton);
			this.Controls.Add(this.StopBtn);
			this.Controls.Add(this.RecordBtn);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.CaptureBtn);
			this.Name = "RecordScreen";
			this.ShowIcon = false;
			this.Text = "Record Screen";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.Settings.Panel1.ResumeLayout(false);
			this.Settings.Panel2.ResumeLayout(false);
			this.Settings.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Settings)).EndInit();
			this.Settings.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PreviewSeconds)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CaptureBtn;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button RecordBtn;
		private System.Windows.Forms.Button StopBtn;
		private System.Windows.Forms.Button SettingButton;
		private System.Windows.Forms.SplitContainer Settings;
		private System.Windows.Forms.CheckBox Countdown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button SettingsExtBtn;
		private System.Windows.Forms.CheckBox AutoMinimize;
		private System.Windows.Forms.Label PreviewSecondsText;
		private System.Windows.Forms.NumericUpDown PreviewSeconds;
		private System.Windows.Forms.Button SaveLocation;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label saveFile;
		private System.Windows.Forms.TextBox ScreenshotsName;
		private System.Windows.Forms.CheckBox MicSounds;
		private System.Windows.Forms.CheckBox ComputerSounds;
	}
}

