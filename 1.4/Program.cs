using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Напишите функцию, которая проверяет, является ли заданная строка перестановкой палиндрома?
Палиндром не ограничивается словами из словаря. (Т.е. любой набор символов) 
*/

namespace _1._4
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"IsPermutationOfPalindrome: {IsPermutationOfPalindrome("tactcoapapa")}");
			Console.WriteLine($"IsPermutationOfPalindrome2: {IsPermutationOfPalindrome2("tactcoapapa")}");
			Console.WriteLine($"IsPermutationOfPalindrome3: {IsPermutationOfPalindrome3("tactcoapapa")}");
			Console.ReadKey();
		}

		// O(N) N - длина строки (за два прохода)
		private static bool IsPermutationOfPalindrome(string phrase)
		{
			var table = BuildCharFrequencyTable(phrase);
			return CheckMaxOneOdd(table);
		}

		// O(N) N - длина строки (за один проход)
		private static bool IsPermutationOfPalindrome2(string phrase)
		{
			var countOdd = 0;
			var table = new int['z' - 'a' + 1];
			foreach (var c in phrase.ToCharArray())
			{
				var x = GetCharNumber(c);
				if (x != -1)
				{
					table[x]++;
					if (table[x] % 2 == 1)
						countOdd++;
					else
						countOdd--;
				}
			}
			return countOdd <= 1;
		}

		// O(N) реализация через битовый вектор
		private static bool IsPermutationOfPalindrome3(string phrase)
		{
			var bitVector = CreateBitVector(phrase);
			return bitVector == 0 || CheckExectlyOneBitSet(bitVector);
		}

		// Проверяем, что символов с нечетным количеством не более одного
		private static bool CheckMaxOneOdd(int[] table)
		{
			var foundOdd = false;
			foreach (var count in table)
			{
				if (count % 2 == 1)
				{
					if (foundOdd)
						return false;
					foundOdd = true;
				}
			}
			return true;
		}

		// Каждый символ связывается с числом: a -> 0, b -> 1..., небуквенный -1
		private static int GetCharNumber(char c)
		{
			var a = (int) 'a';
			var z = (int) 'z';
			var A = (int) 'A';
			var Z = (int) 'Z';

			var val = (int) c;
			if (a <= val && val <= z)
			{
				return val - a;
			}
			if (A <= val && val <= Z)
			{
				return val - A;
			}
			return -1;
		}

		// Подсчет количества вхождений каждого символа
		private static int[] BuildCharFrequencyTable(string phrase)
		{
			var table = new int['z' - 'a' + 1];
			foreach (var c in phrase.ToCharArray())
			{
				var x = GetCharNumber(c);
				if (x != -1)
				{
					table[x]++;
				}
			}
			return table;
		}

		// Создание битового вектора из строки. 
		// Для каждой буквы со значением i изменить значение i бита. 
		private static int CreateBitVector(string phrase)
		{
			var bitVector = 0;
			foreach (var c in phrase.ToCharArray())
			{
				var x = GetCharNumber(c);
				bitVector = Toggle(bitVector, x);
			}
			return bitVector;
		}

		// Переключение i бита в целом значении
		private static int Toggle(int bitVector, int index)
		{
			if (index < 0)
				return bitVector;

			var mask = 1 << index;
			if ((bitVector & mask) == 0)
			{
				bitVector |= mask;
			}
			else
			{
				bitVector &= ~mask;
			}
			return bitVector;
		}

		// Проверить, что в числе установлен ровно один бит
		// Пример: 00010000 - 1 = 00001111
		//         00010000 & 00001111 == 0 
		private static bool CheckExectlyOneBitSet(int bitVector)
		{
			return (bitVector & (bitVector - 1)) == 0;
		}
	}
}
