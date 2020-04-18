using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LevelScripts.Commands
{
    class MoveByWaypointsCommand : BaseCommand
    {
        public bool IsPresident;
        public int Index;
        public List<Vector2> Points;

        public MoveByWaypointsCommand(bool isPresident, int index, List<Vector2> points)
        {
            IsPresident = isPresident;
            Index = index;
            Points = points;
        }
    }
}
