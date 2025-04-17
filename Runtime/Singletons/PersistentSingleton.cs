using UnityEngine;

namespace TripleA.Utils.Singletons
{
	public class PersistentSingleton<T> : GenericSingleton<T> where T : MonoBehaviour
	{
		 public bool autoUnparentOnAwake = true;

		protected override void InstantiateSingleton()
		{
			if (!Application.isPlaying) return;

			if (autoUnparentOnAwake)
				transform.SetParent(null);

			if (_s_instance == null)
			{
				_s_instance = this as T;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}