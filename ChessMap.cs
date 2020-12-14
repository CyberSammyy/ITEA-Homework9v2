using System;
using System.Collections.Generic;
using System.Text;

namespace ITEA_Homework9v2
{

    static class ChessMap
    {
        public static Cell[,] cells = new Cell[8, 8];
        public static Figure[,] figures = new Figure[8, 8];
        public static int MoveCount { get; set; } = 0;
        public static void GenerateMap()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    cells[i, j] = new Cell(i, j);
                    if ((i + j) % 2 != 0)
                    {
                        cells[i, j].Icon = "⬜";
                        cells[i, j].IsWhite = false;
                    }
                    else
                    {
                        cells[i, j].Icon = "⬛";
                        cells[i, j].IsWhite = true;
                    }
                }
            }
            Render();
            SetFigures();
        }
        public static bool MoveWhite(int oldX, int oldY, int newX, int newY)
        {
            if (cells[oldX - 1, oldY - 1].figure != null && cells[oldX - 1, oldY - 1].figure.IsWhite && oldX < 9 && oldX > 0 && oldY < 9 && oldY > 0 && newX < 9 && newX > 0 && newX < 9 && newX > 0)
            {
                if (cells[oldX - 1, oldY - 1].figure == null)
                {
                    Render();
                    return false;
                }
                if (cells[oldX - 1, oldY - 1].figure.Move(oldX - 1, oldY - 1, newX - 1, newY - 1))
                {
                    Render();
                    return true;
                }
                else
                {
                    Render();
                    return false;
                }
            }
            else
            {
                Render();
                return false;
            }
        }
        public static bool MoveBlack(int oldX, int oldY, int newX, int newY)
        {
            if (cells[oldX - 1, oldY - 1].figure != null && !cells[oldX - 1, oldY - 1].figure.IsWhite && oldX < 9 && oldX > 0 && oldY < 9 && oldY > 0 && newX < 9 && newX > 0 && newY < 9 && newY > 0)
            {
                if (cells[oldX - 1, oldY - 1].figure == null)
                {
                    Render();
                    return false;
                }
                if (cells[oldX - 1, oldY - 1].figure.Move(oldX - 1, oldY - 1, newX - 1, newY - 1))
                {
                    Render();
                    return true;
                }
                else
                {
                    Render();
                    return false;
                }
            }
            else
            {
                Render();
                return false;
            }
        }
        private static void SetFigures()
        {
            for (int i = 0; i < 8; i++)
            {
                figures[6,i] = new Pawn("♟", $"Pawn_white{i + 1}", true, 6, i);
                figures[1,i] = new Pawn("♙ ", $"Pawn_black{i + 1}", false, 1, i);
            }
            figures[7, 2] = new Bishop("♝ ", "Bishop_white1", true, 7, 2);
            figures[7, 5] = new Bishop("♝ ", "Bishop_white2", true, 7, 2);
            figures[0, 5] = new Bishop("♗ ", "Bishop_black1", false, 0, 2);
            figures[0, 2] = new Bishop("♗ ", "Bishop_black2", false, 0, 2);
            figures[0, 0] = new Rook("♖ ", "Rook_black1", false, 0, 0);
            figures[0, 7] = new Rook("♖ ", "Rook_black2", false, 0, 7);
            figures[7, 0] = new Rook("♜ ", "Rook_white1", true, 7, 0);
            figures[7, 7] = new Rook("♜ ", "Rook_white2", true, 7, 7);
            figures[7, 4] = new King("♚ ", "King_white", true, 7, 4);
            figures[0, 4] = new King("♔ ", "King_black", false, 7, 4);
            figures[7, 3] = new Queen("♛ ", "Queen_white", true, 7, 3);
            figures[0, 3] = new Queen("♕ ", "Queen_black", false, 0, 3);
            figures[7, 1] = new Knight("♞ ", "Knight_white1", true, 7, 1);
            figures[7, 6] = new Knight("♞ ", "Knight_white2", true, 7, 6);
            figures[0, 1] = new Knight("♘ ", "Knight_black1", false, 0, 1);
            figures[0, 6] = new Knight("♘ ", "Knight_black2", false, 0, 6);
            //
            //
            //
            //
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells[i, j].figure = figures[i, j];
                    if (cells[i, j].figure != null)
                    {
                        cells[i, j].Icon = figures[i, j].Icon;
                        cells[i, j].CanMove = false;
                        cells[i, j].IsFigureKeeper = true;
                    }
                }
            }
            Render();
        }
        public static bool IsPositionAvailable(int x, int y, Figure figure)
        {
            if (cells[x, y].figure == null || cells[x, y].figure.Name == figure.Name)
            {
                return true;
            }
            else return false;
        }
        public static void ChangePos(int oldX, int oldY, int newX, int newY)
        {
            cells[oldX, oldY].figure.X = newX;
            cells[oldX, oldY].figure.Y = newY;
            var fig = cells[oldX, oldY].figure;
            cells[oldX, oldY].Reset();
            cells[newX, newY].figure = fig;
            cells[newX, newY].Icon = cells[newX, newY].figure.Icon;
            cells[newX, newY].CanMove = cells[newX, newY].IsFigureKeeper = true;
        }
        public static void Render()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.Clear();
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("   " + new string('-', 8 * 3 - 1));
                Console.Write($"{i + 1}:");
                for (int k = 0; k < 8; k++)
                {
                    Console.Write($"|{cells[i, k].Icon}");
                }
                Console.WriteLine('|');
            }
            Console.WriteLine("   " + new string('-', 8 * 3 - 1));
            Console.WriteLine("   1  2  3  4  5  6  7  8");
        }
    }
}
