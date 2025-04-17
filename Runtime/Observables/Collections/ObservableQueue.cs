using System.Collections.Generic;
using System.Collections.Specialized;

namespace TripleA.Utils.Observables.Collections
{
	public class ObservableQueue<T> : Queue<T>, INotifyCollectionChanged
	{
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public new void Enqueue(T item)
		{
			base.Enqueue(item);
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
		}

		public new T Dequeue()
		{
			T item = base.Dequeue();
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, 0));
			return item;
		}

		public new void Clear()
		{
			base.Clear();
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
		
		public new bool TryDequeue(out T item)
		{
			bool result = base.TryDequeue(out item);
			if (result)
				CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, 0));
			return result;
		}
	}
}