using ECL.Classes;
using System;

namespace ECL
{
    class Program
    {
        static void Main(string[] args)
        {
            ReliableBit? On = new() { value = false, reliability = true };
            ReliableBit? Off = new() { value = true, reliability = true };

            bool? CommandOn = false;
            bool? CommandOff = false;

            ////DualStateIm dualStateIm = new(ref On, ref Off);
            ////DualStateIm dualStateIm2 = new(ref On, null);

            DualStateIm dualStateIm = new() { statOn = On, statOff = Off, CmdOn = CommandOn, CmdOff = CommandOff };
            //DualStateIm dualStateIm2 = new() { statOn = null, statOff = Off };

            //dualStateIm.Set();
            //dualStateIm2.Set();

            //Console.WriteLine(dualStateIm.OnStatus);
            //Console.WriteLine(dualStateIm.Status);

            //Console.WriteLine(dualStateIm2.OnStatus);
            //Console.WriteLine(dualStateIm2.Status);

            //DualStateSwitch dualStateSwitch = new DualStateSwitch();
            //dualStateSwitch.Set();



            //TON ton = new TON(4000);
            //ton.In = true;
            //ton.Start();
            //while (true)
            //{
            //    Console.WriteLine($"{ton.In} {ton.Q}");
            //}
            
            
            



        }
    }
}
