using UnityEngine;

public class WoundingObstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
