using System;
using UnityEngine;

namespace TripleA.ImprovedTimer
{
	public abstract class Timer : IDisposable
	{
		protected float _initialTime;

		private bool m_disposed;

		public Action onTimerEnd = delegate { };
		public Action onTimerStart = delegate { };

		public Timer(float value)
		{
			_initialTime = value;
		}

		public float CurrentTime { get; protected set; }
		public bool IsRunning { get; private set; }

		public float Progress => Mathf.Clamp01(CurrentTime / _initialTime);
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

		public void Reset()
		{
			CurrentTime = _initialTime;
			IsRunning = false;
			IsFinished = false;
		}

		public void Reset(float value)
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
		/// </summary
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