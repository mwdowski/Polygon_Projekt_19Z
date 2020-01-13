using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System.Collections.Generic;


public class HowToPlayMenu : DefaultSubmenu
{
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private List<GameObject> pages;
    private int currentPageIndex = 0;


    private int CurrentPageIndex
    {
        get
        {
            return currentPageIndex;
        }

        set
        {
            pages[currentPageIndex].SetActive(false);
            currentPageIndex = value;
            pages[currentPageIndex].SetActive(true);
            UpdatePageButtonsVisibility();
        }
    }


    protected override void Awake()
    {
        base.Awake();
        Assert.IsTrue(pages.Count > 0);
        Assert.IsNotNull(prevButton);
        Assert.IsNotNull(nextButton);
        prevButton.onClick.AddListener(PrevPage);
        nextButton.onClick.AddListener(NextPage);
        backButton.onClick.AddListener(delegate () { CurrentPageIndex = 0; });
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
        pages[currentPageIndex].SetActive(true);
        UpdatePageButtonsVisibility();
    }

    private void NextPage()
    {
        Assert.IsTrue(currentPageIndex < pages.Count - 1);
        ++CurrentPageIndex;
    }

    private void PrevPage()
    {
        Assert.IsTrue(currentPageIndex > 0);
        --CurrentPageIndex;
    }

    private void UpdatePageButtonsVisibility()
    {
        prevButton.gameObject.SetActive(currentPageIndex > 0);
        nextButton.gameObject.SetActive(currentPageIndex < pages.Count - 1);
    }
}
