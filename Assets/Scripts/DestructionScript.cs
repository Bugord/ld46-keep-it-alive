using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D), typeof(Joint2D))]
public class DestructionScript : MonoBehaviour
{
    private Joint2D joint;

    private void Start()
    {
        joint = GetComponent<Joint2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) 
        {
            joint.enabled = false;
        }
    }
}
