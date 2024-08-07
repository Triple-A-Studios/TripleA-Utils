using UnityEngine;

namespace Utils.Extensions
{
	public static class Vector2Extensions
	{
		#region With

		/// <summary>
		/// Creates a new Vector2 with the specified x value and the same y value as the original vector.
		/// </summary>
		/// <param name="vector">The original Vector2.</param>
		/// <param name="x">The new x value.</param>
		/// <returns>A new Vector2 with the specified x value and the same y value as the original vector.</returns>
		public static Vector2 WithX(this Vector2 vector, float x)
		{
			return new Vector2(x, vector.y);
		}
		 
		/// <summary>
		/// Creates a new Vector2 with the specified y value and the same x value as the original vector.
		/// </summary>
		/// <param name="vector">The original Vector2.</param>
		/// <param name="y">The new y value.</param>
		/// <returns>A new Vector2 with the specified y value and the same x value as the original vector.</returns>
		public static Vector2 WithY(this Vector2 vector, float y)
		{
			return new Vector2(vector.x, y);
		}
		 
		/// <summary>
		/// Creates a new Vector2 with the specified x and y values or the same values as the original vector if no new values are provided.
		/// </summary>
		/// <param name="vector">The Original Vector2.</param>
		/// <param name="x">The new x value.</param>
		/// <param name="y">The new y value.</param>
		/// <returns>A new Vector2 with the specified x and y values or the same values as the original vector if no new values are provided.</returns>
		public static Vector2 With(this Vector2 vector, float? x = null, float? y = null)
		{
			return new Vector2(x ?? vector.x, y ?? vector.y);
		}
		
		/// <summary>
		/// Sets the x and y values of the original Vector2.
		/// </summary>
		public static void Set(this ref Vector2 vector, float? x = null, float? y = null)
		{
			vector = new Vector2(x ?? vector.x, y ?? vector.y);
		}

		/// <summary>
		/// Assigns the specified x value to the original Vector2.
		/// </summary>
		public static void SetX(this ref Vector2 vector, float x)
		{
			vector = new Vector2(x, vector.y);
		}
		
		/// <summary>
		/// Assigns the specified y value to the original Vector2.
		/// </summary>
		public static void SetY(this ref Vector2 vector, float y)
		{
			vector = new Vector2(vector.x, y);
		}

		#endregion With

		#region Math Operations

		/// <summary>
		/// Adds the specified x and y values to the original Vector2.
		/// </summary>
		/// <param name="vector">The original Vector2.</param>
		/// <param name="x">The x value to add. If null, 0 is used.</param>
		/// <param name="y">The y value to add. If null, 0 is used.</param>
		/// <returns>A new Vector2 with the added x and y values.</returns>
		public static Vector2 Add(this Vector2 vector, float? x = null, float? y = null)
		{
			return new Vector2(vector.x + (x ?? 0), vector.y + (y ?? 0));
		}
		 
		/// <summary>
		/// Subtracts the specified x and y values to the original Vector2.
		/// </summary>
		/// <param name="vector">The original Vector2.</param>
		/// <param name="x">The x value to subtract. If null, 0 is used.</param>
		/// <param name="y">The y value to subtract. If null, 0 is used.</param>
		/// <returns>A new Vector2 with the added x and y values.</returns>
		public static Vector2 Subtract(this Vector2 vector, float? x = null, float? y = null)
		{
			return new Vector2(vector.x - (x ?? 0), vector.y - (y ?? 0));
		}
		 
		/// <summary>
		/// Multiplies the specified x and y values to the original Vector2.
		/// </summary>
		/// <param name="vector">The original Vector2.</param>
		/// <param name="x">The x value to multiply. If null, 1 is used.</param>
		/// <param name="y">The y value to multiply. If null, 1 is used.</param>
		/// <returns>A new Vector2 with the multiplied x and y values.</returns> 
		public static Vector2 Multiply(this Vector2 vector, float? x = null, float? y = null)
		{
			return new Vector2(vector.x * (x ?? 1), vector.y * (y ?? 1));
		}
		 
		/// <summary>
		/// Divides the specified x and y values to the original Vector2.
		/// </summary>
		/// <param name="vector">The original Vector2.</param>
		/// <param name="x">The x value to divide. If null, 1 is used.</param>
		/// <param name="y">The y value to divide. If null, 1 is used.</param>
		/// <returns>A new Vector2 with the divided x and y values.</returns>
		public static Vector2 Divide(this Vector2 vector, float? x = null, float? y = null)
		{
			return new Vector2(vector.x / (x ?? 1), vector.y / (y ?? 1));
		}
		 

		#endregion Math Operations

		#region Swap

		/// <summary>
		/// Converts the vector 2 to a vector 3 with a z value of 0.
		/// </summary>
		public static Vector3 ToVector3WithoutZ(this Vector2 vector)
		{
			return new Vector3(vector.x, vector.y, 0);
		}

		#endregion Swap

		#region Conversion

		/// <summary>
		/// Converts the vector 2 to a vector 3 with a y value of 0.
		/// </summary>
		public static Vector3 ToVector3WithoutY(this Vector2 vector)
		{
			return new Vector3(vector.x, 0 ,vector.y);
		}
		 
		/// <summary>
		/// Converts the vector 2 to a vector 3 with a x value of 0.
		/// </summary>
		public static Vector3 ToVector3WithoutX(this Vector2 vector)
		{
			return new Vector3(0, vector.x, vector.y);
		}

		#endregion
		
		// TODO: all extensions here(Except With region) => assign the result to the original vector 
	}
}
