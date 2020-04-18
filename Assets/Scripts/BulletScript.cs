using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D _rigidbody2D;
    private GameManager _gameManager;
    public Vector2 _direction;


    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction)
    {
        var angle = Vector2.Angle(Vector2.up, direction);
        _rigidbody2D.SetRotation(angle);
        _direction = direction;
    }

    void Update()
    {
        _rigidbody2D.velocity = _direction * Speed * _gameManager.TimeScale;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
    }
}
