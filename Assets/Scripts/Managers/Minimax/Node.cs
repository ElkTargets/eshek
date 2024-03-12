using UnityEngine;
using Pieces;
using UnityEngine.UIElements;

namespace Managers.Minimax
{
    public class Node
    {

        public Piece[,] NodeMatrix;
        
        public Node(Piece[,] boardMatrix)
        {
            NodeMatrix = boardMatrix;
        }

        public void GetHeuristicValue()
        {
            foreach (Piece piece in NodeMatrix)
            {
                if (piece != null)
                {
                    
                }
            }
        }
    }
}
