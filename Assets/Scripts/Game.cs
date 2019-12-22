using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    public float moveSpeed = 5f;

    Vector2 movement;

    public Rigidbody2D square;
    public BoxCollider2D change_scene;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        square.MovePosition(square.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Trigger_Obj")
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }

}