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
            for(int i = 0; i < cells.GetLength(0); i++)
            {
                for(int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            }
            SetFigures();
        }
        public static void Move(int oldX, int oldY, int newX, int newY)
        {
            if (cells[oldX - 1, oldY - 1].figure != null && oldX < 9 && oldX > 0 && oldY < 9 && oldY > 0 && newX < 9 && newX > 0 && newX < 9 && newX > 0)
            {
                if (cells[oldX - 1, oldY - 1].figure == null)
                {
                    Render();
                    return;
                }
                cells[oldX - 1, oldY - 1].figure.Move(oldX - 1, oldY - 1, newX - 1, newY - 1);
                Render();
                MoveCount++;
            }
            else
                return;
        }
        private static void SetFigures()
        {
            for (int i = 0; i < 8; i++)
            {
                figures[6,i] = new Pawn("♟", "Pawn_white", true, 6, i);
                figures[1,i] = new Pawn("♙ ", "Pawn_black", false, 1, i);
            }
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
        public static bool IsPositionAvailable(int x, int y)
        {
            if (cells[x,y].figure == null)
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
