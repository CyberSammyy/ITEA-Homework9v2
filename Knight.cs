using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace ITEA_Homework9v2
{
    class Knight : Figure, IShort
    {
        public int CellsPerMove { get; set; }
        public Knight(string icon, string name, bool isWhite, int x, int y)
            : base(icon, name, isWhite, x, y)
        {
            CellsPerMove = 3;
        }
        public bool Check(int oldX, int oldY, int newX, int newY)
        {
            if (Abs(oldX - newX) == 2)
            {
                if (oldY - newY == -1)
                {
                    if (ChessMap.IsPositionAvailable(newX, newY, this))
                    {
                        return true;
                    }
                    else return false;
                }
                else if (oldY - newY == 1)
                {
                    if (ChessMap.IsPositionAvailable(newX, newY, this))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (Abs(oldY - newY) == 2)
            {
                if (oldX - newX == -1)
                {
                    if (ChessMap.IsPositionAvailable(newX, newY, this))
                    {
                        return true;
                    }
                    else return false;
                }
                else if (oldX - newX == 1)
                {
                    if (ChessMap.IsPositionAvailable(newX, newY, this))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        public override bool Move(int oldX, int oldY, int newX, int newY)
        {
            if (IsAlive)
            {
                if (Check(oldX, oldY, newX, newY) && ChessMap.IsPositionAvailable(newX, newY, this))
                {
                    ChessMap.ChangePos(oldX, oldY, newX, newY);
                    MoveCounter++;
                    return true;
                }
                else return false;
            }
            else
            {
                ChessMap.cells[X, Y].Reset();
                IsDrawable = false;
                return false;
            }
        }

        public override bool Attack(int oldX, int oldY, int newX, int newY, Figure figure)
        {
            throw new NotImplementedException();
        }
    }
}
