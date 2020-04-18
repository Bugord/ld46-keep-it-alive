using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadColliderScript : MonoBehaviour
{
    public Transform RagdollTransform;

    void Update()
    {
        transform.position = new Vector3(RagdollTransform.transform.position.x, transform.position.y);
    }
}
