using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsObserver : MonoBehaviour
{
    [SerializeField]private Transform[] _observablePoints;
    [SerializeField] private float _lookDelay;
    [SerializeField] private GameObject _fieldOfView;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private LayerMask _playerMask;

    private float _timer = 0f;
    private int currentObservablePointIndex = 0;

    private void Awake()
    {
        _timer = _lookDelay;
    }
    private void Update()
    {
        LoookAtTImerTick();
        LookAtPoint();
    }

    private void LookAtPoint()
    {
        Vector3 distanceToPoint = _observablePoints[currentObservablePointIndex].position - transform.position;
        Vector3 directToPoint = distanceToPoint.normalized;
        if (Physics.Raycast(transform.position, directToPoint, out RaycastHit hit, distanceToPoint.magnitude, _playerMask))
            hit.collider.GetComponent<Player>().Kill();
            //Debug.LogError(message: "Player founded!");
        _fieldOfView.SetActive(Physics.Raycast(transform.position, distanceToPoint, directToPoint.magnitude, _obstacleMask) == false);
        Vector3 newDirection = new Vector3(directToPoint.x, 0f, directToPoint.z+0.0001f);
        transform.forward = newDirection;
    }

    private void LoookAtTImerTick()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            int nextPoint = currentObservablePointIndex + 1;
            if (nextPoint >= _observablePoints.Length)
                nextPoint = 0;
            currentObservablePointIndex = nextPoint;
            _timer = _lookDelay;
            //Debug.LogError(message:"TimeLimit!");
        }

    }

}
