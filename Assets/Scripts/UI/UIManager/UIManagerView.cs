using UnityEngine;
using TMPro;

public class UIManagerView : MonoBehaviour
{
	private const string easyString = "EASY",
							mediumString = "MEDIUM",
							hardString = "HARD",
							veryHardString = "VERY HARD";

	[SerializeField] private ColorsDataScriptableObject colorsData;

	[Header("Main Menu")]
	[SerializeField] private GameObject mainMenuUI;
	[SerializeField] private TextMeshProUGUI difficultyText;

	[Header("Gameplay")]
	[SerializeField] private TextMeshProUGUI livesText;

	

	public void ChangeDifficultyText(Enums.GameDifficulty newDifficulty)
	{
		switch(newDifficulty)
		{
			case Enums.GameDifficulty.Easy:
				this.difficultyText.text = easyString;
				this.difficultyText.color = colorsData.colorEasy;
				break;
			case Enums.GameDifficulty.Medium:
				this.difficultyText.text = mediumString;
				this.difficultyText.color = colorsData.colorMedium;
				break;
			case Enums.GameDifficulty.Hard:
				this.difficultyText.text = hardString;
				this.difficultyText.color = colorsData.colorHard;
				break;
			case Enums.GameDifficulty.VeryHard:
				this.difficultyText.text = veryHardString;
				this.difficultyText.color = colorsData.colorVeryHard;
				break;
			default:
				Debug.LogError("Difficulty not Set Correctly");
				break;
		}
	}

	public void HideMainMenuUI()
	{
		mainMenuUI.SetActive(false);
	}

	public void ShowMainMenuUI()
	{
		mainMenuUI.SetActive(true);
	}

	public void ShowGameplayUI()
	{
		livesText.gameObject.SetActive(true);
	}

	public void HideGameplayUI()
	{
		livesText.gameObject.SetActive(false);
	}

}
