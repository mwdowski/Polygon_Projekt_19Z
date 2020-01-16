using UnityEngine;
using UnityEngine.Assertions;


public class CharacterController : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5.0f;
	[SerializeField] private float jumpForce = 5.0f;
	private Rigidbody2D rigidbody = null;
	public LayerMask Ground;
	private const float GROUNDED_RAYCAST_DISTANCE = 1.0f;


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
