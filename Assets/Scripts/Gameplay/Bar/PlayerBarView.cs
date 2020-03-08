using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarView : MonoBehaviour
{
	[SerializeField] private GameObject bar, barGlow;

	private SpriteRenderer barSpriteRenderer, barGlowSpriteRenderer;

	public void Awake()
	{
		barSpriteRenderer = bar?.GetComponent<SpriteRenderer>();
		barGlowSpriteRenderer = barGlow?.GetComponent<SpriteRenderer>();

		if (barSpriteRenderer == null) Debug.LogError("Sprite Bar was not set successfully");
		if (barGlowSpriteRenderer == null) Debug.LogError("Sprite Bar Glow was not set successfully");
	}
	
	public void ChangeBarSize(float newSize)
	{
		if (newSize < 0) newSize = 0;
		this.barSpriteRenderer.size = new Vector2(newSize, this.barSpriteRenderer.size.y);
		this.barGlowSpriteRenderer.size = new Vector2(newSize, this.barGlowSpriteRenderer.size.y);
	}

	public float GetBarSize()
	{
		return this.barSpriteRenderer.size.x;
	}

	public GameObject GetBar()
	{
		return this.bar;
	}

	public GameObject GetBarGlow()
	{
		return this.barGlow;
	}

	public void SetBar(GameObject newObject)
	{
		this.bar = newObject;
	}

	public void SetBarGlow(GameObject newObject)
	{
		this.barGlow = newObject;
	}

	public void ChangeColor(Color32 newColor)
	{
		barSpriteRenderer.color =
		barGlowSpriteRenderer.color = newColor;
	}
}
