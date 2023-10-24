using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    public class Rook : Piece {
    
        public Rook(Color color) : base(color) { }

        public override List<Vector2Int> PossibleMovement(Piece[,] matrix)
        {
            throw new System.NotImplementedException();
        }
    }
}
