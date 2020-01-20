using UnityEngine;


public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string hitTag = collision.gameObject.tag;
        if (hitTag == "Walls")
        {
            Destroy(gameObject);
            return;
        }
        if (hitTag == "Player")
        {
            collision.gameObject.GetComponent<CharacterController>().DecreaseHealthPoints();
            Destroy(gameObject);
            return;
        }
        if (hitTag == "PlayerBullet")
        {
            Physics2D.IgnoreCollision(collision, gameObject.GetComponent<Collider2D>());
            return;
        }
        if (hitTag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision, gameObject.GetComponent<Collider2D>());
            return;
        }
    }
}
