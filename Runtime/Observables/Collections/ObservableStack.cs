using System.Collections.Generic;
using System.Collections.Specialized;

namespace TripleA.Observables.Collections
{
	public class ObservableStack<T> : Stack<T>, INotifyCollectionChanged
	{
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public new void Push(T item)
		{
			base.Push(item);
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
		}

		public new T Pop()
		{
			T item = base.Pop();
			
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, Count));
			
			return item;
		}
		
		public new void Clear()
		{
			base.Clear();
			CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
		
		public new bool TryPop(out T item)
		{
			bool result = base.TryPop(out item);
			if (result)
				CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, Count));
			return result;
		}
	}
}