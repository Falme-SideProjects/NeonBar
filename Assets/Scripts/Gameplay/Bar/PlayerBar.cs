using System;
using UnityEngine;

public class PlayerBar : MonoBehaviour
{
	private PlayerBarView playerBarView;

	private void Awake()
	{
		playerBarView = GetComponent<PlayerBarView>();
	}

	public void Update()
	{
		playerBarView.ChangeBarSize(GetBarWidthBasedOnWindowWidth(GetWindowWidth()));
	}

	public float GetBarWidthBasedOnWindowWidth(float windowWidth)
	{
		float result = windowWidth / 49.307f;
		return (float)Math.Round(result, 2);
	}
    
	public float GetWindowWidth()
	{
#if UNITY_EDITOR
		return GetMainGameViewSize().x;
#else
		return Screen.width;
#endif
	}

	public static Vector2 GetMainGameViewSize()
	{
		System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
		System.Reflection.MethodInfo GetSizeOfMainGameView = T.GetMethod("GetSizeOfMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
		System.Object Res = GetSizeOfMainGameView.Invoke(null, null);
		return (Vector2)Res;
	}
}
