using UnityEngine;

namespace TripleA.ImprovedTimer.Timers
{
	/// <summary>
	///     Timer that counts up from zero to infinity.  Great for measuring durations.
	/// </summary>
	public class StopwatchTimer : Timer
	{
		public StopwatchTimer() : base(0)
		{
		}

		public override bool IsFinished { get; protected set; }

		public override void Tick()
		{
			if (IsRunning) CurrentTime += Time.deltaTime;
		}
	}
}