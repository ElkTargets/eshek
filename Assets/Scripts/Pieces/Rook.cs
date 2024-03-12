using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    public class Rook : Piece {
        
        public override int Score => 5;
        
        public Rook(Color color) : base(color) { }
        
        public override List<Vector2Int> PossibleMovement(Piece[,] matrix) {
            List<Vector2Int> possibleMovements = new List<Vector2Int>();

            //Haut
            for (int i = 1; i <= 7; i++) {
                Vector2Int topMove = new Vector2Int(coordinate.x, coordinate.y + i);
                if (topMove.x is >= 0 and <= 7 && topMove.y is >= 0 and <= 7) {
                    if (matrix[topMove.x, topMove.y] != null) break;
                    if (matrix[topMove.x, topMove.y] == null) {
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
            for (int i = 1; i <= 7; i++) {
                Vector2Int rightMove = new Vector2Int(coordinate.x + i, coordinate.y);
                if (rightMove.x is >= 0 and <= 7 && rightMove.y is >= 0 and <= 7) {
                    if (matrix[rightMove.x, rightMove.y] != null) break;
                    if (matrix[rightMove.x, rightMove.y] == null) {
                        possibleMovements.Add(rightMove);
                    }
                }
            }
            //Droite Manger
            for (int i = 1; i <= 7; i++) {
                Vector2Int eatingRightMove = new Vector2Int(coordinate.x + i, coordinate.y);
                if (eatingRightMove.x is >= 0 and <= 7 && eatingRightMove.y is >= 0 and <= 7) {
                    if (matrix[eatingRightMove.x, eatingRightMove.y] != null) {
                        if (matrix[eatingRightMove.x, eatingRightMove.y].Color == Color) break;
                        if (matrix[eatingRightMove.x, eatingRightMove.y].Color != Color) {
                            possibleMovements.Add(eatingRightMove);
                            break;
                        }
                    }
                }
            }
            
            //Gauche
            for (int i = 1; i <= 7; i++) {
                Vector2Int leftMove = new Vector2Int(coordinate.x - i, coordinate.y);
                if (leftMove.x is >= 0 and <= 7 && leftMove.y is >= 0 and <= 7) {
                    if (matrix[leftMove.x, leftMove.y] != null) break;
                    if (matrix[leftMove.x, leftMove.y] == null) {
                        possibleMovements.Add(leftMove);
                    }
                }
            }
            //Gauche Manger
            for (int i = 1; i <= 7; i++) {
                Vector2Int eatingLeftMove = new Vector2Int(coordinate.x - i, coordinate.y);
                if (eatingLeftMove.x is >= 0 and <= 7 && eatingLeftMove.y is >= 0 and <= 7) {
                    if (matrix[eatingLeftMove.x, eatingLeftMove.y] != null) {
                        if (matrix[eatingLeftMove.x, eatingLeftMove.y].Color == Color) break;
                        if (matrix[eatingLeftMove.x, eatingLeftMove.y].Color != Color) {
                            possibleMovements.Add(eatingLeftMove);
                            break;
                        }
                    }
                }
            }
            
            
            return possibleMovements;
        }
    }
}
