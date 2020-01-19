using UnityEngine;

public class Goal : MonoBehaviour
{
    public System.Action OnPlayerTouched;

    /* usunięcie mechaniki kończenia gry przy wejściu w bramkę
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPlayerTouched?.Invoke();
        }
    }
    */
}
