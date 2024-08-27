using UnityEngine;

namespace Utils.TripleA.ImprovedTimer.Timers
{
	/// <summary>
	///     Timer that counts up from zero to infinity.  Great for measuring durations.
	/// </summary>
	public class StopwatchTimer : Timer
	{
		/// <summary>
		///		Initializes a new instance of the <see cref="StopwatchTimer" /> class.
		/// </summary>
		/// <param name="digitsAfterDecimal">digits after the decimal point to get an update of tick</param>
		public StopwatchTimer(float? digitsAfterDecimal = null) : base(0, digitsAfterDecimal)
		{
		}

		public override bool IsFinished { get; protected set; }

		public override float Progress() => 1f;

		public override void Tick()
		{
			if (!IsRunning) return;
			CurrentTime += Time.deltaTime;
			_tickUpdateTime += Time.deltaTime;
			if (_tickUpdateTime >= _tickUpdateThreshold)
			{
				_tickUpdateTime -= _tickUpdateThreshold;
				onTimerUpdate?.Invoke(this.CurrentTime);
			}
		}
	}
}