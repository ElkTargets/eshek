using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
