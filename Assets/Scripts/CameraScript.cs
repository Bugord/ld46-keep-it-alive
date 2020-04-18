using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraScript : MonoBehaviour
    {
        private Vector2 _targetPos;
        private float _speed;
        private bool _isMoving;

        void Start()
        {
            _targetPos = transform.position;
        }

        public void Move(Vector2 targetPos, float speed)
        {
            _isMoving = true;
            _targetPos = targetPos;
            _speed = speed;
        }

        void Update()
        {
            if (_isMoving)
            {
                var dir = (_targetPos - (Vector2) transform.position).normalized;
                transform.Translate(dir * _speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, _targetPos) < 0.1f)
                {
                    _isMoving = false;
                }
                
            }
        }
    }
}
