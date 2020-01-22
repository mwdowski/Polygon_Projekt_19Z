using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameplayManager : MonoBehaviour
{
	[SerializeField] private GameObject playerCharacter;
	[SerializeField] private GameObject _gameScoreViewer;
	[SerializeField] private GameObject userInterface;
	[SerializeField] private GameObject afterDeathScreen;

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
		Time.timeScale = 1f;
		GameScoreViewer = _gameScoreViewer;
		GameScore = 0;
		Assert.IsNotNull(playerCharacter);
		/* - z GOAL
		Assert.IsNotNull(goal);
		goal.OnPlayerTouched += PlayerTouchedGoal;
		*/
	}

	private void Update()
	{
		if (playerCharacter == null || Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale = 0f;
			userInterface.SetActive(false);
			afterDeathScreen.GetComponentInChildren<Text>().text = "Congrats, you scored\n" + GameScore + "\npoints!\n\nPress SPACE to continue...";

			//DontDestroyOnLoad(afterDeathScreen);
			SceneManager.LoadScene("AfterDeathScreen", LoadSceneMode.Single);
		}
	}

	/* z GOAL
	private void PlayerTouchedGoal()
	{
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}
	*/

	private static void UpdateGameScore()
	{
		GameScoreViewer.GetComponent<Text>().text = "Score: " + GameScore.ToString();
	}
}
