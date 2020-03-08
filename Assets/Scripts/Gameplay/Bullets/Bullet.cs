using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private BulletDataScriptableObject bulletData;

	private BulletView bulletView;
	private bool directionUp;
	private Enums.Colors currentColor = Enums.Colors.Green;

    void Awake()
    {
		bulletView = GetComponent<BulletView>();
    }

	private void Start()
	{
		int rand = Random.Range(0, 100);
		Color32 color = Color.green;

		if(rand>50)
		{
			currentColor = Enums.Colors.Red;
			color = Color.red;
		}

		bulletView.ChangeColor(color);

		if (transform.localPosition.y < 0f) directionUp = true;
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
			EventManager.OnBulletCollidedWithBar.Invoke(currentColor);
			Destroy(gameObject);
		}
	}
}
