using UnityEngine;

public class GameState : MonoBehaviour
{
	public Enums.GameState gameState;

	private void Awake()
	{
		gameState = Enums.GameState.MainMenu;
	}

	private void Start()
	{
		SetGameState();
	}

	public void Update()
	{
		VerifyGoToGameplay();
	}

	private void OnEnable()
	{
		EventManager.OnSetGameState.AddListener(OnSetGameState);
	}

	private void OnDisable()
	{
		EventManager.OnSetGameState.RemoveListener(OnSetGameState);
	}

	private void OnSetGameState(Enums.GameState state)
	{
		gameState = state;
	}

	private void VerifyGoToGameplay()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(gameState.Equals(Enums.GameState.MainMenu))
			{
				ChangeGameStateTo(Enums.GameState.Gameplay);
			}
		}
	}

	private void ChangeGameStateTo(Enums.GameState newState)
	{
		gameState = newState;
		SetGameState();
	}

	private void SetGameState()
	{
		EventManager.OnSetGameState.Invoke(gameState);
	}

}
