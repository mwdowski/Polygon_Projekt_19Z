using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;


public class DefaultSubmenu : MonoBehaviour
{
    [SerializeField] protected Button backButton;


    protected virtual void Awake()
    {
        Assert.IsNotNull(backButton);    
    }

    public Button Button
    {
        get
        {
            return backButton;
        }
    }
}