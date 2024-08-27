using System;
using UnityEngine;

namespace Utils.TripleA.ImprovedTimer.Timers
{
	/// <summary>
	///     A timer that ticks at a specified number of ticks per second.
	/// </summary>
	public class FrequencyTimer : Timer
	{
		private float m_timeThreshold;
		public Action onTick = delegate { };

		/// <summary>
		///     Initializes a new instance of the <see cref="FrequencyTimer" /> class.
		/// </summary>
		/// <param name="ticksPerSecond">The number of ticks per second.</param>
		/// <param name="digitsAfterDecimal">The number of digits after the decimal point to get an update of tick.</param>
		public FrequencyTimer(int ticksPerSecond, float? digitsAfterDecimal = null) : base(0, digitsAfterDecimal)
		{
			CalculateTimeThreshold(ticksPerSecond);
		}

		public int TicksPerSecond { get; private set; }

		public override bool IsFinished { get; protected set; }

		public override void Tick()
		{
			
			if (IsRunning && CurrentTime < m_timeThreshold)
			{
				_tickUpdateTime += Time.deltaTime;
				CurrentTime += Time.deltaTime;
			}
			if (IsRunning && CurrentTime >= m_timeThreshold)
			{
				CurrentTime -= m_timeThreshold;
				onTick.Invoke();
			}
			
			if (IsRunning && _tickUpdateTime >= _tickUpdateThreshold)
			{
				_tickUpdateTime -= _tickUpdateThreshold;
				onTimerUpdate?.Invoke(this.CurrentTime);
			}
		}

		public override void Reset()
		{
			base.Reset();
			CurrentTime = 0;
		}

		public override float Progress() => 1.0f;

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