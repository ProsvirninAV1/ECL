using ECL.Classes;
using System;

namespace ECL
{
    class Program
    {
        static void Main(string[] args)
        {
            ReliableBit On = new() { value = true };
            ReliableBit Off = new() { value = false };

            DualStateIm dualStateIm = new(ref On, ref Off);
            dualStateIm.Set();

            Console.WriteLine(dualStateIm.OnStatus);
           

            

        }
    }
}
