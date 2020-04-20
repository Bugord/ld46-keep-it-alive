using Assets.Scripts.LevelScripts;
using LevelScripts.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LastLevel", menuName = "LastLevel")]
public class LastLevelScript : LevelScript
{
    public LastLevelScript()
    {
        Commands = new List<BaseCommand>
        {            
            new StartCarScript(),
            new WaitCommand(3000),
            new SpawnPresident(),
            new SpeakCommand(),
            new WaitCommand(1000),   
            //president start run
            new MoveToCommand
            {
                IsPresident = true,
                TargetPosition = new Vector2(0, 9.61f)
            },
            new WaitCommand(1500),
            new MoveCameraCommand(true, new Vector2(0, 33.52f), 10f),
            new WaitCommand(1500),
            new MoveToCommand
            {
                IsPresident = true,
                TargetPosition = new Vector2(1.768f, 33.287f),
                Speed = 15
            },
            new WaitCommand(4000),
            new MoveToCommand
            {
                IsPresident = true,
                TargetPosition = new Vector2(1.768f, 33f)
            },
        };
    }
}
