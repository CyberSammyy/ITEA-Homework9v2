using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ITEA_Homework9v2
{
    class Pawn : Figure
    {
        public int CellsPerMove { get; set; }
        public Pawn(string icon, string name, bool isWhite, int x, int y)
            : base(icon, name, isWhite, x, y)
        {
            CellsPerMove = 1;
        }

        public override void Move(int oldX, int oldY, int newX, int newY)
        {
            if (newX > oldX || newY > oldY)
            {
                return;
            }
            else if (oldX - newX > CellsPerMove || oldY - newY > CellsPerMove)
            {
                if (ChessMap.MoveCount == 0)
                {
                    if (oldX + 1 < 8 && oldY - 1 >= 0 && ChessMap.cells[oldX + 1, oldY - 1].IsFigureKeeper)
                    {
                        //ChessMap.Attack();
                        ChessMap.ChangePos(oldX, oldY, newX, newY);
                    }
                    else if (oldY != newY)
                        return;
                    if (ChessMap.IsPositionAvailable(newX, newY))
                    {
                        ChessMap.ChangePos(oldX, oldY, newX, newY);
                    }
                }
                else return;
            }
            else
            {
                if (oldX + 1 < 8 && oldY - 1 >= 0 && ChessMap.cells[oldX + 1, oldY - 1].IsFigureKeeper)
                {
                    //ChessMap.Attack();
                    ChessMap.ChangePos(oldX, oldY, newX, newY);
                }
                else if (oldY != newY)
                    return;
                if (ChessMap.IsPositionAvailable(newX, newY))
                {
                    ChessMap.ChangePos(oldX, oldY, newX, newY);
                }
            }
        }
    }
}
