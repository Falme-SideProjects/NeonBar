using System.Collections;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
	[SerializeField] private GameObject bulletPrefab;

	private BulletsManagerView bulletsManagerView;
	private Coroutine bulletsGenerationCoroutine;

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
			Instantiate(bulletPrefab, transform);
		}
	}

	private void CancelBulletsGeneration()
	{
		StopCoroutine(bulletsGenerationCoroutine);
	}
}
