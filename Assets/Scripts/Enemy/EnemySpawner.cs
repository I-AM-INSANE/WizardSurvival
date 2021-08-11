using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private float cooldownBetweenSpawn;
    [SerializeField] private GameObject[] enemies;

    private GameObject[] spawnPoints;
    private bool cooldown = false;

    #endregion

    #region Methods

    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
    }

    private void Update()
    {
        if (!cooldown)
        {
            SpawnEnemy(Random.Range(0, enemies.Length), Random.Range(0, spawnPoints.Length));
            StartCoroutine(CooldownBetweenSpawnRoutine());
        }
    }

    private void SpawnEnemy(int enemyNum, int pointNum)
    {
        if (pointNum == 0)
        {
            Debug.LogWarning("No spawn points");
            return;
        }

        Instantiate(enemies[enemyNum], spawnPoints[pointNum].transform.position, Quaternion.identity);
    }

    private IEnumerator CooldownBetweenSpawnRoutine()
    {
        cooldown = true;
        yield return new WaitForSeconds(cooldownBetweenSpawn);
        cooldown = false;
    }

    #endregion
}
