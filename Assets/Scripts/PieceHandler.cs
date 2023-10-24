using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PieceHandler : MonoBehaviour {

    public Vector2Int coordinate;
    
    private Vector3 _initialPosition;
    private static bool _pieceSelected;
    private Color _originalColor;

    private void Awake() {
        Vector3 localPosition = transform.position;
        coordinate = new Vector2Int((int)localPosition.x, (int)localPosition.z);
        _originalColor = GetComponent<MeshRenderer>().material.color;
    }

    private void OnMouseOver() {
        if (Input.GetButtonDown("Fire1") && GameManager.Instance.canSelectPiece) {
            GameManager.Instance.canSelectPiece = false;
            Debug.Log("Selected : " + gameObject);
            GetComponent<MeshRenderer>().material.color = Color.red;
            // Bouchon à enlever
            List<Vector2Int> vector2Ints = new List<Vector2Int>();
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    vector2Ints.Add(new Vector2Int(i, j));
                }
            }
            // Fin du bouchon
            GameManager.Instance.SelectedPiece = this;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            GetComponent<MeshRenderer>().material.color = _originalColor;
            GameManager.Instance.SelectedPiece = null;
            GameManager.Instance.canSelectPiece = true;
        }
    }
}