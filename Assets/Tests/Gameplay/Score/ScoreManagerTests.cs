using NUnit.Framework;
using UnityEngine;

namespace Tests
{
	public class ScoreManagerTests
    {
		private ScoreManager scoreManager;

		[SetUp]
		public void Setup()
		{
			scoreManager = new GameObject().AddComponent<ScoreManager>();
			scoreManager.InitializeScore();
		}

        [Test]
		[TestCase(1,1)]
		[TestCase(10, 10)]
		[TestCase(999, 999)]
		[TestCase(0, 0)]
		[TestCase(-20, 0)]
		public void AddValueToCurrentScore_AddValue_changesCurrentScore(int _addedScore, int _expected)
        {
			scoreManager.AddValueToCurrentScore(_addedScore);

			Assert.AreEqual(_expected, scoreManager.GetCurrentScore());
        }


    }
}
