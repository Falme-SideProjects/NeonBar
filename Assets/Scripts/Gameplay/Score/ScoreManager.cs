using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	private Score scoreEasy, scoreMedium, scoreHard, scoreVeryHard, score;
	private ScoreManagerView scoreManagerView;

	private Enums.GameDifficulty gameDifficulty = Enums.GameDifficulty.Easy;

	private void Awake()
	{
		InitializeScore();
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

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.T)) ChangeScoreDifficulty(Enums.GameDifficulty.Easy);
		else if (Input.GetKeyDown(KeyCode.Y)) ChangeScoreDifficulty(Enums.GameDifficulty.Medium);
		else if (Input.GetKeyDown(KeyCode.U)) ChangeScoreDifficulty(Enums.GameDifficulty.Hard);
		else if (Input.GetKeyDown(KeyCode.I)) ChangeScoreDifficulty(Enums.GameDifficulty.VeryHard);
	}

	public void InitializeScore()
	{
		scoreEasy = new Score();
		scoreMedium = new Score();
		scoreHard = new Score();
		scoreVeryHard = new Score();
		score = scoreEasy;
	}

	private void AddScore()
	{
		AddValueToCurrentScore(1);
		scoreManagerView.SetCurrentScore(score);
	}

	public void AddValueToCurrentScore(int value)
	{
		score.currentScore += value;
		if (score.currentScore < 0) score.currentScore = 0;
		score.CheckHighScore();
	}

	public int GetCurrentScore()
	{
		return this.score.currentScore;
	}

	private void ChangeScoreDifficulty(Enums.GameDifficulty newDifficulty)
	{
		gameDifficulty = newDifficulty;

		switch(gameDifficulty)
		{
			case Enums.GameDifficulty.Easy:
				score = scoreEasy;
				break;
			case Enums.GameDifficulty.Medium:
				score = scoreMedium;
				break;
			case Enums.GameDifficulty.Hard:
				score = scoreHard;
				break;
			case Enums.GameDifficulty.VeryHard:
				score = scoreVeryHard;
				break;
			default:
				break;
		}

		scoreManagerView.SetCurrentScore(score);
	}
}
