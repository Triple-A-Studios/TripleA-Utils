using System.Collections.Generic;
using Utils.TripleA.Extensions;

namespace Utils.TripleA.ImprovedTimer
{
	public static class TimerManager
	{
		private static readonly List<Timer> m_S_Timers = new();
		private static readonly List<Timer> m_S_Sweep = new();

		/// <summary>
		///     Registers a timer with the TimerManager.
		/// </summary>
		/// <param name="timer">The timer to register.</param>
		public static void RegisterTimer(Timer timer)
		{
			m_S_Timers.Add(timer);
		}

		/// <summary>
		///     Removes a timer from the TimerManager's list of registered timers.
		/// </summary>
		/// <param name="timer">The timer to deregister.</param>
		public static void DeregisterTimer(Timer timer)
		{
			m_S_Timers.Remove(timer);
		}

		/// <summary>
		///     Updates all registered timers by calling their Tick method.
		/// </summary>
		public static void UpdateTimers()
		{
			if (m_S_Timers.Count == 0) return;

			m_S_Sweep.RefreshWith(m_S_Timers);

			foreach (var timer in new List<Timer>(m_S_Timers)) timer.Tick();
		}

		/// <summary>
		///     Clears all registered timers from the TimerManager.
		/// </summary>
		public static void Clear()
		{
			m_S_Sweep.RefreshWith(m_S_Timers);
			foreach (var timer in m_S_Sweep) timer.Dispose();

			m_S_Sweep.Clear();
			m_S_Timers.Clear();
		}
	}
}