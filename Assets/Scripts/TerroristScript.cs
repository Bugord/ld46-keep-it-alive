using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerroristScript : MonoBehaviour
{
    public NPCTemplate _npcTemplate;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_npcTemplate.isDead) 
        {
            _npcTemplate.isDead = true;
            transform.SetParent(collision.transform);
            GetComponentsInChildren<Rigidbody2D>().ToList().ForEach(f => f.bodyType = RigidbodyType2D.Dynamic);
            GetComponentsInChildren<GrenadeScript>().ToList().ForEach(g => g.ThrowGrenade(g.transform.position, g.transform.position, 0));
        }                
    }    
}
