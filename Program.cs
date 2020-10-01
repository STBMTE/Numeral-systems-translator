using System;
using System.Security.Cryptography.X509Certificates;

namespace Calc
{
    class Program
    {
        private static float Read()
        {
            do
            {
                try
                {
                    return float.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Некоректный ввод");
                }
            } while (true);
        }
        private static float MathFunctionDeclaration(float x)
        {
            float MathFunction = (x * x);
            return MathFunction;
        }
        
        public static float[] FunctionCounting(int step, float startofrange, float endofrange, int arr)
        {
            float[] y = new float[arr];
            for (int i = 0; i < Math.Abs(arr); i++)
            {
                y[i] = MathFunctionDeclaration(startofrange);
                Console.WriteLine(y[i]);
                startofrange = startofrange + step;
            }
            return y;
        }
        static void Main()
        {
            Console.WriteLine("Введите шаг функции");
            int step = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите с какого значения требуется начать вычисление");
            float startofrange = Read();
            Console.WriteLine("Введите до какого значения требуется вычисление функции");
            float endofrange = Read();
            //int delta = (startofrange < 0 && endofrange < 0) ? -1 : 1;
            int arr = Convert.ToInt32(Math.Abs(Math.Abs(Math.Abs(startofrange) - Math.Abs(endofrange)) + 1/*delta*/));
            Program ob = new Program();
            float[] ar = Program.FunctionCounting(step, startofrange, endofrange, arr);
            //ar = Program.FunctionCounting();
            //Console.WriteLine("шаг - {0}; Стартовое значение - {1}; Финальное значение - {2}", step, startofrange, endofrange);
            //Program.FunctionCounting();
            for (int i = 0; i < (arr); i++)
            {
                Console.WriteLine("Значение {0} = {1}", i,ar[i]);
            }
        }
    }
}
