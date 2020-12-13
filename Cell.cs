using System;
using System.Collections.Generic;
using System.Text;

namespace ITEA_Homework9v2
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsFigureKeeper { get; set; } = false;
        public bool IsWhite { get; set; }
        public bool CanMove { get; set; }
        public string Icon { get; set; }
        public Figure figure;
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            //if (y % 2 == 0 && x % 2 == 0) 
            //{
            //    IsWhite = true;
            //    Icon = "⬛";
            //}
            //else
            //{
            //    IsWhite = false;
            //    Icon = "⬜";
            //}
            CanMove = true;
        }
        public void Reset()
        {
            if (IsWhite)
            {
                Icon = "⬛";
            }
            else Icon = "⬜";
            IsFigureKeeper = false;
            CanMove = true;
            figure = null;
        }
    }
}
