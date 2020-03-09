using UnityEngine;

[CreateAssetMenu(fileName = "GameDifficultyData", menuName = "ScriptableObjects/GameDifficultyData", order = 1)]
public class GameDifficultyScriptableObject : ScriptableObject
{
	public DifficultyAttributeScriptableObject easyDifficulty,
												mediumDifficulty,
												hardDifficulty,
												veryHardDifficulty;
}
