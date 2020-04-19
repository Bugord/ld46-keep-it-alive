﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    [SerializeField] private GameObject _president;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private Gradient _prepareGradient;
    [SerializeField] private Gradient _lastPrepareGradient;

    [SerializeField] private float _timeToPrepare;
    [SerializeField] private float _timeToLastPrepare;

    private bool _isPrepare;
    private bool _isLastPrepare;

    [SerializeField] private LayerMask _mask;
    
    private float _timer;
    
    public float BulletSpeed;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
   
    void Update()
    {
        if (_isPrepare)
        {
            _timer += Time.deltaTime;
            var color = _prepareGradient.Evaluate(_timer / _timeToPrepare);
            _lineRenderer.endColor = _lineRenderer.startColor = color;

            if (_timer > _timeToPrepare)
            {
                _timer = 0;
                _isPrepare = false;
                _isLastPrepare = true;
            }
        }

        if (_isLastPrepare)
        {
            _timer += Time.deltaTime;
            
            var color = _lastPrepareGradient.Evaluate(_timer / _timeToLastPrepare);
            _lineRenderer.endColor = _lineRenderer.startColor = color;
            
            if (_timer > _timeToLastPrepare)
            {
                _timer = 0;
                _isLastPrepare = false;
                _lineRenderer.enabled = false;
                Shoot();
            }
        }
        
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPositions(new[] { transform.position, _president.transform.GetChild(0).GetChild(0).position});
    }

    public void Shoot()
    {
        var hit = Physics2D.Raycast(transform.position, _president.transform.GetChild(0).GetChild(0).position, 100);
        
        // Debug.DrawLine(transform.position, hit.point, Color.yellow, 3);
        
        var bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        
        var directionVector = (_president.transform.GetChild(0).GetChild(0).position - transform.position - Vector3.up/4f).normalized;
        bullet.GetComponent<BulletScript>().Launch(directionVector);
    }

    public void SetAiming(bool isActive)
    {
        _lineRenderer.enabled = isActive;
        _isPrepare = true;
    }

    public void NewAttack()
    {
        _isPrepare = true;
        _lineRenderer.enabled = true;
    }
}
