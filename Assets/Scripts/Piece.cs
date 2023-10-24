using System.Collections.Generic;
using UnityEngine;

public abstract class Piece {
    
    public Color Color { get; }

    protected Piece(Color color) {
        Color = color;
    }

    public abstract List<Vector2Int> PossibleMovement(Piece[,] matrix);

}
