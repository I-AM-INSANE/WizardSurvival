using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private float cooldownBetweenSpawn;
    [SerializeField] private EnemyForSpawn[] enemiesForSpawn;

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
            SpawnEnemy(GetRandomEnemyAvailableForSpawn(), GetRandomSpawnPoint());
            StartCoroutine(CooldownBetweenSpawnRoutine());
        }
    }

    private GameObject GetRandomEnemyAvailableForSpawn()
    {
        List<GameObject> enemies = new List<GameObject>();

        foreach (EnemyForSpawn enemyForSpawn in enemiesForSpawn)
        {
            if (enemyForSpawn.AvailableForSpawn == true)
            {
                enemies.Add(enemyForSpawn.Enemy);
            }
        }

        if (enemies.Count <= 0)
            Debug.LogError("No enemies for spawn");

        return enemies[Random.Range(0, enemies.Count)];
    }

    private GameObject GetRandomSpawnPoint()
    {
        if (spawnPoints.Length <= 0)
            Debug.LogError("No spawn points");

        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    private void SpawnEnemy(GameObject enemy, GameObject spawnPoint)
    {
        Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
    }

    private IEnumerator CooldownBetweenSpawnRoutine()
    {
        cooldown = true;
        yield return new WaitForSeconds(cooldownBetweenSpawn);
        cooldown = false;
    }

    #endregion
}
