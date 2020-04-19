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
            new MoveCameraCommand(true, new Vector2(0, 5.23f), 5f),
            new WaitCommand(2000),
            new StartCarScript(),
            new WaitCommand(3000),
            new SpawnPresident(),
            new WaitCommand(1000),            
        };
    }
}
