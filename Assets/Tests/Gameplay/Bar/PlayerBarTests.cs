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
		[TestCase(570f, 49.8305f, 11.43f)]
		[TestCase(1667f, 49.8305f, 33.45f)]
		[TestCase(250f, 49.8305f, 5.02f)]
		public void GetBarWidthBasedOnWindowWidth_SetNewValue_BarKeepsOnEdges(float _windowWidth, float _divisor, float _expectedSpriteWidth)
        {
			float result = playerBar.GetBarWidthBasedOnWindowWidth(_windowWidth, _divisor);

			Assert.AreEqual(Utils.Truncate(_expectedSpriteWidth, 2), Utils.Truncate(result, 2));
        }


    }
}
