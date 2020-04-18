using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private LineRenderer _lineRenderer;
    private bool _isThrowPrepare;
    private bool _wasThrown;
    private Rigidbody2D _rigidbody2D;

    private List<Vector2> _curvePoints;
    private int _currentCurvePoint;


    [SerializeField] private float _flySpeed;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isThrowPrepare)
        {
            SetLineRendererPoint();
        }

        if (_wasThrown)
        {
            var moveVector = (_curvePoints[_currentCurvePoint] - (Vector2)transform.position).normalized * _flySpeed;
            transform.Translate(moveVector);

            if (Vector2.Distance(transform.position, _curvePoints[_currentCurvePoint]) < 0.1f)
            {
                _currentCurvePoint++;
                if (_currentCurvePoint == _curvePoints.Count)
                {
                    _wasThrown = false;
                    _currentCurvePoint = 0;
                }
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isThrowPrepare = true;
        _lineRenderer.enabled = _isThrowPrepare;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isThrowPrepare = false;
        _lineRenderer.enabled = _isThrowPrepare;
        
        Throw();
    }

    private void Throw()
    {
        _wasThrown = true;
    }

    public List<Vector2> GetCurvePoints(Vector2 start, Vector2 end, int anglesCount)
    {
        var curvePoints = new List<Vector2> { start };
       
        for (var i = 1; i < anglesCount; i++)
        {
            curvePoints.Add(Vector2.Lerp(start,end , i * 1.0f / anglesCount) + new Vector2(0, Mathf.Sin(Mathf.PI * (i * 1.0f / anglesCount))));
        }

        curvePoints.Add(end);

        return curvePoints;
    }

    private void SetLineRendererPoint()
    {
        var pointCount = 10;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _curvePoints = GetCurvePoints(transform.position, mousePosition, pointCount);
        _lineRenderer.positionCount = pointCount + 1;
        _lineRenderer.SetPositions(_curvePoints.Select(vector2 => (Vector3)vector2).ToArray());
    }
}
