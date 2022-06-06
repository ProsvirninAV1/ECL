using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ECL.Classes
{
	public partial class CmdTimer
	{
		private Timer timer = new Timer(4000) { AutoReset = false };

		public CmdTimer(double delay)
		{
			Delay = delay; 
			timer.Elapsed += timerElapsed;
		}

		public double Delay
		{
			get
			{
				return timer.Interval;
			}
			set
			{
				timer.Interval = value;
			}
		}

		public delegate void TimerDelegate();

		private TimerDelegate elapseProc;

		public void start(TimerDelegate onElapsed)
		{
			elapseProc = onElapsed;
			timer.Stop();
			timer.Start();
		}

		public void reset()
		{
			timer.Stop();
		}

		private void timerElapsed(object source, ElapsedEventArgs e)
		{
			if (elapseProc != null)
			{
				elapseProc();
			}
		}
	}
}
