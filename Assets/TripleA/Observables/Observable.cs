using System;
using UnityEngine;
using UnityEngine.Events;

namespace TripleA.Observables
{
	[Serializable]
	public class Observable<T>
	{
		[SerializeField] private T value;
		[SerializeField] private UnityEvent<T> onValueChanged;

		public Observable(T value, UnityAction<T> callback = null)
		{
			this.value = value;
			onValueChanged = new UnityEvent<T>();
			if (callback != null) onValueChanged.AddListener(callback);
		}

		public T Value
		{
			get => value;
			set => Set(value);
		}

		public void AddListener(UnityAction<T> callback)
		{
			if (callback == null) return;
			if (onValueChanged == null) onValueChanged = new UnityEvent<T>();
			onValueChanged.AddListener(callback);
		}

		public void RemoveListener(UnityAction<T> callback)
		{
			if (callback == null) return;
			if (onValueChanged == null) return;

			onValueChanged.RemoveListener(callback);
		}

		public void RemoveAllListeners()
		{
			if (onValueChanged == null) return;
			onValueChanged.RemoveAllListeners();
		}

		public void Dispose()
		{
			RemoveAllListeners();
			onValueChanged = null;
			value = default;
		}

		public void Set(T newValue)
		{
			if (Equals(value, newValue)) return;
			value = newValue;
			Invoke();
		}

		public void Invoke()
		{
			onValueChanged.Invoke(value);
		}
	}
}