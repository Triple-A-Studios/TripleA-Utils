using System;
using UnityEngine;

namespace TripleA.ImprovedTimer.Timers
{
	/// <summary>
	///     A timer that ticks at a specified number of ticks per second.
	/// </summary>
	public class FrequencyTimer : Timer
	{
		private float m_timeThreshold;
		public Action onTick = delegate { };

		public FrequencyTimer(int ticksPerSecond) : base(0)
		{
			CalculateTimeThreshold(ticksPerSecond);
		}

		public int TicksPerSecond { get; private set; }

		public override bool IsFinished { get; protected set; }

		public override void Tick()
		{
			if (IsRunning && CurrentTime >= m_timeThreshold)
			{
				CurrentTime -= m_timeThreshold;
				onTick.Invoke();
			}

			if (IsRunning && CurrentTime < m_timeThreshold) CurrentTime += Time.deltaTime;
		}

		public override void Reset()
		{
			CurrentTime = 0;
		}

		public void Reset(int newTicksPerSecond)
		{
			CalculateTimeThreshold(newTicksPerSecond);
			Reset();
		}

		private void CalculateTimeThreshold(int ticksPerSecond)
		{
			TicksPerSecond = ticksPerSecond;
			m_timeThreshold = 1f / TicksPerSecond;
		}
	}
}