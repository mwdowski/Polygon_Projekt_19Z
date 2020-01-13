using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;


public class DefaultSubmenu : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private Button backButton;


    private void Awake()
=======
    [SerializeField] protected Button backButton;


    protected virtual void Awake()
>>>>>>> Game_Scene
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