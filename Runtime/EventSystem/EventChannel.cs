using System.Collections.Generic;
using UnityEngine;

namespace TripleA.EventSystem
{
	public abstract class EventChannel<T> : ScriptableObject
	{
		private readonly HashSet<EventListener<T>> m_observers = new();

		public void Invoke(T value)
		{
			foreach (var observer in m_observers)
			{
				observer.Raise(value);
			}
		}

		public void Register(EventListener<T> observer) => m_observers.Add(observer);

		public void Unregister(EventListener<T> observer) => m_observers.Remove(observer);
	}
}