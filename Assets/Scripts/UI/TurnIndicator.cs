using Managers;
using UnityEngine;

namespace UI
{
    public class TurnIndicator : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        void Update()
        {
            if (GameManager.Instance.WhiteTurn)
            {
                _meshRenderer.material.color = Color.white;
            }

            if (!GameManager.Instance.WhiteTurn)
            {
                _meshRenderer.material.color = Color.black;
            }
        }
    }
}
