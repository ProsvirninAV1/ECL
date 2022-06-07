using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECL.Classes
{
    class BaseIm
    {
		public MyClass myClass = new MyClass(Status);
        public UInt16 command;

		public uint Status { get; private set; } = new();

        public bool commandFault;

        public SmartPack statusSet;

		public BaseIm() {


			statusSet = new SmartPack(Status);
		
		}

        //objectTable:TableDescriptor;
        //_logTwoCommands:AloneLogMessage;

        private UInt16 _command =0;
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


    }
}
