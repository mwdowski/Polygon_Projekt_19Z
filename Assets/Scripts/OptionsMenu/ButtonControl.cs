using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonControl : BaseControl
{
    // Miejsce na GameObject z komponentem
    public GameObject control;
    // Miejsce na komponenty
    private Button button;

    public ButtonControl(GameObject gameObject)
    {
        control = gameObject;
        button = control.GetComponent<Button>();
    }

    public override void SetUpListener(UnityAction action)
    {
        button.onClick.AddListener(action);
    }

    public override void Show(bool show)
    {
        control.SetActive(show);
    }
}
