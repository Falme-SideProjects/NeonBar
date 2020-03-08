using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private BulletView bulletView;

    void Awake()
    {
		bulletView = GetComponent<BulletView>();
    }

	private void Start()
	{
		/*int rand = Random.Range(0, 100);
		Enums.Colors color = (rand < 50 ? Enums.Colors.Green : Enums.Colors.Red);
		bulletView.SetColor(color);*/
	}

	void Update()
    {
		MoveBulletDown();
    }

	private void MoveBulletDown()
	{
		transform.position += Vector3.down * 1f * Time.deltaTime;
	}
}
