using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
	private int cachedScreenWidth;

	private void Start()
	{
		cachedScreenWidth = Screen.width;
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
			EventManager.OnWindowResized.Invoke();
			cachedScreenWidth = Screen.width;
		}
	}
}
