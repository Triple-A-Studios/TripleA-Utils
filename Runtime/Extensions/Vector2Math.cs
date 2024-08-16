using UnityEngine;

namespace TripleA.Extensions
{
	public class Vector2Math
	{
		/// <summary>
		///     Calculates the dot product of a vector and a normalized direction.
		/// </summary>
		/// <param name="vector">The vector to project.</param>
		/// <param name="direction">The direction vector to project onto.</param>
		/// <returns>The dot product of the vector and the direction.</returns>
		public static float GetDotProduct(Vector2 vector, Vector2 direction)
		{
			return Vector2.Dot(vector, direction.normalized);
		}

		/// <summary>
		///     Removes the component of a vector that is in the direction of a given vector.
		/// </summary>
		/// <param name="vector">The vector from which to remove the component.</param>
		/// <param name="direction">The direction vector whose component should be removed.</param>
		/// <returns>The vector with the specified direction removed.</returns>
		public static Vector2 RemoveDotVector(Vector2 vector, Vector2 direction)
		{
			direction.Normalize();
			return vector - direction * Vector2.Dot(vector, direction);
		}

		/// <summary>
		///     Extracts and returns the component of a vector that is in the direction of a given vector.
		/// </summary>
		/// <param name="vector">The vector from which to extract the component.</param>
		/// <param name="direction">The direction vector to extract along.</param>
		/// <returns>The component of the vector in the direction of the given vector.</returns>
		public static Vector2 ExtractDotVector(Vector2 vector, Vector2 direction)
		{
			direction.Normalize();
			return direction * Vector2.Dot(vector, direction);
		}

		/// <summary>
		///     Rotates a vector onto a plane defined by a normal vector using a specified up direction.
		/// </summary>
		/// <param name="vector">The vector to be rotated onto the plane.</param>
		/// <param name="planeNormal">The normal vector of the target plane.</param>
		/// <param name="upDirection">The current 'up' direction used to determine the rotation.</param>
		/// <returns>The vector after being rotated onto the specified plane.</returns>
		public static Vector2 RotateVectorOntoPlane(Vector2 vector, Vector2 planeNormal, Vector2 upDirection)
		{
			// Calculate rotation;
			var rotation = Quaternion.FromToRotation(upDirection, planeNormal);

			// Apply rotation to vector;
			vector = rotation * vector;

			return vector;
		}

		/// <summary>
		///     Projects a given point onto a line defined by a starting position and direction vector.
		/// </summary>
		/// <param name="lineStartPosition">The starting position of the line.</param>
		/// <param name="lineDirection">The direction vector of the line, which should be normalized.</param>
		/// <param name="point">The point to project onto the line.</param>
		/// <returns>The projected point on the line closest to the original point.</returns>
		public static Vector2 ProjectPointOntoLine(Vector2 lineStartPosition, Vector2 lineDirection, Vector2 point)
		{
			var projectLine = point - lineStartPosition;
			var dotProduct = Vector2.Dot(projectLine, lineDirection);

			return lineStartPosition + lineDirection * dotProduct;
		}

		/// <summary>
		///     Increments a vector toward a target vector at a specified speed over a given time interval.
		/// </summary>
		/// <param name="currentVector">The current vector to be incremented.</param>
		/// <param name="speed">The speed at which to move towards the target vector.</param>
		/// <param name="deltaTime">The time interval over which to move.</param>
		/// <param name="targetVector">The target vector to approach.</param>
		/// <returns>The new vector incremented toward the target vector by the specified speed and time interval.</returns>
		public static Vector2 IncrementVectorTowardTargetVector(Vector2 currentVector, float speed, float deltaTime,
			Vector2 targetVector)
		{
			return Vector2.MoveTowards(currentVector, targetVector, speed * deltaTime);
		}
	}
}