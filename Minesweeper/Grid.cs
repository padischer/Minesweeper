using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Grid
    {
        internal int Width { get; set; }
        internal int Height { get; set; }
        public Field TopLeftField { get; set; }
        private int Count = 0;

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;

            TopLeftField = null;
            Field FirstOfRow = null;
            for (int i = 0; i < Height; i++)
            {
                Count++;
                Field LastFirstOfRow = FirstOfRow;
                FirstOfRow = new Field();

                if (i == 0)
                {
                    TopLeftField = FirstOfRow;
                }




                
                Field CurrentField = null;
                for (int j = 0; j < Width; j++)
                {
                    Count++;
                    

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

                    CurrentField.Value = Count;

                    CurrentField = NewField;
                    
                    

                    if (i != 0)
                    {
                        LastFirstOfRow = LastFirstOfRow.Right;
                    }
                }


                
            }

            

        }


        public void ShowGrid()
        {
            Field tempY = TopLeftField;
            Field tempX = TopLeftField;
            int count = 0;

            Console.Write("      ");
            //Console.Write("    ");
            for (int i = 0; i < Width; i++)
            {
                Console.Write(char.ToUpper((char)(i + (int)'a')) + " ");


            }

            Console.WriteLine();
            Console.Write("      ");
            for (int i = 0; i < Width; i++)
            {

                Console.Write("--");
            }
            Console.WriteLine();

            while (tempY != null)
            {

                count++;
                Console.Write($"{count} ");


                tempX = tempY;

                
                if (count < 10)
                {
                    Console.Write(" ");
                }

                Console.Write("|| ");
                while (tempX.Right != null)
                {
                    Console.Write($"{tempX.Value} ");
                    tempX = tempX.Right;
                    
                }
                Console.WriteLine(tempX.Value);

                tempY = tempY.Bottom;
            }
        }

        internal string GetPositionOfField()
        {
            string Input;
            Console.WriteLine("Bitte geben sie die Position des Feldes ein, welches sie Bearbeiten möchten (Bsp. A2)");
            Input = Console.ReadLine();
            return Input;
        }

        
        internal void InteractWithSpecificField(string Input)
        {
            string XNotConverted = Input.Substring(0, 1);
            char XConverter = XNotConverted[0];
            string YConverter = Input.Substring(1, Input.Length-1);
            int y = (int.Parse(YConverter));
            int x = (int) XConverter - 65;
            Field Position = null;
            
            for (int i = 0; i < x; i++)
            {
                TopLeftField = TopLeftField.Right;

            }

            for (int i = 1; i < y; i++)
            {
                TopLeftField = TopLeftField.Bottom;
                
            }

            Console.WriteLine(TopLeftField.Value);

            //for (int i = 0; i < ; i++)
           // {
                
           // }


        }

        



    }

}
