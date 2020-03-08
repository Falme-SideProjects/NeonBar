using System;
using UnityEngine;

[Serializable]
public class ColorState
{
	[HideInInspector] public Enums.Colors currentColor = Enums.Colors.Green;
	public ColorsDataScriptableObject colorsData;
}
