using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ElectricityMeterDetect.Test
{
	public partial class fMain : Form
	{
		private Image<Bgr, byte> imageDetect;
		private Image<Bgr, byte> imageDetCopy;
		private Image<Gray, byte> binarizedReading;
		private Rectangle detectedRect;
		private static fMain sForm = null;
		private OCRReader _ocrDetect;
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
			pbPreview.ImageLocation = imagePath;
		}

		private void btnDetect_Click(object sender, EventArgs e)
		{
			int largestRect = -1;
			imageDetect = new Image<Bgr, Byte>(pbPreview.ImageLocation);
			tbTime.Text = "";
			List<Rectangle> meters = new List<Rectangle>();
			DetectMeter.Detect(imageDetect, "cascade.xml", meters, out long detectionTime);
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
			}
			pbPreview.Image = imageDetect.ToBitmap();
			pbPreview.Update();
			tbTime.Text = detectionTime.ToString() + "ms";
		}

		private void btnOCR_Click(object sender, EventArgs e)
		{
			Image<Bgr, byte> tmpImage = imageDetCopy.Clone();
			Image<Bgr, byte> myImage = tmpImage.Copy(detectedRect);
			ProcessImage(myImage.Convert<Gray, byte>());
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
