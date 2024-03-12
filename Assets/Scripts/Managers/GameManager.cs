using System;
using System.Collections.Generic;
using Handlers;
using Pieces;
using UnityEngine;
using Utils;

namespace Managers
{
    public class GameManager : MonoBehaviourSingleton<GameManager> {
    
        public List<CellHandler> cellsList;
        public Transform cellsParent;
        public Transform piecesParent;
        [SerializeField] public Piece[,] BoardMatrix;
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

        public GameObject Plateau;
        private bool FirstTurn;
        public GameObject LnAWhite;
        public GameObject LnABlack;

        public bool WhiteTurn;
        public bool canSelectPiece;
        public PieceHandler SelectedPiece { get; set; }
        public CellHandler SelectedCell { get; set; }
        public List<CellHandler> PossibleCells { get; set; }
        //public List<King> _kings { get; set; } = new List<King>();


        private void Awake()
        {
            FirstTurn = true;
            PossibleCells = new List<CellHandler>();
            // Remplir matrice
            BoardMatrix = new Piece[8, 8]
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
            WhiteTurn = true;
            LnABlack.SetActive(false);
        }

        private void DisplayMatrix() {
            // Affiche la matrice sur le board
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    Piece current = BoardMatrix[i, j];
                    Vector3 position = new Vector3(i,0,j);
                
                    GameObject piecePrefab = GetPiecePrefab(current);
                    if (piecePrefab) {
                        GameObject instantiate = Instantiate(piecePrefab, piecesParent);
                        instantiate.transform.localPosition = position;
                        instantiate.GetComponent<PieceHandler>().Setup(current);
                    }
                    //Debug.Log(_kings.Count);
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
            if (SelectedPiece)
            {
                SelectedPiece.GetComponent<MeshRenderer>().material.color = Color.red;
                EnableCells(SelectedPiece.Piece.PossibleMovement(BoardMatrix));
            }
            if (SelectedPiece && SelectedCell) {
            
                MovePieceAtCell(SelectedPiece, SelectedCell);
                SelectedPiece.Piece.hasPlayed = true;
                SelectedPiece = null;
                SelectedCell = null;
                canSelectPiece = true;
            }

            if (!SelectedPiece)
            {
                foreach (CellHandler cell in cellsList)
                {
                    cell.gameObject.GetComponent<MeshRenderer>().material.color = new Color(255, 255,255,0);
                }
            }

            if (WhiteTurn)
            {
                if (FirstTurn)
                {
                    return;
                }
                Plateau.GetComponent<Animator>().SetBool("WhiteTurn", true);
                Plateau.GetComponent<Animator>().SetBool("BlackTurn", false);
                LnAWhite.SetActive(true);
                LnABlack.SetActive(false);
            }
            if (!WhiteTurn)
            {
                Plateau.GetComponent<Animator>().SetBool("WhiteTurn", false);
                Plateau.GetComponent<Animator>().SetBool("BlackTurn", true);
                LnAWhite.SetActive(false);
                LnABlack.SetActive(true);
            }
        }
    
        private void MovePieceAtCell(PieceHandler pieceHandler, CellHandler cellHandler) {
            Vector2Int cellCoord = cellHandler.cellCoordinates;
            Vector2Int pieceCoord = pieceHandler.Piece.coordinate;
        
            //Cas particuliers
            if (BoardMatrix[cellCoord.x, cellCoord.y] != null)
            {
                //manger
                if (BoardMatrix[cellCoord.x, cellCoord.y].Color != BoardMatrix[pieceCoord.x, pieceCoord.y].Color)
                { 
                    BoardMatrix[cellCoord.x, cellCoord.y] = null;
                }
                //move impossible
                else
                {
                    SelectedPiece.gameObject.GetComponent<MeshRenderer>().material.color = pieceHandler.originalColor;
                    SelectedCell.gameObject.GetComponent<MeshRenderer>().material.color = new Color(255, 255,255,0);
                    SelectedPiece = null;
                    SelectedCell = null;
                    //canSelectPiece = true;
                    return;
                }
            
            }
        
            //Deplacement de la value, Destruction du game object visuel
            BoardMatrix[cellCoord.x, cellCoord.y] = BoardMatrix[pieceCoord.x, pieceCoord.y];
            GameObject piecePrefab = SelectedPiece.gameObject;
            Destroy(piecePrefab);
            PieceHandler instantiate = Instantiate(SelectedPiece, piecesParent);
            Vector3 position = new Vector3(cellCoord.x-0.5f, 1, cellCoord.y-0.5f);
            instantiate.transform.position = position;
        
            //Couleur Cellule et Piece -> Reset
            SelectedPiece.gameObject.GetComponent<MeshRenderer>().material.color = pieceHandler.originalColor;
            foreach (CellHandler cells in cellsList)
            {
                SelectedCell.gameObject.GetComponent<MeshRenderer>().material.color = new Color(255, 255,255,0);
                SelectedCell.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        
            //Vidage de la cell d'origine
            BoardMatrix[pieceCoord.x, pieceCoord.y] = null;
        
            //Visuel Mouvment
            foreach (Transform child in piecesParent)
            {
                Destroy(child.gameObject);
            }
            foreach (CellHandler cell in cellsList)
            {
                cell.gameObject.GetComponent<MeshRenderer>().material.color = new Color(255, 255,255,0);
            }
            //_kings.Clear();
            //Debug.Log(_kings.Count);
            DisplayMatrix();
            FirstTurn = false;
            //Changement tour
            if (WhiteTurn)
            {
                WhiteTurn = false;
            }
            else if (!WhiteTurn)
            {
                WhiteTurn = true;
            }
        
        }

        public void EnableCells(List<Vector2Int> movements)
        {
            if (movements == null) throw new NullReferenceException("C'est Là");
            List<CellHandler> cells = cellsList;

            foreach (CellHandler item in cells)
            {
                foreach (Vector2Int move in movements)
                {
                    if (CellHandler.CompareCoordinates(item, move))
                    {
                        PossibleCells.Add(item);
                        item.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                        //Debug.Log(PossibleCells);
                    }
                }

                item.gameObject.GetComponent<BoxCollider>().enabled = item.gameObject.GetComponent<MeshRenderer>().material.color == Color.blue;
            }
        }
    
    
    }
}