using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public bool isMoving;
    private bool _isJumping;
    private Vector3 _targetPos;
    private Vector3 _trueCurrentPos;
    private float _timer;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpFrequency;
    [SerializeField] private float _jumpAmplitude;
        
    public void MoveTo(Vector2 targetPos)
    {
        isMoving = true;
        _isJumping = true;
        _targetPos = targetPos;
        _trueCurrentPos = transform.position;
    }

    private void Start()
    {
        _trueCurrentPos = transform.position;
    }

    private void Update()
    {
        transform.position = _trueCurrentPos;
        if (isMoving)
        {
            var directionVector = (_targetPos - transform.position).normalized;
            transform.Translate(directionVector * _moveSpeed);
        }
        _trueCurrentPos = transform.position;


        var verticalOffset = 0f;
      
        if (_isJumping)
        {
            _timer += Time.deltaTime;
            verticalOffset = GetVerticalOffset();
            transform.position += new Vector3(0, verticalOffset);
        }

        if (isMoving && Vector2.Distance(_trueCurrentPos, _targetPos) < 0.1f)
        {
            isMoving = false;
        }

        if (!isMoving && verticalOffset < 0.01f)
        {
            var currentSin = Mathf.Sin(_timer);
            var nextSin = Mathf.Sin(_timer + 0.01f);
            if (nextSin > currentSin)
            {
                _timer += Mathf.PI / 2f;
            }
            _isJumping = false;
        }
    }

    private float GetVerticalOffset()
    {
        return  (Mathf.Sin(_timer * _jumpFrequency) + 1f) / 2f * _jumpAmplitude;
    }

}
