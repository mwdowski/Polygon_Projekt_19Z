using UnityEngine;
using UnityEngine.Assertions;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    private Rigidbody2D rigidbody = null;
    public LayerMask Ground;
    private const float GROUNDED_RAYCAST_DISTANCE = 1.0f;

    private bool isFacingRight;// = true;
    [SerializeField] private float bulletSpeed = 10000f;
    [SerializeField] private GameObject bulletPrefab;
    private static float halfWidth;
    private GameObject bullet;

    public GameObject leftLimitWall;
    public GameObject rightLimitWall;

    [SerializeField] private float jumpingStartDelay = 4f;
    [SerializeField] private float jumpingTimeDifference = 3.28f;
    [SerializeField] private float shootingStartDelay = 2f;
    [SerializeField] private float shootingTimeDifference = 2.15f;

    [SerializeField] private int healthPoints = 3;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rigidbody);

         // wylosowanie strony, w którą na początku będzie iść przeciwnik
        float randomValue = Random.Range(0, 2);
        isFacingRight = randomValue == 0;

        // znalezienie połowy szerokości - pomoże to przy tworzeniu pocisków
        halfWidth = GetComponent<Renderer>().bounds.extents.x + bulletPrefab.GetComponent<Renderer>().bounds.extents.x;
    }

    private void Start()
    {
        InvokeRepeating("Jump", jumpingStartDelay, jumpingTimeDifference);
        InvokeRepeating("Shoot", shootingStartDelay, shootingTimeDifference);
    }

    public void DecreaseHealthPoints()
    {
        healthPoints--;
        if (healthPoints == 0)
        {
            KillEnemy();
        }
    }

    private void Update()
    {
        // nadanie prędkości zgodnie z kierunkiem patrzenia
        if (isFacingRight)
        {
            rigidbody.velocity = new Vector2(moveSpeed * Time.deltaTime, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(-moveSpeed * Time.deltaTime, rigidbody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string hitTag = collision.gameObject.tag;
        if (hitTag == "Player")
        {
            /* natychmiastowa śmierć przy dotknięciu gracza przez przeciwnika
            Destroy(collision.gameObject);
            return;
            */
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
            return;
        }
        if (hitTag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
            return;
        }

        // zmiana kierunku przy podejściu do ściany
        if (collision.gameObject.Equals(leftLimitWall))
        {
            isFacingRight = true;
        }
        if (collision.gameObject.Equals(rightLimitWall))
        {
            isFacingRight = false;
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

    private void KillEnemy()
    {
        GameplayManager.GameScore++;
        Destroy(gameObject);
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
