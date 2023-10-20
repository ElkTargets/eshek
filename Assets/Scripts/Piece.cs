using UnityEngine;

public abstract class Piece {
    
    public Color Color { get; }

    protected Piece(Color color) {
        Color = color;
    }
    
}
