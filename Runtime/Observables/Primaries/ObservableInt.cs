using UnityEngine.Events;

namespace Utils.TripleA.Observables.Primaries
{
	[System.Serializable]
	public class ObservableInt : Observable<int>
	{
		public ObservableInt(int value, UnityAction<int> callback = null) : base(value, callback)
		{
		}
	}
}