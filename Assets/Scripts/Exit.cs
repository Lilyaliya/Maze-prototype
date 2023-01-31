using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]
public class Exit : MonoBehaviour
{
    [SerializeField] private Material _closedMaterial;
    [SerializeField] private Material __openedMaterial;
    public bool isOpened { get; private set; }
    private MeshRenderer rend;
    private void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }
    public void Open()
    {
        isOpened = true;
        rend.sharedMaterial = __openedMaterial;
    }
    public void CLose()
    {
        isOpened = false;
        rend.sharedMaterial = _closedMaterial;
    }

}
