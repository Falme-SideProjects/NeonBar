using System;
using UnityEngine;

public class PlayerBar : MonoBehaviour
{
	[SerializeField] private PlayerBarScriptableObject playerBarData;
	[SerializeField] private ColorState colorState;

	private PlayerBarView playerBarView;

	private void Awake()
	{
		//colorState = new ColorState();
		playerBarView = GetComponent<PlayerBarView>();
	}

	private void Start()
	{
		UpdateBarSize();
	}

	private void OnEnable()
	{
		EventManager.OnWindowResized.AddListener(UpdateBarSize);
		EventManager.OnBulletCollidedWithBar.AddListener(HitBulletInBar);
	}

	private void OnDisable()
	{
		EventManager.OnWindowResized.RemoveListener(UpdateBarSize);
		EventManager.OnBulletCollidedWithBar.RemoveListener(HitBulletInBar);
	}

	private void Update()
	{
		VerifyPlayerChangedColor();
	}

	#region Receive Collision Methods
	
	private void HitBulletInBar(Enums.Colors bulletColor)
	{
		if(this.colorState.currentColor.Equals(bulletColor))
		{
			Debug.Log("Right color, +1 Point");
		} else
		{
			Debug.Log("Wrong Color, No Points");
		}
	}

	#endregion

	#region Color Methods

	private void VerifyPlayerChangedColor()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeToGreen();
		else if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeToRed();
	}

	private void ChangeToGreen()
	{
		colorState.currentColor = Enums.Colors.Green;
		playerBarView.ChangeColor(colorState.colorsData.colorGreen);
	}

	private void ChangeToRed()
	{
		colorState.currentColor = Enums.Colors.Red;
		playerBarView.ChangeColor(colorState.colorsData.colorRed);
	}


	#endregion

	#region Bar Size Methods
	private void UpdateBarSize()
	{
		float _windowWidth = GetWindowWidth();
		float _barWidth = GetBarWidthBasedOnWindowWidth(_windowWidth);
		playerBarView.ChangeBarSize(_barWidth);
	}

	public float GetBarWidthBasedOnWindowWidth(float windowWidth)
	{
		float result = windowWidth / playerBarData.BarDivisor;
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

	#endregion
}
