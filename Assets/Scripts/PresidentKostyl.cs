using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PresidentKostyl : MonoBehaviour
{
    [SerializeField] private BoxCollider2D collider;
    [SerializeField] private LevelRestartManager _levelRestartManager;

    public GameObject shadow;

    private bool wasRestarted;

    private void Start()
    {
        _levelRestartManager = FindObjectOfType<LevelRestartManager>();
    }

    public bool isDead;
    public void EnableCollider()
    {
        isDead = true;
        collider.enabled = true;

        transform.GetChild(0).GetChild(0).GetComponent<HingeJoint2D>().enabled = false;

        shadow.SetActive(false);

        if (!wasRestarted)
        {
            wasRestarted = true;
            StartCoroutine(RestartGame());
        }
    }

    private IEnumerator RestartGame() 
    {
        yield return new WaitForSeconds(3);

        if (SceneManager.GetActiveScene().name != "Level2")
        {
            _levelRestartManager.ResetLevel();
        }
    }
}
