using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    private Rigidbody2D rigidbody = null;
    public LayerMask Ground;
    private const float GROUNDED_RAYCAST_DISTANCE = 1.0f;

    private bool isFacingRight = true;
    [SerializeField] private float bulletSpeed = 10000f;
    [SerializeField] private GameObject bulletPrefab;
    private static float halfWidth;
    private GameObject bullet;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rigidbody);

        // znalezienie połowy szerokości - pomoże to przy tworzeniu pocisków
        halfWidth = GetComponent<Renderer>().bounds.extents.x + bulletPrefab.GetComponent<Renderer>().bounds.extents.x;
    }

    private void Start()
    {
        InvokeRepeating("Jump", 4f, 4f);
        InvokeRepeating("Shoot", 2f, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string hitTag = collision.gameObject.tag;
        if (hitTag == "Player")
        {
            Destroy(collision.gameObject);
            return;
        }
        if (hitTag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
            return;
        }

    }

    private void Shoot()
    {
        if (isFacingRight)
        {
            bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + halfWidth, transform.position.y, transform.position.z), transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
        }
        else
        {
            bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x - halfWidth, transform.position.y, transform.position.z), transform.rotation);

            // ta część kodu obraca pocisk tak, by leciał w drugą stronę
            Vector3 newScale = bullet.transform.localScale;
            newScale *= -1;
            bullet.transform.localScale = newScale;

            // nadanie prędkości
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
        }

    }

    private void Jump()
    {
        rigidbody.AddForce(new Vector2(0.0f, jumpForce));
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, GROUNDED_RAYCAST_DISTANCE, Ground);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
