using UnityEngine;

namespace TripleA.Singletons
{
	public class RegulatorSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		protected static T instance;
		public static bool HasInstance => instance != null;

		public float InitializationTime { get; private set; }

		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindAnyObjectByType<T>();
					if (instance == null)
					{
						var go = new GameObject(typeof(T).Name + " Auto-Generated");
						go.hideFlags = HideFlags.HideAndDontSave;
						instance = go.AddComponent<T>();
					}
				}

				return instance;
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

			if (instance == null)
				instance = this as T;
		}
	}
}