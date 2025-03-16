using UnityEngine;

namespace TripleA.Extensions
{
	public static class PrefabExtensions
	{
		public static bool IsUninstantiatedPrefab(GameObject go) => go.scene.rootCount == 0;
	}
}
