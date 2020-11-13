
namespace ElectricityMeterDetect
{
	partial class fMain
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tvImages = new System.Windows.Forms.TreeView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pbPreview = new System.Windows.Forms.PictureBox();
			this.btnDetect = new System.Windows.Forms.Button();
			this.btnRead = new System.Windows.Forms.Button();
			this.tbTime = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnOCR = new System.Windows.Forms.Button();
			this.tbNumber = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOpen = new System.Windows.Forms.Button();
			this.tbFolderPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dlPictureFolder = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btnDetect);
			this.splitContainer1.Panel2.Controls.Add(this.btnRead);
			this.splitContainer1.Panel2.Controls.Add(this.tbTime);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.btnOCR);
			this.splitContainer1.Panel2.Controls.Add(this.tbNumber);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.btnOpen);
			this.splitContainer1.Panel2.Controls.Add(this.tbFolderPath);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Size = new System.Drawing.Size(884, 461);
			this.splitContainer1.SplitterDistance = 317;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer2.Size = new System.Drawing.Size(884, 317);
			this.splitContainer2.SplitterDistance = 294;
			this.splitContainer2.SplitterWidth = 5;
			this.splitContainer2.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tvImages);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(294, 317);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Images";
			// 
			// tvImages
			// 
			this.tvImages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvImages.Location = new System.Drawing.Point(3, 19);
			this.tvImages.Name = "tvImages";
			this.tvImages.Size = new System.Drawing.Size(288, 295);
			this.tvImages.TabIndex = 1;
			this.tvImages.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvImages_AfterSelect);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pbPreview);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(585, 317);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Preview";
			// 
			// pbPreview
			// 
			this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbPreview.Location = new System.Drawing.Point(3, 19);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new System.Drawing.Size(579, 295);
			this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbPreview.TabIndex = 0;
			this.pbPreview.TabStop = false;
			// 
			// btnDetect
			// 
			this.btnDetect.Location = new System.Drawing.Point(274, 43);
			this.btnDetect.Name = "btnDetect";
			this.btnDetect.Size = new System.Drawing.Size(86, 25);
			this.btnDetect.TabIndex = 9;
			this.btnDetect.Text = "Detect";
			this.btnDetect.UseVisualStyleBackColor = true;
			this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
			// 
			// btnRead
			// 
			this.btnRead.Enabled = false;
			this.btnRead.Location = new System.Drawing.Point(385, 43);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(134, 25);
			this.btnRead.TabIndex = 8;
			this.btnRead.Text = "Read Number";
			this.btnRead.UseVisualStyleBackColor = true;
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// tbTime
			// 
			this.tbTime.Location = new System.Drawing.Point(575, 84);
			this.tbTime.Name = "tbTime";
			this.tbTime.ReadOnly = true;
			this.tbTime.Size = new System.Drawing.Size(100, 23);
			this.tbTime.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(506, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Elapsed:";
			// 
			// btnOCR
			// 
			this.btnOCR.Enabled = false;
			this.btnOCR.Location = new System.Drawing.Point(539, 43);
			this.btnOCR.Name = "btnOCR";
			this.btnOCR.Size = new System.Drawing.Size(86, 25);
			this.btnOCR.TabIndex = 5;
			this.btnOCR.Text = "OCR";
			this.btnOCR.UseVisualStyleBackColor = true;
			this.btnOCR.Click += new System.EventHandler(this.btnOCR_Click);
			// 
			// tbNumber
			// 
			this.tbNumber.ForeColor = System.Drawing.Color.Red;
			this.tbNumber.Location = new System.Drawing.Point(353, 84);
			this.tbNumber.Name = "tbNumber";
			this.tbNumber.ReadOnly = true;
			this.tbNumber.Size = new System.Drawing.Size(135, 23);
			this.tbNumber.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(188, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Recognized number:";
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(689, 14);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(86, 25);
			this.btnOpen.TabIndex = 2;
			this.btnOpen.Text = "Open...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// tbFolderPath
			// 
			this.tbFolderPath.Location = new System.Drawing.Point(242, 14);
			this.tbFolderPath.Name = "tbFolderPath";
			this.tbFolderPath.ReadOnly = true;
			this.tbFolderPath.Size = new System.Drawing.Size(414, 23);
			this.tbFolderPath.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(77, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Image folder path:";
			// 
			// dlPictureFolder
			// 
			this.dlPictureFolder.Description = "Browse to image folder";
			this.dlPictureFolder.ShowNewFolderButton = false;
			// 
			// fMain
			// 
			this.AcceptButton = this.btnOCR;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 461);
			this.Controls.Add(this.splitContainer1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.Name = "fMain";
			this.Text = "Electricity Meter Detect";
			this.Load += new System.EventHandler(this.fMain_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TreeView tvImages;
		private System.Windows.Forms.PictureBox pbPreview;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.TextBox tbFolderPath;
		private System.Windows.Forms.FolderBrowserDialog dlPictureFolder;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbNumber;
		private System.Windows.Forms.Button btnOCR;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox tbTime;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnDetect;
		private System.Windows.Forms.Button btnRead;
	}
}

