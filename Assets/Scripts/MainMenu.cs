using UnityEngine;
using UnityEngine.Assertions;


public class MainMenu : MonoBehaviour
{
	[SerializeField] private DefaultSubmenu optionsMenuPrefab = null;
    [SerializeField] private DefaultSubmenu creditsMenuPrefab = null;
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


	//Na starcie gry menu opcji i credits zostają wyłączone.
	private void Awake()
	{
		Assert.IsNotNull(optionsMenuPrefab, "Missing optionsMenuPrefab on: " + gameObject.name);
		Assert.IsNotNull(creditsMenuPrefab, "Missing creditsMenuPrefab on: " + gameObject.name);
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

	//Stworzenie menu opcji i przejscie do niego.
	public void OpenOptionsMenu()
	{
		CurrentSubmenu = optionsMenuInstance;
	}

	//Stworzenie menu napisow tworcow i przejscie do niego.
	public void OpenCreditsMenu()
	{
		CurrentSubmenu = creditsMenuInstance;
	}

	//Funkcja do wyjscia z gry.
	public void Quit()
    {
		Application.Quit();
	}
}
