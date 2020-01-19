using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
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

	[SerializeField] private int healthPoints = 5;
	[SerializeField] private GameObject healthbar;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		Assert.IsNotNull(rigidbody);

		// znalezienie połowy szerokości - pomoże to przy tworzeniu pocisków
		halfWidth = GetComponent<Renderer>().bounds.extents.x + bulletPrefab.GetComponent<Renderer>().bounds.extents.x;
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
			Destroy(gameObject);
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
			isFacingRight = true;
		}
		if (rigidbody.velocity.x < 0)
		{
			isFacingRight = false;
		}

		// strzał - strzelamy klawiszem "F"
		if (Input.GetKeyDown(KeyCode.F))
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
