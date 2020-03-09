using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManagerView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;

    public void SetCurrentScore(Score score)
	{
		scoreText.text = score.currentScore.ToString();
	}

	internal void SetCurrentHighScore(Score score)
	{
		scoreText.text = string.Format("HighScore: {0}", score.highScore);
	}
}
