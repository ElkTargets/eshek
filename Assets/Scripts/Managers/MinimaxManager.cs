using System;
using Managers.Minimax;
using UnityEngine;
using Pieces;
using UnityEngine.Serialization;
using Utils;


namespace Managers
{
    public class MinimaxManager : MonoBehaviourSingleton<GameManager>
    {
        public int depth;
        public GameManager gameManager;
        
        void Start()
        {
            
        }

        [ContextMenu("New Node")]
        private void NewNode()
        {
            foreach (Piece piece in gameManager.BoardMatrix.Pieces) {
                foreach (Vector2Int move in piece.PossibleMovement(gameManager.BoardMatrix.Pieces))
                {
                    Piece[,] newBoard = (Piece[,]) gameManager.BoardMatrix.Clone();
                    newBoard = MoveThePiece(piece, move, newBoard);
                    Node newNode = new Node(newBoard);
                    int test = newNode.GetHeuristicValue();
                    Debug.Log(test);
                }
            }
        }

        private Piece[,] MoveThePiece(Piece piece, Vector2Int cell, Piece[,] boardMatrix)
        {
            boardMatrix[cell.x, cell.y] = boardMatrix[piece.coordinate.x, piece.coordinate.y];
            boardMatrix[piece.coordinate.x, piece.coordinate.y] = null;
            return boardMatrix;
        }
    }
}
