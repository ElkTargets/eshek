using System.Collections.Generic;
using UnityEngine;

public class PieceHandler : MonoBehaviour {
    
    public Piece Piece;
    
    private Vector3 _initialPosition;
    private static bool _pieceSelected;
    public Color originalColor;

    public void Setup(Piece current) {
        Piece = current;
        Piece.coordinate = new Vector2Int((int)transform.localPosition.x, (int)transform.localPosition.z);
    }
    
    private void OnMouseOver() {
        if (GameManager.Instance.WhiteTurn)
        {
            if (!this.gameObject.CompareTag("White"))
            {
                return;
            }
        }
        else
        {
            if (!GameManager.Instance.WhiteTurn)
            {
                if (!this.gameObject.CompareTag("Black"))
                {
                    return;
                }
            }
        }
        
        if (Input.GetButtonDown("Fire1") && GameManager.Instance.canSelectPiece) {
            GameManager.Instance.canSelectPiece = false;
            Debug.Log("Selected : " + gameObject);
            GetComponent<MeshRenderer>().material.color = Color.red;
            List<Vector2Int> movements = Piece.PossibleMovement(GameManager.Instance.Matrix);

            GameManager.Instance.EnableCells(movements);
            
            GameManager.Instance.SelectedPiece = this;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            GetComponent<MeshRenderer>().material.color = originalColor;
            GameManager.Instance.SelectedPiece = null;
            GameManager.Instance.canSelectPiece = true;
        }
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
    
}