using System.Collections.Generic;
using UnityEngine;

namespace Pieces
{
    public class Knight : Piece {
    
        public Knight(Color color) : base(color) { }

        public override List<Vector2Int> PossibleMovement(Piece[,] matrix)
        {
            throw new System.NotImplementedException();
        }
    }
}
