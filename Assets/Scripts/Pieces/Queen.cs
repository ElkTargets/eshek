using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    [Serializable]
    public class Queen : Piece {
        
        public override int Score => 9;
        
        public Queen(Color color) : base(color) { }
        
        public override List<Vector2Int> PossibleMovement(Piece[,] matrix)
        {
            List<Vector2Int> possibleMovements = new List<Vector2Int>();

            //Haut
            for (int i = 1; i <= 7; i++) {
                Vector2Int topMove = new Vector2Int(coordinate.x, coordinate.y + i);
                if (topMove.x is >= 0 and <= 7 && topMove.y is >= 0 and <= 7) {
                    if (matrix[topMove.x, topMove.y] != null) break;
                    if (matrix[topMove.x, topMove.y] == null)
                    {
                        possibleMovements.Add(topMove);
                    }
                }
            }
            //Haut Manger
            for (int i = 1; i <= 7; i++) {
                Vector2Int eatingTopMove = new Vector2Int(coordinate.x, coordinate.y + i);
                if (eatingTopMove.x is >= 0 and <= 7 && eatingTopMove.y is >= 0 and <= 7) {
                    if (matrix[eatingTopMove.x, eatingTopMove.y] != null) {
                        if (matrix[eatingTopMove.x, eatingTopMove.y].Color == Color) break;
                        if (matrix[eatingTopMove.x, eatingTopMove.y].Color != Color) {
                            possibleMovements.Add(eatingTopMove);
                            break;
                        }
                    }
                }
            }
            
            //Bas
            for (int i = 1; i <= 7; i++) {
                Vector2Int downMove = new Vector2Int(coordinate.x, coordinate.y - i);
                if (downMove.x is >= 0 and <= 7 && downMove.y is >= 0 and <= 7) {
                    if (matrix[downMove.x, downMove.y] != null) break;
                    if (matrix[downMove.x, downMove.y] == null) {
                        possibleMovements.Add(downMove);
                    }
                }
            }
            //Bas Manger
            for (int i = 1; i <= 7; i++) {
                Vector2Int eatingDownMove = new Vector2Int(coordinate.x, coordinate.y - i);
                if (eatingDownMove.x is >= 0 and <= 7 && eatingDownMove.y is >= 0 and <= 7) {
                    if (matrix[eatingDownMove.x, eatingDownMove.y] != null) {
                        if (matrix[eatingDownMove.x, eatingDownMove.y].Color == Color) break;
                        if (matrix[eatingDownMove.x, eatingDownMove.y].Color != Color) {
                            possibleMovements.Add(eatingDownMove);
                            break;
                        }
                    }
                }
            }

            //Droite
            for (int i = 1; i <= 7; i++)
            {
                Vector2Int rightMove = new Vector2Int(coordinate.x + i, coordinate.y);
                if (rightMove.x is >= 0 and <= 7 && rightMove.y is >= 0 and <= 7)
                {
                    if (matrix[rightMove.x, rightMove.y] != null) break;
                    if (matrix[rightMove.x, rightMove.y] == null)
                    {
                        possibleMovements.Add(rightMove);
                    }
                }
            }
            //Droite Manger
            for (int i = 1; i <= 7; i++)
            {
                Vector2Int eatingRightMove = new Vector2Int(coordinate.x + i, coordinate.y);
                if (eatingRightMove.x is >= 0 and <= 7 && eatingRightMove.y is >= 0 and <= 7)
                {
                    if (matrix[eatingRightMove.x, eatingRightMove.y] != null)
                    {
                        if (matrix[eatingRightMove.x, eatingRightMove.y].Color == Color) break;
                        if (matrix[eatingRightMove.x, eatingRightMove.y].Color != Color)
                        {
                            possibleMovements.Add(eatingRightMove);
                            break;
                        }
                    }
                }
            }
            
            //Gauche
            for (int i = 1; i <= 7; i++)
            {
                Vector2Int leftMove = new Vector2Int(coordinate.x - i, coordinate.y);
                if (leftMove.x is >= 0 and <= 7 && leftMove.y is >= 0 and <= 7)
                {
                    if (matrix[leftMove.x, leftMove.y] != null) break;
                    if (matrix[leftMove.x, leftMove.y] == null)
                    {
                        possibleMovements.Add(leftMove);
                    }
                }
            }
            //Gauche Manger
            for (int i = 1; i <= 7; i++)
            {
                Vector2Int eatingLeftMove = new Vector2Int(coordinate.x - i, coordinate.y);
                if (eatingLeftMove.x is >= 0 and <= 7 && eatingLeftMove.y is >= 0 and <= 7)
                {
                    if (matrix[eatingLeftMove.x, eatingLeftMove.y] != null)
                    {
                        if (matrix[eatingLeftMove.x, eatingLeftMove.y].Color == Color) break;
                        if (matrix[eatingLeftMove.x, eatingLeftMove.y].Color != Color)
                        {
                            possibleMovements.Add(eatingLeftMove);
                            break;
                        }
                    }
                }
            }
            
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
