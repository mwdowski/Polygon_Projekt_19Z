using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    // testValue - value that is going to change when AddTest() or SubstractTest() is called
    [SerializeField] private float testValue = 2137f;
    // multiplier - value that is going to change when TestMultiplier() is called
    [SerializeField] private float multiplier = 1f;
    // anotherMultiplier - value that is going to change when TestAnotherMultiplier() is called
    [SerializeField] private float anotherMultiplier = 1f;
    // yetAnotherMultiplier - value that is going to change when TestYetAnotherMultiplier() is called
    [SerializeField] private float yetAnotherMultiplier = 1f;
    // addButton, substractButton, multiplyToggle, multiplySlider, anotherMultiplySplider - actions on these controls will affect testValue
    [SerializeField] private GameObject addButton, substractButton;
    [SerializeField] private GameObject multiplyToggle;
    [SerializeField] private GameObject multiplySlider, anotherMultiplySlider;
    // showAndHideToggle - shows and hides the rest of controls
    [SerializeField] private GameObject showAndHideToggle;
    // createButton - creates new slider
    [SerializeField] private GameObject createButton;
    // sliderPrefab - prefab of slider that will be created by createButton
    [SerializeField] private GameObject sliderPrefab;
    // canvas - canvas on which all controls are located
    [SerializeField] private GameObject canvas;

    // toShowAndHideList - list of controls of which display should be controlled
    // PYTANIE: czy to opłacalne?
    List<GameObject> toShowAndHideList = new List<GameObject>();

    private void Start()
    {
        toShowAndHideList.Add(addButton);
        toShowAndHideList.Add(substractButton);
        toShowAndHideList.Add(multiplyToggle);
        toShowAndHideList.Add(multiplySlider);

        Button addButtonButton = addButton.GetComponent<Button>();
        Button substractButtonButton = substractButton.GetComponent<Button>();
        Toggle multiplyToggleToggle = multiplyToggle.GetComponent<Toggle>();
        Slider multiplySliderSlider = multiplySlider.GetComponent<Slider>();
        Toggle showAndHideToggleToggle = showAndHideToggle.GetComponent<Toggle>();
        Button createButtonButton = createButton.GetComponent<Button>();

        addButtonButton.onClick.AddListener(TestAdd);
        substractButtonButton.onClick.AddListener(TestSubstract);
        multiplyToggleToggle.onValueChanged.AddListener(delegate { TestMultiplier(); });
        multiplySliderSlider.onValueChanged.AddListener(delegate { TestAnotherMultiplier(multiplySliderSlider.value); });
        showAndHideToggleToggle.onValueChanged.AddListener(delegate {
            if (showAndHideToggleToggle.isOn)
            {
                ShowControls();
            }
            else
            {
                HideControls();
            }
        });
        createButtonButton.onClick.AddListener(CreateNewSlider);
    }

    // TestAdd adds multiplier to testValue
    private void TestAdd()
    {
        testValue += multiplier * anotherMultiplier * yetAnotherMultiplier;
        return;
    }

    // TestAdd substracts multiplier from testValue
    private void TestSubstract()
    {
        testValue -= multiplier * anotherMultiplier * yetAnotherMultiplier;
        return;
    }

    // TestMultiplier changes multiplier
    private void TestMultiplier()
    {
        if (multiplier != 1f)
        {
            multiplier = 1f;
        }
        else
        {
            multiplier = 2f;
        }
        return;
    }

    // TestAnotherMultiplier changes anotherMultiplier
    private void TestAnotherMultiplier(float value)
    {
        anotherMultiplier = value;
        return;
    }

    // TestYetAnotherMultiplier changes anotherMultiplier
    private void TestYetAnotherMultiplier(float value)
    {
        yetAnotherMultiplier = value;
        return;
    }

    // ShowControl turns on display of controls
    private void ShowControls()
    {
        Debug.Log("Włączono wyświetlanie kontrolek");
        showAndHideToggle.GetComponentInChildren<Text>().text = "Hide controls";
        foreach (GameObject g in toShowAndHideList)
        {
            g.SetActive(true);
        }
    }

    // HideControl turns off display of controls
    private void HideControls()
    {
        Debug.Log("Wyłączono wyświetlanie kontrolek");
        showAndHideToggle.GetComponentInChildren<Text>().text = "Show controls";
        foreach (GameObject g in toShowAndHideList)
        {
            g.SetActive(false);
        }
    }

    // CreateNewSlider - creates new slider
    private void CreateNewSlider() 
    {
        // create new slider from prefab and save it as anotherMultiplySlider, as child of canvas
        anotherMultiplySlider = Instantiate(sliderPrefab, canvas.transform);

        // set createButton as disabled, so no more sliders will be created
        createButton.GetComponent<Button>().interactable = false;

        // set properties of anotherMultiplySlider
        anotherMultiplySlider.GetComponent<Slider>().minValue = 1;
        anotherMultiplySlider.GetComponent<Slider>().maxValue = 10;
        anotherMultiplySlider.transform.GetChild(3).gameObject.GetComponent<Text>().text = "1";
        anotherMultiplySlider.transform.GetChild(4).gameObject.GetComponent<Text>().text = "10";
        anotherMultiplySlider.transform.GetChild(5).gameObject.GetComponent<Text>().text = "EVEN BIGGER";
        anotherMultiplySlider.transform.GetChild(3).gameObject.GetComponent<Text>().fontSize = 20;

        // add anotherMultiplySlider to list of controls to hide
        toShowAndHideList.Add(anotherMultiplySlider);

        // set up a listener
        anotherMultiplySlider.GetComponent<Slider>().onValueChanged.AddListener(delegate { TestYetAnotherMultiplier(anotherMultiplySlider.GetComponent<Slider>().value); });
    }
}