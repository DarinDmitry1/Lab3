using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public static class FileTasks
    {
        /* =========================
           ЗАДАНИЕ 6 — ТЕКСТОВЫЙ ФАЙЛ
           ========================= */

        public static void FillTextFileNumbers(string path, int count)
        {
            Random rnd = new Random();
            using StreamWriter sw = new StreamWriter(path);

            for (int i = 0; i < count; i++)
                sw.WriteLine(rnd.Next(-100, 101));
        }

        public static int DifferenceMaxMin(string path)
        {
            var numbers = File.ReadAllLines(path).Select(int.Parse).ToArray();
            return numbers.Max() - numbers.Min();
        }

        /* =========================
           ЗАДАНИЕ 7 — ТЕКСТОВЫЙ ФАЙЛ
           ========================= */

        public static int FindMinElement(string path)
        {
            return File.ReadAllLines(path)
                       .Select(int.Parse)
                       .Min();
        }

        /* =========================
           ЗАДАНИЕ 8 — ТЕКСТ
           ========================= */

        public static void CopyLinesStartingWith(string source, string target, char symbol)
        {
            var lines = File.ReadAllLines(source)
                            .Where(l => l.StartsWith(symbol.ToString()));

            File.WriteAllLines(target, lines);
        }
    }
}
