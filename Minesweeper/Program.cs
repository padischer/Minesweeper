using System;
using System.Runtime.CompilerServices;

namespace Minesweeper
{
    internal class Program
    {
        
        //getting input for Grid
        private static Grid CreateGrid()
        {
            //initializig Vriables
            int Width = 0;
            int Height = 0;
            bool ValidnumHeight = false;
            bool ValidnumWidth = false;

            //getting the input for grid Length
            while (ValidnumHeight == false)
            {
                try
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
                catch (System.FormatException)
                {
                    Console.WriteLine("Das ist keine gültige zahl");
                }
            }

            //getting input for grid Width
            while (ValidnumWidth == false)
            {
                try
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
                catch (System.FormatException)
                {
                    Console.WriteLine("Das ist keine gültige zahl");
                }
            }
            //returning Grid
            return new Grid(Width, Height);
        }

        //Main function
        private static void Main(string[] args)
        {
            Console.Clear();
            End Finish = new End();
            int Condition = 0;
            var text1 = System.IO.File.ReadAllText(@"C:\Users\svenw\Pictures\Minesweeper.txt");
            var text2 = System.IO.File.ReadAllText(@"C:\Users\svenw\Pictures\Won.txt");
            var text3 = System.IO.File.ReadAllText(@"C:\Users\svenw\Pictures\Lost.txt");
            bool Gameover = false;

            Console.WriteLine(text1);

            //Creating a Variable to access Grid


            var grid = CreateGrid();
            while (Gameover == false)
            {
                
                var timer = new Stopwatch();
                timer.StartTimer();
                //Usual Grid out and input
                Console.Clear();
                grid.ShowGrid();
                string Position = grid.GetPositionOfField();
                string Interaction = grid.GetEditOfField();
                grid.EditField(grid.GetSpecificField(Position), Interaction);
                //Ending
                if (grid.WinCon == 0)
                {
                    Console.WriteLine(text2);
                    Gameover = Finish.Playagain(timer, grid.GameOver);
                }

                if (grid.GameOver) 
                {
                    Console.WriteLine(text3);
                    Gameover = Finish.Playagain(timer, grid.GameOver);
                }
            }
        }
    }
}