using System;

/*
Имеется изображение, представленное матрицей NxN; каждый пиксел представлен 4 байтами. 
Напишите метод для поворота изображения на 90 градусов.    
*/

namespace _1._7
{
	class Program
	{
		static void Main(string[] args)
		{
			var matrix = new int[,]
			{
				{11, 12, 13, 14, 15},
				{21, 22, 23, 24, 25},
				{31, 32, 33, 34, 35},
				{41, 42, 43, 44, 45},
				{51, 52, 53, 54, 55}
			};

			Console.WriteLine("Before:");
			ShowMatrix(matrix, 5);
			Console.WriteLine();
			Console.WriteLine("Rotatating...");
			Rotate(matrix, 5);
			Console.WriteLine("After:");
			ShowMatrix(matrix, 5);

			Console.ReadKey();
		}

		private static void ShowMatrix(int[,] matrix, int n)
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					Console.Write($"{matrix[i, j]}");
					if (j < n - 1)
						Console.Write(", ");
					else if (i < n - 1)
						Console.WriteLine();
				}
			}
		}

		private static void Rotate(int[,] matrix, int n)
		{
			for (int layer = 0; layer < n / 2; layer++)
			{
				var first = layer;
				var last = n - 1 - layer;
				for (int i = first; i < last; i++)
				{
					var offset = i - first;
					// Сохранить верхнюю сторону
					var top = matrix[first, i];
					// левая сторона -> верхняя сторона
					matrix[first, i] = matrix[last - offset, first];
					// нижняя строна -> левая сторона
					matrix[last - offset, first] = matrix[last, last - offset];
					// правая сторона -> нижняя сторона
					matrix[last, last - offset] = matrix[i, last];
					// верхняя сторона -> правая сторона
					matrix[i, last] = top;
				}
			}
		}
	}
}
