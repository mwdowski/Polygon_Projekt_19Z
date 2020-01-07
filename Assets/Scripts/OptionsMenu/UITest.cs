using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    /* przeniesione do słownika controlValues
    // testValue - value that is going to change when AddTest() or SubstractTest() is called
    [SerializeField] private float testValue = 2137f;
    // multiplier - value that is going to change when TestMultiplier() is called
    [SerializeField] private float multiplier = 1f;
    // anotherMultiplier - value that is going to change when TestAnotherMultiplier() is called
    [SerializeField] private float anotherMultiplier = 1f;
    // yetAnotherMultiplier - value that is going to change when TestYetAnotherMultiplier() is called
    [SerializeField] private float yetAnotherMultiplier = 1f;
    */

    // controlValues - wartości ustawione za pomocą kontrolek
    private Dictionary<string, float> controlValues;

    // controls - kontrolki
    private Dictionary<string, BaseControl> controls;

    // addButton, substractButton, multiplyToggle, multiplySlider, anotherMultiplySplider - actions on these controls will affect testValue
    [SerializeField] private GameObject addButton;
    [SerializeField] private GameObject substractButton;
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
    List<GameObject> toShowAndHideList = new List<GameObject>();


    private void Start()
    {
        // dodanie wartosci do regulowania kontrolkami
        controlValues = new Dictionary<string, float>()
        {
            {"testValue", 2137f}, // testValue - value that is going to change when AddTest() or SubstractTest() is called
            {"multiplier", 1f}, // multiplier - value that is going to change when TestMultiplier() is called
            {"anotherMultiplier", 1f}, // anotherMultiplier - value that is going to change when TestAnotherMultiplier() is called
            {"yetAnotherMultiplier", 1f} // yetAnotherMultiplier - value that is going to change when TestYetAnotherMultiplier() is called
        };

        // dodanie listy kontrolek
        controls = new Dictionary<string, BaseControl>()
        {
            {"addButton", new ButtonControl(addButton)},
            {"substractButton", new ButtonControl(substractButton)},
            {"multiplyToggle", new ToggleControl(multiplyToggle)},
            {"showAndHideToggle", new ToggleControl(showAndHideToggle)},
            {"multiplySlider", new SliderControl(multiplySlider)},
            {"createButton", new ButtonControl(createButton)}
        };

        //toShowAndHideList.Add(addButton);
        //toShowAndHideList.Add(substractButton);
        //toShowAndHideList.Add(multiplyToggle);
        //toShowAndHideList.Add(multiplySlider);

        //Button addButtonButton = addButton.GetComponent<Button>();
        //Button substractButtonButton = substractButton.GetComponent<Button>();
        //Toggle multiplyToggleToggle = multiplyToggle.GetComponent<Toggle>();
        //Slider multiplySliderSlider = multiplySlider.GetComponent<Slider>();
        //Toggle showAndHideToggleToggle = showAndHideToggle.GetComponent<Toggle>();
        //Button createButtonButton = createButton.GetComponent<Button>();

        //addButtonButton.onClick.AddListener(TestAdd);
        //substractButtonButton.onClick.AddListener(TestSubstract);
        //multiplyToggleToggle.onValueChanged.AddListener(delegate { TestMultiplier(); });
        /*
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
         */
        //multiplySliderSlider.onValueChanged.AddListener(delegate { TestAnotherMultiplier(multiplySliderSlider.value); });
        //createButtonButton.onClick.AddListener(CreateNewSlider);

        // ustawienie reakcji na akcje
        controls["addButton"].SetUpListener(TestAdd);
        controls["substractButton"].SetUpListener(TestSubstract);
        controls["multiplyToggle"].SetUpListener(TestMultiplier);
        controls["multiplySlider"].SetUpListener(delegate { TestAnotherMultiplier(((SliderControl) controls["multiplySlider"]).GetValue()); });
        controls["showAndHideToggle"].SetUpListener(delegate {
            if (((ToggleControl) controls["showAndHideToggle"]).IsOn())
            {
                ShowControls();
            }
            else
            {
                HideControls();
            }
        });
        controls["createButton"].SetUpListener(CreateNewSlider);
    }

    // TestAdd adds multiplier to testValue
    private void TestAdd()
    {
        controlValues["testValue"] += controlValues["multiplier"] * controlValues["anotherMultiplier"] * controlValues["yetAnotherMultiplier"];

        Debug.Log("controlValues[\"testValue\"] = " + controlValues["testValue"].ToString());

        return;
    }

    // TestAdd substracts multiplier from testValue
    private void TestSubstract()
    {
        controlValues["testValue"] -= controlValues["multiplier"] * controlValues["anotherMultiplier"] * controlValues["yetAnotherMultiplier"];

        Debug.Log("controlValues[\"testValue\"] = " + controlValues["testValue"].ToString());

        return;
    }

    // TestMultiplier changes multiplier
    private void TestMultiplier()
    {
        if (controlValues["multiplier"] != 1f)
        {
            controlValues["multiplier"] = 1f;
        }
        else
        {
            controlValues["multiplier"] = 2f;
        }

        Debug.Log("controlValues[\"multiplier\"] = " + controlValues["multiplier"].ToString());

        return;
    }

    // TestAnotherMultiplier changes anotherMultiplier
    private void TestAnotherMultiplier(float value)
    {
        controlValues["anotherMultiplier"] = value;

        Debug.Log("controlValues[\"anotherMultiplier\"] = " + controlValues["anotherMultiplier"].ToString());

        return;
    }

    // TestYetAnotherMultiplier changes anotherMultiplier
    private void TestYetAnotherMultiplier(float value)
    {
        controlValues["yetAnotherMultiplier"] = value;

        Debug.Log("controlValues[\"yetAnotherMultiplier\"] = " + controlValues["yetAnotherMultiplier"].ToString());

        return;
    }

    // ShowControl turns on display of controls
    private void ShowControls()
    {
        Debug.Log("Włączono wyświetlanie kontrolek");
        ((ToggleControl) controls["showAndHideToggle"]).control.GetComponentInChildren<Text>().text = "Hide controls";
        foreach (KeyValuePair<string, BaseControl> element in controls)
        {
            if (element.Key == "showAndHideToggle") continue;
            element.Value.Show(true);
        }
    }

    // HideControl turns off display of controls
    private void HideControls()
    {
        Debug.Log("Wyłączono wyświetlanie kontrolek");
        ((ToggleControl) controls["showAndHideToggle"]).control.GetComponentInChildren<Text>().text = "Show controls";
        foreach (KeyValuePair<string, BaseControl> element in controls)
        {
            if (element.Key == "showAndHideToggle") continue;
            element.Value.Show(false);
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

        // add anotherMultiplySlider to list of controls
        //toShowAndHideList.Add(anotherMultiplySlider);
        controls.Add("anotherMultiplySlider", new SliderControl(anotherMultiplySlider));

        // set up a listener
        //anotherMultiplySlider.GetComponent<Slider>().onValueChanged.AddListener(delegate { TestYetAnotherMultiplier(anotherMultiplySlider.GetComponent<Slider>().value); });
        controls["anotherMultiplySlider"].SetUpListener(delegate { TestYetAnotherMultiplier(((SliderControl) controls["anotherMultiplySlider"]).GetValue()); });
        //controls["multiplySlider"].SetUpListener(delegate { TestAnotherMultiplier(((SliderControl)controls["multiplySlider"]).GetValue()); });
    }
}