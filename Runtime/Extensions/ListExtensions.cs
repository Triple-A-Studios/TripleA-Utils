using System;
using System.Collections.Generic;

namespace Utils.TripleA.Extensions
{
	public static class ListExtensions
	{
		private static Random _rand;

		/// <summary>
		///     Clones the list
		/// </summary>
		public static List<T> Clone<T>(this List<T> listToClone)
		{
			List<T> newList = new();
			foreach (var item in listToClone) newList.Add(item);
			return newList;
		}

		/// <summary>
		///     Refreshes the list with the given items
		/// </summary>
		/// <param name="items">The items to add</param>
		public static void RefreshWith<T>(this List<T> list, IEnumerable<T> items)
		{
			list.Clear();
			list.AddRange(items);
		}

		/// <summary>
		///     Shuffles the list using Fisher-Yates algorithm.
		///     Reference: http://en.wikipedia.org/wiki/Fisher-Yates_shuffle
		/// </summary>
		/// <returns>The shuffled list</returns>
		public static IList<T> Shuffle<T>(this IList<T> list)
		{
			_rand ??= new Random();
			var n = list.Count;
			while (n > 1)
			{
				n--;
				var k = _rand.Next(n + 1);
				(list[k], list[n]) = (list[n], list[k]);
			}

			return list;
		}

		/// <summary>
		///     Swaps two elements in the list
		/// </summary>
		/// <param name="indexA">The first index</param>
		/// <param name="indexB">The second index</param>
		public static void Swap<T>(this IList<T> list, int indexA, int indexB)
		{
			(list[indexA], list[indexB]) = (list[indexB], list[indexA]);
		}
	}
}