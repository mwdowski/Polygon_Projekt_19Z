using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;


public class GameplayManager : MonoBehaviour
{
	[SerializeField] private GameObject playerCharacter;


	private void Awake()
	{
		Assert.IsNotNull(playerCharacter);
	}

	private void Update()
	{
		if (playerCharacter == null || Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
		}
	}
}
