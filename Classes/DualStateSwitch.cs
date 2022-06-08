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

        protected TON statusErrorTimer;
        protected TON resetOutputs;

        public new void Set()
        {
            base.Set();
        }

        public new void On()
        {
            SetCmd(cmd_on);
            statusErrorTimer.Reset();
            statusErrorTimer.In = true;
            resetOutputs.Reset();
            resetOutputs.In = true;
            base.On();
        }
        public new void Off()
        {
            SetCmd(cmd_off);
            statusErrorTimer.Reset();
            statusErrorTimer.In = true;
            resetOutputs.Reset();
            resetOutputs.In = true;
            base.Off();
        }

        private bool ResetOutputs()
        {
            resetOutputs.Start(commandTime);
            if (resetOutputs.Q) return true;
            else return false;
            ResetOuts();
        }
    }

    
}
