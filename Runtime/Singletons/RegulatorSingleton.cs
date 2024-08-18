using UnityEngine;

namespace TripleA.Singletons
{
	public class RegulatorSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		protected static T _s_instance;
		public static bool HasInstance => _s_instance != null;

		public float InitializationTime { get; private set; }

		public static T Instance
		{
			get
			{
				if (_s_instance == null)
				{
					_s_instance = FindAnyObjectByType<T>();
					if (_s_instance == null)
					{
						var go = new GameObject(typeof(T).Name + " Auto-Generated");
						go.hideFlags = HideFlags.HideAndDontSave;
						_s_instance = go.AddComponent<T>();
					}
				}

				return _s_instance;
			}
		}

		protected virtual void Awake()
		{
			InstantiateSingleton();
		}

		protected virtual void InstantiateSingleton()
		{
			if (!Application.isPlaying) return;
			InitializationTime = Time.time;
			DontDestroyOnLoad(gameObject);

			var otherInstances = FindObjectsByType<T>(FindObjectsSortMode.None);

			foreach (var other in otherInstances)
				if (other.GetComponent<RegulatorSingleton<T>>().InitializationTime <= InitializationTime)
					Destroy(other.gameObject);

			if (_s_instance == null)
				_s_instance = this as T;
		}
	}
}