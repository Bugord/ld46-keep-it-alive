using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresidentKostyl : MonoBehaviour
{
   [SerializeField] private BoxCollider2D collider;

   public bool isDead;
   public void EnableCollider()
   {
      isDead = true;
      collider.enabled = true;
   }
}
