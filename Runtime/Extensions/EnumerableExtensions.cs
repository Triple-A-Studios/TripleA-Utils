﻿using System.Collections;

namespace TripleA.Extensions
{
	public static class EnumerableExtensions
	{
		public static int CountEnumerable(this IEnumerable enumerable)
		{
			int count = 0;
			if (enumerable != null)
			{
				foreach (object _ in enumerable)
				{
					count++;
				}
			}
			return count;
		}
	}
}
