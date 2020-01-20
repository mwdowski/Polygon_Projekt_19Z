using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
	[SerializeField] private GameObject playerCharacter;
	[SerializeField] private Goal goal;


	private void Awake()
	{
		Assert.IsNotNull(playerCharacter);
		Assert.IsNotNull(goal);
		goal.OnPlayerTouched += PlayerTouchedGoal;
	}

	private void Update()
	{
		if (playerCharacter == null || Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
		}
	}

	private void PlayerTouchedGoal()
	{
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}
}
