using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellProperties : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Color cellColor = Color.red;
    [SerializeField] [Range(-5, 5)] int rotX, rotY, rotZ;

    private void Start()
    {
        meshRenderer.material.color = cellColor;
    }

    private void Update()
    {
        transform.Rotate(rotX, rotY, rotZ);
    }
}
