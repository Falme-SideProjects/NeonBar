using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
	public static Enums.GameDifficulty gameDifficulty;
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
		Enums.GameDifficulty _difficulty = Enums.GameDifficulty.Easy;
		if (screenWidth > 900) _difficulty = Enums.GameDifficulty.VeryHard;
		else if (screenWidth > 600) _difficulty = Enums.GameDifficulty.Hard;
		else if (screenWidth > 300) _difficulty = Enums.GameDifficulty.Medium;

		gameDifficulty = _difficulty;
		EventManager.OnChangedGameDifficulty.Invoke(_difficulty);
	}
}
