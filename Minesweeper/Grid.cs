using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Grid
    {
        private int Width { get; set; }
        private int Height { get; set; }
        public Field TopLeftField { get; set; }


        public Grid(int width, int height)
        {
            Width = width;
            Height = height;

            TopLeftField = null;
            Field FirstOfRow = null;
            for (int i = 0; i < Height; i++)
            {
                Field LastFirstOfRow = FirstOfRow;
                FirstOfRow = new Field();

                if (i == 0)
                {
                    TopLeftField = FirstOfRow;
                }




                
                Field CurrentField = null;
                for (int j = 0; j < Width; j++)
                {

                    

                    if (j == 0)
                    {
                        CurrentField = FirstOfRow;
                    }

                    var NewField = new Field();
                    

                    if (j != Width-1)
                    {
                        CurrentField.Right = NewField;
                        NewField.Left = CurrentField;

                    }

                    if (i != 0)
                    {
                        LastFirstOfRow.Bottom = CurrentField;
                        CurrentField.Top = LastFirstOfRow;
                    }

                    

                    CurrentField = NewField;
                    
                    CurrentField.Value = 1+j;

                    if (i != 0)
                    {
                        LastFirstOfRow = LastFirstOfRow.Right;
                    }
                }


                
            }

            

        }


        


    }

}
