using UnityEngine;

namespace Utils.TripleA.ImprovedTimer.Timers
{
	/// <summary>
	///     A timer that counts down from a specified value to 0.
	/// </summary>
	public class CountDownTimer : Timer
	{
		/// <summary>
		///		Initializes a new instance of the <see cref="CountDownTimer" /> class.
		/// </summary>
		/// <param name="initialTime">Time from which to start.</param>
		/// <param name="digitsAfterDecimal">The number of digits after the decimal point to get an update of tick.</param>
		public CountDownTimer(float initialTime, float? digitsAfterDecimal = null) : base(initialTime, digitsAfterDecimal)
		{
		}

		public override bool IsFinished { get; protected set; }

		/// <summary>
		///     Gets the progress of the timer in decreasing sense.
		///     i.e. if the timer has started at 10 seconds and 3 seconds have passed,
		///		this will return 0.7.
		///		after one more second has passed, it will return 0.6. and so on.
		/// </summary>
		public override float Progress()
		{
			if (_initialTime == 0) return 0;
			return Mathf.Clamp01(CurrentTime / _initialTime);
		}

		/// <summary>
		///     Gets the progress of the timer in increasing sense.
		///     i.e. if the timer has started at 10 seconds and 3 seconds have passed,
		///		this will return 0.3.
		///		after one more second has passed, it will return 0.4. and so on.
		/// </summary>
		public float ProgressInverse()
		{
			if (_initialTime == 0) return 0;
			return Mathf.Clamp01((_initialTime - CurrentTime) / _initialTime);
		}

		public override void Tick()
		{
			if (IsRunning && CurrentTime >= 0)
			{
				CurrentTime -= Time.deltaTime;
				_tickUpdateTime += Time.deltaTime;
				if (_tickUpdateTime >= _tickUpdateThreshold)
				{
					_tickUpdateTime -= _tickUpdateThreshold;
					onTimerUpdate?.Invoke(this.CurrentTime);
				}
			}
			if (IsRunning && CurrentTime <= 0)
			{
				IsFinished = true;
				onTimerUpdate?.Invoke(0);
				Stop();
			}
		}
	}
}