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




namespace Recording_Application {
	public partial class RecordScreen : Form {
		private ScreenCaptureJob thisLittleJob;//This is the value for a new video.

		int timeToPreviewRecord;//in seconds


		public RecordScreen() {
			InitializeComponent();//This seems to put everything in it
			this.Size = new Size(Screen.PrimaryScreen.Bounds.Width/2, Screen.PrimaryScreen.Bounds.Height/2);
			pictureBox.Size = new Size(Screen.PrimaryScreen.Bounds.Width/2-115, Screen.PrimaryScreen.Bounds.Height/2 -50);

			folderBrowserDialog1.SelectedPath = @"C:\Users\caleb\Pictures\Recording";
			saveFile.Text = folderBrowserDialog1.SelectedPath;
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
				thisLittleJob.Stop();//Stops the recording
			}//This actually ensures that the application is recording, without this, it crashes
		}//This stops the recording

		private void SettingBtn_Click( object sender, EventArgs e ) {
			
			Settings.Visible = true;
			Settings.Enabled = true;

		}

		private void SettingsExtBtn_Click( object sender, EventArgs e ) {
			ScreenshotsName.Text.Trim(new Char [] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' });
			Settings.Visible = false;
			Settings.Enabled = false;
		}

		private void SaveLocation_Click( object sender, EventArgs e ) {
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if(result == DialogResult.OK) {
				Console.WriteLine(folderBrowserDialog1.SelectedPath);
				saveFile.Text = folderBrowserDialog1.SelectedPath;
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
				
				System.Threading.Thread.Sleep(15);//Sleeps for 15 milliseconds
			}//Takes a screenshot every 15 milliseconds until done

		}//This takes screenshots and saves/displays them

		

		void StartRecord() {
			thisLittleJob = new ScreenCaptureJob();//This allows you to create new videos

			// I don't know what any of this does
			//System.Drawing.Size WorkingArea = SystemInformation.WorkingArea.Size;
			//Rectangle captureRect = new Rectangle(0, 0, WorkingArea.Width - (WorkingArea.Width % 4), WorkingArea.Height - (WorkingArea.Height % 4));
			//thisLittleJob.CaptureRectangle = captureRect;
			//thisLittleJob.ShowFlashingBoundary = true;
			//thisLittleJob.CaptureMouseCursor = false;
			//thisLittleJob.ScreenCaptureVideoProfile.Quality = 1;
			//thisLittleJob.ScreenCaptureVideoProfile.FrameRate = 1;

			if(Countdown.Checked) {
				thisLittleJob.ShowCountdown = true; //This shows a countdown
			}
			if(MicSounds.Checked) {
				thisLittleJob.AddAudioDeviceSource(AudioDevices(0));//This will grab the sound from the microphone
			}
			if(ComputerSounds.Checked) {
				thisLittleJob.AddAudioDeviceSource(AudioDevices(1));//This will grab the sound from the computer
			}
			thisLittleJob.OutputPath = folderBrowserDialog1.SelectedPath;//This is where to record to
			thisLittleJob.Start();//Starts the recording
			if(AutoMinimize.Checked) {
				this.WindowState = FormWindowState.Minimized;//minimizes the application when start recording
			}//minimizes the application when start recording



		}//This creates a video 



		EncoderDevice AudioDevices(int x) {
			EncoderDevice foundDevice = null;// This sets the variable 
			Collection<EncoderDevice> audioDevices = EncoderDevices.FindDevices(EncoderDeviceType.Audio);//Sets a list with all audio
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
