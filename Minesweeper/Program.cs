using System;

namespace Minesweeper
{
    class Program
    {


        private static Grid CreateGrid()
        {
            int Width = 0;
            int Height = 0;
            bool ValidnumHeight = false;
            bool ValidnumWidth = false;

            while (ValidnumHeight == false)
            {
                Console.WriteLine("Bitte geben sie eine Länge von 8 bis 26 ein");
                Height = int.Parse(Console.ReadLine());
                if (Height >= 8 && Height <= 26)
                {
                    ValidnumHeight = true;
                }
                else
                {
                    Console.WriteLine("Bitte eine richtige Zahl eingeben");
                }

            }

            while (ValidnumWidth == false)
            {
                Console.WriteLine("Bitte geben sie eine breite vn 8 bis 26 ein");
                Width = int.Parse(Console.ReadLine());
                if (Width >= 8 && Width <= 26)
                {
                    ValidnumWidth = true;
                }
                else
                {
                    Console.WriteLine("Bitte eine richtige Zahl eingeben");
                }
            }
            return new Grid(Width, Height);
        }



        static void Main(string[] args)
        {
            var Grid = CreateGrid();
            Field tempY = Grid.TopLeftField;
            Field tempX = Grid.TopLeftField;


            //while (tempX.Right != null)
            //{
            //    tempY = tempX;
            //    while (tempY.Bottom != null)
            //    {
            //        Console.WriteLine(tempY.Value);
            //        tempY = tempY.Bottom;
            //    }
            //    Console.WriteLine(tempY.Value);
            //    tempX = tempX.Right;
            //}
            //while (tempY.Bottom != null)
            //{
            //    Console.WriteLine(tempY.Value);
            //    tempY = tempY.Bottom;
            //}




            while (tempX.Right != null)
            {

                tempY = tempX;

                while (tempY.Bottom != null)
                {
                    Console.Write(tempY.Value);
                    tempY = tempY.Bottom;
                }
                Console.WriteLine(tempY.Value);
                tempX = tempX.Right;
            }
        }


        
    }
}
