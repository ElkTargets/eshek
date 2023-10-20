using UnityEngine;

public class Cell : MonoBehaviour {
    public Vector2Int cellCoordinates;
    
    private void Awake() {
        cellCoordinates = new Vector2Int((int)transform.localPosition.x, (int)transform.localPosition.z);
    }
}
