using System;
using System.Collections.Generic;
using System.Text;

namespace ITEA_Homework9v2
{
    public enum LettersToNumbers
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4,
        F = 5,
        G = 6,
        H = 7
    }
    public abstract class Figure
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public bool IsWhite { get; set; }
        public bool IsOnWhite { get; set; }
        public bool IsAlive { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Figure(string icon, string name, bool isWhite, bool isOnWhite, int x, int y)
        {
            Icon = icon;
            Name = name;
            IsWhite = isWhite;
            IsOnWhite = isOnWhite;
            if (x > 7 || x < -1)
            {
                X = -1;
            }
            else X = x;
            if (y > 7 || y < -1)
            {
                Y = -1;
            }
            else Y = y;
            IsAlive = true;
        }
        public abstract void Move(char letter, int number);
    }
}
