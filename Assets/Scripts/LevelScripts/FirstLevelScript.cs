using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.LevelScripts.Commands;
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
                new MoveCameraCommand(true, new Vector2(0, 5.23f), 5f),
                new WaitCommand(1000),
                new SetAimingCommand(0, true),
                new WaitCommand(1000),
                new MoveByWaypointsCommand(
                    false,
                    0,
                    new List<Vector2>
                    {
                        new Vector2(-1f, 5.75f),
                        new Vector2(-1f, -5.75f)
                    }),
                new MoveByWaypointsCommand(
                    false,
                    1 , 
                    new List<Vector2>
                    {
                        new Vector2(1f, 5.75f),
                        new Vector2(1f, -5.75f)
                    }),
                new WaitCommand(1000),
                new MoveToCommand
                {
                    IsPresident = true,
                    TargetPosition = new Vector2(0.17f, -15f)
                },
                new WaitCommand(4000),
                new MoveCameraCommand(true, new Vector2(0, -5.28f), .3f),
                new WaitCommand(2000),
                new ShootCommand(0, WeaponType.Bullet),
                new WaitCommand(2000),
                new ShootCommand(0, WeaponType.Bullet),
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
                new WaitCommand(2500),
                new SetAimingCommand(1, true),
                new WaitCommand(1000),
                new ShootCommand(1, WeaponType.Bullet),
                new WaitCommand(1000),
                new SetAimingCommand(1, false),


            };
        }
    }
}
