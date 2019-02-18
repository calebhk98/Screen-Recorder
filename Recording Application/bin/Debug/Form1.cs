using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MetroFramework.Forms;
using Microsoft.Expression.Encoder;
using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.ScreenCapture;
using Microsoft.Expression.Encoder.Live;
using System.Collections.ObjectModel;
using Recording_Application.Properties;
using System.Deployment.Application;




namespace Recording_Application {
	public partial class RecordScreen : Form {
		private ScreenCaptureJob thisLittleJob;//This is the value for a new video.

		int timeToPreviewRecord;//in seconds


		public RecordScreen() {
			InitializeComponent();//This seems to put everything in it
			this.Size = new Size(Screen.PrimaryScreen.Bounds.Width/2, Screen.PrimaryScreen.Bounds.Height/2);
			pictureBox.Size = new Size(Screen.PrimaryScreen.Bounds.Width/2-115, Screen.PrimaryScreen.Bounds.Height/2 -50);
			this.Controls.Add(RecordingIcon);
			

			//string fileName = String.Format(@"{0}\type1.txt", Application.StartupPath);
			folderBrowserDialog1.SelectedPath = String.Format(@"{0}", Environment.CurrentDirectory);
			folderBrowserDialog1.SelectedPath = Path.GetFullPath(Path.Combine(folderBrowserDialog1.SelectedPath, @"..\..\..\"));
			//folderBrowserDialog1.SelectedPath = @"./test";
			saveFile.Text = folderBrowserDialog1.SelectedPath;

			string[] AudioNames = AudioDevicesNames();
			Console.WriteLine("Audio Names Length: "+AudioNames.Length);
			for(int i = 0; i < AudioNames.Length; i++) {
				Microphones.Items.Add(AudioNames [i]);
			}
			if(ApplicationDeployment.IsNetworkDeployed) {
				this.Text = string.Format("Your application name - v{0}", ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4));
			}



		}//Not sure what this does, but for anything to appear, we need this

		private void CaptureBtn_Click( object sender, EventArgs e ) {
			timeToPreviewRecord = 1;
			Capture();//Takes a screenshot
		}//This is the Screenshot button

		private void RecordBtn_Click( object sender, EventArgs e ) {
			StartRecord();//This is the recording
			timeToPreviewRecord = (int) (PreviewSeconds.Value);//Sets to preview for 3 seconds.
			Console.WriteLine(timeToPreviewRecord);
			System.Threading.Thread t = new System.Threading.Thread(Capture);// Creates a new thread to reduce lag
			t.Start();//Shows the first 3 seconds
		}//This is the start record button

		private void StopBtn_Click( object sender, EventArgs e ) {
			if(thisLittleJob != null && thisLittleJob.Status == RecordStatus.Running) {
				RecordingIcon.Image = Resources.Red_Circle;
				thisLittleJob.Stop();//Stops the recording
			}//This actually ensures that the application is recording, without this, it crashes
		}//This stops the recording

		private void SettingBtn_Click( object sender, EventArgs e ) {
			SettingCheck.Checked = Properties.Settings.Default.CountDown;
			SettingShow.Text = Properties.Settings.Default.SaveLocation;

			Countdown.Checked = Properties.Settings.Default.CountDown;
			CaptureMouseCursor.Checked = Properties.Settings.Default.MouseCapture;
			AutoMinimize.Checked = Properties.Settings.Default.autoMinimize;
			FlashingBoundry.Checked = Properties.Settings.Default.flashingBoundary;
			PreviewSeconds.Value = Properties.Settings.Default.previewSeconds;
			Unsure.Checked = Properties.Settings.Default.Unsure;
			folderBrowserDialog1.SelectedPath = Properties.Settings.Default.SaveLocation;
			saveFile.Text = Properties.Settings.Default.SaveLocation;
			 ScreenshotsName.Text = Properties.Settings.Default.FileName;
			 FramesPerSecond.Value = Properties.Settings.Default.FPS;
			 QualityAmount.Value = Properties.Settings.Default.Quality;

			Settings.Visible = true;
			Settings.Enabled = true;

		}

		private void SettingsExtBtn_Click( object sender, EventArgs e ) {
			ScreenshotsName.Text.Trim(new Char [] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' });
			Settings.Visible = false;
			Settings.Enabled = false;
			Properties.Settings.Default.CountDown = Countdown.Checked;
			Properties.Settings.Default.MouseCapture = CaptureMouseCursor.Checked;
			Properties.Settings.Default.autoMinimize = AutoMinimize.Checked;
			Properties.Settings.Default.flashingBoundary = FlashingBoundry.Checked;
			Properties.Settings.Default.previewSeconds = PreviewSeconds.Value;
			Properties.Settings.Default.Unsure = Unsure.Checked;
			Properties.Settings.Default.FileName = ScreenshotsName.Text;
			Properties.Settings.Default.FPS = FramesPerSecond.Value;
			Properties.Settings.Default.Quality = QualityAmount.Value;
			Properties.Settings.Default.Save();
		}

		private void SaveLocation_Click( object sender, EventArgs e ) {
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if(result == DialogResult.OK) {
				Console.WriteLine(folderBrowserDialog1.SelectedPath);
				saveFile.Text = folderBrowserDialog1.SelectedPath;
				Properties.Settings.Default.SaveLocation = folderBrowserDialog1.SelectedPath;
				Properties.Settings.Default.Save();
				//MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
			}
		}

		





	new void Capture() {
			bool IsPicture=false;//This variable determines if trying to take a picture or not, and assumes you are not
			if(timeToPreviewRecord == 0) {
				timeToPreviewRecord = 45;//This is a default with 3 seconds * 15 millisecond pause between each frame 
			}//If it is run without haveing an amount, the default is 3 seconds
			else if(timeToPreviewRecord == 1) {
				IsPicture = true;
			}//Checks if there is only 1 frame to take, and if so, then this is a screenshot
			else {
				timeToPreviewRecord=timeToPreviewRecord * 15;
			}//If not a screenshot, then multiply the value by 15 to turn from seconds to the number of screenshots
			
			for(int i = 0; i < (timeToPreviewRecord); timeToPreviewRecord--) {
				Bitmap bm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);//Makes a new bitmap the size of The screen
				Graphics Gr = Graphics.FromImage(bm);//Creates a graphic from the bitmap the size of the screen
				Gr.CopyFromScreen(0, 0, 0, 0, (bm.Size));//This takes the screen and copies it to the bitmap
				// (This determines where it is moved in the x axis at the Left,This determines where it is moved in the y axis at the top,This determines where it is moved in the x axis at the Right , This determines where it is moved in the y axis at the Bottom
				pictureBox.Image = bm;//Sets the Viewing area to the new picture so we can actually see it
				if(IsPicture) {
					DateTime dt = DateTime.Now; 
					string dateString = DateTime.Now.ToString("y-M-d h;m;s tt");//Grabs the current time
					string SaveFile = ScreenshotsName.Text + " "+ dateString; //Sets the Name for the screenshot
					Console.WriteLine(SaveFile);
					pictureBox.Image.Save(folderBrowserDialog1.SelectedPath +"\\" + SaveFile+".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);//Saves the picture as 1000test
				}//Saves the picture if not a preview
				int SleepTicks = (int)(1000 / FramesPerSecond.Value);
				System.Threading.Thread.Sleep(SleepTicks);//Sleeps for 15 milliseconds
			}//Takes a screenshot every 15 milliseconds until done

		}//This takes screenshots and saves/displays them

		

		void StartRecord() {
			thisLittleJob = new ScreenCaptureJob();//This allows you to create new videos

			// I don't know what any of this does
			if(Unsure.Checked) {
				System.Drawing.Size WorkingArea = SystemInformation.WorkingArea.Size;
				Rectangle captureRect = new Rectangle(0, 0, WorkingArea.Width - (WorkingArea.Width % 4), WorkingArea.Height - (WorkingArea.Height % 4));
				thisLittleJob.CaptureRectangle = captureRect;

			}


			thisLittleJob.ShowFlashingBoundary = FlashingBoundry.Checked;//Shows a blank screen in the alt tab list
			thisLittleJob.CaptureMouseCursor = CaptureMouseCursor.Checked;//Allows you to see the mouse in the video
			thisLittleJob.ScreenCaptureVideoProfile.Quality = (int)QualityAmount.Value;//Increases or decreases the "compression"
			thisLittleJob.ScreenCaptureVideoProfile.FrameRate = (double)(FramesPerSecond.Value);//Frames per second
			thisLittleJob.ShowCountdown = Countdown.Checked; //This shows a countdown
			RecordingIcon.Image = Resources.Green_Circle;
			/*
			if(MicSounds.Checked) {
				thisLittleJob.AddAudioDeviceSource(AudioDevices(0));//This will grab the sound from the microphone
			}
			if(ComputerSounds.Checked) {
				thisLittleJob.AddAudioDeviceSource(AudioDevices(2));//This will grab the sound from the computer
			}
			Console.WriteLine();
			Console.WriteLine("Selected Item: " + Microphones.SelectedItem);
			Console.WriteLine("Selected Index: " + Microphones.SelectedIndex);
			Console.WriteLine("Selected Value: " + Microphones.SelectedValue);
			Console.WriteLine();
			*/
			for(int i = 0; i <= (Microphones.Items.Count - 1); i++) {
				if(Microphones.GetItemChecked(i)) {
					//Console.WriteLine(Microphones.Items [i]);
					thisLittleJob.AddAudioDeviceSource(AudioDevices(i));
				}
			}


			thisLittleJob.OutputPath = folderBrowserDialog1.SelectedPath;//This is where to record to
			Console.WriteLine(folderBrowserDialog1.SelectedPath);
			thisLittleJob.Start();//Starts the recording
			if(AutoMinimize.Checked) {
				this.WindowState = FormWindowState.Minimized;//minimizes the application when start recording
			}//minimizes the application when start recording



		}//This creates a video 

		string[] AudioDevicesNames() {
			
			EncoderDevice ListeningDevice = null;
			Collection<EncoderDevice> audioDevicesNames = EncoderDevices.FindDevices(EncoderDeviceType.Audio);
			string [] Names = new string[audioDevicesNames.Count];
			for(int i = 0; i < audioDevicesNames.Count; i++) {
				Names[i] = audioDevicesNames [i].Name;
				Console.WriteLine(audioDevicesNames [i].Name);
				Console.WriteLine(audioDevicesNames [i].DevicePath);
			}
			return Names;
		}

		EncoderDevice AudioDevices(int x) {
			EncoderDevice foundDevice = null;// This sets the variable 
			Collection<EncoderDevice> audioDevices = EncoderDevices.FindDevices(EncoderDeviceType.Audio);//Sets a list with all audio

			Console.WriteLine();
			Console.WriteLine();
			for(int i = 0; i < audioDevices.Count; i++) {
				Console.WriteLine(audioDevices [i].Name);
				Console.WriteLine(audioDevices [i].DevicePath);
			}
			Console.WriteLine();
			Console.WriteLine();

			try {
				foundDevice = audioDevices.First();//Selects the first audio device in the list
				foundDevice = audioDevices [x];//selects the x audio device
				//MessageBox.Show("Audio Devices Found " + audioDevices [0].Name+ "\n Audio Devices Found " + audioDevices [1].Name);

			}
			catch(Exception ex) {
				MessageBox.Show("Audio Devices not Found"+ audioDevices[0].Name + ex.Message);//if there is an error, show what it is
			}//This sets found 

			return foundDevice;// This returns the audio device


		}// This is what adds sound
		
		
		private void Form1_FormClosing( object sender, FormClosingEventArgs e ) {
			if(thisLittleJob != null && thisLittleJob.Status == RecordStatus.Running) {
				RecordingIcon.Image = Resources.Red_Circle;
				thisLittleJob.Stop();//This stops a recording if it is happeing
			}//This makes sure there is a recording happening, without this, can not be easily closed
		}//This is what happens when you close the application

		private void ScreenshotsName_TextChanged( object sender, EventArgs e ) {
			Console.WriteLine("Testing "+ ScreenshotsName.Text);
			ScreenshotsName.Text.Trim(new Char [] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' });
			//var str = "My name @is ,Wan.;'; Wan";
			string [] charsToRemove = new string [] { "\\", "/", ":", "*", "?", "\"", "<", ">", "|" };
			foreach(var c in charsToRemove) {
				ScreenshotsName.Text = ScreenshotsName.Text.Replace(c, string.Empty);
			}
		}
	}
}
