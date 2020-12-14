using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace ITEA_Homework9v2
{
    class Queen : Figure, IUnJumpable
    {
        public Queen(string icon, string name, bool isWhite, int x, int y)
            : base(icon, name, isWhite, x, y)
        {

        }

        public override bool Attack(int oldX, int oldY, int newX, int newY, Figure figure)
        {
            if (IsWhite && !ChessMap.IsPositionAvailable(newX, newY, this) && ChessMap.cells[newX, newY].figure != null && !ChessMap.cells[newX, newY].figure.IsWhite)
            {
                if (Check(oldX, oldY, newX, newY))
                {
                    return true;
                }
                else return false;
            }
            else if (!IsWhite && !ChessMap.IsPositionAvailable(newX, newY, this) && ChessMap.cells[newX, newY].figure != null && ChessMap.cells[newX, newY].figure.IsWhite)
            {
                if (Check(oldX, oldY, newX, newY))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public bool Check(int oldX, int oldY, int newX, int newY)
        {
            int count = 0;
            int i = oldX;
            int j = oldY;
            if (Abs(oldX - newX) != 0 && oldY == newY)
            {
                if (oldX > newX)
                {
                    int i1 = oldX;
                    while (i1 > newX)
                    {
                        if (!ChessMap.IsPositionAvailable(i1, newY, this))
                        {
                            return false;
                        }
                        else
                        {
                            i1--;
                            count++;
                        }
                    }
                }
                else if (oldX < newX)
                {
                    int i1 = oldX;
                    while (i1 < newX)
                    {
                        if (!ChessMap.IsPositionAvailable(i1, newY, this))
                        {
                            return false;
                        }
                        else
                        {
                            i1++;
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
                    int i1 = oldY;
                    while (i1 > newY)
                    {
                        if (!ChessMap.IsPositionAvailable(newX, i1, this))
                        {
                            return false;
                        }
                        else
                        {
                            i1--;
                            count++;
                        }
                    }
                }
                if (oldY < newY)
                {
                    int i1 = oldY;
                    while (i1 < newY)
                    {
                        if (!ChessMap.IsPositionAvailable(newX, i1, this))
                        {
                            return false;
                        }
                        else
                        {
                            i1++;
                            count++;
                        }
                    }
                }
            }
            else if (oldX > newX && oldY > newY)
            {
                while (i > newX && j > newY)
                {
                    if (!ChessMap.IsPositionAvailable(i, j, this))
                    {
                        return false;
                    }
                    else
                    {
                        i--;
                        j--;
                        count++;
                    }
                }
            }
            else if (oldX > newX && oldY < newY)
            {
                while (i > newX && j < newY)
                {
                    if (!ChessMap.IsPositionAvailable(i, j, this))
                    {
                        return false;
                    }
                    else
                    {
                        i--;
                        j++;
                        count++;
                    }
                }
            }
            else if (oldX < newX && oldY > newY)
            {
                while (i < newX && j > newY)
                {
                    if (!ChessMap.IsPositionAvailable(i, j, this))
                    {
                        return false;
                    }
                    else
                    {
                        i++;
                        j--;
                        count++;
                    }
                }
            }
            else if (oldX < newX && oldY < newY)
            {
                while (i < newX && j < newY)
                {
                    if (!ChessMap.IsPositionAvailable(i, j, this))
                    {
                        return false;
                    }
                    else
                    {
                        i++;
                        j++;
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
        
        public override bool Move(int oldX, int oldY, int newX, int newY)
        {
            if (IsAlive)
            {
                if (Attack(oldX, oldY, newX, newY, this))
                {
                    ChessMap.ChangePos(oldX, oldY, newX, newY);
                    MoveCounter++;
                    return true;
                }
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
    }
}
