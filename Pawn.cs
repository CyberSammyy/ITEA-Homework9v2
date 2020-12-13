using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

namespace ITEA_Homework9v2
{
    class Pawn : Figure, IShort
    {
        public int CellsPerMove { get; set; }
        public Pawn(string icon, string name, bool isWhite, int x, int y)
            : base(icon, name, isWhite, x, y)
        {
            CellsPerMove = 1;
        }

        public override bool Move(int oldX, int oldY, int newX, int newY)
        {
            if (newX > oldX && IsWhite || newX < oldX && !IsWhite)
            {
                return false;
            }
            else if (Abs(oldX - newX) > MoveCounter || Abs(oldY - newY) > MoveCounter)
            {
                if (MoveCounter == 0)
                {
                    if (oldX + 1 < 8 && oldY - 1 >= 0 && ChessMap.cells[oldX + 1, oldY - 1].IsFigureKeeper )
                    {
                        //ChessMap.Attack();
                        if (Abs(oldX - newX) > CellsPerMove + 1)
                        {
                            return false;
                        }
                        else
                        {
                            ChessMap.ChangePos(oldX, oldY, newX, newY);
                            MoveCounter++;
                            return true;
                        }
                    }
                    else if (oldY == newY)
                    {
                        if (Abs(oldX - newX) > CellsPerMove + 1)
                        {
                            return false;
                        }
                        else
                        {
                            if (ChessMap.IsPositionAvailable(newX, newY, this))
                            {
                                ChessMap.ChangePos(oldX, oldY, newX, newY);
                                MoveCounter++;
                                return true;
                            }
                            else return false;
                        }
                    }
                }
                else return false;
            }
            else
            {
                if (oldX + 1 < 8 && oldY - 1 >= 0 && ChessMap.cells[oldX + 1, oldY - 1].IsFigureKeeper)
                {
                    //ChessMap.Attack();
                    ChessMap.ChangePos(oldX, oldY, newX, newY);
                    MoveCounter++;
                    return true;
                }
                else if (oldY != newY)
                    return false;
                if (ChessMap.IsPositionAvailable(newX, newY, this))
                {
                    ChessMap.ChangePos(oldX, oldY, newX, newY);
                    MoveCounter++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            return false;
        }
    }
}
