using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("怪物预制体")]
    public GameObject enemyPrefab;
    public float baseSpawnInterval = 2f;
    public float minSpawnInterval = 0.5f; //最小生成间隔，不能无限变快

    private float spawnTimer;

    void Update()
    {
        if (GameManager.Instance.currentState != GameManager.GameState.Playing) return;

        spawnTimer += Time.deltaTime;

        //生存越久，生成间隔越小，怪物刷得越快
        float currentInterval = Mathf.Max(minSpawnInterval, baseSpawnInterval - GameManager.Instance.surviveTime * 0.02f);

        if (spawnTimer >= currentInterval)
        {
            SpawnEnemy();
            spawnTimer = 0;
        }
    }

    void SpawnEnemy()
    {
        //在屏幕四周随机生成怪物
        Vector2 spawnPos;
        float side = Random.Range(0, 4);
        float range = 8;
        if (side == 0) spawnPos = new Vector2(Random.Range(-range, range), range);
        else if (side == 1) spawnPos = new Vector2(Random.Range(-range, range), -range);
        else if (side == 2) spawnPos = new Vector2(range, Random.Range(-range, range));
        else spawnPos = new Vector2(-range, Random.Range(-range, range));

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
