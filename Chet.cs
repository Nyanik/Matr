using System;
using System.Collections.Generic;

namespace Matrix
{
    // Данный класс создан с целью произведения вычисления
    // и подсчета чисел чья сумма кубов равна сумме цифр числа
    class Chet
    {
        string readFile, savingFile;        
        int[,] matr; 
        int count = 0; 
        List<int> neededNum = new List<int>(); 

        public Chet(string readFile, string savingFile) 
        {
            this.readFile = readFile;
            this.savingFile = savingFile;
        }
        bool NumSumCheck(int num) 
        {
            int sum = 0, origNum = num;
            bool result = false;
            while (num > 0)
            {
                sum = sum + Convert.ToInt32(Math.Pow(num % 10, 3));
                num = num / 10;
            }

            if (sum == origNum) result = true;

            return result;
        }
        void MatrixMoving() 
        {  
            foreach(int num in matr)
            {
                if(NumSumCheck(num) == true)
                {
                    count++;
                    neededNum.Add(num);
                }
            }
        }   
        //Чтение матрицы из файла и вывод результата в текстовы файл
        public void CalcStart() 
        {
            ReadWrite.Read(readFile, ref matr);
            MatrixMoving();
            ReadWrite.Write(savingFile, neededNum, count);
        }
    }

}
