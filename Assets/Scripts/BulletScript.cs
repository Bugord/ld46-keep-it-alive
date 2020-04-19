using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D _rigidbody2D;
    private GameManager _gameManager;
    public Vector2 _direction;
    public LayerMask Mask;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    public void Launch(Vector2 direction)
    {
        var angle = Vector2.Angle(Vector2.up, direction);
        _rigidbody2D.SetRotation(angle);
        _direction = direction;
        _rigidbody2D.velocity = _direction * Speed;
    }

    void Update()
    {
        var hit = Physics2D.Raycast(transform.position, _direction, 4, Mask);
        Debug.DrawRay(transform.position,  _direction.normalized * 4f, Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Guard")
            {
                transform.position = hit.point;
                _rigidbody2D.velocity = Vector2.zero;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
    }
}
