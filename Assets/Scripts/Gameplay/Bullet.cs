using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        string hitTag = collision.gameObject.tag;
        if (hitTag == "Walls")
        {
            Destroy(gameObject);
            return;
        }
        if (hitTag == "Enemy")
        {
            // TODO: cos tam zabij
            Destroy(gameObject);
            return;
        }
        if (hitTag == "PlayerBullet")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
            return;
        }
    }
}
