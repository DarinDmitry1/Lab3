using System;

namespace Lab3
{
    public class MatrixTask
    {
        // Единственное поле класса — двумерный массив
        private int[,] data;

        // Размеры матрицы
        public int Rows => data.GetLength(0);
        public int Cols => data.GetLength(1);

        /* =====================================================
           ЗАДАНИЕ 1 — КОНСТРУКТОРЫ
           ===================================================== */

        // 1) Матрица n x m
        // Заполнение с клавиатуры по столбцам
        // от первых элементов столбца к последним
        public MatrixTask(int n, int m)
        {
            data = new int[n, m];

            Console.WriteLine($"Введите элементы матрицы {n}x{m}:");

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    data[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        // 2) Матрица n x n
        // Заполнение относительно побочной диагонали
        public MatrixTask(int n)
        {
            data = new int[n, n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Выше побочной диагонали
                    if (i + j < n - 1)
                        data[i, j] = rnd.Next(-12, 4566);
                    else
                        data[i, j] = rnd.Next(-1024, 1025);
                }
            }
        }

        // 3) Специальная матрица n x n (как для n = 5)
        public static MatrixTask CreateSpecial(int n)
        {
            MatrixTask matrix = new MatrixTask();
            matrix.data = new int[n, n];

            int value = 1;

            for (int col = n - 1; col >= 0; col--)
            {
                for (int row = n - 1; row >= col; row--)
                {
                    matrix.data[row, col] = value++;
                }
            }

            return matrix;
        }

        // Закрытый конструктор — используется внутри класса
        private MatrixTask() { }

        /* =====================================================
           ЗАДАНИЕ 2
           Поиск подмассива 3x3 с максимальной суммой
           ===================================================== */

        public int FindMax3x3Sum()
        {
            if (Rows < 3 || Cols < 3)
                throw new InvalidOperationException("Размер матрицы меньше 3x3");

            int maxSum = int.MinValue;

            for (int i = 0; i <= Rows - 3; i++)
            {
                for (int j = 0; j <= Cols - 3; j++)
                {
                    int currentSum = 0;

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            currentSum += data[i + x, j + y];
                        }
                    }

                    if (currentSum > maxSum)
                        maxSum = currentSum;
                }
            }

            return maxSum;
        }

        /* =====================================================
           ВЫВОД МАТРИЦЫ
           ===================================================== */

        public override string ToString()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"{data[i, j],6}");
                }
                Console.WriteLine();
            }
            return string.Empty;
        }
    }
}
