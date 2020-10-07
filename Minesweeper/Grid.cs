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
        internal bool GameOver = false;
        internal int WinCon;
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

                    CurrentField.Value = "?";
                    
                    if (CurrentField.IsBomb)
                    {
                        WinCon++;
                    }
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
            
            


            var Controler = TopLeftField;
            string XNotConverted = Input.Substring(0, 1);
            char XConverter = XNotConverted[0];
            string YConverter = Input.Substring(1, Input.Length-1);
            int y = (int.Parse(YConverter));
            int x = (int) XConverter - 65;

            for (int i = 0; i < x; i++)
            {
                
                Controler = Controler.Right;
            }

            for (int i = 1; i < y; i++)
            {
                Controler = Controler.Bottom;
            }

            Console.WriteLine("Was möchten sie in bei diesem Feld machen?");
            Console.WriteLine("1:Flag Field\t2:Unflag Field\t3:Uncover Field");
            string EditField = Console.ReadLine();

            switch (EditField)
            {
                case "1":
                    if (Controler.IsFlagged == true)
                    {
                        Console.WriteLine("Field is already flagged");
                        Console.ReadLine();
                    }
                    else
                    {
                        Controler.IsFlagged = true;
                        Controler.Value = "F";
                        WinCon--;
                    }
                    break;
                case "2":
                    if (Controler.IsFlagged == true)
                    {
                        Controler.IsFlagged = false;
                        Controler.Value = "?";
                        if (Controler.IsBomb)
                        {
                            WinCon++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Field is already unflagged");
                        Console.ReadLine();
                    }
                    
                    break;
                case "3":
                    if (Controler.IsBomb == false)
                    {
                        Controler.Value = Controler.CountBombsinArea().ToString();
                    }
                    else
                    {
                        Console.WriteLine("GAME OVER IT WAS A BOMB");
                        GameOver = true;

                    }
                    break;
            }

            

        }

        



    }
    
}
