using System;
using UnityEngine;

public static class Utils
{
	public static Vector2 GetMainGameViewSize()
	{
		Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
		System.Reflection.MethodInfo GetSizeOfMainGameView = T.GetMethod("GetSizeOfMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
		object Res = GetSizeOfMainGameView.Invoke(null, null);
		return (Vector2)Res;
	}


	public static float Truncate(float num, int points)
	{
		int afterComma = (int)Math.Pow(10, points);
		return (float)Math.Truncate(num * afterComma) / afterComma;
	}
}
