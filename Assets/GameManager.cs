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

    public HeliScript HeliScript;
    public CarScript CarScript;

    public float TimeScale;

    public int GuardsJumped;

    public static GameManager Instance;

    public LevelProcessor LevelProcessor;

    public GameObject endCanvas;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level2")
            Shoot();
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
    }
    
}
