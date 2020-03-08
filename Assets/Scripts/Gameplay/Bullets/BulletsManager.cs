using System.Collections;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
	[SerializeField] private GameObject bulletPrefab;

	private BulletsManagerView bulletsManagerView;
	private Coroutine bulletsGenerationCoroutine;
	private bool spawnDirection;

	private const float spawnBulletDistance = 7f; 

	private void Awake()
	{
		bulletsManagerView = GetComponent<BulletsManagerView>();
	}

	public void Start()
	{
		bulletsGenerationCoroutine = StartCoroutine(GenerateBullets());
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha0)) CancelBulletsGeneration();
	}

	private IEnumerator GenerateBullets()
	{
		while(true)
		{
			yield return new WaitForSeconds(1f);
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
		_bullet.transform.localPosition = transform.localPosition + ( (up ? Vector3.up:Vector3.down) * spawnBulletDistance);
	}
	
}
