using UnityEngine.Events;

public static class EventManager
{
	//Gameplay
	public static UnityEvent OnWindowResized = new UnityEvent();
	public static UnityEvent OnPlayerScoredPoint = new UnityEvent();
	public static UnityEvent OnPlayerLostLife = new UnityEvent();
	public static EnumColorEvent OnBulletCollidedWithBar = new EnumColorEvent();
}

public class EnumColorEvent : UnityEvent<Enums.Colors> { }