using System;
using System.Collections.Generic;
using System.Text;

namespace ITEA_Homework9v2
{
    public static class Extensions
    {
        const string chessFigures = "♔♕♖♗♘♙♚♛♜♝♞♟";

        public static string ToChessFormat(this char c)
        {
            string add = chessFigures.Contains(c) ? " " : string.Empty;
            return $"{c}{add}";
        }
    }
}
