using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Security.Cryptography;
using System.Text;

namespace Minesweeper
{
    class Field
    {

        Random rnd = new  Random();
        
        internal bool IsBomb { get; set; }

        public Field Right { get; set; }
        public Field Left { get; set; }



        internal int setValue()
        {

        }


        public Field()
        {
            int randomnumber;
            randomnumber = rnd.Next(1, 100);
            if (randomnumber < 16)
            {
                IsBomb = true;

            }
            else
            {
                IsBomb = false;
            }
        }

    }
}
