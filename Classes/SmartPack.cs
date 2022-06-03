using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECL.Classes
{
    class SmartPack
    {
        ref UInt32 status;
        public UInt32 settedBits;
        public string name;

        

        private void Reset() => settedBits = 0;
        private void SetBit(UInt16 bitNum, bool value) => SetBits(bitNum, (uint)value);
        

    }
}
