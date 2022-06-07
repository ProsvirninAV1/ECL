using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECL.ENUM;

namespace ECL.Classes
{
    class DualStateIm: BaseIm
    {
        public ReliableBit statOn { get; set; }
        public ReliableBit statOff { get; set; }

        public bool? CmdOn;
        public bool? CmdOff;

        private int _lastCmd;
        private StatusDualInput _lastStatus;

        const int baseCmdOn = 1;
        const int baseCmdOff = 2;

        public StatusDualInput OnStatus { get; private set; }

        public DualStateIm()
        {
            //this.statOn = statOn;
            //this.statOff = statOff;
        }
        //public DualStateIm(ref ReliableBit? statOn, ref ReliableBit? statOff)
        //{
        //    this.statOn = statOn; 
        //    this.statOff =  statOff;
        //}

        public void Set()
        {
            OnStatus = GetStatus();
            WriteImStatus();
            _lastStatus = OnStatus;

            //base.Set();
        }

        public void On()
        {
            if (CmdOn != null)
            {
                CmdOn = true;

                if (CmdOff != null) CmdOff = false;
            }

            else if (CmdOff != null) CmdOff = false;

            _lastCmd = baseCmdOn;
        }

        public void Off()
        {
            if (CmdOff != null)
            {
                CmdOff = true;

                if (CmdOn != null) CmdOn = false;
            }

            else if (CmdOn != null) CmdOn = false;

            _lastCmd = baseCmdOn;
        }

        protected StatusDualInput GetStatus()

        {
            if (statOn != null && statOff != null) return CalcStatus(statOn.value, statOff.value, statOn.reliability && statOff.reliability);

                else if (statOn != null) return CalcStatus(statOn.value, !statOn.value, statOn.reliability);

                else if (statOff != null) return CalcStatus(!statOff.value, statOff.value, statOff.reliability);

                else return NoStatusLinks();
        }

        protected StatusDualInput NoStatusLinks()
        {
            if (_lastCmd == baseCmdOn) return StatusDualInput.STATUS_ON;

            else if (_lastCmd == baseCmdOff) return StatusDualInput.STATUS_OFF;

            else return StatusDualInput.STATUS_NOTDEFINED;
        }

        private StatusDualInput CalcStatus(bool statOn, bool statOff, bool reliability)
        {
            if (reliability)
            {
                if (statOn && !statOff) return StatusDualInput.STATUS_ON;

                else if (statOff && !statOn) return StatusDualInput.STATUS_OFF;

                else return StatusDualInput.STATUS_ERROR;
            }
            else return StatusDualInput.STATUS_NOTDEFINED;
        }

        private void WriteImStatus()
        {
            statusSet.SetBits(0, 2, (uint)OnStatus);

        }

        private void ResetOuts()
        {
            if (CmdOn != null && CmdOff != null)
            {
                CmdOn = false;
                CmdOff = false;
            }
        }

    }
}
