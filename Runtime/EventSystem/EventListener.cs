using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace TripleA.EventSystem
{
	public abstract class EventListener<T> : MonoBehaviour
	{
		[FormerlySerializedAs("_eventChannel")]
		[Header("Event Listener Fields")]
		[SerializeField] private EventChannel<T> m_eventChannel;
		[SerializeField] protected UnityEvent<T> _unityEvent;

		protected virtual void Awake()
		{
			m_eventChannel.Register(this);
		}

		protected virtual void OnDestroy()
		{
			m_eventChannel.Unregister(this);
		}

		public void Raise(T value)
		{
			_unityEvent?.Invoke(value);
		}
	}
}