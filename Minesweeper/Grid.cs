using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Grid
    {
        private int Width { get; set; }
        private int Height { get; set; }

        

        public Grid(int width, int height)
        {
            


            for (int i = 0; i < Height; i++)
            {
                var FirstOfRow = new Field();





                var CurrentField = new Field();
                for (int j = 0; j < Width; j++)
                {
                    var newField = new Field();
                }

            }

        }


    }

}
