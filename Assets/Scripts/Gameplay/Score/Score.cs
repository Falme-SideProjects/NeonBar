public class Score
{
	public int currentScore;
	public int highScore;

	public void CheckHighScore()
	{
		if (currentScore > highScore) highScore = currentScore;
		if (highScore < 0) highScore = 0;
	}
}
