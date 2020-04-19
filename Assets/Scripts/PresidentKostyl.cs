using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresidentKostyl : MonoBehaviour
{
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private LevelRestartManager _levelRestartManager;

    private void Start()
    {
        _levelRestartManager = FindObjectOfType<LevelRestartManager>();
    }

    public bool isDead;
    public void EnableCollider()
    {
        isDead = true;
        collider.enabled = true;

        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame() 
    {
        yield return new WaitForSeconds(3);

        _levelRestartManager.ResetLevel();
    }
}
