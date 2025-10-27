using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;

    public float delta;
    public float span = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
        SpawnDelay();
    }

    public void SpawnEnemy()
    {
        if (delta < span)
            return;
        
        GameObject enemyGo = enemies[Random.Range(0, enemies.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyGo, spawnPoint.position, spawnPoint.rotation);
        Debug.Log($"적 생성됨 delay:{span.ToString("F2")}");

        span = Random.Range(0.5f, 2.5f);

        delta = 0;
    }

    public void SpawnDelay()
    {
        delta += Time.deltaTime;
    }
}
