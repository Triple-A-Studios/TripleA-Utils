using TripleA.LowLevel;
using UnityEditor;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace TripleA.ImprovedTimer
{
	internal static class TimerBootstrapper
	{
		private static PlayerLoopSystem m_s_timerSystem;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		internal static void Initialise()
		{
			var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();

			if (!InsertTimerManager<Update>(ref currentPlayerLoop, 0))
			{
				Debug.LogWarning(
					"Improved Timers could not be initialised. Unable to register TimerManager in player loop.");
				return;
			}

			PlayerLoop.SetPlayerLoop(currentPlayerLoop);
			// PlayerLoopUtils.PrintPlayerLoop(currentPlayerLoop);

#if UNITY_EDITOR
			EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
			EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

			static void OnPlayModeStateChanged(PlayModeStateChange state)
			{
				if (state == PlayModeStateChange.ExitingPlayMode)
				{
					var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
					RemoveTimerManager<Update>(ref currentPlayerLoop);
					PlayerLoop.SetPlayerLoop(currentPlayerLoop);

					TimerManager.Clear();
				}
			}
#endif
		}

		private static void RemoveTimerManager<T>(ref PlayerLoopSystem loop)
		{
			PlayerLoopUtils.RemoveSystem<T>(ref loop, in m_s_timerSystem);
		}

		private static bool InsertTimerManager<T>(ref PlayerLoopSystem loop, int index)
		{
			m_s_timerSystem = new PlayerLoopSystem
			{
				type = typeof(TimerManager),
				updateDelegate = TimerManager.UpdateTimers,
				subSystemList = null
			};

			return PlayerLoopUtils.InsertSystem<T>(ref loop, in m_s_timerSystem, index);
		}
	}
}