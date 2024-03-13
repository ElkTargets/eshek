using UnityEngine;
using Pieces;
using UnityEngine.UIElements;

namespace Managers.Minimax
{
    public class Node
    {
        private readonly Piece[,] _nodeMatrix;
        public int PiecesScore;
        
        public Node(Piece[,] boardMatrix)
        {
            _nodeMatrix = boardMatrix;
        }

        public int GetHeuristicValue()
        {
            foreach (Piece piece in _nodeMatrix)
            {
                if (piece != null)
                {
                    PiecesScore += piece.score;
                }
            }

            return PiecesScore;
        }
    }
}
