using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
	private int cachedScreenWidth;

	private void Start()
	{
		cachedScreenWidth = Screen.width;
		RefreshResizedWindowInfo();
	}

	void Update()
    {
		VerifyScreenHeightChanged();
		VerifyScreenWidthChanged();
	}

	private void VerifyScreenHeightChanged()
	{
		if (Screen.height != 575) Screen.SetResolution(Screen.width, 575, false);
	}

	private void VerifyScreenWidthChanged()
	{
		if(cachedScreenWidth != Screen.width)
		{
			RefreshResizedWindowInfo();
		}
	}

	private void RefreshResizedWindowInfo()
	{
		EventManager.OnWindowResized.Invoke();
		cachedScreenWidth = Screen.width;
		CheckWidthDifficultyLimits(cachedScreenWidth);
	}

	private void CheckWidthDifficultyLimits(int screenWidth)
	{
		if (screenWidth > 900) EventManager.OnChangedGameDifficulty.Invoke(Enums.GameDifficulty.VeryHard);
		else if (screenWidth > 600) EventManager.OnChangedGameDifficulty.Invoke(Enums.GameDifficulty.Hard);
		else if (screenWidth > 300) EventManager.OnChangedGameDifficulty.Invoke(Enums.GameDifficulty.Medium);
		else  EventManager.OnChangedGameDifficulty.Invoke(Enums.GameDifficulty.Easy);
	}
}
