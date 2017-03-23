using System;

/*
Существуют три вида модифицирующих операций со строками: вставка символа, удаление символа и замена символа.
Напишите функцию, которая проверяет, находятся ли две строки на расстоянии одной модификации (или нуля модификаций)?
Пример: 
pale, ple -> true
pales, pale -> true
pale, bale -> true
pale, bake -> false    
*/

namespace _1._5
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"OneEditAway: {OneEditAway("pale", "ple")}");
			Console.WriteLine($"OneEditAway: {OneEditAway("pales", "pale")}");
			Console.WriteLine($"OneEditAway: {OneEditAway("pale", "bale")}");
			Console.WriteLine($"OneEditAway: {OneEditAway("pale", "bake")}");

			Console.WriteLine($"OneEditAway2: {OneEditAway2("pale", "ple")}");
			Console.WriteLine($"OneEditAway2: {OneEditAway2("pales", "pale")}");
			Console.WriteLine($"OneEditAway2: {OneEditAway2("pale", "bale")}");
			Console.WriteLine($"OneEditAway2: {OneEditAway2("pale", "bake")}");

			Console.ReadKey();
		}

		// O(N)
		private static bool OneEditAway(string first, string second)
		{
			if (first.Length == second.Length)
				return OneEditReplace(first, second);
			if (first.Length + 1 == second.Length)
				return OneEditInsert(first, second);
			if (first.Length - 1 == second.Length)
				return OneEditInsert(second, first);
			return false;
		}

		// O(N)
		private static bool OneEditAway2(string first, string second)
		{
			// Проверка длины.
			if (Math.Abs(first.Length - second.Length) > 1)
				return false;

			// Получение более короткой и более длинной строки s1 < s2
			var s1 = first.Length < second.Length ? first : second;
			var s2 = first.Length < second.Length ? second : first;

			var index1 = 0;
			var index2 = 0;
			bool foundDifference = false;
			while (index2 < s2.Length && index1 < s1.Length)
			{
				if (s1[index1] != s2[index2])
				{
					if (foundDifference)
						return false;
					foundDifference = true;

					// При замене сместить указатель колроткой строки
					if (s1.Length == s2.Length)
						index1++;
				}
				else
				{
					index1++; // При совпадении сместить указатель короткой строки
				}
				index2++; // Всегда смещать указатель длинной строки
			}
			return true;
		}

		private static bool OneEditReplace(string first, string second)
		{
			bool foundDifference = false;
			for (int i = 0; i < first.Length - 1; i++)
			{
				if (first[i] != second[i])
				{
					if (foundDifference)
						return false;
					foundDifference = true;
				}
			}
			return true;
		}

		private static bool OneEditInsert(string first, string second)
		{
			var index1 = 0;
			var index2 = 0;

			while (index2 < second.Length && index1 < first.Length)
			{
				if (first[index1] != second[index2])
				{
					if (index1 != index2)
						return false;
					index2++;
				}
				else
				{
					index1++;
					index2++;
				}
			}
			return true;
		}
	}
}
