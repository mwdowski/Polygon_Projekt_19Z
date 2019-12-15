using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private DefaultSubmenu optionsMenu;
    [SerializeField] private DefaultSubmenu creditsMenu;
	[SerializeField] private GameObject Submenu;
	private DefaultSubmenu currentSubmenu;


	private DefaultSubmenu CurrentSubmenu //automatycznie przechodzi miedzy wybranymi menu i cofa do glownego menu
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
				Destroy(currentSubmenu.gameObject);
				Submenu.gameObject.SetActive(false);
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
				Submenu.gameObject.SetActive(true);
				currentSubmenu.Button.onClick.AddListener(OnBackButtonClicked);
			}
		}
	}


	private void Awake() //na starcie gry menu opcji i credits zostają wyłączone
	{
		Submenu.gameObject.SetActive(false);
	}

	private void OnBackButtonClicked() //cofniecie sie do MainMenu
	{
		CurrentSubmenu = null;
	}

	public void OpenOptionsMenu() //stworzenie menu opcji i przejscie do niego
	{
		DefaultSubmenu menu_1;
		menu_1 = Instantiate(optionsMenu, Submenu.transform);
		CurrentSubmenu = menu_1;
	}

	public void OpenCreditsMenu() //stworzenie menu napisow tworcow i przejscie do niego
	{
		DefaultSubmenu menu_2;
		menu_2 = Instantiate(creditsMenu, Submenu.transform);
		CurrentSubmenu = menu_2;
	}

	public void quit()//funkcja do wyjscia z gry
    {
		Application.Quit();
	}

}
