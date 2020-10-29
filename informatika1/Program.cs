using System;

namespace informatika1
{
    class Program
    {
        static string[] a = new string[50] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "#", "@", "†", "‡", "!", "$", "%", "^", "&", "*", "Ў", "-", "+", "=" };
        private static int Read()
        {
            string x;
            int z;
            do
            {
                x = Console.ReadLine();
                try
                {
                    z = Convert.ToInt32(x);
                    break;
                }
                catch
                {
                    Console.WriteLine("Неверный ввод");
                }
            } while (true);
            return z;
        }

        private static int VerificationOfOwnership(string x, int M)
        {
            for (int i = 0; i < M + 2; i++)
            {
                if (a[i] == x)
                {
                    return 1;
                }
            }
            return 0;
        }

        private static string ReadNumber(int M)
        {
            do
            {
                string x = Console.ReadLine();
                int y = x.Length;
                int z = 0;
                for (int i = 0; i < y; i++)
                {
                    z = z + (VerificationOfOwnership(Convert.ToString(x[i]), M));
                }
                if (z == y)
                {
                    return x;
                }
                Console.WriteLine("Введено неверное значение");
            } while (true);
        }
        private static string ExpandString(string x)
        {
            string z = null;
            int y = x.Length;
            for (int i = 1; i <= y; i++)
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

        private static int ConversionToDecimalSystem(string x, int M)
        {
            /*M - основание системы счисления из которой переводим число N - основание системы в которую переводим число*/
            int length = x.Length;
            int C = 0;
            for (int i = 1; i < length + 1; i++)
            {
                int y = Convert.ToInt32(DefiningASymbolAsANumber(Convert.ToString(x[i - 1])));
                C = C + (y * ((int)Math.Pow(M, (length - i))));
                Console.WriteLine("для перевода из {0}-ричной системы счисления требуется: {1} * {0}^{2}", M, y, length - i);
            }
            Console.WriteLine("Переведем число {0} из системы счисления с основанием {1} в систему счисления с основанием 10 и получим {2}", x, M, C);
            return C;
        }

        private static int DefiningASymbolAsANumber(string r)
        {
            int x;
            string g = null;
            for (int j = 0; j < 50; j++)
            {
                if (Convert.ToString(r) == a[j])
                {
                    g = g + Convert.ToString(j);
                }
            }
            x = Convert.ToInt32(g);
            return x;
        }
        private static string TransferToAnotherNumberSystem(string r, int M, int N, int type)
        {
            Console.WriteLine("Строка = {0}",r);
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
        private static int ReadType()
        {
            Console.WriteLine("Выберите тип");
            int x;
            Console.WriteLine("1) беззнаковыое целое");
            Console.WriteLine("2) целые со знаком");
            Console.WriteLine("3) дробные");
            do
            {
                x = Read();
                if ((x > 0) && (x < 4))
                {
                    return x;
                }
            } while (true);
        }

        private static int GettingTheBaseOfTheNumberSystem()
        {
            Console.WriteLine("Введите основание системы счисления в которой находится число сейчас");
            int M = Read();
            return M;
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("{0}) = {1}   ", i + 1, a[i]);
                if ((i + 1) % 10 == 0 && i != 0)
                {
                    Console.WriteLine();
                }
            }

            int type = ReadType();
            int M = GettingTheBaseOfTheNumberSystem();
            string num = ReadNumber(M);
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(TransferToAnotherNumberSystem(num, M, N, type));
            Console.ReadLine();
        }
    }
}
