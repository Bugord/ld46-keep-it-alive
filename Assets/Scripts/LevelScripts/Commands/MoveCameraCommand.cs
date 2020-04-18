using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LevelScripts
{
    public class MoveCameraCommand : BaseCommand
    {
        public bool Move;
        public Vector2 TargetPosition;
        public float Speed;

        public MoveCameraCommand(bool move, Vector2 targetPosition, float speed)
        {
            Move = move;
            TargetPosition = targetPosition;
            Speed = speed;
        }
    }
}
