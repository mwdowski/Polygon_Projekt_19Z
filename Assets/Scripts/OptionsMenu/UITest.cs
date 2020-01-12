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
    private Dictionary<string, float> controlValues = new Dictionary<string, float>();

    // defaultControlValues - wartości ustawione za pomocą kontrolek
    private static readonly Dictionary<string, float> defaultControlValues = new Dictionary<string, float>()
    {
        {"testValue", 2137f}, // testValue - value that is going to change when AddTest() or SubstractTest() is called
        {"multiplier", 1f}, // multiplier - value that is going to change when TestMultiplier() is called
        {"anotherMultiplier", 1f}, // anotherMultiplier - value that is going to change when TestAnotherMultiplier() is called
        {"yetAnotherMultiplier", 1f} // yetAnotherMultiplier - value that is going to change when TestYetAnotherMultiplier() is called
    };

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
    // [SerializeField] private GameObject canvas;
    // saveButton - przycisk do zapisywania 
    [SerializeField] private GameObject saveButton;
    // returnDefaultButton - przycisk do powrotu do domyślnych ustawień
    [SerializeField] private GameObject returnDefaultButton;


    // toShowAndHideList - list of controls of which display should be controlled
    // private List<GameObject> toShowAndHideList;

    private void Start()
    {
        // dodanie listy kontrolek
        controls = new Dictionary<string, BaseControl>()
        {
            {"addButton", new ButtonControl(addButton)},
            {"substractButton", new ButtonControl(substractButton)},
            {"multiplyToggle", new ToggleControl(multiplyToggle)},
            {"showAndHideToggle", new ToggleControl(showAndHideToggle)},
            {"multiplySlider", new SliderControl(multiplySlider)},
            {"createButton", new ButtonControl(createButton)},
            {"saveButton", new ButtonControl(saveButton)},
            {"returnDefaultButton", new ButtonControl(returnDefaultButton)}
        };

        // wczytanie wartosci do regulowania kontrolkami (wraz z ich odpowiednim ustawieniem) - dlatego to musi nastąpić PO stworzeniu słownika z kontrolkami
        LoadValues();

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
        controls["saveButton"].SetUpListener(SaveValues);
        controls["returnDefaultButton"].SetUpListener(ReturnDefaultValues);
    }

    private void LoadValues()
    {
        // wczytuje wartości z pliku
        float test;
        // dla każdej pary w słowniku z domyślnymi wartościami pętla próbuje przypisać wczytaną wartość z pliku o odpowiedniej nazwie
        // jeśli nie uda się wczytać wartości z pliku, to podaje wartość domyślną, która zapisana jest w iterowanym słowniku
        foreach (KeyValuePair<string, float> element in defaultControlValues)
        {
            test = PlayerPrefs.GetFloat(element.Key, element.Value);
            Debug.Log(test.ToString());
            controlValues[element.Key] = test;
        }
        SetControlsValues();

        Debug.Log("wczytane wartości:" + controlValues.ToString());
    }

    private void SetControlsValues()
    {
        // ustawienie wartosci na kontrolkach, na których te wartości widać

        ((ToggleControl)controls["multiplyToggle"]).SetValue(controlValues["multiplier"] != 1f);
        ((SliderControl)controls["multiplySlider"]).SetValue(controlValues["anotherMultiplier"]);
        if (controls.ContainsKey("anotherMultiplySlider"))
        {
            ((SliderControl)controls["anotherMultiplySlider"]).SetValue(controlValues["yetAnotherMultiplier"]);
        }
    }

    private void ReturnDefaultValues()
    {
        // ustawia wartości kontrolek na domyślne
        // zapisanie ich wymaga jednak użycia SaveValues

        controlValues = defaultControlValues;
        SetControlsValues();
    }

    private void SaveValues()
    {
        // zapisuje wartości do pliku

        Debug.Log("próba zapisania wartości:" + controlValues.ToString());

        foreach (KeyValuePair<string, float> element in controlValues)
        {
            PlayerPrefs.SetFloat(element.Key, element.Value);
        }
    }

    private void TestAdd()
    {
        // TestAdd adds multiplier to testValue

        controlValues["testValue"] += controlValues["multiplier"] * controlValues["anotherMultiplier"] * controlValues["yetAnotherMultiplier"];

        Debug.Log("controlValues[\"testValue\"] = " + controlValues["testValue"].ToString());
    }

    private void TestSubstract()
    {
        // TestAdd substracts multiplier from testValue

        controlValues["testValue"] -= controlValues["multiplier"] * controlValues["anotherMultiplier"] * controlValues["yetAnotherMultiplier"];

        Debug.Log("controlValues[\"testValue\"] = " + controlValues["testValue"].ToString());
    }

    private void TestMultiplier()
    {
        // TestMultiplier changes multiplier

        if (controlValues["multiplier"] != 1f)
        {
            controlValues["multiplier"] = 1f;
        }
        else
        {
            controlValues["multiplier"] = 2f;
        }

        Debug.Log("controlValues[\"multiplier\"] = " + controlValues["multiplier"].ToString());
    }

    private void TestAnotherMultiplier(float value)
    {
        // TestAnotherMultiplier changes anotherMultiplier

        controlValues["anotherMultiplier"] = value;

        Debug.Log("controlValues[\"anotherMultiplier\"] = " + controlValues["anotherMultiplier"].ToString());
    }

    private void TestYetAnotherMultiplier(float value)
    {
        // TestYetAnotherMultiplier changes anotherMultiplier

        controlValues["yetAnotherMultiplier"] = value;

        Debug.Log("controlValues[\"yetAnotherMultiplier\"] = " + controlValues["yetAnotherMultiplier"].ToString());
    }

    private void ShowControls()
    {
        // ShowControl turns on display of controls

        Debug.Log("Włączono wyświetlanie kontrolek");
        ((ToggleControl) controls["showAndHideToggle"]).control.GetComponentInChildren<Text>().text = "Hide controls";
        foreach (KeyValuePair<string, BaseControl> element in controls)
        {
            if (element.Key == "showAndHideToggle") continue;
            element.Value.Show(true);
        }
    }

    private void HideControls()
    {
        // HideControl turns off display of controls

        Debug.Log("Wyłączono wyświetlanie kontrolek");
        ((ToggleControl) controls["showAndHideToggle"]).control.GetComponentInChildren<Text>().text = "Show controls";
        foreach (KeyValuePair<string, BaseControl> element in controls)
        {
            if (element.Key == "showAndHideToggle") continue;
            element.Value.Show(false);
        }
    }

    private void CreateNewSlider() 
    {
        // CreateNewSlider - creates new slider

        // create new slider from prefab and save it as anotherMultiplySlider
        anotherMultiplySlider = Instantiate(sliderPrefab, transform.parent);

        // set createButton as disabled, so no more sliders will be created
        createButton.GetComponent<Button>().interactable = false;

        // set properties of anotherMultiplySlider
        anotherMultiplySlider.GetComponent<Slider>().minValue = 1;
        anotherMultiplySlider.GetComponent<Slider>().maxValue = 10;
        anotherMultiplySlider.GetComponent<Slider>().value = controlValues["yetAnotherMiltiplier"];
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