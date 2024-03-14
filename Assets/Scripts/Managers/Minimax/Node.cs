using System.Collections.Generic;
using Pieces;
using UnityEngine;

namespace Managers.Minimax
{
    public class Node
    {
        public int Heuristic = 0;
        public Color OwnerColor;
        public Color TurnColor;
        public Board CurrentBoard;

        public Node(Board board, Color ownerColor)
        {
            CurrentBoard = board;
            OwnerColor = ownerColor;
        }

        public List<Node> GetChilds()
        {
            List<Node> nodes = new List<Node>();
            foreach (Piece piece in CurrentBoard.Pieces) 
            {
                if (piece == null) continue;
                if (piece.Color != TurnColor) continue;
                
                foreach (Vector2Int move in piece.PossibleMovement(CurrentBoard.Pieces)) {
                    Board nextBoard = (Board) CurrentBoard.Clone();
                    nextBoard.MovePiece(piece, move);
                    OwnerColor = OwnerColor == Color.white ? Color.black : Color.white;
                    nodes.Add(new Node(nextBoard, OwnerColor));
                }
            }
            return nodes;
        }
        
        public bool IsTerminal()
        {
            return GetChilds().Count == 0;
        }

        public int GetHeuristic()
        {
            return CurrentBoard.GetHeuristicValue(TurnColor);
        }
        
        }

        
        
    }
}
