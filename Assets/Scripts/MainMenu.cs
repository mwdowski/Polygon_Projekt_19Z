using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private DefaultSubmenu optionsMenu;
    [SerializeField] private DefaultSubmenu creditsMenu;

    private void Awake() //na starcie gry menu opcji i credits zostają wyłączone
    {
        optionsMenu.gameObject.SetActive(false);
        creditsMenu.gameObject.SetActive(false);
    }

    private DefaultSubmenu currentSubmenu;

    private void OnBackButtonClicked() //cofniecie sie do MainMenu
    {
        CurrentSubmenu = null;
    }

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

	public void OpenOptionsMenu()
    {
       CurrentSubmenu = optionsMenu;
    }

    public void OpenCreditsMenu()
    {
       CurrentSubmenu = creditsMenu;
    }

}
