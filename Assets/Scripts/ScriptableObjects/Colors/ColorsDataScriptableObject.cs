using UnityEngine;

[CreateAssetMenu(fileName = "ColorsData", menuName = "ScriptableObjects/ColorsData", order = 1)]
public class ColorsDataScriptableObject : ScriptableObject
{
	[Header("Bar and Bullets Color")]
	public Color32 colorGreen, colorRed;

	[Header("Difficulty Colors")]
	public Color32 colorEasy, colorMedium, colorHard, colorVeryHard;
}
