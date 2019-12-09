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
    // addButton, substractButton, multiplyToggle, multiplySlider - actions on these controls will affect testValue
    [SerializeField] private GameObject addButton;//, substractButton;
    //[SerializeField] private GameObject multiplyToggle;
    //[SerializeField] private GameObject multiplySlider;

    //
    public void Start()
    {
        Button addButtonButton = addButton.GetComponent<Button>();
        addButtonButton.OnClick.AddListener(TestAdd);

    }

    // TestAdd adds 1 to testValue
    private void TestAdd()
    {
        testValue += multiplier * anotherMultiplier;
        return;
    }

    // TestAdd substracts 1 from testValue
    private void TestSubstract()
    {
        testValue -= multiplier * anotherMultiplier;
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
}
