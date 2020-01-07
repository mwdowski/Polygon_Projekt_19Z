using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleControl : BaseControl
{
    // Miejsce na GameObject z komponentem
    public GameObject control;
    // Miejsce na komponenty
    private Toggle toggle;

    public ToggleControl(GameObject gameObject)
    {
        control = gameObject;
        toggle = control.GetComponent<Toggle>();
    }

    public override void SetUpListener(UnityAction action)
    {
        toggle.onValueChanged.AddListener(delegate { action(); });
    }

    public bool IsOn()
    {
        return toggle.isOn;
    }

    public override void Show(bool show)
    {
        control.SetActive(show);
    }
}