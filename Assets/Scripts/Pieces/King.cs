using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    [Serializable]
    public class King : Piece {
    
        public King(Color color) : base(color) { }

        public override List<Vector2Int> PossibleMovement(Piece[,] matrix) {
            throw new System.NotImplementedException();
        }
    }
}
