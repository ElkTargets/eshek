using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    [Serializable]
    public class Bishop : Piece {
    
        public Bishop(Color color) : base(color) { }

        public override List<Vector2Int> PossibleMovement(Piece[,] matrix)
        {
            List<Vector2Int> possibleMovements = new List<Vector2Int>();

            //Diagonal Haut Droite
            for (int i = 1; i <= 8; i++)
            {
                Vector2Int topRightMove = new Vector2Int(coordinate.x + i, coordinate.y + i);
                if (topRightMove.x is >= 0 and <= 7 && topRightMove.y is >= 0 and <= 7)
                {
                    if (matrix[topRightMove.x, topRightMove.y] != null) break;
                    if (matrix[topRightMove.x, topRightMove.y] == null)
                    {
                        possibleMovements.Add(topRightMove);
                    }
                }
            }
            //Manger
            for (int i = 1; i <= 7; i++)
            {
                Vector2Int eatingTopRightMove = new Vector2Int(coordinate.x + i, coordinate.y + i);
                if (eatingTopRightMove.x is >= 0 and <= 7 && eatingTopRightMove.y is >= 0 and <= 7)
                {
                    if (matrix[eatingTopRightMove.x, eatingTopRightMove.y] != null)
                    {
                        if (matrix[eatingTopRightMove.x, eatingTopRightMove.y].Color == Color) break;
                        if (matrix[eatingTopRightMove.x, eatingTopRightMove.y].Color != Color)
                        {
                            possibleMovements.Add(eatingTopRightMove);
                            break;
                        }
                    }
                }
            }
            
            //Diagonal Bas Droite
            for (int i = 1; i <= 8; i++)
            {
                Vector2Int downRightMove = new Vector2Int(coordinate.x + i, coordinate.y - i);
                if (downRightMove.x is >= 0 and <= 7 && downRightMove.y is >= 0 and <= 7)
                {
                    if (matrix[downRightMove.x, downRightMove.y] != null) break;
                    if (matrix[downRightMove.x, downRightMove.y] == null)
                    {
                        possibleMovements.Add(downRightMove);
                    }
                }
            }
            //Manger
            for (int i = 1; i <= 7; i++)
            {
                Vector2Int eatingDownRightMove = new Vector2Int(coordinate.x + i, coordinate.y - i);
                if (eatingDownRightMove.x is >= 0 and <= 7 && eatingDownRightMove.y is >= 0 and <= 7)
                {
                    if (matrix[eatingDownRightMove.x, eatingDownRightMove.y] != null)
                    {
                        if (matrix[eatingDownRightMove.x, eatingDownRightMove.y].Color == Color) break;
                        if (matrix[eatingDownRightMove.x, eatingDownRightMove.y].Color != Color)
                        {
                            possibleMovements.Add(eatingDownRightMove);
                            break;
                        }
                    }
                }
            }
            
            //Diagonal Haut Gauche
            for (int i = 1; i <= 8; i++)
            {
                Vector2Int topLeftMove = new Vector2Int(coordinate.x - i, coordinate.y + i);
                if (topLeftMove.x is >= 0 and <= 7 && topLeftMove.y is >= 0 and <= 7)
                {
                    if (matrix[topLeftMove.x, topLeftMove.y] != null) break;
                    if (matrix[topLeftMove.x, topLeftMove.y] == null)
                    {
                        possibleMovements.Add(topLeftMove);
                    }
                }
            }
            //Manger
            for (int i = 1; i <= 7; i++)
            {
                Vector2Int eatingTopLeftMove = new Vector2Int(coordinate.x - i, coordinate.y + i);
                if (eatingTopLeftMove.x is >= 0 and <= 7 && eatingTopLeftMove.y is >= 0 and <= 7)
                {
                    if (matrix[eatingTopLeftMove.x, eatingTopLeftMove.y] != null)
                    {
                        if (matrix[eatingTopLeftMove.x, eatingTopLeftMove.y].Color == Color) break;
                        if (matrix[eatingTopLeftMove.x, eatingTopLeftMove.y].Color != Color)
                        {
                            possibleMovements.Add(eatingTopLeftMove);
                            break;
                        }
                    }
                }
            }
            
            //Diagonal Bas Gauche
            for (int i = 1; i <= 8; i++)
            {
                Vector2Int downLeftMove = new Vector2Int(coordinate.x - i, coordinate.y - i);
                if (downLeftMove.x is >= 0 and <= 7 && downLeftMove.y is >= 0 and <= 7)
                {
                    if (matrix[downLeftMove.x, downLeftMove.y] != null) break;
                    if (matrix[downLeftMove.x, downLeftMove.y] == null)
                    {
                        possibleMovements.Add(downLeftMove);
                    }
                }
            }
            //Manger
            for (int i = 1; i <= 7; i++)
            {
                Vector2Int eatingDownLeftMove = new Vector2Int(coordinate.x - i, coordinate.y - i);
                if (eatingDownLeftMove.x is >= 0 and <= 7 && eatingDownLeftMove.y is >= 0 and <= 7)
                {
                    if (matrix[eatingDownLeftMove.x, eatingDownLeftMove.y] != null)
                    {
                        if (matrix[eatingDownLeftMove.x, eatingDownLeftMove.y].Color == Color) break;
                        if (matrix[eatingDownLeftMove.x, eatingDownLeftMove.y].Color != Color)
                        {
                            possibleMovements.Add(eatingDownLeftMove);
                            break;
                        }
                    }
                }
            }
            
            return possibleMovements;
        }
    }
}
