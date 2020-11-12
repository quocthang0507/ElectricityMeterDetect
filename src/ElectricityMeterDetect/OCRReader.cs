using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ElectricityMeterDetect
{
	public class OCRReader : DisposableObject
	{
		private Tesseract _ocr;

		public OCRReader(string dataPath)
		{
			//create OCR engine
			_ocr = new Tesseract(dataPath, "eng", OcrEngineMode.Default);
			_ocr.SetVariable("tessedit_char_whitelist", "1234567890");
		}

		public List<string> FindMeterReading(Image<Gray, byte> gray, List<string> strmeterreadings, out Image<Gray, byte> binarizedImage)
		{
			Image<Gray, byte> filteredReadingShow;
			using (Image<Gray, byte> tmp1 = gray.Copy())
			{
				//Resize. This size of front results in better accuracy from tesseract
				using (Image<Gray, byte> tmp2 = tmp1.Resize(1000, 800, Emgu.CV.CvEnum.Inter.Cubic, true))
				{
					//removes some pixels from the edge
					int edgePixelSize = 2;
					tmp2.ROI = new Rectangle(new Point(edgePixelSize, edgePixelSize), tmp2.Size - new Size(2 * edgePixelSize, 2 * edgePixelSize));
					Image<Gray, byte> mrdImg = tmp2.Copy();
					Image<Gray, byte> filteredReading = FilterMeterReading(mrdImg);
					filteredReadingShow = filteredReading.Copy();
					Tesseract.Character[] words;
					StringBuilder strBuilder = new StringBuilder();

					using (Image<Gray, byte> tmp = filteredReading.Clone())
					{
						_ocr.SetImage(tmp);
						_ocr.Recognize();
						words = _ocr.GetCharacters();
						for (int i = 0; i < words.Length; i++)
						{
							strBuilder.Append(words[i].Text);
						}
					}
					strmeterreadings.Add(strBuilder.ToString());
				}
			}
			binarizedImage = filteredReadingShow.Clone();
			return strmeterreadings;
		}

		protected override void DisposeObject()
		{
			_ocr.Dispose();
		}

		private Image<Gray, byte> FilterMeterReading(Image<Gray, byte> mreadImg)
		{
			mreadImg._EqualizeHist();
			//smoothed
			Image<Gray, byte> smoothedGrayFrame = mreadImg.PyrDown();
			smoothedGrayFrame = smoothedGrayFrame.PyrUp();
			//canny
			Image<Gray, byte> cannyFrame = null;
			cannyFrame = smoothedGrayFrame.Canny(50, 50);
			//smoothing
			mreadImg = smoothedGrayFrame;

			//binarize
			Image<Gray, byte> thresh = mreadImg.ThresholdBinaryInv(new Gray(50), new Gray(255));
			thresh._Not();
			thresh._Or(cannyFrame);
			return thresh;
		}
	}
}