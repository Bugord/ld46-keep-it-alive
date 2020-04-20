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
    [CreateAssetMenu(fileName = "FirstLevelCasulRestart", menuName = "LevelCasulRestart")]
    class FirstLevelCasulRestart : LevelScript
    {
        public FirstLevelCasulRestart()
        {
            Commands = new List<BaseCommand>
            {

                //initial camera roll from center to start
                new MoveCameraCommand(true, new Vector2(0, 5.23f), 5f),
                new WaitCommand(2000),

                new MoveToCommand
                {
                    Index = 0,
                    TargetPosition = new Vector2(-1.8f, 6.27f),
                    Speed = 1.5f
                },
                new MoveToCommand
                {
                    Index = 1,
                    TargetPosition = new Vector2(1.8f, 6.27f),
                    Speed = 1.5f
                },
                new WaitCommand(2000),

                new StartHeliScript(),

                new WaitCommand(2500),
                new SpawnPresident(),
                new WaitCommand(1000),

                new SpeakCommand(),

                new WaitCommand(1500),

                new ShootCommand(0, WeaponType.Bullet),

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

                new WaitCommand(2000),
                
                //2 guards start moving
              
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
                //new ShootCommand(0, WeaponType.Bullet),

               new MoveByWaypointsCommand(
                   false,
                   2,
                   new List<Vector2>
                   {
                       new Vector2(-0.89f, 0.19f),
                       new Vector2(1f, -5.75f)
                   }),
                new WaitCommand(2000),
                
                //shooter 2 start shoot 1 time
                new WaitCommand(2500),
                new WaitCommand(1000),
                new ShootCommand(1, WeaponType.Grenade),
                new WaitCommand(1000),
                
                //guard 4 arrives
                new MoveByWaypointsCommand(
                    false,
                    3,
                    new List<Vector2>
                    {
                        new Vector2(0.89f, -1.19f),
                        new Vector2(1f, -5.75f)
                    }),
                new WaitCommand(2000),
                new MoveByWaypointsCommand(
                    false,
                    4,
                    new List<Vector2>
                    {
                        new Vector2(-0.89f, 0f),
                        new Vector2(1f, -5.75f)
                    }),
                new MoveByWaypointsCommand(
                    false,
                    5,
                    new List<Vector2>
                    {
                        new Vector2(-0.89f, -1f),
                        new Vector2(0.9f, -5.75f)
                    }),
                // shooter 3 start shoot 1 time
                new WaitCommand(2000),
                // 2 from left
              
                new WaitCommand(500),




                new ShootCommand(2, WeaponType.Bullet),


                new WaitCommand(500),
                new WaitCommand(4000),
                new ShootCommand(4, WeaponType.Bullet),
                //new ShootCommand(5, WeaponType.Bullet),

                new MoveByWaypointsCommand(
                    false,
                    6,
                    new List<Vector2>
                    {
                        new Vector2(0.89f, -3f),
                        new Vector2(.9f, -5.75f)
                    }),
                new MoveByWaypointsCommand(
                    false,
                    7,
                    new List<Vector2>
                    {
                        new Vector2(0.89f, -5f),
                        new Vector2(1.1f, -5.75f)
                    }),
                new WaitCommand(3000),

                new ShootCommand(6, WeaponType.Grenade),

                new MoveByWaypointsCommand(
                    false,
                    8,
                    new List<Vector2>
                    {
                        new Vector2(0.89f, -5f),
                        new Vector2(1.1f, -5.65f)
                    }),
                new WaitCommand(1000),
                new MoveByWaypointsCommand(
                    false,
                    9,
                    new List<Vector2>
                    {
                        new Vector2(-0.89f, -5f),
                        new Vector2(1.2f, -5.75f)
                    }),
                new MoveByWaypointsCommand(
                    false,
                    10,
                    new List<Vector2>
                    {
                        new Vector2(-0.89f, -5f),
                        new Vector2(1.2f, -5.75f)
                    }),

                new WaitCommand(3000),
                new ShootCommand(7, WeaponType.Bullet),

                new WaitCommand(4000),
                //new ShootCommand(8, WeaponType.Bullet),
                new WaitCommand(5000),
                new ShootCommand(9, WeaponType.Bullet),
                new WaitCommand(7000),
                new StartCarScript(),
                new WaitCommand(2000),
                new MoveToCommand
                {
                    IsPresident = true,
                    TargetPosition = new Vector2(1.768f, 33.287f),
                    Speed = 15
                },
                new WaitCommand(5000),
                new LastLevelCommand()

            };

        }
    }
}
