using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Security.Cryptography;
using System.Text;

namespace Minesweeper
{
    class Field
    {
        
        Random rnd = new Random();

        internal bool IsBomb { get; set; }
        internal bool IsFlagged { get; set; }
        internal string Value { get; set; }
        public Field Right { get; set; }
        public Field Left { get; set; }
        public Field Top { get; set; }
        public Field Bottom { get; set; }
        

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


        public int CountBombsinArea()
        {
            int BombCount = 0;

            if (Top != null)
            {
                if (Top.IsBomb)
                {
                    BombCount++;
                }
            }
            if (Left != null)
            {
                if (Left.IsBomb)
                {
                    BombCount++;
                }
            }
            if (Right != null)
            {
                if (Right.IsBomb)
                {
                    BombCount++;
                }
            }
            if (Bottom != null)
            {
                if (Bottom.IsBomb)
                {
                    BombCount++;
                }
            }

            if (Top != null && Top.Right != null)
            {
                if (Top.Right.IsBomb)
                {
                    BombCount++;
                }
            }
            if(Top != null && Top.Left != null)
            {
                if (Top.Left.IsBomb)
                {
                    BombCount++;
                }
            }
            if(Bottom != null && Bottom.Right != null)
            {
                if (Bottom.Right.IsBomb)
                {
                    BombCount++;
                }
            }
            if(Bottom != null && Bottom.Left != null)
            {
                if (Bottom.Left.IsBomb)
                {
                    BombCount++;
                }

            }
            return BombCount;
        }
    }
}
