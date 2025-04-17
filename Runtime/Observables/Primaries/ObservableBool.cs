using UnityEngine.Events;

namespace TripleA.Utils.Observables.Primaries
{
	[System.Serializable]
	public class ObservableBool : Observable<bool>
	{
		public ObservableBool(bool value, UnityAction<bool> callback = null) : base(value, callback)
		{
		}
	}
}