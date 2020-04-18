﻿using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.LevelScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<EnemyScript> Enemies;
    public GameObject President;
    public List<GameObject> Guards;

    [SerializeField] private Scrollbar _scrollbar;

    public float TimeScale;

    public int GuardsJumped;

    public static GameManager Instance => GameObject.Find("GameManager").GetComponent<GameManager>();

    public LevelProcessor LevelProcessor;

    void Awake()
    {
        
    }

    public void Shoot()
    {
        LevelProcessor.Launch();
        //foreach (var enemy in Enemies)
        //{
        //    enemy.GetComponent<EnemyScript>().Shoot();
        //}
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnGuardJump()
    {
        GuardsJumped++;
        if (GuardsJumped == Guards.Count)
        {
            //TimeScale = .3f;
        }
    }

    public void OnTimeScaleChange()
    {
        TimeScale = _scrollbar.value;
    }
    
}
