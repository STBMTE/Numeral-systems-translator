using System;
using System.Threading;

namespace informatika1
{
    class Program
    {/*C = an * Mn + an-1 * Mn-1 + ... + a1 * M + a0.*/
        static string[] a = new string[50] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "#", "@", "†", "‡", "!", "$", "%", "^", "&", "*", "Ў", "-", "+", "="};
        private static int Read()
        {
            do
            {
                try
                {

                }
                catch
                {

                }
            } while (true);
        }
        private static string ExpandString(string x)
        {
            string z = null;
            int y = x.Length;
            for(int i = 1; i <= y; i++)
            {
                z = z + x[y - i];
            }
            Console.WriteLine("Что бы получить правильное число нам надо развернуть число {0} и мы получим число {1}", x, z);
            return z;
        }

        private static int ByteFormatSelection(string type, string y)
        {
            if (type == "беззнаковый")
            {

            }
            if (type == "знаковый")
            {

            }

            return 0;
        }
        
        private static int ConversionToDecimalSystem(int x, int M)
        {
            /*M - основание системы счисления из которой переводим число N - основание сисстемы в которую переводим число*/
            string x1 = Convert.ToString(x);
            int length = x1.Length;
            int C = 0;
            for (int i = 1; i <= length; i++)
            {
                int y = Convert.ToInt32(Convert.ToString(x1[i - 1]));
                C = C + (y * ((int)Math.Pow(M, (length - i))));
            }
            Console.WriteLine("Переведем число {0} из системы счисления с основанием {1} в систему счисления с основанием 10 и получим {2}", x, M, C);
            return C;
        }

        private static string TransferToAnotherNumberSystem(int r, int M, int N, string type)
        {
            int x = ConversionToDecimalSystem(r, M);
            Console.WriteLine("Приведем целую часть числа {0} в {1}-ричную систему счисления последовательным делением на {1}", x, N);
            string z = null;
            int y = x;
            do
            {
                Console.Write("{0} % {1} = ", y, N);
                z = z + a[(y % N)];
                Console.WriteLine(y % N);
                y = y / N;
                
                if (y == 0) break;
            } while (true);
            Console.WriteLine("Переводим число {0} из 10-сятичной в {1}-ричную и получим число {2} в {1}-ричной системе счисления", x, N, z);
            return ExpandString(z);
        }
        private static string ReadType()
        {
            Console.WriteLine("Выберите тип");
            string x;
            Console.WriteLine("1) беззнаковыое целое");
            Console.WriteLine("2) целые со знаком");
            Console.WriteLine("3) дробные");
            do
            {
                x = Console.ReadLine();
                if((x > 0) && (x < 4))
                {
                    return x;
                }
                break
            } while (true);
            return x;
        }

        static void Main(string[] args)
        {
            /*string[] a = new string[50] {"0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F","G","H","","I","J","K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Ђ", "Ѓ", "†", "‡", "Љ", "Њ", "Ќ", "Ћ", "Џ", "Ђ", "Ў", "µ", "•" }; */
            for (int i = 0; i < 50; i++)
            {
                Console.Write("{0}) = {1}   ", i + 1, a[i]);
                if ((i + 1) % 10 == 0 && i != 0)
                {
                    Console.WriteLine();
                }
            }
            string type = ReadType();
            int num = Convert.ToInt32(Console.ReadLine());
            int M = Convert.ToInt32(Console.ReadLine());
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(TransferToAnotherNumberSystem(num, M, N, type));
            
        }
    }
}
