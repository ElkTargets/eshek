using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public abstract class Piece {
    
    public Color Color { get; }
    public Vector2Int coordinate;
    public bool hasPlayed;
    
    protected Piece(Color color) {
        Color = color;
    }
    
    public abstract List<Vector2Int> PossibleMovement(Piece[,] matrix);
    
    private bool IsWithinChessboardBounds(int x, int y)
    {
        return x >= 0 && x <= 7 && y >= 0 && y <= 7;
    }
    
    
}