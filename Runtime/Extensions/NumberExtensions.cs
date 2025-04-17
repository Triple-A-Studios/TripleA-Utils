using UnityEngine;

namespace TripleA.Utils.Extensions
{
	public static class NumberExtensions
	{
		public static float PercentageOf(this int part, int whole)
		{
			if (whole == 0) return 0;
			return (float) part / whole * 100;
		}
		
		public static bool IsApproximately(this float a, float b) => Mathf.Approximately(a, b);
		public static bool IsEven(this int a) => a % 2 == 0;
		public static bool IsOdd(this int a) => a % 2 == 1;
		
		public static int AtLeast(this int a, int b) => Mathf.Max(a, b);
		public static int AtMost(this int a, int b) => Mathf.Min(a, b);
		
		public static float AtLeast(this float a, float b) => Mathf.Max(a, b);
		public static float AtMost(this float a, float b) => Mathf.Min(a, b);
		
		public static double AtLeast(this double a, double b) => MathfExtension.Max(a, b);
		public static double AtMost(this double a, double b) => MathfExtension.Min(a, b);
	}
}
