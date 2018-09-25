﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Expression.Encoder;




namespace Recording_Application {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void CaptureBtn_Click( object sender, EventArgs e ) {
			Capture(1);
		}

		new void Capture( int time ) {
			//int time = 1;
			bool IsPicture;
			if(time == 1) {
				IsPicture = true;
			}
			else {
				IsPicture = false;
			}
			for(int i=0; i<time; i++) {
				Bitmap bm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
				Graphics Gr = Graphics.FromImage(bm);
				Gr.CopyFromScreen(0, 0, 0, 0, bm.Size);
				pictureBox.Image = bm;
				pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
				if(IsPicture) {
					pictureBox.Image.Save(@"C:\Users\caleb\Pictures\Recording\100000test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
				}
				if(!IsPicture) {
					//bm.Save(@"C:\Users\caleb\Pictures\Recording\testVideo.MP4", System.Drawing.Imaging.ImageFormat.Jpeg);
					string txtFP = "Lol";
					bm.Save(txtFP.Text + Guid.NewGuid() + ".MP4");
				}
				System.Threading.Thread.Sleep(15);
			}
		}
		new void Video(){
			//This should stop
			Capture(60);
		}

		private void RecordBtn_Click( object sender, EventArgs e ) {
			System.Threading.Thread t = new System.Threading.Thread(Video);
			t.Start();
		}
	}
}