using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LevelScripts.Commands
{
    public class SetAimingCommand : BaseCommand
    {
        public int Index;
        public bool IsActive;

        public SetAimingCommand(int index, bool isActive)
        {
            Index = index;
            IsActive = isActive;
        }
    }
}
