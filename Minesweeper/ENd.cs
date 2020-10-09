using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Minesweeper
{
    class End
    {

        internal bool Playagain(Stopwatch Stopwatch, bool Gameover)
        {
            Console.WriteLine();
            Stopwatch.EndTimer();
            while (true)
            {
                Console.WriteLine("Möchten sie nocheinmal spielen? y/n");
                string Again = Console.ReadLine();
                switch (Again)
                {
                    case "y":
                        Gameover = false;
                        return Gameover;
                        break;

                    case "n":
                        Gameover = true;
                        return Gameover;
                        
                    default:
                        Console.WriteLine("Das ist keine gültige Eingabe. Bitte nochmal versuchen");
                        return Gameover;
                        
                }
            }


        }

        

    }
}
