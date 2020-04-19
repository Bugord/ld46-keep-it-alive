using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private float _speed;
    // Start is called before the first frame update

    public void Launch() 
    {
        StartCoroutine(StartCar());
    }

    private IEnumerator StartCar() 
    {
        float distance = Vector2.Distance(_waypoints[0].position, _waypoints[1].position);

        float t = 0;
        while (t <= 1) 
        {
            transform.position = Vector2.Lerp(_waypoints[0].position, _waypoints[1].position, t);
            t += Mathf.Lerp(1, _speed, 1-t) * Time.deltaTime / distance;
            yield return null;
        }

        yield return new WaitForSeconds(2);

        distance = Vector2.Distance(_waypoints[1].position, _waypoints[2].position);

        t = 0;

        while (t <= 1)
        {
            transform.position = Vector2.Lerp(_waypoints[1].position, _waypoints[2].position, t);
            t += Mathf.Lerp(1, _speed, t) * Time.deltaTime / distance;
            yield return null;
        }
    }
}
