﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private BulletDataScriptableObject bulletData;

	private BulletView bulletView;
	private bool directionUp;

    void Awake()
    {
		bulletView = GetComponent<BulletView>();
    }

	private void Start()
	{
		int rand = Random.Range(0, 100);
		Color32 color = (rand < 50 ? Color.green : Color.red);
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
			Destroy(gameObject);
		}
	}
}