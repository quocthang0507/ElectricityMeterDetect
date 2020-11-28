using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ElectricityMeterDetect.Test
{
	public class OCRReader : DisposableObject
	{
		private Tesseract ocr;
		private const double CV_PI = 3.1415926535897932384626433832795;

		public OCRReader(string dataPath)
		{
			//create OCR engine
			ocr = new Tesseract(dataPath, "eng", OcrEngineMode.Default);
			ocr.SetVariable("tessedit_char_whitelist", "1234567890");
		}

		public List<string> FindMeterReading(Image<Bgr, byte> original, out Image<Bgr, byte> imageDetection)
		{
			List<string> strmeterreadings = new List<string>();
			using (var temp1 = original.Clone())
			{
				//Resize. This size of front results in better accuracy from tesseract
				using (var temp2 = temp1.Resize(1000, 800, Inter.Cubic, true))
				{
					//removes some pixels from the edge
					int edgePixelSize = 20;
					temp2.ROI = new Rectangle(new Point(edgePixelSize, edgePixelSize), temp2.Size - new Size(2 * edgePixelSize, 2 * edgePixelSize));
					Image<Gray, byte> filteredReading = FilterMeterReading(temp2.Clone(), out imageDetection);
					Tesseract.Character[] words;
					StringBuilder strBuilder = new StringBuilder();

					using (var temp3 = filteredReading.Clone())
					{
						ocr.SetImage(temp3);
						ocr.Recognize();
						words = ocr.GetCharacters();
						for (int i = 0; i < words.Length; i++)
						{
							strBuilder.Append(words[i].Text);
						}
					}
					strmeterreadings.Add(strBuilder.ToString());
				}
			}
			return strmeterreadings;
		}

		protected override void DisposeObject()
		{
			ocr.Dispose();
		}

		private Image<Gray, byte> FilterMeterReading(Image<Bgr, byte> image, out Image<Bgr, byte> imageDetection)
		{
			var _image = image.Convert<Gray, byte>();
			var blur = _image.SmoothBlur(5, 5);

			var thresh = blur.ThresholdBinary(new Gray(100), new Gray(255));
			thresh._Not();

			Mat kernel1 = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(1, 1));
			var morph = thresh.MorphologyEx(MorphOp.Close, kernel1, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());

			VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
			Mat hier = new Mat();
			CvInvoke.FindContours(morph, contours, hier, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
			List<VectorOfPoint> selection = new List<VectorOfPoint>();
			if (contours.Size > 0)
			{
				for (int i = 0; i < contours.Size; i++)
				{
					double area = CvInvoke.ContourArea(contours[i]);
					if (area > 1000 && area < 10000)
					{
						selection.Add(contours[i]);
					}
				}
			}
			selection = RemoveIntersectionRect(selection);
			imageDetection = image.Clone();
			foreach (var item in selection)
			{
				Rectangle rect = CvInvoke.BoundingRectangle(item);
				CvInvoke.Rectangle(imageDetection, rect, new MCvScalar(255, 0, 0), 2);
			}
			return morph;
		}

		private List<VectorOfPoint> RemoveIntersectionRect(List<VectorOfPoint> vectorOfPoints)
		{
			var result = new List<VectorOfPoint>();
			var descending = vectorOfPoints.OrderByDescending(i => CvInvoke.ContourArea(i)).ToList();
			var ascending = vectorOfPoints.OrderBy(i => CvInvoke.ContourArea(i)).ToList();
			var willDelete = new List<VectorOfPoint>();
			for (int i = 0; i < ascending.Count(); i++)
			{
				for (int j = 0; j < descending.Count(); j++)
				{
					Rectangle rect = CvInvoke.BoundingRectangle(descending[j]);
					if (rect.Contains((ascending[i])[0]) && descending[j] != ascending[i])
					{
						willDelete.Add(ascending[i]);
					}
				}
			}

			foreach (var item in willDelete)
			{
				ascending.Remove(item);
			}
			return ascending;
		}
	}
}