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
    private AudioSource _audioSource;

    public float ratio;

    private int _currentIndex;
    private bool _isMoving;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Launch()
    {
        _isMoving = true;
        _audioSource.mute = false;
    }

    void Update()
    {
        if (_isMoving)
        {
            ratio = _currentIndex * 1f / (_waypoints.Count -1);

            _audioSource.panStereo = Mathf.Lerp(1f, -1f, ratio);
              _audioSource.volume = Mathf.Sin(ratio * Mathf.PI);
            
           
            if (Vector2.Distance(transform.position, _waypoints[_currentIndex].position) < 0.1f)
            {
                _currentIndex++;
                if (_currentIndex == _waypoints.Count)
                {
                    _isMoving = false;
                    _currentIndex = 0;
                    _audioSource.mute = true;

                    return;
                }
            }

            _speed = _basespeed* _speedCurve.Evaluate(ratio);
            
            var dir = (_waypoints[_currentIndex].position - transform.position).normalized;
            transform.Translate(dir * _speed * Time.deltaTime);
        }
    }

    
}
