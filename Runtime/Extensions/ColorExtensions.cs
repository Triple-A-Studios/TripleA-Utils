using UnityEngine;

namespace TripleA.Utils.Extensions
{
	public static class ColorExtensions
	{
		/// <summary>
		///     Creates and returns a new color with the specified alpha value.
		/// </summary>
		/// <returns></returns>
		public static Color WithAlpha(this Color color, float alpha)
		{
			return new Color(color.r, color.g, color.b, alpha);
		}
		
		/// <summary>
		///     Assigns the specified alpha value to the original color.
		/// </summary>
		public static Color SetThisAlpha(this ref Color color, float alpha)
		{
			return color = color.WithAlpha(alpha);
		}
		
		/// <summary>
		///     Creates and returns a new Color with the specified r, g, b, and a values or the same values as the original color if
		///     no new values are provided.
		/// </summary>
		public static Color With(this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
		{
			return new Color(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);
		}
		
		/// <summary>
		///     Assigns the specified r, g, b, and a values to the original color.
		/// </summary>
		public static Color SetThis(this ref Color color, float? r = null, float? g = null, float? b = null, float? a = null)
		{
			return color = color.With(r, g, b, a);
		}
	}
}
