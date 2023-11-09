using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    [Serializable]
    public class Knight : Piece {
    
        public Knight(Color color) : base(color) { }

        public override List<Vector2Int> PossibleMovement(Piece[,] matrix)
        {
            List<Vector2Int> possibleMovements = new List<Vector2Int>();

            Vector2Int topRightMove = new Vector2Int(coordinate.x + 1, coordinate.y + 2);
            Vector2Int topLeftMove = new Vector2Int(coordinate.x - 1, coordinate.y + 2);

            Vector2Int rightTopMove = new Vector2Int(coordinate.x + 2, coordinate.y + 1);
            Vector2Int rightDownMove = new Vector2Int(coordinate.x + 2, coordinate.y - 1);
            
            Vector2Int downRightMove = new Vector2Int(coordinate.x + 1, coordinate.y - 2);
            Vector2Int downLeftMove = new Vector2Int(coordinate.x - 1, coordinate.y - 2);
            
            Vector2Int leftTopMove = new Vector2Int(coordinate.x - 2, coordinate.y + 1);
            Vector2Int leftDownMove = new Vector2Int(coordinate.x - 2, coordinate.y - 1);

            //Haut Droite
            if (topRightMove.x is >= 0 and <= 7 && topRightMove.y is >= 0 and <= 7)
            {
                if (matrix[topRightMove.x, topRightMove.y] == null)
                {
                    possibleMovements.Add(topRightMove);
                }
                if (matrix[topRightMove.x, topRightMove.y] != null && matrix[topRightMove.x, topRightMove.y].Color != Color)
                {
                    possibleMovements.Add(topRightMove);
                }
            }
            //Haut Gauche
            if (topLeftMove.x is >= 0 and <= 7 && topLeftMove.y is >= 0 and <= 7)
            {
                if (matrix[topLeftMove.x, topLeftMove.y] == null)
                {
                    possibleMovements.Add(topLeftMove);
                }
                if (matrix[topLeftMove.x, topLeftMove.y] != null && matrix[topLeftMove.x, topLeftMove.y].Color != Color)
                {
                    possibleMovements.Add(topLeftMove);
                }
            }
            
            //Droite Haut
            if (rightTopMove.x is >= 0 and <= 7 && rightTopMove.y is >= 0 and <= 7)
            {
                if (matrix[rightTopMove.x, rightTopMove.y] == null)
                {
                    possibleMovements.Add(rightTopMove);
                }
                if (matrix[rightTopMove.x, rightTopMove.y] != null && matrix[rightTopMove.x, rightTopMove.y].Color != Color)
                {
                    possibleMovements.Add(rightTopMove);
                }
            }
            //Droite Bas
            if (rightDownMove.x is >= 0 and <= 7 && rightDownMove.y is >= 0 and <= 7)
            {
                if (matrix[rightDownMove.x, rightDownMove.y] == null)
                {
                    possibleMovements.Add(rightDownMove);
                }
                if (matrix[rightDownMove.x, rightDownMove.y] != null && matrix[rightDownMove.x, rightDownMove.y].Color != Color)
                {
                    possibleMovements.Add(rightDownMove);
                }
            }
            
            //Bas Droite
            if (downRightMove.x is >= 0 and <= 7 && downRightMove.y is >= 0 and <= 7)
            {
                if (matrix[downRightMove.x, downRightMove.y] == null)
                {
                    possibleMovements.Add(downRightMove);
                }
                if (matrix[downRightMove.x, downRightMove.y] != null && matrix[downRightMove.x, downRightMove.y].Color != Color)
                {
                    possibleMovements.Add(downRightMove);
                }
            }
            //Bas Gauche
            if (downLeftMove.x is >= 0 and <= 7 && downLeftMove.y is >= 0 and <= 7)
            {
                if (matrix[downLeftMove.x, downLeftMove.y] == null)
                {
                    possibleMovements.Add(downLeftMove);
                }
                if (matrix[downLeftMove.x, downLeftMove.y] != null && matrix[downLeftMove.x, downLeftMove.y].Color != Color)
                {
                    possibleMovements.Add(downLeftMove);
                }
            }
            
            //Gauche Haut
            if (leftTopMove.x is >= 0 and <= 7 && leftTopMove.y is >= 0 and <= 7)
            {
                if (matrix[leftTopMove.x, leftTopMove.y] == null)
                {
                    possibleMovements.Add(leftTopMove);
                }
                if (matrix[leftTopMove.x, leftTopMove.y] != null && matrix[leftTopMove.x, leftTopMove.y].Color != Color)
                {
                    possibleMovements.Add(leftTopMove);
                }
            }
            //Gauche Bas
            if (leftDownMove.x is >= 0 and <= 7 && leftDownMove.y is >= 0 and <= 7)
            {
                if (matrix[leftDownMove.x, leftDownMove.y] == null)
                {
                    possibleMovements.Add(leftDownMove);
                }
                if (matrix[leftDownMove.x, leftDownMove.y] != null && matrix[leftDownMove.x, leftDownMove.y].Color != Color)
                {
                    possibleMovements.Add(leftDownMove);
                }
            }
            
            return possibleMovements;
        }
    }
}
