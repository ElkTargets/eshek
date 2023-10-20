using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pieces;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Cell> cellsList;
    public Transform cellsParent;
    public Transform piecesParent;
    public Piece[,] Matrix;
    public GameObject WhiteRookPrefab;
    public GameObject BlackRookPrefab;
    public GameObject WhiteKnightPrefab;
    public GameObject BlackKnightPrefab;
    public GameObject WhiteBishopPrefab;
    public GameObject BlackBishopPrefab;
    public GameObject WhiteKingPrefab;
    public GameObject BlackKingPrefab;
    public GameObject WhiteQueenPrefab;
    public GameObject BlackQueenPrefab;
    public GameObject WhitePawnPrefab;
    public GameObject BlackPawnPrefab;

    private void Awake()
    {
        // Remplir matrice
        Matrix = new Piece[8, 8]
        { 
            { new Rook(Color.white), new Knight(Color.white), new Bishop(Color.white), new Queen(Color.white), new King(Color.white), new Bishop(Color.white), new Knight(Color.white), new Rook(Color.white)},
            {new Pawn(Color.white), new Pawn(Color.white), new Pawn(Color.white), new Pawn(Color.white), new Pawn(Color.white), new Pawn(Color.white), new Pawn(Color.white), new Pawn(Color.white)},
            {null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null},
            {null,null,null,null,null,null,null,null},
            {new Pawn(Color.black), new Pawn(Color.black), new Pawn(Color.black), new Pawn(Color.black), new Pawn(Color.black), new Pawn(Color.black), new Pawn(Color.black), new Pawn(Color.black)},
            { new Rook(Color.black), new Knight(Color.black), new Bishop(Color.black),new King(Color.black), new Queen(Color.black), new Bishop(Color.black), new Knight(Color.black), new Rook(Color.black)},
        };
        
        cellsList = new List<Cell>(cellsParent.GetComponentsInChildren<Cell>());
        DisplayMatrix();
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
                Debug.Log(i + " " + j);
            }
        }
    }
    
    private Cell FindCellAtCoord(Vector2Int coord) {
        foreach (Cell cell in cellsList) {
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
                return piece.Color == Color.white ? WhiteBishopPrefab : BlackBishopPrefab;
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
}
