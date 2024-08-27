using UnityEngine;

namespace Utils.TripleA.Singletons
{
	public class GenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		protected static T _s_instance;
		public static bool HasInstance => _s_instance != null;

		public static T Instance
		{
			get
			{
				if (_s_instance == null)
				{
					_s_instance = FindAnyObjectByType<T>();
					if (_s_instance == null)
					{
						var obj = new GameObject
						{
							name = typeof(T).Name + " Auto-Instantiated"
						};
						_s_instance = obj.AddComponent<T>();
					}
				}

				return _s_instance;
			}
		}

		protected virtual void Awake()
		{
			InstantiateSingleton();
		}

		public static T TryGetInstance()
		{
			return HasInstance ? _s_instance : null;
		}

		protected virtual void InstantiateSingleton()
		{
			if (!Application.isPlaying) return;

			if (_s_instance == null)
				_s_instance = this as T;
			else
				Destroy(gameObject);
		}
	}
}