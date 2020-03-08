using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesManagerView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI livesText;

	private const string livesString = "Lives: {0}";

	public void UpdateLivesText(int lives)
	{
		livesText.text = string.Format(livesString, lives);
	}
}
