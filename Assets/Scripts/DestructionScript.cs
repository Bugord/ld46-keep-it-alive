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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) 
        {
            joint.enabled = false;
            Destroy(collision.gameObject);

            var dir = collision.GetComponent<BulletScript>()._direction;
            transform.parent?.parent?.GetChild(1)?.GetComponent<ThrowScript>()?.Shoted(dir);
            transform.parent.parent.GetChild(1).GetComponent<MoveScript>().isMoving = false;
            transform.parent.parent.GetComponent<PresidentKostyl>()?.EnableCollider();
            GetComponent<ParticleSystem>()?.Emit(30);
        }
        if (collision.gameObject.CompareTag("Grenade"))
        {            
            joint.enabled = false;
            Destroy(collision.gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        joint.enabled = false;
        GetComponent<Rigidbody2D>().AddForce((transform.position - other.transform.position)*30, ForceMode2D.Impulse);
    }
}
