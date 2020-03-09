using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private BulletDataScriptableObject bulletData;
	[SerializeField] private GameDifficultyScriptableObject gameDifficultyData;
	[SerializeField] private ColorState colorState;

	private BulletView bulletView;
	private bool directionUp;
	private float velocityModifier;
	private int randomColor;

	#region UnityMethods
	void Awake()
    {
		bulletView = GetComponent<BulletView>();
    }

	private void Start()
	{
		CheckBulletColor();
		CheckBulletDirection();
		UpdateGameDifficulty(WindowManager.gameDifficulty);
	}

	private void OnEnable()
	{
		EventManager.OnChangedGameDifficulty.AddListener(UpdateGameDifficulty);
		EventManager.OnDestroyAllBullets.AddListener(DestroyBullet);
	}

	private void OnDisable()
	{
		EventManager.OnChangedGameDifficulty.RemoveListener(UpdateGameDifficulty);
		EventManager.OnDestroyAllBullets.RemoveListener(DestroyBullet);
	}

	void Update()
    {
		MoveBulletDown();
		CheckBulletCollided();
	}
	#endregion

	#region Bullet Behaviour Methods
	private void CheckBulletColor()
	{
		randomColor = Random.Range(0, 100);
		Color32 color = colorState.colorsData.colorGreen;

		if (randomColor > 50)
		{
			colorState.currentColor = Enums.Colors.Red;
			color = colorState.colorsData.colorRed;
		}

		bulletView.ChangeColor(color);
	}

	private void CheckBulletDirection()
	{
		if (transform.localPosition.y < 0f) directionUp = true;
	}

	private void MoveBulletDown()
	{
		Vector3 _direction = (directionUp ? Vector3.up : Vector3.down);
		float _bulletVelocity = (bulletData.bulletVelocity * velocityModifier);

		transform.position += _direction * _bulletVelocity * Time.deltaTime;
	}

	private void CheckBulletCollided()
	{
		if(transform.localPosition.y < bulletData.distanceToCollide &&
			transform.localPosition.y > -bulletData.distanceToCollide)
		{
			EventManager.OnBulletCollidedWithBar.Invoke(colorState.currentColor);
			DestroyBullet();
		}
	}

	private void DestroyBullet()
	{
		Destroy(gameObject);
	}
	#endregion

	#region Bullet Difficulty Methods
	private void UpdateGameDifficulty(Enums.GameDifficulty difficulty)
	{
		switch(difficulty)
		{
			case Enums.GameDifficulty.Easy:
				velocityModifier = gameDifficultyData.easyDifficulty.bulletVelocityModifier;
				break;
			case Enums.GameDifficulty.Medium:
				velocityModifier = gameDifficultyData.mediumDifficulty.bulletVelocityModifier;
				break;
			case Enums.GameDifficulty.Hard:
				velocityModifier = gameDifficultyData.hardDifficulty.bulletVelocityModifier;
				break;
			case Enums.GameDifficulty.VeryHard:
				velocityModifier = gameDifficultyData.veryHardDifficulty.bulletVelocityModifier;
				break;
			default:
				Debug.LogError("GameDifficulty Not Set Correctly");
				break;
		}
	}
	#endregion
}
