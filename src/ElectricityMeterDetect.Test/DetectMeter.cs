using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace ElectricityMeterDetect.Test
{
	public static class DetectMeter
	{
		public static void Detect(Image<Bgr, byte> image, string meterFileName, List<Rectangle> meters, out long detectionTime)
		{
			Stopwatch watch;
			//Read the HaarCascade objects
			using (CascadeClassifier meter = new CascadeClassifier(meterFileName))
			{
				watch = Stopwatch.StartNew();
				//Convert it to Grayscale
				using (Image<Gray, byte> gray = image.Clone().Convert<Gray, byte>())
				{
					//normalizes brightness and increases contrast of the image
					try
					{
						gray._EqualizeHist();
					}
					catch (AccessViolationException ex)
					{
						Debug.Print(ex.Message);
					}
					catch (Exception ex)
					{
						Debug.Print(ex.Message);
					}
					Rectangle[] meterDetected = meter.DetectMultiScale(gray, 1.1, 3, Size.Empty, Size.Empty);
					meters.AddRange(meterDetected);
				}
				watch.Stop();
			}
			detectionTime = watch.ElapsedMilliseconds;
		}
	}
}