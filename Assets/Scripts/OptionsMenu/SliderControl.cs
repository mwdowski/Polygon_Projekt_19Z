using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SliderControl : BaseControl
{
    // Miejsce na GameObject z komponentem
    public GameObject control;
    // Miejsce na komponenty
    private Slider slider;

    public SliderControl(GameObject gameObject)
    {
        control = gameObject;
        slider = control.GetComponent<Slider>();
    }

    public override void SetUpListener(UnityAction action)
    {
        slider.onValueChanged.AddListener(delegate { action(); });
    }

    public float GetValue()
    {
        return slider.value;
    }

    public void SetValue(float newValue)
    {
        slider.value = newValue;
    }

    public override void Show(bool show)
    {
        control.SetActive(show);
    }
}
