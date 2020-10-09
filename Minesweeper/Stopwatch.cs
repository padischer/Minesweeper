using System;
using System.Timers;

namespace Minesweeper
{
    internal class Stopwatch
    {
        public static int time = 0;
        internal static System.Timers.Timer timer;

        internal void StartTimer()
        {
            timer = new System.Timers.Timer(1000);

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        internal void EndTimer()
        {
            Console.WriteLine();
            timer.Dispose();
            Console.WriteLine($"Deine Zeit: {time} Sekunden");
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            time++;
        }
    }
}