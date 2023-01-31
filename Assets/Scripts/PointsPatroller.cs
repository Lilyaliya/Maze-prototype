using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPatroller : MonoBehaviour
{
    [SerializeField] private Transform[] _patrollingPoints;
    [SerializeField] private float _patrolDelay;
    [SerializeField] private float _step;
    private float _timer = 0f;
    private int currentPatrolPointIndex = 0;

    private void Awake()
    {
        _timer = _patrolDelay;
    }
    private void Update()
    {
        PatrolTimerTick();
        MoveToPoint(currentPatrolPointIndex);
    }

    private void MoveToPoint(int PointIndex)
    {
        transform.position = new Vector3(_patrollingPoints[currentPatrolPointIndex].position.x, transform.position.y, _patrollingPoints[currentPatrolPointIndex].position.z);
    }

    private void PatrolTimerTick()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            int nextPoint = currentPatrolPointIndex + 1;
            if (nextPoint >= _patrollingPoints.Length)
                nextPoint = 0;
            currentPatrolPointIndex = nextPoint;
            _timer = _patrolDelay;
            //Debug.LogError(message:"TimeLimit!");
        }

    }
}
