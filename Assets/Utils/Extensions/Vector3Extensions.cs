using UnityEngine;

namespace Utils.Extensions
{
	 public static class Vector3Extensions
	 {
		 #region With

		 /// <summary>
		 /// Creates a new vector with the specified x value and the same y and z values as the original vector.
		 /// </summary>
		 /// <param name="vector">The original vector.</param>
		 /// <param name="x">The new x value.</param>
		 /// <returns>The new vector with the updated x value.</returns>
		 public static Vector3 WithX(this Vector3 vector, float x)
		 {
			 return new Vector3(x, vector.y, vector.z);
		 }
		 
		 /// <summary>
		 /// Creates a new vector with the specified y value and the same x and z values as the original vector.
		 /// </summary>
		 /// <param name="vector">The original vector.</param>
		 /// <param name="y">The new x value.</param>
		 /// <returns>The new vector with the updated x value.</returns>
		 public static Vector3 WithY(this Vector3 vector, float y)
		 {
			 return new Vector3(vector.x, y, vector.z);
		 }
		 
		 /// <summary>
		 /// Creates a new vector with the specified z value and the same x and y values as the original vector.
		 /// </summary>
		 /// <param name="vector">The original vector.</param>
		 /// <param name="z">The new z value.</param>
		 /// <returns>The new vector with the updated x value.</returns>
		 public static Vector3 WithZ(this Vector3 vector, float z)
		 {
			 return new Vector3(vector.x, vector.y, z);
		 }
		 
		 /// <summary>
		 /// Creates a new vector with the specified x, y, and z values or the same values as the original vector if no new values are provided.
		 /// </summary>
		 /// <param name="vector">The original vector.</param>
		 /// <param name="x">The new x value. If null, the original x value is used.</param>
		 /// <param name="y">The new y value. If null, the original y value is used.</param>
		 /// <param name="z">The new z value. If null, the original z value is used.</param>
		 /// <returns>The new vector with the updated x, y, and z values.</returns>
		 public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
		 {
			 return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
		 }
		 
		 /// <summary>
		 /// Assigns the specified x, y, and z values to the original vector.
		 /// </summary>
		 public static void Set(this ref Vector3 vector, float? x = null, float? y = null, float? z = null)
		 {
			 vector = new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
		 }
		 
		 /// <summary>
		 /// Assigns the specified x value to the original vector.
		 /// </summary>
		 public static void SetX(this ref Vector3 vector, float x)
		 {
			 vector = new Vector3(x, vector.y, vector.z);
		 }
		 
		 /// <summary>
		 /// Assigns the specified y value to the original vector.
		 /// </summary>
		 public static void SetY(this ref Vector3 vector, float y)
		 {
			 vector = new Vector3(vector.x, y, vector.z);
		 }
		 
		 /// <summary>
		 /// Assigns the specified z value to the original vector.
		 /// </summary>
		 public static void SetZ(this ref Vector3 vector, float z)
		 {
			 vector = new Vector3(vector.x, vector.y, z);
		 }

		 #endregion With

		 #region Math Operations

		 /// <summary>
         /// Adds the specified x, y, and z values to the original vector.
         /// </summary>
         /// <param name="vector">The original vector.</param>
         /// <param name="x">The x value to add. If null, the original x value is used.</param>
         /// <param name="y">The y value to add. If null, the original y value is used.</param>
         /// <param name="z">The z value to add. If null, the original z value is used.</param>
         /// <returns>The original vector with the added x, y, and z values.</returns>
         public static Vector3 Add(this Vector3 vector, float? x = null, float? y = null, float? z = null)
         {
         	 return new Vector3(vector.x + (x ?? 0), vector.y + (y ?? 0), vector.z + (z ?? 0));
         }

		 /// <summary>
		 /// Adds the specified x, y, and z values to the original vector and assigns the result to the original vector.
		 /// </summary>
		 public static void AddToThis(this ref Vector3 vector, float? x = null, float? y = null, float? z = null)
		 {
			 vector = vector.Add(x, y, z);
		 }
         
         /// <summary>
         /// Subtracts the specified x, y, and z values from the original vector.
         /// </summary>
         /// <param name="vector">The original vector.</param>
         /// <param name="x">The x value to subtract. If null, the original x value is used.</param>
         /// <param name="y">The y value to subtract. If null, the original y value is used.</param>
         /// <param name="z">The z value to subtract. If null, the original z value is used.</param>
         /// <returns>The original vector with the subtracted x, y, and z values.</returns>
         public static Vector3 Subtract(this Vector3 vector, float? x = null, float? y = null, float? z = null)
         {
         	 return new Vector3(vector.x - (x ?? 0), vector.y - (y ?? 0), vector.z - (z ?? 0));
         }
         
         /// <summary>
         /// Subtracts the specified x, y, and z values from the original vector and assigns the result to the original vector.
         /// </summary>
         public static void SubtractFromThis(this ref Vector3 vector, float? x = null, float? y = null, float? z = null)
		 {
		 	 vector = vector.Subtract(x, y, z);
		 }
         
         /// <summary>
         /// Multiplies the specified x, y, and z values by the original vector.
         /// </summary>
         /// <param name="vector">The original vector.</param>
         /// <param name="x">The x value to multiply. If null, the original x value is used.</param>
         /// <param name="y">The y value to multiply. If null, the original y value is used.</param>
         /// <param name="z">The z value to multiply. If null, the original z value is used.</param>
         /// <returns>The original vector with the multiplied x, y, and z values.</returns>
         public static Vector3 Multiply(this Vector3 vector, float? x = null, float? y = null, float? z = null)
         {
         	 return new Vector3(vector.x * (x ?? 1), vector.y * (y ?? 1), vector.z * (z ?? 1));
         }

         /// <summary>
         /// Multiplies the specified x, y, and z values by the original vector and assigns the result to the original vector.
         /// </summary>
         public static void MultiplyThisBy(this ref Vector3 vector, float? x = null, float? y = null, float? z = null)
         {
	         vector = vector.Multiply(x, y, z);
         }
         
         /// <summary>
         /// Divides the specified x, y, and z values by the original vector.
         /// </summary>
         /// <param name="vector">The original vector.</param>
         /// <param name="x">The x value to divide. If null, the original x value is used.</param>
         /// <param name="y">The y value to divide. If null, the original y value is used.</param>
         /// <param name="z">The z value to divide. If null, the original z value is used.</param>
         /// <returns>The original vector with the divided x, y, and z values.</returns>
         public static Vector3 Divide(this Vector3 vector, float? x = null, float? y = null, float? z = null)
         {
         	 return new Vector3(vector.x / (x ?? 1), vector.y / (y ?? 1), vector.z / (z ?? 1));
         }
         
         /// <summary>
         /// Divides the specified x, y, and z values by the original vector and assigns the result to the original vector.
         /// </summary>
		 public static void DivideThisBy(this ref Vector3 vector, float? x = null, float? y = null, float? z = null)
		 {
			 vector = vector.Divide(x, y, z);
		 }

         /// <summary>
         /// Rounds the Vector to the nearest integer according to the specified conditions.
         /// By default, rounds all the values to the nearest integer.
         /// </summary>
         public static Vector3 Round(this Vector3 vector, bool x = true, bool y = true, bool z = true)
         {
	         return new Vector3(x ? Mathf.RoundToInt(vector.x) : vector.x, y ? Mathf.RoundToInt(vector.y) : vector.y, z ? Mathf.RoundToInt(vector.z) : vector.z);
         }
         
         /// <summary>
         /// Rounds the Vector to the nearest integer according to the specified conditions and assigns the result to the original vector.
         /// By default, rounds all the values to the nearest integer.
         /// </summary>
         /// <param name="vector"></param>
         /// <param name="x"></param>
         /// <param name="y"></param>
         /// <param name="z"></param>
         public static void RoundThis(this ref Vector3 vector, bool x = true, bool y = true, bool z = true)
		 {
			 vector = vector.Round(x, y, z);
         }

         /// <summary>
         /// Rounds the X value to the nearest integer
         /// </summary>
         public static Vector3 RoundX(this Vector3 vector)
         {
	         return vector.WithX(Mathf.RoundToInt(vector.x));
         }
         
         /// <summary>
         /// Rounds the X value to the nearest integer and assigns the result to the original vector
         /// </summary>
         public static void RoundThisX(this ref Vector3 vector)
		 {
			 vector = vector.RoundX();
		 }
         
         /// <summary>
         /// Rounds the Y value to the nearest integer
         /// </summary>
		 public static Vector3 RoundY(this Vector3 vector)
		 {
			 return vector.WithY(Mathf.RoundToInt(vector.y));
		 }
         
         /// <summary>
         /// Rounds the Y value to the nearest integer and assigns the result to the original vector
         /// </summary>
		 public static void RoundThisY(this ref Vector3 vector)
		 {
			 vector = vector.RoundY();
		 }

		 /// <summary>
		 /// Rounds the Y value to the nearest integer
		 /// </summary>
		 public static Vector3 RoundZ(this Vector3 vector)
		 {
			 return vector.WithZ(Mathf.RoundToInt(vector.z));
		 }
		 
		 /// <summary>
		 /// Rounds the Z value to the nearest integer and assigns the result to the original vector
		 /// </summary>
		 public static void RoundThisZ(this ref Vector3 vector)
		 {
			 vector = vector.RoundZ();
		 }

		 /// <summary>
		 /// Clamps the vector to the specified min and max values
		 /// </summary>
		 public static Vector3 Clamp(this Vector3 vector, float min, float max)
		 {
			 return new Vector3(
				 Mathf.Clamp(vector.x, min, max),
				 Mathf.Clamp(vector.y, min, max),
				 Mathf.Clamp(vector.z, min, max));
		 }
		 
		 // TODO: ClampThis, ClampThisX, ClampThisY, ClampThisZ
		 
		 /// <summary>
		 /// Clamps the x value to the specified min and max values
		 /// </summary>
		 public static Vector3 ClampX(this Vector3 vector, float min, float max)
		 {
			 return vector.WithX(Mathf.Clamp(vector.x, min, max));
		 }
		 
		 /// <summary>
		 /// Clamps the y value to the specified min and max values
		 /// </summary>
		 public static Vector3 ClampY(this Vector3 vector, float min, float max)
		 {
			 return vector.WithY(Mathf.Clamp(vector.y, min, max));
		 }
		 
		 /// <summary>
		 /// Clamps the z value to the specified min and max values
		 /// </summary>
		 public static Vector3 ClampZ(this Vector3 vector, float min, float max)
		 {
			 return vector.WithZ(Mathf.Clamp(vector.z, min, max));
		 }

		 /// <summary>
		 /// Lerps the x value of the vector
		 /// </summary>
		 public static Vector3 LerpX(this Vector3 vector, float x, float t)
		 {
			 return vector.WithX(Mathf.Lerp(vector.x, x, t));
		 }
		 
		 /// <summary>
		 /// Lerps the y value of the vector
		 /// </summary>
		 public static Vector3 LerpY(this Vector3 vector, float y, float t)
		 {
			 return vector.WithY(Mathf.Lerp(vector.y, y, t));
		 }
		 
		 /// <summary>
		 /// Lerps the z value of the vector
		 /// </summary>
		 public static Vector3 LerpZ(this Vector3 vector, float z, float t)
		 {
			 return vector.WithZ(Mathf.Lerp(vector.z, z, t));
		 }

		 #endregion Math Operations

		 #region Conversion To Vector2

		 /// <summary>
         /// Converts a vector 3 with an x component to a vector2 without an x component with y at x and z at y.
         /// </summary>
         /// <param name="vector">The vector3 to convert</param>
         /// <returns>The converted vector</returns>
         public static Vector2 ToVector2IgnoreX(this Vector3 vector)
         {
         	 return new Vector2(vector.y, vector.z);
         }
         
         /// <summary>
         /// Converts a vector 3 with a y component to a vector2 without a y component with x at y and z at x.
         /// </summary>
         /// <param name="vector">The vector3 to convert</param>
         /// <returns>The converted vector</returns>
         public static Vector2 ToVector2IgnoreY(this Vector3 vector)
         {
         	 return new Vector2(vector.x, vector.z);
         }
 
         /// <summary>
         /// Converts a vector with a Z component to a vector without a Z component with x at x and y at y.
         /// </summary>
         /// <param name="vector">The vector to convert.</param>
         /// <returns>The converted vector.</returns>
         public static Vector2 ToVector2IgnoreZ(this Vector3 vector)
         {
         	 return new Vector2(vector.x, vector.y);
         }

		 #endregion Conversion To Vector2

		 #region Swap

		 /// <summary>
		 /// Switches the x and y values of the vector.
		 /// </summary>
		 public static Vector3 SwapXAndY(this Vector3 vector)
		 {
			 return new Vector3(vector.y, vector.x, vector.z);
		 }
		 
		 /// <summary>
		 /// Switches the y and z values of the vector.
		 /// </summary>
		 public static Vector3 SwapYAndZ(this Vector3 vector)
		 {
			 return new Vector3(vector.x, vector.z, vector.y);
		 }
		 
		 /// <summary>
		 /// Switches the x and z values of the vector.
		 /// </summary>
		 /// <param name="vector">The original Vector3.</param>
		 /// <returns>A new Vector3 with the switched x and z values.</returns> 
		 public static Vector3 SwapXAndZ(this Vector3 vector)
		 {
			 return new Vector3(vector.z, vector.x, vector.y);
		 }

		 #endregion Swap
		 
		 
		 // TODO: all extensions here(Except With region) => assign the result to the original vector
		 // TODO: Create similar methods for Vector2
	 }
}
