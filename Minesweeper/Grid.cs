using System;
using System.Linq;

namespace Minesweeper
{
    internal class Grid
    {
        //initializing Variables
        

        internal int Width { get; set; }
        internal int Height { get; set; }
        public Field TopLeftField { get; set; }
        internal bool GameOver = false;
        internal int WinCon;

        //makking a Grid when the constructor is selected
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;

            TopLeftField = null;
            Field FirstOfRow = null;

            //for-loop for the height
            for (int i = 0; i < Height; i++)
            {
                Field LastFirstOfRow = FirstOfRow;
                FirstOfRow = new Field();

                if (i == 0)
                {
                    TopLeftField = FirstOfRow;
                }

                Field CurrentField = null;

                //for-loop for the width
                for (int j = 0; j < Width; j++)
                {
                    if (j == 0)
                    {
                        CurrentField = FirstOfRow;
                    }

                    var NewField = new Field();

                    if (j != Width - 1)
                    {
                        CurrentField.Right = NewField;
                        NewField.Left = CurrentField;
                    }

                    if (i != 0)
                    {
                        LastFirstOfRow.Bottom = CurrentField;
                        CurrentField.Top = LastFirstOfRow;
                    }

                    //Setting the Value and counting all Bombs in the Grid
                    CurrentField.Value = "?";
                    CurrentField.IsUncoverd = false;
                    if (CurrentField.IsBomb)
                    {
                        WinCon++;
                    }

                    //preparing for next loop
                    CurrentField = NewField;

                    if (i != 0)
                    {
                        LastFirstOfRow = LastFirstOfRow.Right;
                    }
                }
            }
        }

        //Displaying the Grid
        public void ShowGrid()
        {
            //Initializing Variables
            Field tempY = TopLeftField;
            Field tempX = TopLeftField;
            int count = 0;

            //making the top line of the Grid
            Console.Write("      ");
            for (int i = 0; i < Width; i++)
            {
                Console.Write(char.ToUpper((char)(i + (int)'a')) + " ");
            }

            Console.WriteLine();

            //line that seperates the topLine from Values
            Console.Write("      ");
            for (int i = 0; i < Width; i++)
            {
                Console.Write("--");
            }
            Console.WriteLine();

            //Creating Sideline of Grid
            while (tempY != null)
            {
                count++;
                Console.Write($"{count} ");

                tempX = tempY;

                if (count < 10)
                {
                    Console.Write(" ");
                }

                //line that seperates the Sideline from Values
                Console.Write("|| ");

                //Loop for writing Values in grid

                while (tempX.Right != null)
                {
                    Console.Write($"{tempX.Value} ");
                    tempX = tempX.Right;
                }

                //extra output because else last column would not be displayed
                Console.WriteLine(tempX.Value);

                //going to nex Line
                tempY = tempY.Bottom;
            }
        }

        //Getting a Field that the user wnats to edit
        internal string GetPositionOfField()
        {
            string Input;

            while (true)
            {
                Console.WriteLine("Bitte geben sie die Position des Feldes ein, welches sie Bearbeiten möchten (Bsp. A2)");
                Input = Console.ReadLine();
                if (Input.Length <= 3 && Input.Length > 0 && Input.Any(c => char.IsDigit(c)) && Input.Any(b => char.IsLetter(b)))
                {
                    return Input;
                    /*
                    char anfang = Input[0];
                    char middle = Input[1];
                    if (char.IsLetter(anfang))
                    {
                        return Input;
                    }
                    else
                    {
                        if (Input.Length == 3)
                        {
                            
                        }
                    }
                    
                    */

                }
            }
        }

        //Converting the FieldPosition input and setting the position of controler
        internal Field GetSpecificField(string Input)
        {

            try
            {
                var Controler = TopLeftField;

                string XString = Input.Substring(0, 1);
                char XConverter = XString[0];
                int x = (int) XConverter - 65;

                string YConverter = Input.Substring(1, Input.Length - 1);
                int y = (int.Parse(YConverter));

                for (int i = 0; i < x; i++)
                {
                    Controler = Controler.Right;
                }

                for (int i = 1; i < y; i++)
                {
                    Controler = Controler.Bottom;
                }
                return Controler;
            }

            
            catch (System.FormatException)
            {
                Console.WriteLine("Falsche Eingabe");
                Console.ReadLine();
                return TopLeftField;
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Error Bitte nochmal versuchen");
                Console.ReadLine();
                return TopLeftField;
            }

        }

        //function for getting editing input
        public string GetEditOfField()
        {
            //ask for input
            Console.WriteLine("Was möchten sie in bei diesem Feld machen?");
            Console.WriteLine("1:Flag Field\t2:Unflag Field\t3:Uncover Field");

            //save and return input
            string EditField = Console.ReadLine();
            return EditField;
        }

        //function for deciding what to to with input
        public void EditField(Field Controler, string EditField)
        {
            switch (EditField)
            {
                //Flag Field
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

                        if (Controler.IsBomb)
                        {
                            WinCon--;
                        }
                        else
                        {
                            WinCon++;
                        }
                    }
                    break;
                //Unflag Field
                case "2":
                    if (Controler.IsFlagged == true)
                    {
                        Controler.IsFlagged = false;
                        Controler.Value = "?";
                        if (Controler.IsBomb)
                        {
                            WinCon++;
                        }
                        else
                        {
                            WinCon--;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Field is already unflagged");
                        Console.ReadLine();
                    }

                    break;
                //Uncover Field
                case "3":
                    if (Controler.IsBomb == false)
                    {
                        Controler.Value = Controler.CountBombsinArea().ToString();
                        Controler.UncoverField();
                    }
                    else
                    {
                        GameOver = true;
                    }

        
                    break;
            }
        }
    }
}