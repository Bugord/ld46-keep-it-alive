using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private LineRenderer _lineRenderer;
    private bool _isThrowPrepare;
    private bool _wasThrown;

    [SerializeField] private bool _isThrowable; 
    
    private List<Vector2> _curvePoints;
    private int _currentCurvePoint;

    private GameManager _gameManager;

    [SerializeField] private Transform _ragdollTransform;

    [SerializeField] private List<Rigidbody2D> _partRigidbody2Ds;
    [SerializeField] private Rigidbody2D _leftHandRigidbody2D;
    [SerializeField] private Rigidbody2D _rightHandRigidbody2D;
    [SerializeField] private HingeJoint2D _bodyHingeJoint2D;
    [SerializeField] private BoxCollider2D _deadCollider;

    [SerializeField] private float _flySpeed;
    [SerializeField] private float _flyMaxDistance;

    public bool IsDead;
    public bool WasShoted;

    [SerializeField] private SpeachController _speachController;

    private List<string> _messages;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _partRigidbody2Ds = _ragdollTransform.GetComponentsInChildren<Rigidbody2D>().ToList();
        _gameManager = GameManager.Instance;

        _messages = new List<string>
        {
            "Nooooooo!",
            "Ai blyat!",
            "Suka!",
            "Not again!"
        };
    }      

    private void Update()
    {
        if (_isThrowPrepare)
        {
            SetLineRendererPoint();
        }

        if (_wasThrown)
        {
            var moveVector = (_curvePoints[_currentCurvePoint] - (Vector2)transform.position).normalized * _flySpeed * Time.deltaTime;
            transform.Translate(moveVector);

            if (Vector2.Distance(transform.position, _curvePoints[_currentCurvePoint]) < 0.1f)
            {
                _currentCurvePoint++;
                if (_currentCurvePoint == _curvePoints.Count)
                {
                    _wasThrown = false;
                    _currentCurvePoint = 0;


                    Die();

                }
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!_isThrowable)
            return;
        _isThrowPrepare = true;
        _lineRenderer.enabled = _isThrowPrepare;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(!_isThrowable)
            return;
        _isThrowPrepare = false;
        _lineRenderer.enabled = _isThrowPrepare;

        Throw();
    }

    private void Throw()
    {
        _wasThrown = true;

        foreach (var partRigidbody2D in _partRigidbody2Ds)
        {
            partRigidbody2D.gravityScale = 0.05f;
        }

        _gameManager.OnGuardJump();

        GetComponent<MoveScript>().enabled = false;

        _leftHandRigidbody2D.AddForce(Vector2.left * 25, ForceMode2D.Impulse);
        _rightHandRigidbody2D.AddForce(Vector2.right * 25, ForceMode2D.Impulse);
    }

    public List<Vector2> GetCurvePoints(Vector2 start, Vector2 end, int anglesCount)
    {
        var curvePoints = new List<Vector2> { start };

        for (var i = 1; i < anglesCount; i++)
        {
            curvePoints.Add(Vector2.Lerp(start, end, i * 1.0f / anglesCount) + new Vector2(0, Mathf.Sin(Mathf.PI * (i * 1.0f / anglesCount))));
        }

        curvePoints.Add(end);

        return curvePoints;
    }

    private void SetLineRendererPoint()
    {
        var pointCount = 10;
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var flyVector = (Vector2)(mousePosition - transform.position);

        if (flyVector.magnitude > _flyMaxDistance)
        {
            flyVector = flyVector.normalized * _flyMaxDistance;
        }

        _curvePoints = GetCurvePoints(transform.position, (Vector2)transform.position + flyVector, pointCount);
        _lineRenderer.positionCount = pointCount + 1;
        _lineRenderer.SetPositions(_curvePoints.Select(vector2 => (Vector3)vector2).ToArray());
    }

    public void Shoted(Vector2 dir)
    {
        WasShoted = true;
        var bodyRigidbody2D = _bodyHingeJoint2D.GetComponent<Rigidbody2D>();

        bodyRigidbody2D.AddForce(dir * 5f, ForceMode2D.Impulse);

        Die();
    }

    private void Die()
    {
        IsDead = true;
        _deadCollider.enabled = true;

        foreach (var partRigidbody2D in _partRigidbody2Ds)
        {
            partRigidbody2D.gravityScale = 1f;
            partRigidbody2D.gameObject.layer = 9;
        }

        _bodyHingeJoint2D.enabled = false;

        if (!WasShoted)
        {

            var bodyRigidbody2D = _bodyHingeJoint2D.GetComponent<Rigidbody2D>();

            var continueThrowDirection =
                _curvePoints[_curvePoints.Count - 1] - _curvePoints[_curvePoints.Count - 2];

            bodyRigidbody2D.AddForce(new Vector2(continueThrowDirection.x, .1f) * 100f, ForceMode2D.Impulse);
        }

        if (Random.Range(0, 3) == 1)
        {
            _speachController.Speak(_messages[new System.Random().Next(0, _messages.Count)]);
        }        
    }
}
