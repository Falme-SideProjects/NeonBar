using UnityEngine;

public class GameState : MonoBehaviour
{
	private Enums.GameState gameState;

	private void Awake()
	{
		gameState = Enums.GameState.MainMenu;
	}

	private void Start()
	{
		SetGameState();
	}

	private void SetGameState()
	{
		EventManager.OnSetGameState.Invoke(gameState);
	}

}
