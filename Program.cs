using ECL.Classes;
using System;

namespace ECL
{
    class Program
    {
        static void Main(string[] args)
        {
            ReliableBit On = new();
            ReliableBit Off = new();

            DualStateIm dualStateIm = new(ref On);
            DualStateIm dualStateIm1 = new() { statOn = null, statOff =  Off };
            DualStateIm dualStateIm2 = new(null,  Off);
        }
    }
}
