using System;
using System.Collections.Generic;
using System.IO;

namespace Matrix
{
    //Определение длины строки массива
    //Инициализируется массив, куда будут записываться значения
    class ReadWrite
    {
        public static void Read(string path, ref int[,] matrix)
        {

            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            var lines = File.ReadAllLines(path);
            int k = 0;
            string[] strLen = lines[0].Split(';'); 
            matrix = new int[lines.Length, strLen.Length]; 
            foreach (var line in lines)
            {

                string[] str = line.Split(';'); 
                for (int j = 0; j < str.Length; j++)
                {
                    matrix[k, j] = Convert.ToInt32(str[j]); 
                }
                k++;
            }
        }

        public static void Write(string path, List<int> neededNums, int count)
        {
            if (!File.Exists(path)) File.Create(path).Close();
            using (StreamWriter sw = new StreamWriter(path, false))
            {

                sw.WriteLine("Элементы массива, соответсвующие условия задачи:");
                foreach(var num in neededNums)
                {
                    sw.Write(num+"; ");
                }
                sw.WriteLine("\nОбщее количество элементов, подходящие по условию задачи: " +count);
            }
        }
    }
}
