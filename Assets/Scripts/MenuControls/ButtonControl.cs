using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Assertions;


public class ButtonControl : BaseControl
{
    private Button button;


    public ButtonControl(GameObject gameObject) : base(gameObject)
    {
        button = control.GetComponent<Button>();
        Assert.IsNotNull(button);
    }

    public override void SetUpListener(UnityAction action)
    {
        button.onClick.AddListener(action);
    }

    public override void SetShow(bool show)
    {
        control.SetActive(show);
    }
}
