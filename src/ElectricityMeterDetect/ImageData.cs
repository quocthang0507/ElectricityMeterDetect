namespace ElectricityMeterDetect
{
	public class ImageData
	{
		public string Label { get; set; }
		public string Path { get; set; }

		public ImageData(string label, string path)
		{
			Label = label;
			Path = path;
		}
	}
}
