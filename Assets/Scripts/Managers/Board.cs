using System;
using Pieces;
using UnityEngine;

namespace Managers
{
    [Serializable]
    public class Board : ICloneable
    {
        public Piece[,] Pieces;

        public void SetupDefaultBoard()
        {
            Pieces = new Piece[8, 8]
            { 
                {new Rook(Color.white), new Pawn(Color.white),null,null,null,null,new Pawn(Color.black),new Rook(Color.black)},
                {new Knight(Color.white), new Pawn(Color.white),null,null,null,null,new Pawn(Color.black),new Knight(Color.black)},
                {new Bishop(Color.white),new Pawn(Color.white),null,null,null,null, new Pawn(Color.black),new Bishop(Color.black)},
                {new Queen(Color.white),new Pawn(Color.white),null,null,null,null, new Pawn(Color.black),new Queen(Color.black)},
                {new King(Color.white),new Pawn(Color.white),null,null,null,null, new Pawn(Color.black),new King(Color.black)},
                {new Bishop(Color.white), new Pawn(Color.white),null,null,null,null, new Pawn(Color.black),new Bishop(Color.black)},
                {new Knight(Color.white), new Pawn(Color.white),null,null,null,null,new Pawn(Color.black),new Knight(Color.black)},
                {new Rook(Color.white), new Pawn(Color.white),null,null,null,null,new Pawn(Color.black),new Rook(Color.black)},
            };
        }

        public void MovePiece(Piece piece, Vector2Int cell)
        {
            //manger
            if (Pieces[cell.x, cell.y].Color != Pieces[piece.coordinate.x, piece.coordinate.y].Color)
            { 
                Pieces[cell.x, cell.y] = null;
            }
            Pieces[cell.x, cell.y] = Pieces[piece.coordinate.x, piece.coordinate.y];
            Pieces[piece.coordinate.x, piece.coordinate.y] = null;
        }

        public int GetHeuristicValue(Color turnColor)
        {
            int heuristicValue = 0;
            foreach (Piece piece in Pieces)
            {
                if (piece == null) continue;
                heuristicValue += piece.Score;
            }
            Debug.Log(heuristicValue);
            return heuristicValue;
        }
        
        public object Clone()
        {
            Board newBoard = new Board
            {
                Pieces = new Piece[8, 8]
            };
            
            foreach (Piece piece in Pieces)
            {
                if (piece == null) continue;
                newBoard.Pieces[piece.coordinate.x, piece.coordinate.y] = (Piece)piece.Clone();

            }

            return newBoard;
        }
        
    }
}
