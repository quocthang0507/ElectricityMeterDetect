using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ElectricityMeterDetect.Test
{
	public class OCRReader : DisposableObject
	{
		private Tesseract ocr;

		public OCRReader(string dataPath)
		{
			//create OCR engine
			ocr = new Tesseract(dataPath, "eng", OcrEngineMode.Default);
			ocr.SetVariable("tessedit_char_whitelist", "1234567890");
		}

		public List<string> FindMeterReading(Image<Gray, byte> gray, out Image<Gray, byte> binarizedImage)
		{
			List<string> strmeterreadings = new List<string>();
			using (Image<Gray, byte> temp1 = gray.Clone())
			{
				//Resize. This size of front results in better accuracy from tesseract
				using (Image<Gray, byte> temp2 = temp1.Resize(1000, 800, Emgu.CV.CvEnum.Inter.Cubic, true))
				{
					//removes some pixels from the edge
					int edgePixelSize = 20;
					temp2.ROI = new Rectangle(new Point(edgePixelSize, edgePixelSize), temp2.Size - new Size(2 * edgePixelSize, 2 * edgePixelSize));
					Image<Gray, byte> filteredReading = FilterMeterReading(temp2.Clone());
					binarizedImage = filteredReading.Clone();
					Tesseract.Character[] words;
					StringBuilder strBuilder = new StringBuilder();

					using (Image<Gray, byte> temp3 = filteredReading.Clone())
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

		private Image<Gray, byte> FilterMeterReading(Image<Gray, byte> image, out Image<Gray, byte> imageDetection)
		{
			////smoothed
			//Image<Gray, byte> smoothedGrayFrame = image.PyrDown();
			//smoothedGrayFrame = smoothedGrayFrame.PyrUp();
			////canny
			//Image<Gray, byte> cannyFrame = smoothedGrayFrame.Canny(50, 50);
			////smoothing
			//image = smoothedGrayFrame;

			////binarize
			//Image<Gray, byte> thresh = image.ThresholdBinaryInv(new Gray(50), new Gray(255));
			//thresh._Not();
			//thresh._Or(cannyFrame);
			//return thresh;
			var blur = image.SmoothBlur(5, 5);

			var thresh = blur.ThresholdBinary(new Gray(100), new Gray(255));
			thresh._Not();

			Mat kernel1 = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(1, 1));
			var morph = thresh.MorphologyEx(MorphOp.Close, kernel1, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());

			VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
			Mat hier = new Mat();
			CvInvoke.FindContours(morph, contours, hier, RetrType.External, ChainApproxMethod.ChainApproxNone);
			Dictionary<int, double> dict = new Dictionary<int, double>();
			if (contours.Size > 0)
			{
				for (int i = 0; i < contours.Size; i++)
				{
					double aera = CvInvoke.ContourArea(contours[i]);
					Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
					dict.Add(i, aera);
				}
			}
			imageDetection = image.Clone();
			var nDict = dict.OrderBy(v => v.Value);
			foreach (var item in nDict)
			{
				int key = int.Parse(item.Key.ToString());
				Rectangle rect = CvInvoke.BoundingRectangle(contours[key]);
				CvInvoke.Rectangle(imageDetection, rect, new MCvScalar(255, 0, 0), 8);
			}
			return morph;
		}
	}
}