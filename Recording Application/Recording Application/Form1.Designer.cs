namespace Recording_Application {
	partial class Form1 {
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
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// CaptureBtn
			// 
			this.CaptureBtn.Location = new System.Drawing.Point(12, 12);
			this.CaptureBtn.Name = "CaptureBtn";
			this.CaptureBtn.Size = new System.Drawing.Size(75, 23);
			this.CaptureBtn.TabIndex = 0;
			this.CaptureBtn.Text = "Screen Shot";
			this.CaptureBtn.UseVisualStyleBackColor = true;
			this.CaptureBtn.Click += new System.EventHandler(this.CaptureBtn_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(94, 12);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(705, 343);
			this.pictureBox.TabIndex = 1;
			this.pictureBox.TabStop = false;
			// 
			// RecordBtn
			// 
			this.RecordBtn.Location = new System.Drawing.Point(13, 41);
			this.RecordBtn.Name = "RecordBtn";
			this.RecordBtn.Size = new System.Drawing.Size(75, 23);
			this.RecordBtn.TabIndex = 2;
			this.RecordBtn.Text = "Record";
			this.RecordBtn.UseVisualStyleBackColor = true;
			this.RecordBtn.Click += new System.EventHandler(this.RecordBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(811, 368);
			this.Controls.Add(this.RecordBtn);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.CaptureBtn);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CaptureBtn;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button RecordBtn;
	}
}

