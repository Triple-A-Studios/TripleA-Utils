using UnityEngine;

namespace TripleA.Utils.Extensions
{
	public static class PrefabExtensions
	{
		public static bool IsUninstantiatedPrefab(GameObject go) => go.scene.rootCount == 0;
	}
}
