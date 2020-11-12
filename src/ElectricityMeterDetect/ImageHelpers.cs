using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ElectricityMeterDetect
{
	public class ImageHelpers
	{
		public static IEnumerable<ImageData> LoadImagesFromDirectory(string folderPath)
		{
			IEnumerable<string> images = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories).
				Where(file => Path.GetExtension(file).Contains("jpg") || Path.GetExtension(file).Contains("png"));
			return images.Select(path => new ImageData(Path.GetFileName(path), path));
		}
	}
}
