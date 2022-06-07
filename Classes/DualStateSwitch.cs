using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECL.Classes
{
    class DualStateSwitch: DualStateIm
    {
        public int commandTime = 5000;
        public int waitStatus = 5000;

        public const uint cmd_on = 1;
        public const uint cmd_off = 2;

        public void Set()
        {
            base.Set();
        }

        public void On()
        {
            SetCmd(cmd_on);
        }
    }

    
}
