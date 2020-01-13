using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Assertions;


public class SliderControl : BaseControl
{
    private Slider slider;


    public SliderControl(GameObject gameObject) : base(gameObject)
    {
        slider = control.GetComponent<Slider>();
        Assert.IsNotNull(slider);
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

    public override void SetShow(bool show)
    {
        control.SetActive(show);
    }
}
