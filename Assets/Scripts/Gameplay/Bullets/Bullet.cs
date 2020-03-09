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

	void Awake()
    {
		bulletView = GetComponent<BulletView>();
    }

	private void Start()
	{
		int rand = Random.Range(0, 100);
		Color32 color = colorState.colorsData.colorGreen;

		if(rand>50)
		{
			colorState.currentColor = Enums.Colors.Red;
			color = colorState.colorsData.colorRed;
		}

		bulletView.ChangeColor(color);

		if (transform.localPosition.y < 0f) directionUp = true;
		UpdateGameDifficulty(WindowManager.gameDifficulty);
	}

	private void OnEnable()
	{
		EventManager.OnChangedGameDifficulty.AddListener(UpdateGameDifficulty);
		EventManager.OnDestroyAllBullets.AddListener(OnDestroyAllBullets);
	}

	private void OnDisable()
	{
		EventManager.OnChangedGameDifficulty.RemoveListener(UpdateGameDifficulty);
		EventManager.OnDestroyAllBullets.RemoveListener(OnDestroyAllBullets);
	}

	void Update()
    {
		MoveBulletDown();
		CheckBulletCollided();
	}

	private void MoveBulletDown()
	{
		transform.position += (directionUp ? Vector3.up:Vector3.down) * (bulletData.bulletVelocity * velocityModifier) * Time.deltaTime;
	}

	private void CheckBulletCollided()
	{
		if(transform.localPosition.y < bulletData.distanceToCollide &&
			transform.localPosition.y > -bulletData.distanceToCollide)
		{
			EventManager.OnBulletCollidedWithBar.Invoke(colorState.currentColor);
			Destroy(gameObject);
		}
	}

	private void OnDestroyAllBullets()
	{
		Destroy(gameObject);
	}

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
				break;
		}
	}
}
