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

    void Start()
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPositions(new []{transform.position, _president.transform.position});
    }

    public void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

        var directionVector = (_president.transform.position - transform.position).normalized;
        bullet.GetComponent<BulletScript>().Launch(directionVector);
    }
}
