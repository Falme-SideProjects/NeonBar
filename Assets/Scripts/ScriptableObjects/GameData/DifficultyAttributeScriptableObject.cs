
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyAttributeData", menuName = "ScriptableObjects/DifficultyAttributeData", order = 1)]
public class DifficultyAttributeScriptableObject : ScriptableObject
{
	public float bulletVelocityModifier = 1f;
	public float spawnIntervalModifier = 1f;
}
