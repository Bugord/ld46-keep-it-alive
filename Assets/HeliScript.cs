using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliScript : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _basespeed;
    [SerializeField] private float _speed;
    [SerializeField] private AnimationCurve _speedCurve;

    private int _currentIndex;
    private bool _isMoving;
    
    public void Launch()
    {
        _isMoving = true;
    }

    void Update()
    {
        if (_isMoving)
        {
            if (Vector2.Distance(transform.position, _waypoints[_currentIndex].position) < 0.1f)
            {
                _currentIndex++;
                if (_currentIndex == _waypoints.Count)
                {
                    _isMoving = false;
                    _currentIndex = 0;
                    return;
                }
            }

            _speed = _basespeed* _speedCurve.Evaluate(_currentIndex * 1f/ _waypoints.Count);
            
            var dir = (_waypoints[_currentIndex].position - transform.position).normalized;
            transform.Translate(dir * _speed * Time.deltaTime);
        }
    }
}
