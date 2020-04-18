using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MoveScript))]
public class WayPointsScript : MonoBehaviour
{
    private MoveScript _moveScript;

    [SerializeField] private List<Transform> _waypoints;

    private Transform _target;

    private int _nextTargetIndex;

    // Start is called before the first frame update
    void Start()
    {
        _moveScript = GetComponent<MoveScript>();
        if (_waypoints.Count != 0) 
        {
            _target = _waypoints.First();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_nextTargetIndex == _waypoints.Count) return;

        if (!_moveScript.isMoving) 
        {
            _moveScript.MoveTo(_target.position);
            _nextTargetIndex = _waypoints.IndexOf(_target) + 1;
            if (_nextTargetIndex < _waypoints.Count)
                _target = _waypoints[_nextTargetIndex];
        }
    }
}
