using UnityEngine;
using UnityEngine.UI;

public interface IControlBehaviour
{
    // Interface implemented by controls in OptionsMenu

    // SetUpListener turns on a listener on control and delegates a method on target
    void SetUpListener(GameObject target);
}