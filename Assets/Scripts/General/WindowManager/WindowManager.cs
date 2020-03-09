using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
	public static Enums.GameDifficulty gameDifficulty;
	private int cachedScreenWidth;

	private const int veryHardDifficultyWidth = 900,
						hardDifficultyWidth = 600,
						mediumDifficultyWidth = 300;

	private const int screenLockedHeight = 575;

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
		if (Screen.height != screenLockedHeight) Screen.SetResolution(Screen.width, screenLockedHeight, false);
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

		if (screenWidth > veryHardDifficultyWidth) _difficulty = Enums.GameDifficulty.VeryHard;
		else if (screenWidth > hardDifficultyWidth) _difficulty = Enums.GameDifficulty.Hard;
		else if (screenWidth > mediumDifficultyWidth) _difficulty = Enums.GameDifficulty.Medium;

		gameDifficulty = _difficulty;
		EventManager.OnChangedGameDifficulty.Invoke(_difficulty);
	}
}
