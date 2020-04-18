using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    [SerializeField] private GameObject _president;
    [SerializeField] private GameObject _bulletPrefab;
    
    public float BulletSpeed;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }


    void Update()
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPositions(new[] { transform.position, _president.transform.GetChild(0).GetChild(0).position - Vector3.up /4f});
    }

    public void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

        var directionVector = (_president.transform.GetChild(0).GetChild(0).position - transform.position - Vector3.up/4f).normalized;
        bullet.GetComponent<BulletScript>().Launch(directionVector);
    }

    public void SetAiming(bool isActive)
    {
        _lineRenderer.enabled = isActive;
    }
}
