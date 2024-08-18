using System;
using UnityEngine;

namespace TripleA.ImprovedTimer
{
	public abstract class Timer : IDisposable
	{
		protected float _initialTime;
		protected float _tickUpdateThreshold;
		protected float _tickUpdateTime;

		private bool m_disposed;

		public Action<float> onTimerUpdate = delegate { };
		public Action onTimerEnd = delegate { };
		public Action onTimerStart = delegate { };

		public Timer(float initialTime, float? digitsAfterDecimal = null)
		{
			_initialTime = initialTime;
			CalculateTickUpdateThreshold(digitsAfterDecimal);
		}

		private void CalculateTickUpdateThreshold(float? tickUpdateThreshold = null)
		{
			if (tickUpdateThreshold == null) _tickUpdateThreshold = 0;
			else
			{
				float power = -1 * (float)tickUpdateThreshold;
				_tickUpdateThreshold = Mathf.Pow(10, power);
			}
		}

		public float CurrentTime { get; protected set; }
		public bool IsRunning { get; private set; }

		public abstract float Progress();


		public abstract bool IsFinished { get; protected set; }

		// call this to ensure deregistration of the timer
		// when it is no longer needed
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public abstract void Tick();

		public void Start()
		{
			CurrentTime = _initialTime;
			onTimerStart?.Invoke();

			if (IsRunning) return;
			IsRunning = true;
			IsFinished = false;
			TimerManager.RegisterTimer(this);
		}

		public void Pause()
		{
			IsRunning = false;
		}

		public void Resume()
		{
			IsRunning = true;
		}

		public virtual void Reset()
		{
			CurrentTime = _initialTime;
			IsRunning = false;
			IsFinished = false;
		}

		public virtual void Reset(float value)
		{
			_initialTime = value;
			Reset();
		}

		public void Stop()
		{
			if (!IsRunning) return;
			IsRunning = false;
			TimerManager.DeregisterTimer(this);
			onTimerEnd?.Invoke();
		}

		/// <summary>
		///     Disposes of the timer.
		/// </summary>
		public virtual void Dispose(bool isDisposing)
		{
			if (m_disposed) return;
			if (isDisposing) TimerManager.DeregisterTimer(this);
			m_disposed = true;
		}

		~Timer()
		{
			Dispose(false);
		}
	}
}