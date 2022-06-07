using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECL.Classes
{
    class SmartPack
    {
        //private uint _status;
        public UInt32 Status { get; set; }
        public uint settedBits;
        public string name;
               

        public SmartPack(ref uint status)
        {
            Status = status;
        }
        public SmartPack(uint status)
        {
            Status = status;
        }



        public void Reset() => settedBits = 0;
        public void SetBit(int bitNum, bool nvalue) => SetBits(bitNum, bitNum, nvalue ? 1u : 0u);
        public void SetBits(int start, int end, uint nvalue)
        {
            int bitsCount = end - start + 1;
            UInt32 valueMask = (((UInt32)1 << bitsCount) - 1) << start;
            Status = ((Status & ~valueMask) | ((nvalue << start) & valueMask));
        }


    }
}
