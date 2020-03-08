using UnityEngine;

[CreateAssetMenu(fileName ="PlayerBarData", menuName = "ScriptableObjects/PlayerBarData", order = 1)]
public class PlayerBarScriptableObject : ScriptableObject
{

	[SerializeField] private float barDivisor = 49.8305f;
	public float BarDivisor
	{
		get { return barDivisor; }
	}
}
