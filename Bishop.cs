using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace ITEA_Homework9v2
{
    class Bishop : Figure, IUnJumpable
    {
        public bool IsOnWhite { get; set; } = false;
        public Bishop(string icon, string name, bool isWhite, int x, int y)
            : base(icon, name, isWhite, x, y)
        {
            if (ChessMap.cells[x, y].IsWhite)
            {
                IsOnWhite = true;
            }
            else IsOnWhite = false;
        }
        public override bool Move(int oldX, int oldY, int newX, int newY)
        {
            if (IsAlive)
            {
                if (Abs(oldX - newX) == Abs(oldY - newY))
                {
                    if (Attack(oldX, oldY, newX, newY, this))
                    {
                        ChessMap.ChangePos(oldX, oldY, newX, newY);
                        MoveCounter++;
                        return true;
                    }
                    if (Check(oldX, oldY, newX, newY))
                    {
                        if (ChessMap.IsPositionAvailable(newX, newY, this))
                        {
                            ChessMap.ChangePos(oldX, oldY, newX, newY);
                            MoveCounter++;
                            return true;
                        }
                        else return false;
                    }
                    else return false;
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
        public bool Check(int oldX, int oldY, int newX, int newY)
        {
            int counter = 0;
            int i = oldX;
            int j = oldY;
            if(oldX > newX && oldY > newY)
            {
                while(i > newX && j > newY)
                {
                    if (!ChessMap.IsPositionAvailable(i, j, this))
                    {
                        return false;
                    }
                    else
                    {
                        i--;
                        j--;
                        counter++;
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
                        counter++;
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
                        counter++;
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
                        counter++;
                    }
                }
            }
            if (counter == Abs(oldX - newX))
            {
                return true;
            }
            else return false;
        }

        public override bool Attack(int oldX, int oldY, int newX, int newY, Figure figure)
        {
            int count = 0;
            int i = oldX;
            int j = oldY;
            if (Abs(oldX - newX) == Abs(oldY - newY) && IsWhite && ChessMap.cells[newX, newY].figure != null && !ChessMap.cells[newX, newY].figure.IsWhite)
            {
                if (oldX > newX && oldY > newY)
                {
                    while (i > newX && j > newY)
                    {
                        if (ChessMap.cells[i, j].IsFigureKeeper == true && ChessMap.cells[i, j].figure != figure)
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
                        if (ChessMap.cells[i, j].IsFigureKeeper == true && ChessMap.cells[i, j].figure != figure)
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
                else if (oldX < newX && oldY < newY)
                {
                    while (i < newX && j < newY)
                    {
                        if (ChessMap.cells[i, j].IsFigureKeeper == true && ChessMap.cells[i, j].figure != figure)
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
                else if (oldX < newX && oldY > newY)
                {
                    while (i < newX && j > newY)
                    {
                        if (ChessMap.cells[i, j].IsFigureKeeper == true && ChessMap.cells[i, j].figure != figure)
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
            }
            else if (Abs(oldX - newX) == Abs(oldY - newY) && !IsWhite && ChessMap.cells[newX, newY].figure != null && ChessMap.cells[newX, newY].figure.IsWhite)
            {
                if (oldX > newX && oldY > newY)
                {
                    while (i > newX && j > newY)
                    {
                        if (ChessMap.cells[i, j].IsFigureKeeper == true && ChessMap.cells[i, j].figure != figure)
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
                        if (ChessMap.cells[i, j].IsFigureKeeper == true && ChessMap.cells[i, j].figure != figure)
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
                else if (oldX < newX && oldY < newY)
                {
                    while (i < newX && j < newY)
                    {
                        if (ChessMap.cells[i, j].IsFigureKeeper == true && ChessMap.cells[i, j].figure != figure)
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
                else if (oldX < newX && oldY > newY)
                {
                    while (i < newX && j > newY)
                    {
                        if (ChessMap.cells[i, j].IsFigureKeeper == true && ChessMap.cells[i, j].figure != figure)
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
            }
            if (count == Abs(oldX - newX))
            {
                return true;
            }
            else return false;
        }
    }
}
