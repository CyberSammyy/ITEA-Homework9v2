using System;
using System.Collections.Generic;
using System.Text;

namespace ITEA_Homework9v2
{
    public abstract class Figure
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public bool IsWhite { get; set; }
        public bool IsAlive { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int oldX { get; set; }
        public int oldY { get; set; }
        public int MoveCounter { get; set; } = 0;
        public Figure(string icon, string name, bool isWhite, int x, int y)
        {
            Icon = icon;
            Name = name;
            IsWhite = isWhite;
            if (x > 7 || x < -1)
            {
                X = -1;
            }
            else
            {
                X = x;
                oldX = x;
            }
            if (y > 7 || y < -1)
            {
                Y = -1;
            }
            else
            {
                Y = y;
                oldY = y;
            }
            IsAlive = true;
        }
        public Figure()
        {

        }
        public abstract bool Move(int oldX, int oldY, int newX, int newY);
    }
}
