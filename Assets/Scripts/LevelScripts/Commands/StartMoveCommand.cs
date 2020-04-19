using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LevelScripts
{
    class MoveToCommand : BaseCommand
    {
        public bool IsPresident;
        public int Index;
        public Vector2 TargetPosition;
        public float Speed = 0.3f;
    }
}
