using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerBarViewTests
    {
		private GameObject barObject;
		private PlayerBarView playerBarView;

		[SetUp]
		public void Setup()
		{
			barObject = new GameObject();
			playerBarView = barObject.AddComponent<PlayerBarView>();

			playerBarView.SetBar(new GameObject());
			playerBarView.SetBarGlow(new GameObject());

			playerBarView.GetBar().AddComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Sliced;
			playerBarView.GetBarGlow().AddComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Sliced;

			playerBarView.Awake();
		}
		
        [Test]
		[TestCase(40.5f, 40.5f)]
		[TestCase(0f, 0f)]
		[TestCase(400f, 400f)]
		[TestCase(-15f, 0f)]
		public void ChangeBarSize_OnChangeValue_SetX(float _input, float _expected)
        {
			playerBarView.ChangeBarSize(_input);
			Assert.AreEqual(_expected, playerBarView.GetBarSize());
		}
    }
}
