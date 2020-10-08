using System;
using System.Threading.Channels;
using System.Timers;

namespace Minesweeper
{
    class Program
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
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            //Creating a Variable to access Grid
            var grid = CreateGrid();
            timer.StartTimer();
            while (grid.GameOver == false) 
            {

                //Usual Grid out and input
                Console.Clear();
                grid.ShowGrid();
                string Position = grid.GetPositionOfField();
                string Interaction = grid.GetEditOfField();
                grid.EditField(grid.GetSpecificField(Position), Interaction);

                //Winning
                if (grid.WinCon == 0)
                {
                    timer.EndTimer();
                    Console.WriteLine("YOU WON ALL MINES HAVE BEEN FLAGGED");
                    return;
                }
            }
        }
    }
}
