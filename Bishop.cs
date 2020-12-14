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

        //public override void Attack(int newX, int newY)
        //{
        //    if()
        //}
    }
}
