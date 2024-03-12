using Managers;
using UnityEngine;

namespace Handlers
{
    public class CellHandler : MonoBehaviour {
    
        public Vector2Int cellCoordinates;
    
        private void Awake() {
            cellCoordinates = new Vector2Int((int)transform.localPosition.x, (int)transform.localPosition.z);
        }

        private void OnMouseEnter() {
            if (!GameManager.Instance.SelectedPiece) return;
            GetComponent<MeshRenderer>().material.color = Color.green;
        }

        private void OnMouseExit() {
            if (!GameManager.Instance.SelectedPiece) return;
            GetComponent<MeshRenderer>().material.color = Color.white;
        }

        private void OnMouseOver() {
            if (GameManager.Instance.SelectedPiece && Input.GetButtonDown("Fire1")) {
                GetComponent<MeshRenderer>().material.color = Color.red;
                GameManager.Instance.SelectedCell = this;
            }
        }

        public static bool CompareCoordinates(CellHandler otherCell, Vector2Int coordinates)
        {
            Vector2Int cellCoords = otherCell.cellCoordinates;
            return (cellCoords.x == coordinates.x && cellCoords.y == coordinates.y);
        }
    }
}
