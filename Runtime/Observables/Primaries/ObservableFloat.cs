using UnityEngine.Events;

namespace Utils.TripleA.Observables.Primaries
{
	[System.Serializable]
	public class ObservableFloat : Observable<float>
	{
		public ObservableFloat(float value, UnityAction<float> callback = null) : base(value, callback)
		{
		}
	}
}