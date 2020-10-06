﻿using System;

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






            while (tempY != null)
            {
                tempX = tempY;

                while (tempX.Right != null)
                {
                    Console.Write($"{tempX.Value}   ");
                    tempX = tempX.Right;
                }
                Console.WriteLine(tempX.Value);
                tempY = tempY.Bottom;
            }
        }


        
    }
}
