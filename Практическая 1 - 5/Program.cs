using System;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //запись чисел в массив и подсчет суммы
            int kol = Int32.Parse(Console.ReadLine());
            string[] str = Console.ReadLine().Split(' ');

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int[] str_int = new int[str.Length];
            int sum = 0; //общая сумма
            for (int i = 0; i < kol; i++)
            {
                str_int[i] = int.Parse(str[i]);
                sum = sum + str_int[i]; // 2 4 6 8 10 12 sum=42
            } 

            // поиск минимальной разницы
            int min = sum;
            int pere = (int)(Math.Pow(2, kol - 1) - 1);//всего переборов
            for (int i = 0; i <= pere; i++)
            {
                int num = i + 1;
                int[] a = new int[kol];
                int t = 0;

                for (; num != 1; t++) //если num!=1 то цикл выполнится 
                {
                    a[t] = (int)(num % 2); // остаток от деления на 2
                    num = num / 2;
                }

                a[t] = 1; // 100000 010000 110000 001000 101000 011000 111000 000100 100100
                          // 010100 110100 001100 101100 011100 111100 000010 100010
                          // 010010 110010 001010 101010 011010 111010 000110 100110
                          // 010110 110110 001110 101110 011110 111110  ...

                int data = 0; // число для счетов

                for (int k = 0; k < kol; k++)
                    if (a[k] == 1)
                        data = data + str_int[k]; // берет по очереди все элементы
                int data2 = sum - data;

                if (Math.Abs(data - data2) < min)
                    min = Math.Abs(data - data2);
            }
            Console.WriteLine(min);

            stopWatch.Stop();
            Console.WriteLine("Runtime " + stopWatch.Elapsed);

            Console.ReadLine();

        }
    }
}