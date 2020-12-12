using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ITEA_Homework9v2
{
    class Pawn : Figure
    {
        public int CellsPerMove { get; set; }
        public Pawn(string icon, string name, bool isWhite, bool isOnWhite, int x, int y)
            : base(icon, name, isWhite, isOnWhite, x, y)
        {
            CellsPerMove = 1;
        }

        public override void Move(char letter, int number)
        {
            LettersToNumbers let = new LettersToNumbers();
            letter = (char)let;
        }
    }
}
