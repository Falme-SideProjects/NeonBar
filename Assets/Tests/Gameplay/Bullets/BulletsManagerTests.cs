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
		
    }
}
