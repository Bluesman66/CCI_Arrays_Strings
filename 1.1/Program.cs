using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
1.1 Реализуйте алгоритм, определяющий, все ли символы в строке встречаются только один раз.
	А если при этом запрещено использование дополнительных структур данных?
	Используется набор символов ASCII.
*/

namespace _1._1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"IsUniqueChars: {IsUniqueChars("asdfga")}");
			Console.WriteLine($"IsUniqueChars2: {IsUniqueChars2("asdfg")}");
			Console.ReadKey();
		}

		// O(N)
		private static bool IsUniqueChars(string str)
		{
			if (str.Length > 128)
			{
				return false;
			}

			bool[] charSet = new bool[128];
			foreach (var c in str)
			{
				if (charSet[c]) // Символ уже встречался в строке
				{
					return false;
				}
				charSet[c] = true;
			}

			return true;
		}

		// O(N)
		private static bool IsUniqueChars2(string str)
		{
			int checker = 0;

			foreach (var c in str)
			{
				int val = c - 'a';
				if ((checker & (1 << val)) > 0)
				{
					return false;
				}
				checker |= (1 << val);
			}

			return true;
		}

		/*
		1. Сравнить каждый символ строки со всеми остальными символами строки. 
			Это потребует О(N^2) времени и О(1) памяти.  
		2. Если изменение строки разрешено, то можно ее отсортировать (что потребует
		   О(N log(N)) времени), а затем последовательно проверить строку на идентичность
		   соседних символов. Будьте внимательны: некоторые алгоритмы сортировки
		   требуют больших объемов памяти.
		*/
	}
}
