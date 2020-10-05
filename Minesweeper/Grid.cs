using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Grid
    {
        private int Width { get; set; }
        private int Length { get; set; }

        public Grid CreateGrid()
        {
            Console.WriteLine("Bitte geben sie eine breite vn 8 bis 26 ein");
            var widthzs= int.Parse(Console.ReadLine());
            Console.WriteLine("Bitte geben sie eine Länge vn 8 bis 26 ein");
            var lengthzs = int.Parse(Console.ReadLine());

            return new Grid()
            {
                Width = widthzs,
                Length = lengthzs
            };
        }




    }

}
