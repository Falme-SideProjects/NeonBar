using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	private UIManagerView uiManagerView;

	private void Awake()
	{
		uiManagerView = GetComponent<UIManagerView>();
	}

	private void OnEnable()
	{
		EventManager.OnChangedGameDifficulty.AddListener(OnChangedGameDifficulty);
		EventManager.OnSetGameState.AddListener(OnSetGameState);
	}

	private void OnDisable()
	{
		EventManager.OnChangedGameDifficulty.RemoveListener(OnChangedGameDifficulty);
		EventManager.OnSetGameState.RemoveListener(OnSetGameState);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q)) EventManager.OnChangedGameDifficulty.Invoke(Enums.GameDifficulty.Easy);
		else if (Input.GetKeyDown(KeyCode.W)) EventManager.OnChangedGameDifficulty.Invoke(Enums.GameDifficulty.Medium);
		else if (Input.GetKeyDown(KeyCode.E)) EventManager.OnChangedGameDifficulty.Invoke(Enums.GameDifficulty.Hard);
		else if (Input.GetKeyDown(KeyCode.R)) EventManager.OnChangedGameDifficulty.Invoke(Enums.GameDifficulty.VeryHard);
	}

	private void OnChangedGameDifficulty(Enums.GameDifficulty newDifficulty)
	{
		uiManagerView.ChangeDifficultyText(newDifficulty);
	}

	private void OnSetGameState(Enums.GameState state)
	{
		if(state.Equals(Enums.GameState.Gameplay))
		{
			uiManagerView.HideMainMenuUI();
			uiManagerView.ShowGameplayUI();
		} else
		{
			uiManagerView.ShowMainMenuUI();
			uiManagerView.HideGameplayUI();
		}
	}
}
