using System;
using System.Text;

/*
Реализуйте метод для выполнения простейшего сжатия строк с использованием счетчика повторяющихся символов.
Например строка aabcccccaaa превращается в a2b15c3a. Если "сжатая" строка не становится короче исходной,
то метод возвращает исходную строку. Предполагается, что строка состоит из букв верхнего и нижнего регистра.   
*/

namespace _1._6
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"CompressBad: {CompressBad("aabcccccaaa")}");
			Console.WriteLine($"Compress: {Compress("aabcccccaaa")}");
			Console.WriteLine($"Compress2: {Compress2("aabcccccaaa")}");

			Console.ReadKey();
		}

		private static string CompressBad(string str)
		{
			var compressedString = string.Empty;
			var countConsecutive = 0;

			for (int i = 0; i < str.Length; i++)
			{
				countConsecutive++;
				// Если следующий символ отличается от текущего, присоединить текущий символ к результату
				if (i + 1 >= str.Length || str[i] != str[i + 1])
				{
					compressedString += "" + str[i] + countConsecutive;
					countConsecutive = 0;
				}
			}

			return compressedString.Length < str.Length ? compressedString : str;
		}

		private static string Compress(string str)
		{
			var compressed = new StringBuilder();
			var countConsecutive = 0;

			for (int i = 0; i < str.Length; i++)
			{
				countConsecutive++;
				// Если следующий символ отличается от текущего, присоединить текущий символ к результату
				if (i + 1 >= str.Length || str[i] != str[i + 1])
				{
					compressed.Append(str[i]).Append(countConsecutive);
					countConsecutive = 0;
				}
			}

			return compressed.Length < str.Length ? compressed.ToString() : str;
		}

		private static string Compress2(string str)
		{
			var finalLength = CountCompression(str);
			if (finalLength > str.Length) return str;

			var compressed = new StringBuilder(finalLength); // Исходная емкость
			var countConsecutive = 0;

			for (int i = 0; i < str.Length; i++)
			{
				countConsecutive++;
				// Если следующий символ отличается от текущего, присоединить текущий символ к результату
				if (i + 1 >= str.Length || str[i] != str[i + 1])
				{
					compressed.Append(str[i]).Append(countConsecutive);
					countConsecutive = 0;
				}
			}

			return compressed.Length < str.Length ? compressed.ToString() : str;
		}

		private static int CountCompression(string str)
		{
			var compressedLength = 0;
			var countConsecutive = 0;

			for (int i = 0; i < str.Length; i++)
			{
				countConsecutive++;
				// Если следующий символ отличается от текущего, увеличить длину
				if (i + 1 >= str.Length || str[i] != str[i + 1])
				{
					compressedLength += 1 + countConsecutive.ToString().Length;
					countConsecutive = 0;
				}
			}

			return compressedLength;
		}
	}
}
