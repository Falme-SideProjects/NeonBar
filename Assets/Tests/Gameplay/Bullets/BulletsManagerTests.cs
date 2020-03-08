using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BulletsManagerTests
    {
		BulletsManager bulletsManager;

		[SetUp]
		public void Setup()
		{
			bulletsManager = new GameObject().AddComponent<BulletsManager>();
		}

		[Test]
		[TestCase(751, 5.45f)]
		public void MaxDistanceToSpawnBulletInX_GetNumberInsideScreen(int _screenWidth, float _expected)
		{
			float _distanceSpawnX = bulletsManager.MaxDistanceToSpawnBulletInX(_screenWidth);

			Assert.AreEqual(Utils.Truncate(_expected, 2),Utils.Truncate(_distanceSpawnX, 2));
		}


	}
}
