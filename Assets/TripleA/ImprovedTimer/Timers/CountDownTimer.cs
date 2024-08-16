using UnityEngine;

namespace TripleA.ImprovedTimer.Timers
{
	/// <summary>
	///     A timer that counts down from a specified value to 0.
	/// </summary>
	public class CountDownTimer : Timer
	{
		public CountDownTimer(float value) : base(value)
		{
		}

		public override bool IsFinished { get; protected set; }

		public override void Tick()
		{
			if (IsRunning && CurrentTime >= 0) CurrentTime -= Time.deltaTime;
			if (IsRunning && CurrentTime <= 0)
			{
				IsFinished = true;
				Stop();
			}
		}
	}
}