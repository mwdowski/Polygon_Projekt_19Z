using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefrab;
    [SerializeField] private GameObject leftLimitWall;
    [SerializeField] private GameObject rightLimitWall;
    [SerializeField] private GameObject newEnemy;

    [SerializeField] private float directionMultiplier = 1f;


    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 2f);
    }

    private void Update()
    {
        // Spawner lata między X=-9 a X=9
        if (transform.position.x > 9f | transform.position.x < -9f)
        {
            directionMultiplier *= -1f;
        }

        // Ruch
        transform.position = new Vector3(transform.position.x + directionMultiplier * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void SpawnEnemy()
    {
        newEnemy = Instantiate(enemyPrefrab, transform);
        newEnemy.GetComponent<EnemyBehaviour>().leftLimitWall = leftLimitWall;
        newEnemy.GetComponent<EnemyBehaviour>().rightLimitWall = rightLimitWall;
    }
}
