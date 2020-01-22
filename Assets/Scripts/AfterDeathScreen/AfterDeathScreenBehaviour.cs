using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterDeathScreenBehaviour : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MainMenu")
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }
        if (scene.name == "AfterDeathScreen")
        {
            //gameObject.SetActive(true);
            gameObject.GetComponent<Canvas>().enabled = true;
        }
        if (scene.name == "Game")
        {
            //gameObject.SetActive(false);
            gameObject.GetComponent<Canvas>().enabled = false;
        }
    }
}
