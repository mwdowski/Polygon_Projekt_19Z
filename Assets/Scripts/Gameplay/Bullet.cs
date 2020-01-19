using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string hitTag = collision.gameObject.tag;
        if (hitTag == "Walls")
        {
            Destroy(gameObject);
            return;
        }
        if (hitTag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }
        if (hitTag == "PlayerBullet")
        {
            Physics2D.IgnoreCollision(collision, gameObject.GetComponent<Collider2D>());
            return;
        }
    }
}
