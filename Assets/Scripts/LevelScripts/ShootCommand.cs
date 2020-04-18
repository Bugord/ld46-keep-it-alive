using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LevelScripts
{
    public class ShootCommand : BaseCommand
    {
        public int ShooterIndex;
        public WeaponType WeaponType;
    }

    public enum WeaponType
    {
        Bullet
    }
}
