using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D square;
    public BoxCollider2D change_scene;
    public Vector2 movement;
    private Vector2 Bounds;

    void Start()
    {
        //Bounds = Camera.main.ScreenToWorldPoint(new Vector 3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2f, 2f), Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
    }

    void FixedUpdate()
    {
        //square.MovePosition(square.position + movement * moveSpeed * Time.fixedDeltaTime);
        square.AddForce(movement * moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Trigger_Obj")
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }

}