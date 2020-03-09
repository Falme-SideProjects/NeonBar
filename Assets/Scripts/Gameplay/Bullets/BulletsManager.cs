using System.Collections;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
	[SerializeField] private GameDifficultyScriptableObject gameDifficultyData;
	[SerializeField] private GameObject bulletPrefab;

	private BulletsManagerView bulletsManagerView;
	private Coroutine bulletsGenerationCoroutine;
	private bool spawnDirection;
	private float spawnTimeDivisor;

	private const float spawnBulletYDistance = 7f;
	private const float spawnBulletXDivisor = 137.79f;

	private void Awake()
	{
		bulletsManagerView = GetComponent<BulletsManagerView>();
	}
	
	private void OnEnable()
	{
		EventManager.OnChangedGameDifficulty.AddListener(OnChangedGameDifficulty);
		EventManager.OnSetGameState.AddListener(OnSetGameState);
	}

	private void OnDisable()
	{
		EventManager.OnChangedGameDifficulty.RemoveListener(OnChangedGameDifficulty);
		EventManager.OnSetGameState.RemoveListener(OnSetGameState);
	}

	private void OnSetGameState(Enums.GameState state)
	{
		if(state.Equals(Enums.GameState.Gameplay))
		{
			bulletsGenerationCoroutine = StartCoroutine(GenerateBullets());
		} else
		{
			if(bulletsGenerationCoroutine != null)
				StopCoroutine(bulletsGenerationCoroutine);
		}
	}

	private IEnumerator GenerateBullets()
	{
		while(true)
		{
			yield return new WaitForSeconds((1f/spawnTimeDivisor));
			CreateNewBullet(spawnDirection);
			spawnDirection = !spawnDirection;
		}
	}

	private void CancelBulletsGeneration()
	{
		StopCoroutine(bulletsGenerationCoroutine);
	}

	private void CreateNewBullet(bool up)
	{
		GameObject _bullet = Instantiate(bulletPrefab, transform);
		_bullet.transform.localPosition = transform.localPosition + ( (up ? Vector3.up:Vector3.down) * spawnBulletYDistance);

		float _distanceSpawnX = MaxDistanceToSpawnBulletInX(Screen.width);

		_bullet.transform.localPosition += Vector3.right * Random.Range(-_distanceSpawnX, _distanceSpawnX);
	}

	public float MaxDistanceToSpawnBulletInX(int screenWidth)
	{
		return screenWidth / spawnBulletXDivisor;
	}

	private void OnChangedGameDifficulty(Enums.GameDifficulty difficulty)
	{
		switch (difficulty)
		{
			case Enums.GameDifficulty.Easy:
				spawnTimeDivisor = gameDifficultyData.easyDifficulty.spawnIntervalModifier;
				break;
			case Enums.GameDifficulty.Medium:
				spawnTimeDivisor = gameDifficultyData.mediumDifficulty.spawnIntervalModifier;
				break;
			case Enums.GameDifficulty.Hard:
				spawnTimeDivisor = gameDifficultyData.hardDifficulty.spawnIntervalModifier;
				break;
			case Enums.GameDifficulty.VeryHard:
				spawnTimeDivisor = gameDifficultyData.veryHardDifficulty.spawnIntervalModifier;
				break;
			default:
				break;
		}
	}


}
