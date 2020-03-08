using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData", order = 1)]
public class BulletDataScriptableObject : ScriptableObject
{
	public float distanceToCollide = 1f;
	public float bulletVelocity = 1f;
}
