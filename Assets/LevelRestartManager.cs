using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.LevelScripts;
using UnityEngine;
using Random = UnityEngine.Random;

public enum PrefabType
{
    guard,
    president
}

[Serializable]
public struct SpawnPositions
{
    public Vector3 Position;
    public PrefabType PrefabType;
}

public class LevelRestartManager : MonoBehaviour
{
    public List<SpawnPositions> SpawnPositions;
    public List<SpawnPositions> RestartSpawnPositions;

    [SerializeField] private bool _isFirstLoad = true;
    private GameManager _gameManager;

    public GameObject GuardPrefab;
    public GameObject PresidentPrefab;

    public FirstLevelScript FirstLevelScript;
    public FirstLevelRestartScript FirstLevelRestartScript;

    private List<GameObject> lastRestartGuards = new List<GameObject>();
    
    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    public void ResetLevel()
    {
        if (_isFirstLoad)
        {
            _isFirstLoad = false;
            
            _gameManager.Guards.Clear();

            _gameManager.LevelProcessor.LevelScript = FirstLevelScript;
            
            foreach (var spawnPosition in SpawnPositions)
            {
                switch (spawnPosition.PrefabType)
                {
                    case PrefabType.guard:
                        var guard = Instantiate(GuardPrefab, spawnPosition.Position, Quaternion.identity);
                        _gameManager.Guards.Add(guard);
                        break;
                    case PrefabType.president:
                        var president = Instantiate(PresidentPrefab, spawnPosition.Position, Quaternion.identity);
                        _gameManager.President = president;
                        break;
                }
            }
            
            _gameManager.Shoot();
        }
        else
        {
            for (int i = 0; i < lastRestartGuards.Count; i++)
            {
                Destroy(lastRestartGuards[i], 300);
            }

            foreach (var enemy in _gameManager.Enemies)
            {
                enemy.Reset();
            }
            
            lastRestartGuards = new List<GameObject>();
            foreach (var guard in _gameManager.Guards)
            {
                if (!guard.transform.GetChild(1).GetComponent<ThrowScript>().IsDead)
                {
                    guard.transform.GetChild(1).GetComponent<MoveScript>().MoveTo(new Vector3(20 * (Random.Range(1, 2) == 1 ? -1 : 1), guard.transform.position.y), 3f);
                    Destroy(guard, 5);
                    continue;
                }

                if (!_gameManager.President.GetComponent<PresidentKostyl>().isDead)
                {
                    _gameManager.President.transform.GetChild(1).GetComponent<MoveScript>().MoveTo(new Vector3(20 * (Random.Range(1, 2) == 1 ? -1 : 1), guard.transform.position.y), 3f);
                }
                    
                Destroy(_gameManager.President);
                
                lastRestartGuards.Add(guard);
                Destroy(guard.transform.GetChild(1).gameObject);
                var ragdoll = guard.transform.GetChild(0);
                foreach (var componentsInChild in ragdoll.GetComponentsInChildren<Rigidbody2D>())
                {
                    componentsInChild.bodyType = RigidbodyType2D.Static;
                }
                foreach (var componentsInChild in ragdoll.GetComponentsInChildren<Collider2D>())
                {
                    componentsInChild.enabled = false;
                }
                foreach (var componentsInChild in ragdoll.GetComponentsInChildren<DestructionScript>())
                {
                    componentsInChild.enabled = false;
                }
                
            }
            
            _gameManager.Guards.Clear();

            _gameManager.LevelProcessor.LevelScript = FirstLevelRestartScript;
            
            foreach (var spawnPosition in RestartSpawnPositions)
            {
                switch (spawnPosition.PrefabType)
                {
                    case PrefabType.guard:
                        var guard = Instantiate(GuardPrefab, spawnPosition.Position, Quaternion.identity);
                        _gameManager.Guards.Add(guard);
                        break;
                    case PrefabType.president:
                        var president = Instantiate(PresidentPrefab, spawnPosition.Position, Quaternion.identity);
                        _gameManager.President = president;
                        break;
                }
            }
            
            _gameManager.Shoot();
        }
    }
}
