using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
	[SerializeField] private SpriteRenderer bulletBorder, bulletGlow;

	public void ChangeColor(Color32 newColor)
	{
		bulletBorder.color =
		bulletGlow.color = newColor;
	}
}
