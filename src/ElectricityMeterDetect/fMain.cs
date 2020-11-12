using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ElectricityMeterDetect
{
	public partial class fMain : Form
	{
		private Image<Bgr, byte> imageDetect;
		private Image<Bgr, Byte> detectedImage;
		private Image<Bgr, Byte> imageDetCopy;
		private Image<Gray, byte> binarizedReading;
		private Rectangle detectedRect;
		private Rectangle meterReadingRect;
		private static fMain sForm = null;
		private OCRReader _ocrDetect;
		private bool gray_in_use = false;
		private Environment.SpecialFolder root;

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

		private void fMain_Load(object sender, EventArgs e)
		{
			string path = GetAbsolutePath(@"../../img");
			tbFolderPath.Text = path;
			PopulateTreeView(Helpers.LoadImagesFromDirectory(path));
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			dlPictureFolder.RootFolder = root;
			DialogResult result = dlPictureFolder.ShowDialog();
			if (result == DialogResult.OK)
			{
				string path = dlPictureFolder.SelectedPath;
				tbFolderPath.Text = path;
				root = dlPictureFolder.RootFolder;
				PopulateTreeView(Helpers.LoadImagesFromDirectory(path));
			}
		}

		private void tvImages_AfterSelect(object sender, TreeViewEventArgs e)
		{
			string imagePath = Path.Combine(tbFolderPath.Text, tvImages.SelectedNode.Text);
			pbPreview.Image = new Bitmap(imagePath);
		}

		private void btnDetect_Click(object sender, EventArgs e)
		{
			int meterAcNum = 0;
			decimal meterRed = 0;
			int largestRect = -1;
			btnRead.Enabled = false;
			imageDetect = new Image<Bgr, Byte>(pbPreview.ImageLocation);
			imageDetCopy = imageDetCopy.Copy();
			long detectionTime;
			tbTime.Text = "";
			List<Rectangle> meters = new List<Rectangle>();
			DetectMeter.Detect(imageDetect, "cascade_test.xml", meters, out detectionTime);
			if (meters.Count > 0)
			{
				int[] rectArray = new int[meters.Count];
				int curCount = 0;
				foreach (Rectangle meter in meters)
				{
					rectArray[curCount] = meter.Width * meter.Height;
					curCount += 1;
				}
				largestRect = rectArray.ToList().IndexOf(rectArray.Max());
			}
			if (largestRect != -1)
			{
				imageDetect.Draw(meters[largestRect], new Bgr(Color.Red), 2);
				detectedRect = meters[largestRect];
				btnRead.Enabled = true;
			}
			pbPreview.Image = imageDetect.ToBitmap();
			pbPreview.Update();
			tbTime.Text = detectionTime.ToString() + "ms";
		}

		private void btnRead_Click(object sender, EventArgs e)
		{
			pbPreview.Image = imageDetCopy.ToBitmap();
			pbPreview.Update();
			detectedImage = imageDetCopy.Copy(detectedRect);
			pbPreview.Image = detectedImage.ToBitmap();
			pbPreview.Update();
			Image<Bgr, byte> template = new Image<Bgr, byte>("tempimage11.jpg");
			Image<Bgr, byte> imageToShow = detectedImage.Copy();
			using (Image<Gray, float> result = detectedImage.MatchTemplate(template, Emgu.CV.CvEnum.TM_TYPE.CV_TM_CCOEFF_NORMED))
			{
				double[] minValues, maxValues;
				Point[] minLocations, maxLocations;
				result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
				if (maxValues[0] > 0.5)
				{
					Rectangle match = new Rectangle(maxLocations[0], template.Size);
					Rectangle meterRect = new Rectangle(match.X + match.Width + 9,
				   match.Y + 7, match.Width * 7, 35);
					imageToShow.Draw(meterRect, new Bgr(Color.Red), 1);
					meterReadingRect = meterRect;
					pbPreview.Image = imageToShow.ToBitmap();
					pbPreview.Update();
				}
			}
		}

		private void btnOCR_Click(object sender, EventArgs e)
		{
			Image<Bgr, byte> tmpImage = imageDetCopy.Clone();
			Image<Bgr, byte> myImage = tmpImage.Copy(detectedRect);
			Image<Bgr, byte> img = myImage.Copy(meterReadingRect);
			ProcessImage(img.Convert<Gray, byte>());
			pbPreview.Image = binarizedReading.ToBitmap();
		}

		#region Methods
		static string GetAbsolutePath(string relativePath)
			=> Helpers.GetAbsolutePath(typeof(Program).Assembly, relativePath);

		private void PopulateTreeView(IEnumerable<ImageData> list)
		{
			tvImages.Nodes.Clear();
			foreach (var image in list)
			{
				tvImages.Nodes.Add(image.Label);
			}
		}

		private void ProcessImage(Image<Gray, byte> image)
		{
			Stopwatch watch = Stopwatch.StartNew(); // time the detection process
			List<String> metreadings = new List<String>();
			List<string> words = _ocrDetect.FindMeterReading(image, metreadings, out binarizedReading);
			watch.Stop(); //stop the timer
			tbTime.Text = String.Format(watch.Elapsed.TotalMilliseconds.ToString()) + "ms";
			Point startPoint = new Point(10, 10);
			for (int i = 0; i < words.Count; i++)
			{
				Debug.Print(String.Format("Meter Reading: {0}", words[i]));
			}
		}
		#endregion

	}
}