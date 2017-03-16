using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
1.2 Для двух строк напишите метод, проверяющий является ли одна строка перестановкой другой?
	Используется набор символов ASCII.
*/

namespace _1._2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"Permutation: {Permutation("asd", "dsa")}");
			Console.WriteLine($"Permutation2: {Permutation2("asd", "dsa")}");
			Console.ReadKey();
		}

		private static string Sort(string str)
		{
			var content = str.ToCharArray();
			Array.Sort(content);
			return new string(content);
		}

		private static bool Permutation(string str1, string str2)
		{
			if (str1.Length != str2.Length)
				return false;
			return Sort(str1).Equals(Sort(str2));
		}

		private static bool Permutation2(string str1, string str2)
		{
			if (str1.Length != str2.Length)
				return false;

			var letters = new int[128];

			foreach (var c in str1)
			{
				letters[c]++;
			}

			foreach (var c in str2)
			{
				letters[c]--;
				if (letters[c] < 0)
					return false;
			}

			return true;
		}
	}
}
