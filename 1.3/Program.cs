using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Напишите метод, заменяющий в строке все пробелы символами '%20'. Фактическая длина строки известна заранее.  
Вместо строки используйте символьный массив.
*/

namespace _1._3
{
	class Program
	{
		static void Main(string[] args)
		{
			var str = "Mr John Smith   ".ToCharArray();

			Console.WriteLine($"ReplaceSpaces Before");
			foreach (var c in str) Console.Write($"[{c}]");
			Console.WriteLine();

			ReplaceSpaces(ref str, str.Length);

			Console.WriteLine($"ReplaceSpaces After");
			foreach (var c in str) Console.Write($"[{c}]");

			Console.ReadKey();
		}

		private static void ReplaceSpaces(ref char[] str, int length)
		{
			int spaceCount = 0, newLength = 0;
			for (int i = 0; i < length; i++)
			{
				if (str[i] == ' ')
				{
					spaceCount++;
				}
			}

			newLength = length + spaceCount * 2;
			Array.Resize(ref str, newLength);

			for (int i = length - 1; i >= 0; i--)
			{
				if (str[i] == ' ')
				{
					str[newLength - 1] = '0';
					str[newLength - 2] = '2';
					str[newLength - 3] = '%';
					newLength -= 3;
				}
				else
				{
					str[newLength - 1] = str[i];
					newLength--;
				}
			}
		}
	}
}
