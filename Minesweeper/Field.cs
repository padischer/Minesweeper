using System;

namespace Minesweeper
{
    internal class Field
    {
        private Random rnd = new Random();

        //initializing Variables
        internal bool IsBomb { get; set; }

        internal bool IsFlagged { get; set; }
        internal bool IsUncoverd { get; set; }
        internal string Value { get; set; }
        public Field Right { get; set; }
        public Field Left { get; set; }
        public Field Top { get; set; }
        public Field Bottom { get; set; }

        //deciding if a Field is a bomb in constructor
        public Field()
        {
            int randomnumber;
            randomnumber = rnd.Next(1, 100);
            if (randomnumber < 3)
            {
                IsBomb = true;
            }
            else
            {
                IsBomb = false;
            }
        }

        //function to uncover field
        public void UncoverField()
        {
            //to secrue that it can't loop infinetly
            if (IsUncoverd)
            {
                return;
            }
            //setValue
            Value = CountBombsinArea().ToString();
            if (Value == "0")
            {
                Value = "~";
            }
            IsUncoverd = true;
            //uncover multiple Fields
            if (CountBombsinArea() == 0)
            {
                Top?.UncoverField();
                Right?.UncoverField();
                Left?.UncoverField();
                Bottom?.UncoverField();
                Top?.Left?.UncoverField();
                Top?.Right?.UncoverField();
                Bottom?.Right?.UncoverField();
                Bottom?.Left?.UncoverField();
            }
        }

        //Count Bombs around a Field
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
            if (Top != null && Top.Left != null)
            {
                if (Top.Left.IsBomb)
                {
                    BombCount++;
                }
            }
            if (Bottom != null && Bottom.Right != null)
            {
                if (Bottom.Right.IsBomb)
                {
                    BombCount++;
                }
            }
            if (Bottom != null && Bottom.Left != null)
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