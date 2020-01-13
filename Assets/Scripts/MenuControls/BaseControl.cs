using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Assertions;


/*
 * Klasa bazowa pozostałych kontrolek.
 * Opakowują GameObject zawierający odpowiedni komponent kontrolujący.
 */
public abstract class BaseControl
{
    [SerializeField] protected GameObject control;


    public BaseControl(GameObject gameObject)
    {
        Assert.IsNotNull(gameObject);
        control = gameObject;
    }

    public abstract void SetUpListener(UnityAction action);
    public abstract void SetShow(bool show);
}
