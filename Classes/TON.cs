using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ECL.Classes
{
	public class TON
	{
		private Timer timer;
				
		public TON()
		{
			timer = new Timer(4000) { AutoReset = false };
			timer.Elapsed += timerElapsed;
		}

		public TON(double delay)
		{
			timer = new Timer(delay) { AutoReset = false };
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
		public bool In { get; set; }

		public bool Q { get; private set;}

		public void Start()
		{
			if (In)
			{
				timer.Stop();
				timer.Start();
			}
			else timer.Stop();
		}

		public void Start(bool input)
		{
			In = input;
			Start();
		}

		public void Start(int time)
		{
			Delay = time;
			Start();
		}

		public void Reset()
		{
			In = false;
			timer.Stop();
		}

		private void timerElapsed(object source, ElapsedEventArgs e)
		{
			if (In) Q = true;
			else Q = false;
		}
	}
}
