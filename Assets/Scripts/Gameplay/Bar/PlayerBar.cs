using System;
using UnityEngine;

public class PlayerBar : MonoBehaviour
{
	[SerializeField] private PlayerBarScriptableObject playerBarData;

	private PlayerBarView playerBarView;
	private Enums.Colors currentColor = Enums.Colors.Green;

	private void Awake()
	{
		playerBarView = GetComponent<PlayerBarView>();
	}

	private void Start()
	{
		UpdateBarSize();
	}

	private void OnEnable()
	{
		EventManager.OnWindowResized.AddListener(UpdateBarSize);
	}

	private void OnDisable()
	{
		EventManager.OnWindowResized.RemoveListener(UpdateBarSize);
	}

	private void Update()
	{
		VerifyPlayerChangedColor();
		VerifyPlayerSimulatedHit();
	}

	#region Receive Collision Methods

	private void VerifyPlayerSimulatedHit()
	{
		if (Input.GetKeyDown(KeyCode.Q)) HitBulletInBar(Enums.Colors.Green);
		else if (Input.GetKeyDown(KeyCode.W)) HitBulletInBar(Enums.Colors.Red);
	}

	private void HitBulletInBar(Enums.Colors bulletColor)
	{
		if(this.currentColor.Equals(bulletColor))
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
		currentColor = Enums.Colors.Green;
		playerBarView.ChangeColor(playerBarData.colorGreen);
	}

	private void ChangeToRed()
	{
		currentColor = Enums.Colors.Red;
		playerBarView.ChangeColor(playerBarData.colorRed);
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
