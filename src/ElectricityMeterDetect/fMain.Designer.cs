
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
			this.label1 = new System.Windows.Forms.Label();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.pbPreview = new System.Windows.Forms.PictureBox();
			this.tvImages = new System.Windows.Forms.TreeView();
			this.tbFolderPath = new System.Windows.Forms.TextBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.dlPictureFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.tbNumber = new System.Windows.Forms.TextBox();
			this.btnOCR = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
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
			this.splitContainer1.Panel2.Controls.Add(this.btnOCR);
			this.splitContainer1.Panel2.Controls.Add(this.tbNumber);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.btnOpen);
			this.splitContainer1.Panel2.Controls.Add(this.tbFolderPath);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Size = new System.Drawing.Size(933, 519);
			this.splitContainer1.SplitterDistance = 357;
			this.splitContainer1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(150, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Image folder path:";
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.tvImages);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.pbPreview);
			this.splitContainer2.Size = new System.Drawing.Size(933, 357);
			this.splitContainer2.SplitterDistance = 311;
			this.splitContainer2.TabIndex = 0;
			// 
			// pbPreview
			// 
			this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbPreview.Location = new System.Drawing.Point(0, 0);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new System.Drawing.Size(618, 357);
			this.pbPreview.TabIndex = 0;
			this.pbPreview.TabStop = false;
			// 
			// tvImages
			// 
			this.tvImages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvImages.Location = new System.Drawing.Point(0, 0);
			this.tvImages.Name = "tvImages";
			this.tvImages.Size = new System.Drawing.Size(311, 357);
			this.tvImages.TabIndex = 1;
			// 
			// tbFolderPath
			// 
			this.tbFolderPath.Location = new System.Drawing.Point(294, 43);
			this.tbFolderPath.Name = "tbFolderPath";
			this.tbFolderPath.Size = new System.Drawing.Size(363, 21);
			this.tbFolderPath.TabIndex = 1;
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(673, 42);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(75, 23);
			this.btnOpen.TabIndex = 2;
			this.btnOpen.Text = "Open...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// dlPictureFolder
			// 
			this.dlPictureFolder.Description = "Browse to image folder";
			this.dlPictureFolder.ShowNewFolderButton = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(150, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Recognized number:";
			// 
			// tbNumber
			// 
			this.tbNumber.Location = new System.Drawing.Point(294, 69);
			this.tbNumber.Name = "tbNumber";
			this.tbNumber.ReadOnly = true;
			this.tbNumber.Size = new System.Drawing.Size(119, 21);
			this.tbNumber.TabIndex = 4;
			// 
			// btnOCR
			// 
			this.btnOCR.Location = new System.Drawing.Point(764, 42);
			this.btnOCR.Name = "btnOCR";
			this.btnOCR.Size = new System.Drawing.Size(75, 23);
			this.btnOCR.TabIndex = 5;
			this.btnOCR.Text = "OCR";
			this.btnOCR.UseVisualStyleBackColor = true;
			// 
			// fMain
			// 
			this.AcceptButton = this.btnOCR;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(933, 519);
			this.Controls.Add(this.splitContainer1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
			this.Name = "fMain";
			this.Text = "Electricity Meter Detect";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
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
	}
}

