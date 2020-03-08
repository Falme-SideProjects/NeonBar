using System;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
	public class PlayerBarTests
    {
		PlayerBar playerBar;

		[SetUp]
		public void Setup()
		{
			playerBar = new GameObject().AddComponent<PlayerBar>();
		}

        [Test]
		[TestCase(570f, 11.56f)]
        public void GetBarWidthBasedOnWindowWidth_SetNewValue_BarKeepsOnEdges(float _windowWidth, float _expectedSpriteWidth)
        {
			Debug.Log(playerBar.GetWindowWidth());

			float result = playerBar.GetBarWidthBasedOnWindowWidth(_windowWidth);

			Assert.AreEqual((float)Math.Round(_expectedSpriteWidth, 2), (float)Math.Round(result, 2));
        }
    }
}
