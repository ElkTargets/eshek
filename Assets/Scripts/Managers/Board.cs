using System;
using Handlers;
using Pieces;
using UnityEngine;

namespace Managers
{
    [Serializable]
    public class Board : ICloneable
    {
        public Piece[,] Pieces; 
        
        public Board() { }

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


        public object Clone()
        {
            Board newBoard = new Board();
            newBoard.Pieces = new Piece[8, 8];
            foreach (Piece piece in Pieces)
            {
                newBoard.Pieces[piece.coordinate.x, piece.coordinate.y] = (Piece) piece.Clone();
            }
            return newBoard;
        }
    }
}
