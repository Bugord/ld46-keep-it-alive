using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.LevelScripts.Commands;
using LevelScripts.Commands;
using UnityEngine;

namespace Assets.Scripts.LevelScripts
{
    [CreateAssetMenu(fileName = "FirstLevel", menuName = "Level")]
    public class FirstLevelScript : LevelScript
    {
        public FirstLevelScript()
        {
            Commands = new List<BaseCommand>
            {

                //initial camera roll from center to start
                new SpawnPresident(),
                new MoveCameraCommand(true, new Vector2(0, 5.23f), 5f),
                
                new WaitCommand(2000),
                
                new SpeakCommand(),

                // new StartHeliScript(),
                
                new WaitCommand(2000),

                //shooter 1 start aiming
                new ShootCommand(0, WeaponType.Bullet),

                new WaitCommand(1000),
                
                //2 guards start moving
                new MoveByWaypointsCommand(
                    false,
                    0,
                    new List<Vector2>
                    {
                        new Vector2(-1f, 5.95f),
                        new Vector2(-1f, -5.75f)
                    }),
                new MoveByWaypointsCommand(
                    false,
                    1 , 
                    new List<Vector2>
                    {
                        new Vector2(1f, 5.95f),
                        new Vector2(1f, -5.75f)
                    }),
                new WaitCommand(1000),
                
                //president start run
                new MoveToCommand
                {
                    IsPresident = true,
                    TargetPosition = new Vector2(0.17f, -15f)
                },
                new WaitCommand(4000),
                
                //main camera roll
                new MoveCameraCommand(true, new Vector2(0, -5.28f), .3f),
                
                //shooter 1 shoots 2 times
                new ShootCommand(0, WeaponType.Bullet),
                
                //guard 3 arrives
                new MoveByWaypointsCommand(
                    false, 
                    2, 
                    new List<Vector2>
                    {
                        new Vector2(-1.3f, 0.61f),
                        new Vector2(-1f, -5.75f)
                    }),
                new WaitCommand(2000),
                new SetAimingCommand(0, false),
                
                //shooter 2 start shoot 1 time
                new WaitCommand(2500),
                new SetAimingCommand(1, true),
                new WaitCommand(1000),
                new ShootCommand(1, WeaponType.Bullet),
                new WaitCommand(1000),
                new SetAimingCommand(1, false),
                
                //guard 4 arrives
                new MoveByWaypointsCommand(
                    false, 
                    2, 
                    new List<Vector2>
                    {
                        new Vector2(-0.89f, 1.19f),
                        new Vector2(1f, -5.75f)
                    }),
                new WaitCommand(2000),
                new SetAimingCommand(0, false),
                
                // shooter 3 start shoot 1 time
                new WaitCommand(1000),
                new SetAimingCommand(2, true),
                new WaitCommand(500),
                new ShootCommand(2, WeaponType.Bullet),
                new WaitCommand(500),
                new SetAimingCommand(2, false),

        
            };
        }
    }
}
