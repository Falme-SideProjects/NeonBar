using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private BulletDataScriptableObject bulletData;
	[SerializeField] private ColorState colorState;

	private BulletView bulletView;
	private bool directionUp;

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
	}

	private void OnEnable()
	{
		EventManager.OnDestroyAllBullets.AddListener(OnDestroyAllBullets);
	}

	private void OnDisable()
	{
		EventManager.OnDestroyAllBullets.RemoveListener(OnDestroyAllBullets);
	}

	void Update()
    {
		MoveBulletDown();
		CheckBulletCollided();
	}

	private void MoveBulletDown()
	{
		transform.position += (directionUp ? Vector3.up:Vector3.down) * bulletData.bulletVelocity * Time.deltaTime;
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
}
