using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    [Serializable]
    public class King : Piece {
        
        public override int Score => 10000;
        
        public King(Color color) : base(color) { }
        
        public override List<Vector2Int> PossibleMovement(Piece[,] matrix) {
            List<Vector2Int> possibleMovements = new List<Vector2Int>();

            //Haut
            Vector2Int topMove = new Vector2Int(coordinate.x, coordinate.y + 1);
            if (topMove.x is >= 0 and <= 7 && topMove.y is >= 0 and <= 7)
            {
                if (matrix[topMove.x, topMove.y] == null)
                {
                    possibleMovements.Add(topMove);
                }
            }
            //Haut Manger
            Vector2Int eatingTopMove = new Vector2Int(coordinate.x, coordinate.y + 1);
            if (eatingTopMove.x is >= 0 and <= 7 && eatingTopMove.y is >= 0 and <= 7)
            {
                if (matrix[eatingTopMove.x, eatingTopMove.y] != null)
                {
                    if (matrix[eatingTopMove.x, eatingTopMove.y].Color != Color)
                    {
                        possibleMovements.Add(eatingTopMove);
                    }
                }
            }
            
            //Bas
            Vector2Int downMove = new Vector2Int(coordinate.x, coordinate.y - 1);
            if (downMove.x is >= 0 and <= 7 && downMove.y is >= 0 and <= 7)
            {
                if (matrix[downMove.x, downMove.y] == null)
                {
                    possibleMovements.Add(downMove);
                }
            }
            //Bas Manger
            Vector2Int eatingDownMove = new Vector2Int(coordinate.x, coordinate.y - 1);
            if (eatingDownMove.x is >= 0 and <= 7 && eatingDownMove.y is >= 0 and <= 7)
            {
                if (matrix[eatingDownMove.x, eatingDownMove.y] != null)
                {
                    if (matrix[eatingDownMove.x, eatingDownMove.y].Color != Color)
                    {
                        possibleMovements.Add(eatingDownMove);
                    }
                }
            }

            //Droite
            Vector2Int rightMove = new Vector2Int(coordinate.x + 1, coordinate.y);
            if (rightMove.x is >= 0 and <= 7 && rightMove.y is >= 0 and <= 7)
            {
                
                if (matrix[rightMove.x, rightMove.y] == null)
                {
                    possibleMovements.Add(rightMove);
                }
            }
            //Droite Manger
            Vector2Int eatingRightMove = new Vector2Int(coordinate.x + 1, coordinate.y);
            if (eatingRightMove.x is >= 0 and <= 7 && eatingRightMove.y is >= 0 and <= 7)
            {
                if (matrix[eatingRightMove.x, eatingRightMove.y] != null)
                {
                    if (matrix[eatingRightMove.x, eatingRightMove.y].Color != Color)
                    {
                        possibleMovements.Add(eatingRightMove);
                    }
                }
            }
            
            //Gauche
            Vector2Int leftMove = new Vector2Int(coordinate.x - 1, coordinate.y);
            if (leftMove.x is >= 0 and <= 7 && leftMove.y is >= 0 and <= 7)
            {
                if (matrix[leftMove.x, leftMove.y] == null)
                {
                    possibleMovements.Add(leftMove);
                }
            }
            //Gauche Manger
            Vector2Int eatingLeftMove = new Vector2Int(coordinate.x - 1, coordinate.y);
            if (eatingLeftMove.x is >= 0 and <= 7 && eatingLeftMove.y is >= 0 and <= 7)
            {
                if (matrix[eatingLeftMove.x, eatingLeftMove.y] != null)
                {
                    if (matrix[eatingLeftMove.x, eatingLeftMove.y].Color != Color)
                    {
                        possibleMovements.Add(eatingLeftMove);
                    }
                }
            }
            
            //Diagonal Haut Droite
            Vector2Int topRightMove = new Vector2Int(coordinate.x + 1, coordinate.y + 1);
            if (topRightMove.x is >= 0 and <= 7 && topRightMove.y is >= 0 and <= 7)
            {
                if (matrix[topRightMove.x, topRightMove.y] == null)
                {
                    possibleMovements.Add(topRightMove);
                }
            }
            //Manger
            Vector2Int eatingTopRightMove = new Vector2Int(coordinate.x + 1, coordinate.y + 1);
            if (eatingTopRightMove.x is >= 0 and <= 7 && eatingTopRightMove.y is >= 0 and <= 7)
            {
                if (matrix[eatingTopRightMove.x, eatingTopRightMove.y] != null)
                {
                    if (matrix[eatingTopRightMove.x, eatingTopRightMove.y].Color != Color)
                    {
                        possibleMovements.Add(eatingTopRightMove);
                    }
                }
            }
            
            //Diagonal Bas Droite
            Vector2Int downRightMove = new Vector2Int(coordinate.x + 1, coordinate.y - 1);
            if (downRightMove.x is >= 0 and <= 7 && downRightMove.y is >= 0 and <= 7)
            {
                if (matrix[downRightMove.x, downRightMove.y] == null)
                {
                    possibleMovements.Add(downRightMove);
                }
            }
            //Manger
            Vector2Int eatingDownRightMove = new Vector2Int(coordinate.x + 1, coordinate.y - 1);
            if (eatingDownRightMove.x is >= 0 and <= 7 && eatingDownRightMove.y is >= 0 and <= 7)
            {
                if (matrix[eatingDownRightMove.x, eatingDownRightMove.y] != null)
                {
                    if (matrix[eatingDownRightMove.x, eatingDownRightMove.y].Color != Color)
                    {
                        possibleMovements.Add(eatingDownRightMove);
                    }
                }
            }
            
            //Diagonal Haut Gauche
            Vector2Int topLeftMove = new Vector2Int(coordinate.x - 1, coordinate.y + 1);
            if (topLeftMove.x is >= 0 and <= 7 && topLeftMove.y is >= 0 and <= 7)
            {
                if (matrix[topLeftMove.x, topLeftMove.y] == null)
                {
                    possibleMovements.Add(topLeftMove);
                }
            }
            //Manger
            Vector2Int eatingTopLeftMove = new Vector2Int(coordinate.x - 1, coordinate.y + 1);
            if (eatingTopLeftMove.x is >= 0 and <= 7 && eatingTopLeftMove.y is >= 0 and <= 7)
            {
                if (matrix[eatingTopLeftMove.x, eatingTopLeftMove.y] != null)
                {
                    if (matrix[eatingTopLeftMove.x, eatingTopLeftMove.y].Color != Color)
                    {
                        possibleMovements.Add(eatingTopLeftMove);
                        
                    }
                }
            }
            
            //Diagonal Bas Gauche
            Vector2Int downLeftMove = new Vector2Int(coordinate.x - 1, coordinate.y - 1);
            if (downLeftMove.x is >= 0 and <= 7 && downLeftMove.y is >= 0 and <= 7)
            {
                if (matrix[downLeftMove.x, downLeftMove.y] == null)
                {
                    possibleMovements.Add(downLeftMove);
                }
            }
            //Manger
            Vector2Int eatingDownLeftMove = new Vector2Int(coordinate.x - 1, coordinate.y - 1);
            if (eatingDownLeftMove.x is >= 0 and <= 7 && eatingDownLeftMove.y is >= 0 and <= 7)
            {
                if (matrix[eatingDownLeftMove.x, eatingDownLeftMove.y] != null)
                {
                    if (matrix[eatingDownLeftMove.x, eatingDownLeftMove.y].Color != Color)
                    {
                        possibleMovements.Add(eatingDownLeftMove);
                    }
                }
            }

            return possibleMovements;
        }
    }
}
