using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour
{
    private Movement _movevent = null;
    public bool ISAlive { get; private set; } = true;
    public bool HasKey { get; private set; } = false;

    private void Awake()
    {
        _movevent = GetComponent<Movement>();
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            Kill();
        }
    }*/
    public void Enable()
    {
        _movevent.enabled = true;
    }
    public void Disable()
    {
        _movevent.enabled = false;
    }
    public void Kill()
    {
        ISAlive = false;
    }
    public void PickUpKey()
    {
        HasKey = true;
    }
}
