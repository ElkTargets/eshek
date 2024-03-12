using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    [Serializable]
    public class Pawn : Piece {
        
        public override int Score => 1;
        
        public Pawn(Color color) : base(color) { }
        
        public override List<Vector2Int> PossibleMovement(Piece[,] matrix) {
            List<Vector2Int> possiblesMovements = new List<Vector2Int>();
            int direction = (Color == Color.white) ? 1 : -1;
            
            Vector2Int topMove = new Vector2Int(coordinate.x, coordinate.y + direction);
            Vector2Int doubleTopMove = new Vector2Int(coordinate.x, coordinate.y + direction*2);
            Vector2Int eatingTopMoveRight = new Vector2Int(coordinate.x + 1, coordinate.y + direction);
            Vector2Int eatingTopMoveLeft = new Vector2Int(coordinate.x - 1, coordinate.y + direction);

            // Top move
            if (matrix[topMove.x, topMove.y] == null) {
                possiblesMovements.Add(topMove);
            }
            
            // Double Top move
            if (Color == Color.black && coordinate.y == 6 || Color == Color.white && coordinate.y == 1) {
                if (Color == Color.black) {
                    if (matrix[topMove.x, topMove.y -1] == null) possiblesMovements.Add(doubleTopMove);
                }
                else {
                    if (matrix[topMove.x, topMove.y +1] == null) possiblesMovements.Add(doubleTopMove);
                }
            }
            
            //Manger
            if (eatingTopMoveRight.x is >= 0 and <= 7 && eatingTopMoveRight.y is >= 0 and <= 7) {
                if (matrix[eatingTopMoveRight.x, eatingTopMoveRight.y] != null) {
                    if (matrix[eatingTopMoveRight.x, eatingTopMoveRight.y].Color != Color) {
                        possiblesMovements.Add(eatingTopMoveRight);
                    }
                }
            }
            if (eatingTopMoveLeft.x is >= 0 and <= 7 && eatingTopMoveLeft.y is >= 0 and <= 7 ) {
                if (matrix[eatingTopMoveLeft.x, eatingTopMoveLeft.y] != null) {
                    if (matrix[eatingTopMoveLeft.x, eatingTopMoveLeft.y].Color != Color) { 
                        possiblesMovements.Add(eatingTopMoveLeft);
                    }
                }
            }
            
            return possiblesMovements;
        }
    }
}
