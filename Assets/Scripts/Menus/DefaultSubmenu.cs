using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;


public class DefaultSubmenu : MonoBehaviour
{
    [SerializeField] private Button backButton;


    private void Awake()
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