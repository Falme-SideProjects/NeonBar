using UnityEngine;

[CreateAssetMenu(fileName = "LivesData", menuName = "ScriptableObjects/LivesData", order = 1)]
public class LivesDataScriptableObject : ScriptableObject
{
	public int initialLives = 3;
}
