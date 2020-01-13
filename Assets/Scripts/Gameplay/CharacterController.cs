using UnityEngine;
using UnityEngine.Assertions;


public class CharacterController : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5.0f;
	[SerializeField] private float jumpForce = 5.0f;
	private Rigidbody2D rigidbody;


	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		Assert.IsNotNull(rigidbody);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce(new Vector2(0.0f, jumpForce));
		}
		rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, rigidbody.velocity.y);
	}
}
