using UnityEngine;
using UnityEngine.Events;

public abstract class BaseControl
{
    /*
     * Klasa BaseCoontrol jest wzorcem dla klas pozostałych kontrolek:
     * - ButtonControl
     * - ToggleControl
     * - SliderControl
     * Mają być one opakowaniem na GameObject zawierający odpowiedni komponent kontrolujący
     */

    // Miejsce na GameObject z komponentem
    public GameObject control;

    public abstract void SetUpListener(UnityAction action);

    public abstract void Show(bool show);
}
