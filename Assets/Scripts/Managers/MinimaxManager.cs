using System;
using Managers.Minimax;
using UnityEngine;
using Utils;


namespace Managers
{
    public class MinimaxManager : MonoBehaviourSingleton<MinimaxManager>
    {
        public int depth;
        public Color PlayerTurn;

        [ContextMenu("Think")]
        public void Think()
        {
            if (GameManager.Instance.WhiteTurn) { PlayerTurn = Color.white; }
            else { PlayerTurn = Color.black; }
            Node startingNode = new Node(GameManager.Instance.BoardMatrix, PlayerTurn);
            MinMax(startingNode, depth, true);
        }

        private void MinMax(Node node, int depth, bool maximizingPlayer)
        {
            
        }

        /*private Piece[,] MoveThePiece(Piece piece, Vector2Int cell, b boardMatrix)
        {
            boardMatrix[cell.x, cell.y] = boardMatrix[piece.coordinate.x, piece.coordinate.y];
            boardMatrix[piece.coordinate.x, piece.coordinate.y] = null;
            return boardMatrix;
        }*/
        
    }
}
