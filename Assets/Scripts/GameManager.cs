using System.Collections.Generic;
using Pieces;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager> {
    
    public List<CellHandler> cellsList;
    public Transform cellsParent;
    public Transform piecesParent;
    [SerializeField] public Piece[,] Matrix;
    [SerializeField] private GameObject cellPrefab;
    public GameObject WhiteRookPrefab;
    public GameObject BlackRookPrefab;
    public GameObject WhiteKnightPrefab;
    public GameObject BlackKnightPrefab;
    public GameObject WhiteBishopPrefab; 
    [SerializeField] private GameObject blackBishopPrefab;
    public GameObject WhiteKingPrefab;
    public GameObject BlackKingPrefab;
    public GameObject WhiteQueenPrefab;
    public GameObject BlackQueenPrefab;
    public GameObject WhitePawnPrefab;
    public GameObject BlackPawnPrefab;
    
    public bool canSelectPiece;
    public PieceHandler SelectedPiece { get; set; }
    public CellHandler SelectedCell { get; set; }


    private void Awake()
    {
        // Remplir matrice
        Matrix = new Piece[8, 8]
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
        
        cellsList = new List<CellHandler>(cellsParent.GetComponentsInChildren<CellHandler>());
        DisplayMatrix();
        canSelectPiece = true;
    }

    private void DisplayMatrix() {
        // Affiche la matrice sur le board
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                Piece current = Matrix[i, j];
                Vector3 position = new Vector3(i,0,j);
                
                GameObject piecePrefab = GetPiecePrefab(current);
                if (piecePrefab) {
                    GameObject instantiate = Instantiate(piecePrefab, piecesParent);
                    instantiate.transform.localPosition = position;
                }
            }
        }
    }
    
    public CellHandler FindCellAtCoord(Vector2Int coord) {
        foreach (CellHandler cell in cellsList) {
            if (coord == cell.cellCoordinates) return cell;
        }
        return null;
    }

    private GameObject GetPiecePrefab(Piece piece) {
        switch (piece) {
            case Rook _:
                return piece.Color == Color.white ? WhiteRookPrefab : BlackRookPrefab;
            case Knight _:
                return piece.Color == Color.white ? WhiteKnightPrefab : BlackKnightPrefab;
            case Bishop _:
                return piece.Color == Color.white ? WhiteBishopPrefab : blackBishopPrefab;
            case King _:
                return piece.Color == Color.white ? WhiteKingPrefab : BlackKingPrefab;
            case Queen _:
                return piece.Color == Color.white ? WhiteQueenPrefab : BlackQueenPrefab;
            case Pawn _:
                return piece.Color == Color.white ? WhitePawnPrefab : BlackPawnPrefab;
            default:
                return null;
        }
    }
    
    private void Update() {
        if (SelectedPiece && SelectedCell) {
            //Debug.Log(SelectedPiece.coordinate + " = Original Piece Coord");
            //Debug.Log(SelectedCell.cellCoordinates + " = Original Cell Coord");
            MovePieceAtCell(SelectedPiece, SelectedCell);
            //if ()
            //{
                
            //}
            //Debug.Log(SelectedPiece.coordinate + " = New Piece Coord");
            //Debug.Log(SelectedCell.cellCoordinates + " = New Cell Coord");
            SelectedPiece = null;
            SelectedCell = null;
            canSelectPiece = true;
        }
    }
    
    private void MovePieceAtCell(PieceHandler pieceHandler, CellHandler cellHandler) {
        Vector2Int cellCoord = cellHandler.cellCoordinates;
        Vector2Int pieceCoord = pieceHandler.coordinate;
        if (Matrix[cellCoord.x, cellCoord.y] != null)
        {
            if (Matrix[cellCoord.x, cellCoord.y].Color != Matrix[pieceCoord.x, pieceCoord.y].Color)
            {
                //Destroy(Matrix[cellCoord.x, cellCoord.y]);
            }
        }
        
        Matrix[cellCoord.x, cellCoord.y] = Matrix[pieceCoord.x, pieceCoord.y];
        GameObject piecePrefab = SelectedPiece.gameObject;
        Destroy(piecePrefab);
        PieceHandler instantiate = Instantiate(SelectedPiece, piecesParent);
        Vector3 position = new Vector3(cellCoord.x-0.5f, 1, cellCoord.y-0.5f);
        instantiate.transform.position = position;
        SelectedPiece.gameObject.GetComponent<MeshRenderer>().material.color = pieceHandler.originalColor;
        SelectedCell.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        Debug.Log(Matrix[cellCoord.x,cellCoord.y]);
        Matrix[pieceCoord.x, pieceCoord.y] = null;
    }
}