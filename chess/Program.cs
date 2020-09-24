using System;
using System.Security.Cryptography;
using System.Text;

namespace chess
{
    class Program
    {
        static char[] Conver(string x)
        {
            char[] bar = x.ToCharArray();
            return bar;
        }
        static void Main()
        {
            string startposition = Console.ReadLine();
            string endposition = Console.ReadLine();
            
            Console.WriteLine(Conver(startposition));
        }
    }
}
