using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private DefaultSubmenu optionsMenu;
    [SerializeField] private DefaultSubmenu creditsMenu;
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


	private void Awake() //na starcie gry menu opcji i credits zostają wyłączone
	{
		optionsMenu.gameObject.SetActive(false);
		creditsMenu.gameObject.SetActive(false);
	}

	private void OnBackButtonClicked() //cofniecie sie do MainMenu
	{
		CurrentSubmenu = null;
	}

	public void OpenOptionsMenu() //przejscie do menu opcji
    {
       CurrentSubmenu = optionsMenu;
    }

    public void OpenCreditsMenu() //przejscie do napisow tworcow
    {
       CurrentSubmenu = creditsMenu;
    }

}
