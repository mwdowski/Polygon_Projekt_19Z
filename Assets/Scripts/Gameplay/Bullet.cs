using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidbody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string hitTag = collision.collider.gameObject.tag;
        if (hitTag == "Enemy" || hitTag == "Walls")
        {
            Destroy(gameObject);
        }
    }
}
