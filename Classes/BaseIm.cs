using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECL.Classes
{
    class BaseIm
    {
        public UInt16 command;
        public UInt32 status;
        public bool commandFault;

		//statusSet:smartPack:=(status:=status);	
		//objectTable:TableDescriptor;
		//_logTwoCommands:AloneLogMessage;
	
		private UInt16 _command =0;
		private bool _haveCommand;
		private uint _cmd;
		private uint _source;
		private uint _error;
		private bool _needResetCmd;
		private bool _opcCommandsDisabled = false;

		//_errorReset:TON:=(PT:=T#15S);
		//_cmdReset:TON:=	(PT:=T#1S);

		


    }
}
