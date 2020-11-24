using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ElectricityMeterDetect.Test
{
	public class Helpers
	{
		public static IEnumerable<ImageData> LoadImagesFromDirectory(string folderPath)
		{
			IEnumerable<string> images = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories).
				Where(file => Path.GetExtension(file).Contains("jpg") || Path.GetExtension(file).Contains("png"));
			return images.Select(path => new ImageData(Path.GetFileName(path), path));
		}

		public static string GetAbsolutePath(Assembly assembly, string relativePath)
		{
			string assemblyFolderPath = new FileInfo(assembly.Location).Directory.FullName;
			return Path.GetFullPath(Path.Combine(assemblyFolderPath, relativePath));
		}
	}
}
