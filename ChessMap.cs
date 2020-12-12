using System;
using System.Collections.Generic;
using System.Text;

namespace ITEA_Homework9v2
{

    class ChessMap
    {
        public Cell[,] cells = new Cell[8, 8];
        public void GenerateMap()
        {
            for(int i = 0; i < cells.GetLength(0); i++)
            {
                for(int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            }
        }
        public void Render()
        {
            Console.OutputEncoding = Encoding.Unicode;
            string c = "♖♘♗♔♕♗♘♖♜♞♝♚♛♝♞♜";
            char[,] chessDesk = new char[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    if (i == 0)
                    {
                        chessDesk[i, k] = c[k];
                    }
                    else if (i == 1)
                    {
                        chessDesk[i, k] = '♙';
                    }
                    else if (i == 6)
                    {
                        chessDesk[i, k] = '♟';
                    }
                    else if (i == 7)
                    {
                        chessDesk[i, k] = c[k + 8];
                    }
                    else
                    {
                        chessDesk[i, k] = (i + k) % 2 == 1 ? '⬛' : '⬜';
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(new string('-', 8 * 3 + 1));
                for (int k = 0; k < 8; k++)
                {
                    Console.Write($"|{chessDesk[i, k].ToChessFormat()}");
                }
                Console.WriteLine('|');
            }
            Console.WriteLine(new string('-', 8 * 3 + 1));
            Console.WriteLine(c);
            Console.ReadKey();
        }
    }
}
