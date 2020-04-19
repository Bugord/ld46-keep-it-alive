﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    private float distance;

    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        distance = Vector2.Distance(startPoint.position, endPoint.position);
        ThrowGrenade();
    }

    public void ThrowGrenade() 
    {
        StartCoroutine(Throw(GetCurvePoints(startPoint.position, endPoint.position, 15)));
    }

    private IEnumerator Throw(List<Vector2> pointsList) 
    {
        Vector2 currentPos = transform.position;
        foreach (var nextPoint in pointsList)
        {
            float t = 0;
            while (t <= 1) 
            {
                transform.position = Vector2.Lerp(currentPos, nextPoint, t);
                t += _speed*Time.deltaTime/distance;
                yield return null;
            }
            currentPos = nextPoint;            
        }

        yield return new WaitForSeconds(_lifeTime);

        particle.Play();
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
}