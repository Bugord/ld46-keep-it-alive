using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MoveScript))]
public class WayPointsScript : MonoBehaviour
{
    private MoveScript _moveScript;

    [SerializeField] private List<Vector2> _waypoints;

    private Vector2 _target;

    private int _nextTargetIndex;

    private bool _isMoving;

    // Start is called before the first frame update
    void Start()
    {
        _moveScript = GetComponent<MoveScript>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            if (_nextTargetIndex == _waypoints.Count)
            {
                _isMoving = false;
            };

            if (!_moveScript.isMoving)
            {
                _moveScript.MoveTo(_target);
                _nextTargetIndex = _waypoints.IndexOf(_target) + 1;
                if (_nextTargetIndex < _waypoints.Count)
                    _target = _waypoints[_nextTargetIndex];
            }
        }
    }

    public void MoveTo(List<Vector2> point)
    {
        _waypoints = point;
        _isMoving = true;
        if (_waypoints.Count != 0)
        {
            _target = _waypoints.First();
        }
    }
}
