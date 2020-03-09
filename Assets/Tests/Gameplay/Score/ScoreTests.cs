using NUnit.Framework;

namespace Tests
{
	public class ScoreTests
    {
		Score score;

		[SetUp]
		public void Setup()
		{
			this.score = new Score();
		}


        [Test]
		[TestCase(1,1,1)]
		[TestCase(1, 0, 1)]
		[TestCase(1, 5, 5)]
		[TestCase(-10, -5, 0)]
		[TestCase(0, 0, 0)]
		[TestCase(99, 1, 99)]
		public void CheckHighScore_IfCurrentScoreMoreThanHighScore_SetHighScoreAsScore(int _currentScore, int _currentHighScore, int _expectedHighScore)
        {
			this.score.currentScore = _currentScore;
			this.score.highScore = _currentHighScore;

			this.score.CheckHighScore();

			Assert.AreEqual(_expectedHighScore, this.score.highScore);
		}
		
    }
}
