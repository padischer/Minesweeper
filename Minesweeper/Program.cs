using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {


            Field f1 = new Field();


            Console.WriteLine((f1.IsBomb));

            Console.ReadKey();

        }
    }
}
