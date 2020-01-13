using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
	[SerializeField] private DefaultSubmenu howToPlayMenuPrefab = null;
	[SerializeField] private DefaultSubmenu optionsMenuPrefab = null;
    [SerializeField] private DefaultSubmenu creditsMenuPrefab = null;
	private DefaultSubmenu howToPlayMenuInstance = null;
	private DefaultSubmenu optionsMenuInstance = null;
	private DefaultSubmenu creditsMenuInstance = null;
	private DefaultSubmenu currentSubmenu = null;


	//Automatycznie przechodzi miedzy wybranymi menu i cofa do glownego menu.
	private DefaultSubmenu CurrentSubmenu
	{
		get
		{
			return currentSubmenu;
		}

		set
		{
			if (currentSubmenu == null)
			{
				gameObject.SetActive(false);
			}
			else
			{
				currentSubmenu.gameObject.SetActive(false);
				currentSubmenu.Button.onClick.RemoveListener(OnBackButtonClicked);
			}
			currentSubmenu = value;
			if (currentSubmenu == null)
			{
				gameObject.SetActive(true);
			}
			else
			{
				currentSubmenu.gameObject.SetActive(true);
				currentSubmenu.Button.onClick.AddListener(OnBackButtonClicked);
			}
		}
	}


	//Na starcie gry podległe menu zostają stworzone i wyłączone.
	private void Awake()
	{
		Assert.IsNotNull(howToPlayMenuPrefab, "Missing howToPlayMenuPrefab on: " + gameObject.name);
		Assert.IsNotNull(optionsMenuPrefab, "Missing optionsMenuPrefab on: " + gameObject.name);
		Assert.IsNotNull(creditsMenuPrefab, "Missing creditsMenuPrefab on: " + gameObject.name);		
		howToPlayMenuInstance = Instantiate(howToPlayMenuPrefab, transform.parent);
		howToPlayMenuInstance.gameObject.SetActive(false);
		optionsMenuInstance = Instantiate(optionsMenuPrefab, transform.parent);
		optionsMenuInstance.gameObject.SetActive(false);
		creditsMenuInstance = Instantiate(creditsMenuPrefab, transform.parent);
		creditsMenuInstance.gameObject.SetActive(false);
	}

	//Cofniecie sie do MainMenu.
	private void OnBackButtonClicked()
	{
		CurrentSubmenu = null;
	}

	public void StartGame()
	{
<<<<<<< HEAD:Assets/Scripts/Menus/MainMenu.cs
		//TODO: Uruchamianie sceny z rozgrywką.
=======
		SceneManager.LoadScene("Game", LoadSceneMode.Single);
>>>>>>> Game_Scene:Assets/Scripts/MainMenu.cs
	}

	public void OpenHowToPlay()
	{
		CurrentSubmenu = howToPlayMenuInstance;
	}

	public void OpenOptionsMenu()
	{
		CurrentSubmenu = optionsMenuInstance;
	}

	public void OpenCreditsMenu()
	{
		CurrentSubmenu = creditsMenuInstance;
	}

	public void QuitGame()
    {
		Application.Quit();
	}
}
