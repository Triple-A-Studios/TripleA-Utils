using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace TripleA.Observables
{
	[Serializable]
	public class Observable<T>
	{
		[SerializeField] private T m_value;
		[SerializeField] private UnityEvent<T> m_onValueChanged;

		public Observable(T value, UnityAction<T> callback = null)
		{
			this.m_value = value;
			m_onValueChanged = new UnityEvent<T>();
			if (callback != null) m_onValueChanged.AddListener(callback);
		}

		public T Value
		{
			get => m_value;
			set => Set(value);
		}

		public void AddListener(UnityAction<T> callback)
		{
			if (callback == null) return;
			if (m_onValueChanged == null) m_onValueChanged = new UnityEvent<T>();
			m_onValueChanged.AddListener(callback);
		}

		public void RemoveListener(UnityAction<T> callback)
		{
			if (callback == null) return;
			if (m_onValueChanged == null) return;

			m_onValueChanged.RemoveListener(callback);
		}

		public void RemoveAllListeners()
		{
			if (m_onValueChanged == null) return;
			m_onValueChanged.RemoveAllListeners();
		}

		public void Dispose()
		{
			RemoveAllListeners();
			m_onValueChanged = null;
			m_value = default;
		}

		public void Set(T newValue)
		{
			if (Equals(m_value, newValue)) return;
			m_value = newValue;
			Invoke();
		}

		public void Invoke()
		{
			m_onValueChanged.Invoke(m_value);
		}
	}
}