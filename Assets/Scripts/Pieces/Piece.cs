using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    [Serializable]
    public abstract class Piece {
    
        public Color Color { get; }
        public Vector2Int coordinate;
        public bool hasPlayed;
        public int score;
    
        public abstract int Score { get; }
        
        protected Piece(Color color) {
            Color = color;
        }
    
        public abstract List<Vector2Int> PossibleMovement(Piece[,] matrix);
    
        private bool IsWithinChessboardBounds(int x, int y)
        {
            return x >= 0 && x <= 7 && y >= 0 && y <= 7;
        }
    
    
    }
}