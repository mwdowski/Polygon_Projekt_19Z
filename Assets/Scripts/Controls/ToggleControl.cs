using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Assertions;


public class ToggleControl : BaseControl
{
    // Miejsce na komponenty
    private Toggle toggle;


    public ToggleControl(GameObject gameObject) : base(gameObject)
    {
        toggle = control.GetComponent<Toggle>();
        Assert.IsNotNull(toggle);
    }

    public override void SetUpListener(UnityAction action)
    {
        toggle.onValueChanged.AddListener(delegate { action(); });
    }

    public bool IsOn()
    {
        return toggle.isOn;
    }

    public void SetValue(bool newValue)
    {
        toggle.isOn = newValue;
    }

    public override void SetShow(bool show)
    {
        control.SetActive(show);
    }
}