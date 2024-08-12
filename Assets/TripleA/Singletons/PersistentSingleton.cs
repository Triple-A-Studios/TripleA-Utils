using UnityEngine;

namespace TripleA.Singletons
{
	public class PersistentSingleton<T> : GenericSingleton<T> where T : MonoBehaviour
	{
		public bool AutoUnparentOnAwake = true;

		protected override void InstantiateSingleton()
		{
			if (!Application.isPlaying) return;

			if (AutoUnparentOnAwake)
				transform.SetParent(null);

			if (instance == null)
			{
				instance = this as T;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}