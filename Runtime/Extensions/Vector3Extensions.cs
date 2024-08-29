using UnityEngine;

namespace TripleA.Extensions
{
	public static class Vector3Extensions
	{
		#region With

		/// <summary>
		///     Creates and returns a new vector with the specified x, y, and z values or the same values as the original vector if
		///     no new values are provided.
		/// </summary>
		public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
		{
			return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
		}

		/// <summary>
		///     Assigns the specified x, y, and z values to the original vector.
		/// </summary>
		public static void SetThis(this ref Vector3 vector, float? x = null, float? y = null, float? z = null)
		{
			vector = new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
		}

		#endregion With

		#region Math Operations

		/// <summary>
		///     Adds the specified x, y, and z values to the original vector and returns the result.
		/// </summary>
		public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0)
		{
			return new Vector3(vector.x + x, vector.y + y, vector.z + z);
		}

		/// <summary>
		///     Adds the specified x, y, and z values to the original vector and assigns the result to the original vector.
		/// </summary>
		public static void AddToThis(this ref Vector3 vector, float x = 0, float y = 0, float z = 0)
		{
			vector = vector.Add(x, y, z);
		}

		/// <summary>
		///     Subtracts the specified x, y, and z values from the original vector and returns the result.
		/// </summary>
		public static Vector3 Subtract(this Vector3 vector, float x = 0, float y = 0, float z = 0)
		{
			return new Vector3(vector.x - x, vector.y - y, vector.z - z);
		}

		/// <summary>
		///     Subtracts the specified x, y, and z values from the original vector and assigns the result to the original vector.
		/// </summary>
		public static void SubtractFromThis(this ref Vector3 vector, float x = 0, float y = 0, float z = 0)
		{
			vector = vector.Subtract(x, y, z);
		}

		/// <summary>
		///     Multiplies the specified x, y, and z values by the original vector and returns the result.
		/// </summary>
		public static Vector3 Multiply(this Vector3 vector, float x = 1, float y = 1, float z = 1)
		{
			return new Vector3(vector.x * x, vector.y * y, vector.z * z);
		}

		/// <summary>
		///     Multiplies the specified x, y, and z values by the original vector and assigns the result to the original vector.
		/// </summary>
		public static void MultiplyThisBy(this ref Vector3 vector, float x = 1, float y = 1, float z = 1)
		{
			vector = vector.Multiply(x, y, z);
		}

		/// <summary>
		///     Divides the specified x, y, and z values by the original vector and returns the result.
		/// </summary>
		public static Vector3 Divide(this Vector3 vector, float x = 1, float y = 1, float z = 1)
		{
			return new Vector3(vector.x / x, vector.y / y, vector.z / z);
		}

		/// <summary>
		///     Divides the specified x, y, and z values by the original vector and assigns the result to the original vector.
		/// </summary>
		public static void DivideThisBy(this ref Vector3 vector, float x = 1, float y = 1, float z = 1)
		{
			vector = vector.Divide(x, y, z);
		}

		/// <summary>
		///     Divides two Vector3 objects component-wise.
		/// </summary>
		/// <remarks>
		///     For each component in v0 (x, y, z), it is divided by the corresponding component in v1 if the component in v1 is
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
		/// <param name="v0">The Vector3 object that this method extends.</param>
		/// <param name="v1">The Vector3 object by which v0 is divided.</param>
		/// <returns>A new Vector3 object resulting from the component-wise division.</returns>
		public static Vector3 ComponentDivide(this Vector3 v0, Vector3 v1)
		{
			return new Vector3(
				v1.x != 0 ? v0.x / v1.x : v0.x,
				v1.y != 0 ? v0.y / v1.y : v0.y,
				v1.z != 0 ? v0.z / v1.z : v0.z);
		}

		/// <summary>
		///     Multiplies two Vector3 objects component-wise.
		/// </summary>
		/// <remarks>
		///     For each component in v0 (x, y, z), it is multiplied by the corresponding component in v1 if the component in v1 is
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
		/// <param name="v0">The Vector3 object that this method extends.</param>
		/// <param name="v1">The Vector3 object by which v0 is multiplied.</param>
		/// <returns>A new Vector3 object resulting from the component-wise multiplication.</returns>
		public static Vector3 ComponentMultiply(this Vector3 v0, Vector3 v1)
		{
			return new Vector3(
				v1.x != 0 ? v0.x * v1.x : v0.x,
				v1.y != 0 ? v0.y * v1.y : v0.y,
				v1.z != 0 ? v0.z * v1.z : v0.z);
		}

		/// <summary>
		///     Rounds the Vector to the nearest integer according to the specified conditions and returns the result.
		///     By default, rounds all the values to the nearest integer.
		/// </summary>
		public static Vector3 Round(this Vector3 vector, bool shouldRoundX = true, bool shouldRoundY = true,
			bool shouldRoundZ = true)
		{
			return new Vector3(shouldRoundX ? Mathf.RoundToInt(vector.x) : vector.x,
				shouldRoundY ? Mathf.RoundToInt(vector.y) : vector.y,
				shouldRoundZ ? Mathf.RoundToInt(vector.z) : vector.z);
		}

		/// <summary>
		///     Rounds the Vector to the nearest integer according to the specified conditions and assigns the result to the
		///     original vector.
		///     By default, rounds all the values to the nearest integer.
		/// </summary>
		public static void RoundThis(this ref Vector3 vector, bool shouldRoundX = true, bool shouldRoundY = true,
			bool shouldRoundZ = true)
		{
			vector = vector.Round(shouldRoundX, shouldRoundY, shouldRoundZ);
		}

		/// <summary>
		///     Clamps the vector to the specified min and max values and returns the result
		/// </summary>
		public static Vector3 Clamp(this Vector3 vector, float min, float max)
		{
			return new Vector3(
				Mathf.Clamp(vector.x, min, max),
				Mathf.Clamp(vector.y, min, max),
				Mathf.Clamp(vector.z, min, max));
		}


		/// <summary>
		///     Clamps the vector to the specified min and max values and assigns the result to the original vector
		/// </summary>
		public static void ClampThis(this ref Vector3 vector, float min, float max)
		{
			vector = vector.Clamp(min, max);
		}

		/// <summary>
		///     Clamps the x value to the specified min and max values and returns the result
		/// </summary>
		public static Vector3 ClampX(this Vector3 vector, float min, float max)
		{
			return vector.With(Mathf.Clamp(vector.x, min, max));
		}

		/// <summary>
		///     Clamps the x value to the specified min and max values and assigns the result to the original vector
		/// </summary>
		public static void ClampThisX(this ref Vector3 vector, float min, float max)
		{
			vector = vector.ClampX(min, max);
		}

		/// <summary>
		///     Clamps the y value to the specified min and max values and returns the result.
		/// </summary>
		public static Vector3 ClampY(this Vector3 vector, float min, float max)
		{
			return vector.With(y: Mathf.Clamp(vector.y, min, max));
		}

		/// <summary>
		///     Clamps the y value to the specified min and max values and assigns the result to the original vector.
		/// </summary>
		public static void ClampThisY(this ref Vector3 vector, float min, float max)
		{
			vector = vector.ClampY(min, max);
		}

		/// <summary>
		///     Clamps the z value to the specified min and max values and returns the result.
		/// </summary>
		public static Vector3 ClampZ(this Vector3 vector, float min, float max)
		{
			return vector.With(z: Mathf.Clamp(vector.z, min, max));
		}

		/// <summary>
		///     Clamps the z value to the specified min and max values and assigns the result to the original vector.
		/// </summary>
		public static void ClampThisZ(this ref Vector3 vector, float min, float max)
		{
			vector = vector.ClampZ(min, max);
		}

		/// <summary>
		///     Lerps the x value of the vector and returns the result.
		/// </summary>
		public static Vector3 LerpX(this Vector3 vector, float x, float t)
		{
			return vector.With(Mathf.Lerp(vector.x, x, t));
		}

		/// <summary>
		///     Lerps the x value of the vector and assigns the result to the original vector
		/// </summary>
		public static void LerpThisX(this ref Vector3 vector, float x, float t)
		{
			vector = vector.LerpX(x, t);
		}

		/// <summary>
		///     Lerps the y value of the vector and returns the result.
		/// </summary>
		public static Vector3 LerpY(this Vector3 vector, float y, float t)
		{
			return vector.With(y: Mathf.Lerp(vector.y, y, t));
		}

		/// <summary>
		///     Lerps the y value of the vector and assigns the result to the original vector.
		/// </summary>
		public static void LerpThisY(this ref Vector3 vector, float y, float t)
		{
			vector = vector.LerpY(y, t);
		}

		/// <summary>
		///     Lerps the z value of the vector and returns the result.
		/// </summary>
		public static Vector3 LerpZ(this Vector3 vector, float z, float t)
		{
			return vector.With(z: Mathf.Lerp(vector.z, z, t));
		}

		/// <summary>
		///     Lerps the z value of the vector and assigns the result to the original vector.
		/// </summary>
		public static void LerpThisZ(this ref Vector3 vector, float z, float t)
		{
			vector = vector.LerpZ(z, t);
		}

		#endregion Math Operations

		#region Conversion To Vector2

		/// <summary>
		///     Converts a vector 3 with an x component to a vector2 without an x component with y at x and z at y.
		/// </summary>
		public static Vector2 ToVector2IgnoreX(this Vector3 vector)
		{
			return new Vector2(vector.y, vector.z);
		}

		/// <summary>
		///     Converts a vector 3 with a y component to a vector2 without a y component with x at y and z at x.
		/// </summary>
		public static Vector2 ToVector2IgnoreY(this Vector3 vector)
		{
			return new Vector2(vector.x, vector.z);
		}

		/// <summary>
		///     Converts a vector with a Z component to a vector without a Z component with x at x and y at y.
		/// </summary>
		public static Vector2 ToVector2IgnoreZ(this Vector3 vector)
		{
			return new Vector2(vector.x, vector.y);
		}

		#endregion Conversion To Vector2

		#region Swap

		/// <summary>
		///     Switches the x and y values of the vector and returns the result.
		/// </summary>
		public static Vector3 SwapXAndY(this Vector3 vector)
		{
			return new Vector3(vector.y, vector.x, vector.z);
		}

		/// <summary>
		///     Switches the x and y values of the vector and assigns the result to the original vector.
		/// </summary>
		public static void SwapThisXAndY(this ref Vector3 vector)
		{
			vector = vector.SwapXAndY();
		}

		/// <summary>
		///     Switches the y and z values of the vector and returns the result.
		/// </summary>
		public static Vector3 SwapYAndZ(this Vector3 vector)
		{
			return new Vector3(vector.x, vector.z, vector.y);
		}

		/// <summary>
		///     Switches the y and z values of the vector and assigns the result to the original vector.
		/// </summary>
		public static void SwapThisYAndZ(this ref Vector3 vector)
		{
			vector = vector.SwapYAndZ();
		}

		/// <summary>
		///     Switches the x and z values of the vector and returns the result.
		/// </summary>
		public static Vector3 SwapXAndZ(this Vector3 vector)
		{
			return new Vector3(vector.z, vector.x, vector.y);
		}

		/// <summary>
		///     Switches the x and z values of the vector and assigns the result to the original vector.
		/// </summary>
		public static void SwapThisXAndZ(this ref Vector3 vector)
		{
			vector = vector.SwapXAndZ();
		}

		#endregion Swap
	}
}