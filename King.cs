using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace ITEA_Homework9v2
{
    class King : Figure, IShort, IUnJumpable
    {
        public int CellsPerMove { get; set; }
        public King(string icon, string name, bool isWhite, int x, int y)
            : base(icon, name, isWhite, x, y)
        {
            CellsPerMove = 1;
        }
        public bool Check(int oldX, int oldY, int newX, int newY)
        {
            if ((Abs(oldX - newX) == 1 && oldY == newY) || (Abs(oldY - newY) == 1 && oldX == newX) || (Abs(oldX - newX) == 1 && Abs(oldY - newY) == 1))
            {
                if (ChessMap.IsPositionAvailable(newX, newY, this))
                {
                    return true;
                }
                else return false;
            }
            else if(IsWhite && MoveCounter == 0 && ChessMap.cells[7,7].figure is Rook && ChessMap.cells[7, 7].figure.IsWhite && ChessMap.cells[7, 6].figure == null && ChessMap.cells[7, 5].figure == null)
            {
                ChessMap.ChangePos(oldX, oldY, 7, 6);
                ChessMap.cells[7, 5].figure = ChessMap.cells[7, 7].figure;
                ChessMap.cells[7, 5].IsFigureKeeper = true;
                ChessMap.cells[7, 5].Icon = ChessMap.cells[7, 5].figure.Icon;
                ChessMap.cells[7, 5].CanMove = false;
                ChessMap.cells[7, 7].Reset();
                ChessMap.Render();
                Program.count++;
                return false;
            }
            else if (!IsWhite && MoveCounter == 0 && ChessMap.cells[0, 7].figure is Rook && !ChessMap.cells[0, 7].figure.IsWhite && ChessMap.cells[0, 6].figure == null && ChessMap.cells[0, 5].figure == null)
            {
                ChessMap.ChangePos(oldX, oldY, 0, 6);
                ChessMap.cells[0, 5].figure = ChessMap.cells[0, 7].figure;
                ChessMap.cells[0, 5].IsFigureKeeper = true;
                ChessMap.cells[0, 5].Icon = ChessMap.cells[0, 5].figure.Icon;
                ChessMap.cells[0, 5].CanMove = false;
                ChessMap.cells[0, 7].Reset();
                ChessMap.Render();
                Program.count++;
                return false;
            }
            else return false;
        }

        public override bool Move(int oldX, int oldY, int newX, int newY)
        {
            if (IsAlive)
            {
                if (Check(oldX, oldY, newX, newY))
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
