using UnityEngine.Events;

namespace TripleA.Observables.Primaries
{
	[System.Serializable]
	public class ObservableInt : Observable<int>
	{
		public ObservableInt(int value, UnityAction<int> callback = null) : base(value, callback)
		{
		}
	}
}