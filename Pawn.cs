using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

namespace ITEA_Homework9v2
{
    class Pawn : Figure, IShort, IUnJumpable
    {
        public int CellsPerMove { get; set; }
        public Pawn(string icon, string name, bool isWhite, int x, int y)
            : base(icon, name, isWhite, x, y)
        {
            CellsPerMove = 1;
        }

        public override bool Move(int oldX, int oldY, int newX, int newY)
        {
            if (IsAlive)
            {
                if (IsWhite && newX == 0)
                {
                    IsAlive = false;
                    IsDrawable = false;
                    Console.Clear();
                    Console.WriteLine("Choose new figure (Rook, Knight, Queen or Bishop.");
                    while (true)
                    {
                        string s = Console.ReadLine();
                        if (s == "Rook")
                        {
                            ChessMap.TurningCount++;
                            ChessMap.cells[newX, newY].figure = new Rook("♜ ", $"Rook_white3{ChessMap.TurningCount + 2}", true, newX, newY);
                            ChessMap.cells[newX, newY].Icon = ChessMap.cells[newX, newY].figure.Icon;
                            return true;
                        }
                        else if (s == "Queen")
                        {
                            ChessMap.TurningCount++;
                            ChessMap.cells[newX, newY].figure = new Queen("♛ ", $"Queen_white{ChessMap.TurningCount + 2}", true, newX, newY);
                            ChessMap.cells[newX, newY].Icon = ChessMap.cells[newX, newY].figure.Icon;
                            return true;
                        }
                        else if (s == "Knight")
                        {
                            ChessMap.TurningCount++;
                            ChessMap.cells[newX, newY].figure = new Knight("♞ ", $"Knight_white{ChessMap.TurningCount + 2}", true, newX, newY);
                            ChessMap.cells[newX, newY].Icon = ChessMap.cells[newX, newY].figure.Icon;
                            return true;
                        }
                        else if (s == "Bishop")
                        {
                            ChessMap.TurningCount++;
                            ChessMap.cells[newX, newY].figure = new Bishop("♝ ", $"Bishop_white{ChessMap.TurningCount + 2}", true, newX, newY);
                            ChessMap.cells[newX, newY].Icon = ChessMap.cells[newX, newY].figure.Icon;
                            return true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Try Again");
                        }
                    }
                }
                else if (!IsWhite && newX == 7)
                {
                    IsAlive = false;
                    IsDrawable = false;
                    Console.Clear();
                    Console.WriteLine("Choose new figure (Rook, Knight, Queen or Bishop.");
                    while (true)
                    {
                        string s = Console.ReadLine();
                        if (s == "Rook")
                        {
                            ChessMap.TurningCount++;
                            ChessMap.cells[newX, newY].figure = new Rook("♖ ", $"Rook_black{ChessMap.TurningCount + 2}", false, newX, newY);
                            ChessMap.cells[newX, newY].Icon = ChessMap.cells[newX, newY].figure.Icon;
                            return true;
                        }
                        else if (s == "Queen")
                        {
                            ChessMap.TurningCount++;
                            ChessMap.cells[newX, newY].figure = new Queen("♕ ", $"Queen_black{ChessMap.TurningCount + 2}", false, newX, newY);
                            ChessMap.cells[newX, newY].Icon = ChessMap.cells[newX, newY].figure.Icon;
                            return true;
                        }
                        else if (s == "Knight")
                        {
                            ChessMap.TurningCount++;
                            ChessMap.cells[newX, newY].figure = new Knight("♘ ", $"Knight_black{ChessMap.TurningCount + 2}", false, newX, newY);
                            ChessMap.cells[newX, newY].Icon = ChessMap.cells[newX, newY].figure.Icon;
                            return true;
                        }
                        else if (s == "Bishop")
                        {
                            ChessMap.TurningCount++;
                            ChessMap.cells[newX, newY].figure = new Bishop("♗ ", $"Bishop_black{ChessMap.TurningCount + 2}", false, newX, newY);
                            ChessMap.cells[newX, newY].Icon = ChessMap.cells[newX, newY].figure.Icon;
                            return true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Try Again");
                        }
                    }
                }
                if (newX > oldX && IsWhite || newX < oldX && !IsWhite)
                {
                    return false;
                }
                else if (Abs(oldX - newX) > MoveCounter || Abs(oldY - newY) > MoveCounter)
                {
                    if(Attack(oldX, oldY, newX, newY, this))
                    {
                        MoveCounter++;
                        return true;
                    }
                    if (MoveCounter == 0)
                    {
                        if (oldX + 1 < 8 && oldY - 1 >= 0 && ChessMap.cells[oldX + 1, oldY - 1].IsFigureKeeper)
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
                    if (Attack(oldX, oldY, newX, newY, this))
                    {
                        MoveCounter++;
                        return true;
                    }
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
            else
            {
                ChessMap.cells[X, Y].Reset();
                IsDrawable = false;
                return false;
            }
        }

        public bool Check(int oldX, int oldY, int newX, int newY)
        {
            if (oldX - newX == 1)
            {
                if (oldY - newY == -1)
                {
                    return true;
                }
                else if (oldY - newY == 1) 
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public override bool Attack(int oldX, int oldY, int newX, int newY, Figure figure)
        {
            if (Check(oldX, oldY, newX, newY) && IsWhite && !ChessMap.IsPositionAvailable(newX, newY, this) && !ChessMap.cells[newX, newY].figure.IsWhite)
            {
                ChessMap.cells[newX, newY].figure.IsAlive = false;
                ChessMap.cells[newX, newY].figure.IsDrawable = false;
                ChessMap.cells[newX, newY].IsFigureKeeper = false;
                ChessMap.cells[newX, newY].CanMove = true;
                ChessMap.ChangePos(oldX, oldY, newX, newY);
                return true;
            }
            else if (Check(oldX, oldY, newX, newY) && !IsWhite && !ChessMap.IsPositionAvailable(newX, newY, this) && ChessMap.cells[newX, newY].figure.IsWhite)
            {
                ChessMap.cells[newX, newY].figure.IsAlive = false;
                ChessMap.cells[newX, newY].figure.IsDrawable = false;
                ChessMap.cells[newX, newY].IsFigureKeeper = false;
                ChessMap.cells[newX, newY].CanMove = true;
                ChessMap.ChangePos(oldX, oldY, newX, newY);
                return true;
            }
            else return false;
        }
    }
}
