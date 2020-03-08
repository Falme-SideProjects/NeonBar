using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManagerView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;

    public void SetCurrentScore(Score score)
	{
		scoreText.text = score.currentScore.ToString();
	}
}
