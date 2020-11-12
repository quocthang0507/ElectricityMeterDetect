using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ElectricityMeterDetect
{
	public partial class fMain : Form
	{
		private Image<Bgr, Byte> imageDetect;
		private Image<Bgr, Byte> detectedImage;
		private Image<Bgr, Byte> imageDetCopy;
		private Image<Gray, byte> binarizedReading;
		private Rectangle detectedRect;
		private Rectangle meterReadingRect;
		private static fMain sForm = null;
		private OCRReader _ocrDetect;
		private bool gray_in_use = false;

		public fMain()
		{
			InitializeComponent();
			_ocrDetect = new OCRReader("tessdata/");
		}

		public static fMain Instance()
		{
			if (sForm == null)
				sForm = new fMain();
			return sForm;
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			DialogResult result = dlPictureFolder.ShowDialog();
			if (result == DialogResult.OK)
			{
				tbFolderPath.Text = dlPictureFolder.SelectedPath;
				Environment.SpecialFolder root = dlPictureFolder.RootFolder;
			}
		}


	}
}
