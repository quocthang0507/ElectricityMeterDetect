using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ElectricityMeterDetect.Test
{
	public partial class fMain : Form
	{
		private Image<Bgr, byte> image;
		private Image<Bgr, byte> imageCopy;
		private Rectangle detection;
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
			image = new Image<Bgr, Byte>(pbPreview.ImageLocation);
			imageCopy = image.Copy();
			tbTime.Text = "";
			List<Rectangle> meters = new List<Rectangle>();
			DetectMeter.Detect(image, "cascade.xml", meters, out long detectionTime);
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
			else
			{
				MessageBox.Show("Not found");
				return;
			}
			if (largestRect != -1)
			{
				//image.Draw(meters[largestRect], new Bgr(Color.Red), 2);
				CvInvoke.Rectangle(image, meters[largestRect], new MCvScalar(255, 0, 0), 2);
				detection = meters[largestRect];
			}
			pbPreview.Image = image.ToBitmap();
			pbPreview.Update();
			tbTime.Text = detectionTime.ToString() + "ms";
		}

		private void btnOCR_Click(object sender, EventArgs e)
		{
			Image<Bgr, byte> tmpImage = imageCopy.Copy(detection);
			ProcessImage(tmpImage);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var image = pbPreview.Image;
			image.Save(Path.Combine(tbFolderPath.Text, Path.GetRandomFileName() + ".jpg"), ImageFormat.Jpeg);
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

		private void ProcessImage(Image<Bgr, byte> image)
		{
			Image<Bgr, byte> imageDetection;
			Stopwatch watch = Stopwatch.StartNew(); // time the detection process
			List<string> words = _ocrDetect.FindMeterReading(image, out imageDetection);
			watch.Stop(); //stop the timer
			tbTime.Text = string.Format(watch.Elapsed.TotalMilliseconds.ToString()) + "ms";
			for (int i = 0; i < words.Count; i++)
			{
				Debug.Print(string.Format("Meter Reading: {0}", words[i]));
			}
			pbPreview.Image = imageDetection.ToBitmap();
		}
		#endregion
	}
}
