using UnityEngine;
using UnityEngine.UI;


public class DefaultSubmenu : MonoBehaviour
{
    [SerializeField] private Button button;


    public Button Button
    {
        get
        {
            return button;
        }
    }

}