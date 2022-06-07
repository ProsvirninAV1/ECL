using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECL.Classes
{
    class SmartPack
    {
        private uint _status;
        public string name;
               

        public SmartPack(ref uint status)
        {
            _status = status;
        }
        
        public void Reset() => SetBits(0, 31, 0);
        public void SetBit(int bitNum, bool nvalue) => SetBits(bitNum, bitNum, nvalue ? 1u : 0u);
        public void SetBits(int start, int end, uint nvalue)
        {
            int bitsCount = end - start + 1;
            UInt32 valueMask = (((UInt32)1 << bitsCount) - 1) << start;
            _status = ((_status & ~valueMask) | ((nvalue << start) & valueMask));
        }


    }
}
