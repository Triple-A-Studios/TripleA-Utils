using UnityEngine;

namespace Utils.TripleA.ImprovedTimer.Timers
{
	/// <summary>
	///     A timer that counts up from a 0 to a specified value.
	/// </summary>
	public class CountUpTimer : Timer
	{
		private float m_finalTime;
		
		/// <summary>
		///		Initializes a new instance of the <see cref="CountUpTimer" /> class.
		/// </summary>
		/// <param name="finalTime">Time from which to start.</param>
		/// <param name="digitsAfterDecimal">The number of digits after the decimal point to get an update of tick.</param>
		public CountUpTimer(float finalTime, float? digitsAfterDecimal = null) : base(0, digitsAfterDecimal)
		{
			m_finalTime = finalTime;
		}

		public override bool IsFinished { get; protected set; }

		public override void Tick()
		{
			if (IsRunning && CurrentTime <= m_finalTime)
			{
				CurrentTime += Time.deltaTime;
				_tickUpdateTime += Time.deltaTime;
				if (_tickUpdateTime >= _tickUpdateThreshold)
				{
					_tickUpdateTime -= _tickUpdateThreshold;
					onTimerUpdate?.Invoke(this.CurrentTime);
				}
			}
			if (IsRunning && CurrentTime >= m_finalTime)
			{
				IsFinished = true;
				onTimerUpdate?.Invoke(m_finalTime);
				Stop();
			}
		}
		
		/// <summary>
		///     Gets the progress of the timer in increasing sense.
		///     i.e. if the timer has started at 10 seconds and 3 seconds have passed,
		///		this will return 0.3.
		///		after one more second has passed, it will return 0.4. and so on.
		/// </summary>
		public override float Progress()
		{
			if (m_finalTime == 0) return 0;
			return Mathf.Clamp01(CurrentTime / m_finalTime);
		}
		
		/// <summary>
		///     Gets the progress of the timer in decreasing sense.
		///     i.e. if the timer has started at 10 seconds and 3 seconds have passed,
		///		this will return 0.7.
		///		after one more second has passed, it will return 0.6. and so on.
		/// </summary>
		public float ProgressInverse()
		{
			if (m_finalTime == 0) return 0;
			return Mathf.Clamp01((m_finalTime - CurrentTime) / m_finalTime);
		}

		public override void Reset(float finalTime)
		{
			base.Reset(0f);
			m_finalTime = finalTime;
		}
	}
}