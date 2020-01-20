using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
	[SerializeField] private GameObject playerCharacter;
	[SerializeField] private Goal goal;
	[SerializeField] private GameObject _gameScoreViewer;

	private static GameObject GameScoreViewer;
	private static int _gameScore;

	public static int GameScore {
		get
		{
			return _gameScore;
		}
		set
		{
			_gameScore = value;
			UpdateGameScore();
		}
	}

	private void Awake()
	{
		GameScoreViewer = _gameScoreViewer;
		GameScore = 0;
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

	private static void UpdateGameScore()
	{
		GameScoreViewer.GetComponent<Text>().text = "Score: " + GameScore.ToString();
	}
}
