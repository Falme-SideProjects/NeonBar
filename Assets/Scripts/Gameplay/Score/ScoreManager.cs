using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	private Score score;
	private ScoreManagerView scoreManagerView;

	private void Awake()
	{
		score = new Score();
		scoreManagerView = GetComponent<ScoreManagerView>();
	}

	private void OnEnable()
	{
		EventManager.OnPlayerScoredPoint.AddListener(AddScore);
	}

	private void OnDisable()
	{
		EventManager.OnPlayerScoredPoint.RemoveListener(AddScore);
	}

	private void AddScore()
	{
		score.currentScore++;
		scoreManagerView.SetCurrentScore(score);
	}
}
