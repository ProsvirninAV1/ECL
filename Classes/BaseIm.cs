using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECL.Classes
{
    class BaseIm
    {
		public uint command;
	    public bool commandFault;
        public SmartPack statusSet;

		public BaseIm()
		{
			statusSet = new SmartPack(ref _status);
		}

		private uint _status;
		private uint _command =0;
		private bool _haveCommand;
		private uint _cmd;
		private uint _source;
		private uint _error;
		private bool _needResetCmd;
		private bool _opcCommandsDisabled = false;

		private CmdTimer _errorReset = new CmdTimer(12000);
		private CmdTimer _cmdReset = new CmdTimer(1000);
		

		public void Set()
		{
			_haveCommand = false;
			statusSet.Reset();

			//_errorReset(IN:= (_error <> 0));

			_command = command;
			command = 0;


		}
		public uint Status { get => _status; }
		
		protected void SetCmd(uint nCmd)
		{
			_haveCommand = true;
			_cmd = nCmd;
			_error = 0;
			_cmdReset.reset();
			//_cmdReset.IN = true;
			_needResetCmd = false;
			WriteCommandToStatus();
        }

		private void WriteCommandToStatus()
		{
			statusSet.SetBits(23, 25, _error);
			statusSet.SetBits(26, 28, _cmd);
			statusSet.SetBits(29, 31, _source);
        }



	}
}
