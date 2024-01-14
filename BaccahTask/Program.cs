namespace BaccahTask
{
	internal class Program
	{
		static void Main(string[] args)
		{

			float number = 520120212;

			string arabicText = NumberConverter.ConvertToText(number, true);
			string englishText = NumberConverter.ConvertToText(number, false);

			Console.WriteLine($"Arabic: {arabicText}\nEnglish: {englishText}");
			

		}
	}
}