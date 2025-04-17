using UnityEngine;

namespace TripleA.Utils.Extensions
{
	public static class GameObjectExtensions
	{
		/// <summary>
		///     Hides the game object in the hierarchy
		/// </summary>
		public static void HideInHierarchy(this GameObject gameObject)
		{
			gameObject.hideFlags = HideFlags.HideInHierarchy;
		}

		/// <summary>
		///     Gets the component or adds it if it doesn't exist
		/// </summary>
		/// <typeparam name="T">The type of the component</typeparam>
		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
		{
			return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
		}

		/// <summary>
		///     Returns the object on the game object or null if it's null
		/// </summary>
		/// <typeparam name="T">The type of the object</typeparam>
		public static T OrNull<T>(this T obj) where T : Object
		{
			return obj ? obj : null;
		}

		/// <summary>
		///     Destroys all children of the game object
		/// </summary>
		public static void DestroyChildren(this GameObject gameObject)
		{
			foreach (Transform child in gameObject.transform) Object.Destroy(child.gameObject);
		}

		/// <summary>
		///     Sets the layer of the game object and all of its children
		/// </summary>
		/// <param name="gameObject">The game object</param>
		/// <param name="layer">The int layer</param>
		public static void SetLayerRecursively(this GameObject gameObject, int layer)
		{
			gameObject.layer = layer;
			foreach (Transform child in gameObject.transform) child.gameObject.SetLayerRecursively(layer);
		}

		/// <summary>
		///     Sets the layer of the game object and all of its children
		/// </summary>
		/// <param name="gameObject">The game object</param>
		/// <param name="layerMask">The layer mask</param>
		public static void SetLayerRecursively(this GameObject gameObject, LayerMask layerMask)
		{
			gameObject.layer = layerMask.value;
			foreach (Transform child in gameObject.transform) child.gameObject.SetLayerRecursively(layerMask);
		}
	}
}