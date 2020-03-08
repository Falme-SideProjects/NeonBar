using System;
using UnityEngine;

public class PlayerBar : MonoBehaviour
{
	private PlayerBarView playerBarView;

	private const float barDivisor = 49.8305f;

	private void Awake()
	{
		playerBarView = GetComponent<PlayerBarView>();
	}

	private void OnEnable()
	{
		EventManager.OnWindowResized.AddListener(UpdateBarSize);
	}

	private void OnDisable()
	{
		EventManager.OnWindowResized.RemoveListener(UpdateBarSize);
	}

	private void UpdateBarSize()
	{
		playerBarView.ChangeBarSize(GetBarWidthBasedOnWindowWidth(GetWindowWidth()));
	}

	public float GetBarWidthBasedOnWindowWidth(float windowWidth)
	{
		float result = windowWidth / barDivisor;
		return (float)Math.Round(result, 2);
	}
    
	public float GetWindowWidth()
	{
		#if UNITY_EDITOR
			return Utils.GetMainGameViewSize().x;
		#else
			return Screen.width;
		#endif
	}
}
