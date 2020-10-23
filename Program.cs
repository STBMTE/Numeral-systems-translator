using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Lection3
{
    class Program
    {
        private static string rightthetopcorner = "┌";
        private static string thetopitersection = "┬";
        private static string leftthetopcorner = "┐";
        private static string rigthcentersection = "├";
        private static string centersection = "┼";
        private static string leftthecentersection = "┤";
        private static string rigthbottomcross = "└";
        private static string centerbottomsection = "┴";
        private static string leftbottomcross = "┘";
        private static string verticalbar = "│";
        private static string horizontalbar = "─";
        private static void WritePositionElement(string s, int x, int y, int deltay, int deltax)
        {
            try
            {
                Console.SetCursorPosition(x + deltax, y + deltay);
                Console.Write(s);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Вышел за пределы буфера?");
                Console.WriteLine("Размер буфера {0} полей. PositionField = {1}", Console.BufferWidth, x);
                Console.WriteLine("PositionField[i + 1] = {0}", y);
            }
        }

        private static bool ChoisVerticalBar(int i, int j, int wC, int sTTop, int xCoordinate, int yCoordinate, int sL)
        {
            return (((((i % wC) == 0) && (i != sTTop) && (i != xCoordinate - 1)) && (j != sL))
                || (i == xCoordinate) && (j != sL) && (j == yCoordinate) || (i == sTTop) || (i == xCoordinate - 1));
        }

        private static bool ChoisHorizontalBar(int i, int j, int hF, int sTTop, int xCoordinate, int yCoordinate, int sL)
        {
            return (i != sTTop) && ((j == (yCoordinate - 1)) || (j == sL)) && (i != xCoordinate) || ((j % hF == 0));
        }

        private static /*int[,]*/ void PositionFields(int wF, int hF, int sTTop, int sL, int hC, int wC)
        {
            int xCoordinate = wF * wC + sL;
            int yCoordinate = hF * hC + sTTop;
            string[,] position = new string[xCoordinate, yCoordinate];
            for (int i = sL; i < (xCoordinate); i++)
            {
                for (int j = sTTop; j < (yCoordinate); j++)
                {
                    
                    if (ChoisHorizontalBar(i, j, hF, sTTop, xCoordinate, yCoordinate, sL))
                    {
                        position[i, j] = horizontalbar;
                    }
                    if (ChoisVerticalBar(i, j, wC, sTTop, xCoordinate, yCoordinate, sL))
                    {
                        position[i, j] = verticalbar;
                    }
                    if ((((i % wC) == 0) && (i != sTTop) && (i != xCoordinate - 1)) && (j == sL))
                    {
                        position[i, j] = thetopitersection;
                    }
                    if (((i % wC) == 0) && (j == yCoordinate - 1))
                    {
                        position[i, j] = centerbottomsection;
                    }
                    if ((i == sTTop) && (j == sL))
                    {
                        position[i, j] = rightthetopcorner;
                    }
                    if ((i == sTTop) && (j == yCoordinate - 1))
                    {
                        position[i, j] = rigthbottomcross;
                    } 
                    if ((i == xCoordinate - 1) && (j == sTTop))
                    {
                        position[i, j] = leftthetopcorner;
                    }
                    if ((i == (xCoordinate - 1)) && (j == yCoordinate - 1))
                    {
                        position[i, j] = leftbottomcross;
                    }
                    if (ChoisVerticalBar(i, j, wC, sTTop, xCoordinate, yCoordinate, sL) 
                        && ChoisHorizontalBar(i, j, hF, sTTop, xCoordinate, yCoordinate, sL) 
                        && (i != sL) && (j != sTTop) && (i != xCoordinate - 1) && (j != yCoordinate - 1))
                    {
                        position[i, j] = centersection;
                    }
                    if ((j % hF == 0) && i == sL)
                    {
                        position[i, j] = rigthcentersection;
                    }
                    WritePositionElement(position[i, j], i, j, sTTop, sL);
                    Thread.Sleep(10);
                }
            }
        }

static void Main()
{

    int widthField = 4;//ширина поля
    int heightField = 2;//высота поля 
    int stepTheTop = 1;//отступ сверху
    int stepLeft = 1;//отступ слева
    int heightCell = 4;// высота ячейки
    int widthCell = 3;// ширина ячейки
    int y = stepTheTop;
    int x = stepLeft;
    PositionFields(widthField, heightField, stepTheTop, stepLeft, heightCell, widthCell);
    /*int[,] PositionFields = Program.PositionFields(widthField, heightField, stepTheTop, stepLeft, heightCell, widthCell);
    for (int i = 0; i < ((widthField * heightField * heightCell * widthCell) * 2); i++)
    {
    }*/
    Console.ReadKey();
}
    }
}
