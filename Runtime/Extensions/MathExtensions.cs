using System;
using UnityEngine;

namespace TripleA.Utils.Extensions
{
	public static class MathExtensions
	{
		public static bool Approximately(double a, double b)
		{
			return Math.Abs(b - a) < Math.Max(1E-06 * Math.Max(Math.Abs(a), Math.Abs(b)), Mathf.Epsilon * 8f);
		}
	}
}
