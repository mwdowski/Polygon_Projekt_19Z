using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class CharacterController : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5.0f;
	[SerializeField] private float jumpForce = 10.0f;
	private Rigidbody2D rigidbody = null;
	public LayerMask Ground;
	private const float GROUNDED_RAYCAST_DISTANCE = 2.0f;
	[SerializeField] private GameObject body = null;

	private bool isFacingRight = true;
	[SerializeField] private float bulletSpeed = 40000f;
	[SerializeField] private GameObject bulletPrefab = null;
	private static float halfWidth = 0.0f;
	private GameObject bullet = null;

	[SerializeField] private int healthPoints = 5;
	[SerializeField] private GameObject healthbar = null;


	private bool IsFacingRight
	{
		get
		{
			return isFacingRight;
		}

		set
		{
			isFacingRight = value;
			if (isFacingRight)
			{
				body.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			}
			else
			{
				body.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
			}
		}
	}



	[SerializeField] private GameObject afterDeathScreen;
	[SerializeField] private GameObject userInterface;

	private void Awake()
	{
		body = transform.GetChild(0).gameObject;
		Assert.IsNotNull(body);

		rigidbody = GetComponent<Rigidbody2D>();
		Assert.IsNotNull(rigidbody);

		// znalezienie połowy szerokości - pomoże to przy tworzeniu pocisków
		halfWidth = GetComponent<BoxCollider2D>().size.x / 2.0f;
	}

	public void DecreaseHealthPoints()
	{
		// zmniejszenie punktów życia
		healthPoints--;

		// zmiana na pasku życia
		string healthbarText = healthbar.GetComponent<Text>().text;
		healthbarText = healthbarText.Remove(healthbarText.Length - 1);
		healthbar.GetComponent<Text>().text = healthbarText;

		// smierć w wypadku gdy życie spadnie do zera
		if (healthPoints == 0)
		{
			KillPlayer();
		}
	}

	private void Update()
	{
		// skok
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
		{
			rigidbody.AddForce(new Vector2(0.0f, jumpForce));
		}

		rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, rigidbody.velocity.y);

		// ustalenie, w którą stronę gracz "patrzy", czyli w którą stornę szedł ostatnio
		if (rigidbody.velocity.x > 0)
		{
			IsFacingRight = true;
		}
		if (rigidbody.velocity.x < 0)
		{
			IsFacingRight = false;
		}

		// strzał - strzelamy klawiszem "Lewy Control"
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (IsFacingRight)
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

	public void KillPlayer()
	{
		Destroy(gameObject);
	}
}
