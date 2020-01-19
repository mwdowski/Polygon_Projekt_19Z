using UnityEngine;

public class Goal : MonoBehaviour
{
    public System.Action OnPlayerTouched;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPlayerTouched?.Invoke();
        }
    }
}
