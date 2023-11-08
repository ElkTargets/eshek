using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    [Serializable]
    public class Bishop : Piece {
    
        public Bishop(Color color) : base(color) { }

        public override List<Vector2Int> PossibleMovement(Piece[,] matrix)
        {
            throw new System.NotImplementedException();
        }
    }
}
