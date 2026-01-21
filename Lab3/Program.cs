using Lab3;
using Laba2;
using System;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Задания 1–3: Работа с матрицами ===");

            // --- Задание 1: конструкторы ---
            // 1) Ввод с клавиатуры
            Console.WriteLine("Введите размер матрицы n x m для ввода с клавиатуры:");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            MatrixTask A = new MatrixTask(n, m);
            Console.WriteLine("Матрица A:");
            Console.WriteLine(A.ToString());

            // 2) Квадратная матрица с генерацией
            Console.WriteLine("\nВведите размер квадратной матрицы n:");
            int size = int.Parse(Console.ReadLine());
            MatrixTask B = new MatrixTask(size);
            Console.WriteLine("Матрица B:");
            Console.WriteLine(B.ToString());

            // 3) Специальная матрица
            MatrixTask C = MatrixTask.CreateSpecial(5);
            Console.WriteLine("\nСпециальная матрица C:");
            Console.WriteLine(C.ToString());

            // --- Задание 2: поиск подмассива 3x3 с максимальной суммой ---
            try
            {
                int maxSum = A.FindMax3x3Sum();
                Console.WriteLine($"Максимальная сумма 3x3 подмассива в матрице A: {maxSum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Задание 6: текстовый файл с числами (по одному в строке)
            string txtPath = "numbers.txt";
            FileTasks.FillTextFileNumbers(txtPath, 15);
            int diff = FileTasks.DifferenceMaxMin(txtPath);
            Console.WriteLine($"Разница max-min в текстовом файле: {diff}");

            // Задание 7: текстовый файл, найти минимальный элемент
            int minElem = FileTasks.FindMinElement(txtPath);
            Console.WriteLine($"Минимальный элемент: {minElem}");

            // Задание 8: копирование строк, начинающихся с символа
            string textSource = "text.txt";
            string textTarget = "lines.txt";
            FileTasks.CopyLinesStartingWith(textSource, textTarget, 'A');
            Console.WriteLine($"Скопированные строки из {textSource} в {textTarget}, начинающиеся с 'A'");
        }
    }
}
