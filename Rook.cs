using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace ITEA_Homework9v2
{
    class Rook : Figure, IUnJumpable
    {
        public bool IsOnWhite { get; set; } = false;
        public Rook(string icon, string name, bool isWhite, int x, int y)
            : base(icon, name, isWhite, x, y)
        {
            if (ChessMap.cells[x, y].IsWhite)
            {
                IsOnWhite = true;
            }
            else IsOnWhite = false;
        }
        public bool Check(int oldX, int oldY, int newX, int newY)
        {
            int count = 0;

            if (Abs(oldX - newX) != 0 && oldY == newY)
            {
                if (oldX > newX)
                {
                    int i = oldX;
                    while (i > newX)
                    {
                        if (!ChessMap.IsPositionAvailable(i, newY, this))
                        {
                            return false;
                        }
                        else
                        {
                            i--;
                            count++;
                        }
                    }
                }
                else if (oldX < newX)
                {
                    int i = oldX;
                    while (i < newX)
                    {
                        if (!ChessMap.IsPositionAvailable(i, newY, this))
                        {
                            return false;
                        }
                        else
                        {
                            i++;
                            count++;
                        }
                    }
                }
                if (count == Abs(oldX - newX))
                {
                    return true;
                }
                else return false;
            }
            else if (Abs(oldY - newY) != 0 && oldX == newX)
            {
                if (oldY > newY)
                {
                    int i = oldY;
                    while (i > newY)
                    {
                        if (!ChessMap.IsPositionAvailable(newX, i, this))
                        {
                            return false;
                        }
                        else
                        {
                            i--;
                            count++;
                        }
                    }
                }
                if (oldY < newY)
                {
                    int i = oldY;
                    while (i < newY)
                    {
                        if (!ChessMap.IsPositionAvailable(newX, i, this))
                        {
                            return false;
                        }
                        else
                        {
                            i++;
                            count++;
                        }
                    }
                }
                if (count == Abs(oldY - newY))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public override bool Move(int oldX, int oldY, int newX, int newY)
        {
            if (Check(oldX, oldY, newX, newY) && ChessMap.IsPositionAvailable(newX, newY, this))
            {
                ChessMap.ChangePos(oldX, oldY, newX, newY);
                MoveCounter++;
                return true;
            }
            else return false;
        }
    }
}
