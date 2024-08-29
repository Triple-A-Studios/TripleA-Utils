using UnityEngine;

namespace TripleA.Extensions
{
	public static class Vector2Extensions
	{
		#region Swap

		/// <summary>
		///     Swaps and returns the x and y values of the original Vector2.
		/// </summary>
		public static Vector2 Swap(this Vector2 vector)
		{
			return new Vector2(vector.y, vector.x);
		}

		/// <summary>
		///     Swaps the x and y values of the original Vector2 and assigns the result to the original Vector2.
		/// </summary>
		public static void SwapThis(this ref Vector2 vector)
		{
			vector = vector.Swap();
		}

		#endregion Swap

		#region With

		/// <summary>
		///     Creates and returns a new Vector2 with the specified x and y values or the same values as the original vector if no
		///     new values are provided.
		/// </summary>
		public static Vector2 With(this Vector2 vector, float? x = null, float? y = null)
		{
			return new Vector2(x ?? vector.x, y ?? vector.y);
		}

		/// <summary>
		///     Sets the x and y values of the original Vector2.
		/// </summary>
		public static void SetThis(this ref Vector2 vector, float? x = null, float? y = null)
		{
			vector = vector.With(x, y);
		}

		#endregion With

		#region Math Operations

		/// <summary>
		///     Adds and returns the specified x and y values to the original Vector2.
		/// </summary>
		public static Vector2 Add(this Vector2 vector, float x = 0, float y = 0)
		{
			return new Vector2(vector.x + x, vector.y + y);
		}

		/// <summary>
		///     Adds the specified x and y values to the original Vector2 and assigns the result to the original Vector2.
		/// </summary>
		public static void AddToThis(this ref Vector2 vector, float x = 0, float y = 0)
		{
			vector = vector.Add(x, y);
		}

		/// <summary>
		///     Subtracts and returns the specified x and y values to the original Vector2.
		/// </summary>
		public static Vector2 Subtract(this Vector2 vector, float x = 0, float y = 0)
		{
			return new Vector2(vector.x - x, vector.y - y);
		}

		/// <summary>
		///     Subtracts the specified x and y values to the original Vector2 and assigns the result to the original Vector2.
		/// </summary>
		public static void SubtractFromThis(this ref Vector2 vector, float x = 0, float y = 0)
		{
			vector = vector.Subtract(x, y);
		}

		/// <summary>
		///     Multiplies and returns the specified x and y values to the original Vector2.
		/// </summary>
		public static Vector2 Multiply(this Vector2 vector, float x = 1, float y = 1)
		{
			return new Vector2(vector.x * x, vector.y * y);
		}

		/// <summary>
		///     Multiplies the specified x and y values to the original Vector2 and assigns the result to the original Vector2.
		/// </summary>
		public static void MultiplyThisBy(this ref Vector2 vector, float x = 1, float y = 1)
		{
			vector = vector.Multiply(x, y);
		}

		/// <summary>
		///     Divides and returns the specified x and y values to the original Vector2.
		/// </summary>
		public static Vector2 Divide(this Vector2 vector, float x = 1, float y = 1)
		{
			return new Vector2(vector.x / x, vector.y / y);
		}

		/// <summary>
		///     Divides the specified x and y values to the original Vector2 and assigns the result to the original Vector2.
		/// </summary>
		public static void DivideThisBy(this ref Vector2 vector, float x = 1, float y = 1)
		{
			vector = vector.Divide(x, y);
		}

		/// <summary>
		///     Divides two Vector2 objects component-wise.
		/// </summary>
		/// <remarks>
		///     For each component in v0 (x, y), it is divided by the corresponding component in v1 if the component in v1 is
		///     not zero.
		///     Otherwise, the component in v0 remains unchanged.
		/// </remarks>
		/// <example>
		///     Use 'ComponentDivide' to scale a game object proportionally:
		///     <code>
		/// 			myObject.transform.localScale = originalScale.ComponentDivide(targetDimensions);
		/// 	</code>
		///     This scales the object size to fit within the target dimensions while maintaining its original proportions.
		/// </example>
		/// <param name="v0">The Vector2 object that this method extends.</param>
		/// <param name="v1">The Vector2 object by which v0 is divided.</param>
		/// <returns>A new Vector3 object resulting from the component-wise division.</returns>
		public static Vector2 ComponentDivide(this Vector2 v0, Vector2 v1)
		{
			return new Vector2(
				v1.x != 0 ? v0.x / v1.x : v0.x,
				v1.y != 0 ? v0.y / v1.y : v0.y);
		}

		/// <summary>
		///     Multiplies two Vector3 objects component-wise.
		/// </summary>
		/// <remarks>
		///     For each component in v0 (x, y), it is multiplied by the corresponding component in v1 if the component in v1 is
		///     not zero.
		///     Otherwise, the component in v0 remains unchanged.
		/// </remarks>
		/// <example>
		///     Use 'ComponentMultiply' to scale a game object proportionally:
		///     <code>
		/// 			myObject.transform.localScale = originalScale.ComponentMultiply(targetDimensions);
		/// 	</code>
		///     This scales the object size to fit within the target dimensions while maintaining its original proportions.
		/// </example>
		/// <param name="v0">The Vector2 object that this method extends.</param>
		/// <param name="v1">The Vector2 object by which v0 is multiplied.</param>
		/// <returns>A new Vector3 object resulting from the component-wise multiplication.</returns>
		public static Vector2 ComponentMultiply(this Vector2 v0, Vector2 v1)
		{
			return new Vector2(
				v1.x != 0 ? v0.x * v1.x : v0.x,
				v1.y != 0 ? v0.y * v1.y : v0.y);
		}

		/// <summary>
		///     Rounds and returns the Vector to the nearest integer according to the specified conditions.
		///     By default, rounds all the values to the nearest integer.
		/// </summary>
		public static Vector2 Round(this Vector2 vector, bool shouldRoundX = true, bool shouldRoundY = true)
		{
			return new Vector2(shouldRoundX ? Mathf.Round(vector.x) : vector.x,
				shouldRoundY ? Mathf.Round(vector.y) : vector.y);
		}

		/// <summary>
		///     Rounds the Vector to the nearest integer according to the specified conditions.
		///     By default, rounds all the values to the nearest integer.
		/// </summary>
		public static void RoundThis(this ref Vector2 vector, bool shouldRoundX = true, bool shouldRoundY = true)
		{
			vector = vector.Round(shouldRoundX, shouldRoundY);
		}

		/// <summary>
		///     Clamps and returns the Vector to the specified min and max values.
		/// </summary>
		public static Vector2 Clamp(this Vector2 vector, float min, float max)
		{
			return new Vector2(
				Mathf.Clamp(vector.x, min, max),
				Mathf.Clamp(vector.y, min, max));
		}

		/// <summary>
		///     Clamps the Vector to the specified min and max values and assigns the result to the original Vector2.
		/// </summary>
		public static void ClampThis(this ref Vector2 vector, float min, float max)
		{
			vector = vector.Clamp(min, max);
		}

		/// <summary>
		///     Clamps the x value to the specified min and max values and returns the result.
		/// </summary>
		public static Vector2 ClampX(this Vector2 vector, float min, float max)
		{
			return new Vector2(vector.x, Mathf.Clamp(vector.y, min, max));
		}

		/// <summary>
		///     Clamps the x value to the specified min and max values and assigns the result to the original Vector2.
		/// </summary>
		public static void ClampThisX(this ref Vector2 vector, float min, float max)
		{
			vector = vector.ClampX(min, max);
		}

		/// <summary>
		///     Clamps the y value to the specified min and max values and returns the result.
		/// </summary>
		public static Vector2 ClampY(this Vector2 vector, float min, float max)
		{
			return new Vector2(vector.x, Mathf.Clamp(vector.y, min, max));
		}

		/// <summary>
		///     Clamps the y value to the specified min and max values and assigns the result to the original Vector2.
		/// </summary>
		public static void ClampThisY(this ref Vector2 vector, float min, float max)
		{
			vector = vector.ClampY(min, max);
		}


		/// <summary>
		///     Lerps the x value of the vector and returns the result
		/// </summary>
		public static Vector2 LerpX(this Vector2 vector, float x, float t)
		{
			return vector.With(Mathf.Lerp(vector.x, x, t));
		}

		/// <summary>
		///     Lerps the x value of the vector and assigns the result to the original vector
		/// </summary>
		public static void LerpThisX(this ref Vector2 vector, float x, float t)
		{
			vector = vector.LerpX(x, t);
		}

		/// <summary>
		///     Lerps the y value of the vector and returns the result
		/// </summary>
		public static Vector2 LerpY(this Vector2 vector, float y, float t)
		{
			return vector.With(y: Mathf.Lerp(vector.y, y, t));
		}

		/// <summary>
		///     Lerps the y value of the vector and assigns the result to the original vector
		/// </summary>
		public static void LerpThisY(this ref Vector2 vector, float y, float t)
		{
			vector = vector.LerpY(y, t);
		}

		#endregion Math Operations

		#region Conversion

		/// <summary>
		///     Converts the vector 2 to a vector 3 with a y value of 0.
		/// </summary>
		public static Vector3 ToVector3WithoutY(this Vector2 vector)
		{
			return new Vector3(vector.x, 0, vector.y);
		}

		/// <summary>
		///     Converts the vector 2 to a vector 3 with a x value of 0.
		/// </summary>
		public static Vector3 ToVector3WithoutX(this Vector2 vector)
		{
			return new Vector3(0, vector.x, vector.y);
		}

		/// <summary>
		///     Converts the vector 2 to a vector 3 with a z value of 0.
		/// </summary>
		public static Vector3 ToVector3WithoutZ(this Vector2 vector)
		{
			return new Vector3(vector.x, vector.y, 0);
		}

		#endregion Conversion
	}
}