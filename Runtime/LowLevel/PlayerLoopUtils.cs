using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.LowLevel;

namespace TripleA.LowLevel
{
	public static class PlayerLoopUtils
	{
		/// <summary>
		///     Inserts a new subsystem into the given Unity Player Loop at the given index.
		/// </summary>
		/// <typeparam name="T">The type of the subsystem to insert.</typeparam>
		/// <param name="loop">The player loop to insert into.</param>
		/// <param name="systemToInsert">The subsystem to insert.</param>
		/// <param name="index">The index at which to insert the subsystem.</param>
		public static bool InsertSystem<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem systemToInsert, int index)
		{
			if (loop.type != typeof(T)) return HandleSubSystemLoopForInsertion<T>(ref loop, systemToInsert, index);
			var playerLoopSystemList = new List<PlayerLoopSystem>();
			if (loop.subSystemList != null) playerLoopSystemList.AddRange(loop.subSystemList);
			playerLoopSystemList.Insert(index, systemToInsert);
			loop.subSystemList = playerLoopSystemList.ToArray();
			return true;
		}


		/// <summary>
		///     Prints the Unity Player Loop to the console as a tree.
		/// </summary>
		/// <param name="playerLoop">The current player loop.</param>
		public static void PrintPlayerLoop(PlayerLoopSystem playerLoop)
		{
			StringBuilder sb = new();
			sb.AppendLine("Unity Player Loop");
			foreach (var loopSubSystem in playerLoop.subSystemList) PrintSubSystem(loopSubSystem, sb);
			Debug.Log(sb.ToString());
		}

		public static void RemoveSystem<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem subSystemToRemove)
		{
			if (loop.subSystemList == null) return;

			var playerLoopSystemList = new List<PlayerLoopSystem>(loop.subSystemList);
			for (var i = 0; i < playerLoopSystemList.Count; i++)
				if (playerLoopSystemList[i].type == subSystemToRemove.type &&
				    playerLoopSystemList[i].updateDelegate == subSystemToRemove.updateDelegate)
				{
					playerLoopSystemList.RemoveAt(i);
					loop.subSystemList = playerLoopSystemList.ToArray();
				}

			HandleSubSystemLoopForRemoval<T>(ref loop, subSystemToRemove);
		}

		private static bool HandleSubSystemLoopForInsertion<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem subSystem,
			int index)
		{
			if (loop.subSystemList == null || loop.subSystemList.Length == 0) return false;

			for (var i = 0; i < loop.subSystemList.Length; i++)
			{
				if (!InsertSystem<T>(ref loop.subSystemList[i], subSystem, index)) continue;
				return true;
			}

			return false;
		}

		private static void HandleSubSystemLoopForRemoval<T>(ref PlayerLoopSystem loop,
			in PlayerLoopSystem subSystemToRemove)
		{
			if (loop.subSystemList == null || loop.subSystemList.Length == 0) return;

			for (var i = 0; i < loop.subSystemList.Length; i++)
				RemoveSystem<T>(ref loop.subSystemList[i], subSystemToRemove);
		}

		/// <summary>
		///     Recursively prints the subsystems of the given loop.
		/// </summary>
		/// <param name="system">The current subsystem.</param>
		/// <param name="sb">The StringBuilder to which to write the output.</param>
		/// <param name="level">The indentation level. Starts with 0.</param>
		private static void PrintSubSystem(PlayerLoopSystem system, StringBuilder sb, int level = 0)
		{
			sb.Append(' ', level * 2).AppendLine(system.type.ToString());
			if (system.subSystemList == null || system.subSystemList.Length == 0) return;

			foreach (var loopSubSystem in system.subSystemList) PrintSubSystem(loopSubSystem, sb, level + 1);
		}
	}
}