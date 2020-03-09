using UnityEngine;

public class LivesManager : MonoBehaviour
{
	[SerializeField] private LivesDataScriptableObject livesData;

	private LivesManagerView livesManagerView;

	private int currentLives;

	#region UnityMethods
	private void Awake()
	{
		livesManagerView = GetComponent<LivesManagerView>();
	}

	private void OnEnable()
	{
		EventManager.OnPlayerLostLife.AddListener(LostALife);
	}

	private void OnDisable()
	{
		EventManager.OnPlayerLostLife.RemoveListener(LostALife);
	}

	private void Start()
	{
		ResetLives();
	}
	#endregion

	private void UpdateLives()
	{
		livesManagerView.UpdateLivesText(currentLives);
	}

	private void ResetLives()
	{
		currentLives = livesData.initialLives;
		if (currentLives <= 0) currentLives = 1;
		UpdateLives();
	}

	private void LostALife()
	{
		currentLives--;
		UpdateLives();
		if (currentLives <= 0) CallGameOver();
	}

	private void CallGameOver()
	{
		EventManager.OnDestroyAllBullets.Invoke();
		EventManager.OnSetGameState.Invoke(Enums.GameState.MainMenu);
		ResetLives();
	}
}
