using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                new ShootCommand
                {
                    CommandType = CommandType.Shoot,
                    WeaponType = WeaponType.Bullet,
                    ShooterIndex = 0
                },
                new WaitCommand
                {
                    CommandType = CommandType.Sleep,
                    TimeToWait = 2000
                },
                new ShootCommand
                {
                CommandType = CommandType.Shoot,
                WeaponType = WeaponType.Bullet,
                ShooterIndex = 0
            },
            };
        }
    }
}
