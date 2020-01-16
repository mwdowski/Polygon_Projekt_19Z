using UnityEngine;
using UnityEngine.Assertions;


public class CharacterController : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5.0f;
	[SerializeField] private float jumpForce = 5.0f;
	private Rigidbody2D rigidbody;
	public LayerMask Ground;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		Assert.IsNotNull(rigidbody);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
		{
			rigidbody.AddForce(new Vector2(0.0f, jumpForce));
		}
		rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, rigidbody.velocity.y);
	}

	bool IsGrounded()
	{
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 1.0f;

		RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, Ground);
		if (hit.collider != null)
		{
			return true;
		}

		return false;
	}

}
