using System;
using UnityEngine;

[Serializable]
public struct EnemyForSpawn
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnTimeInMinutes;

    public GameObject Enemy => enemy;

    public bool AvailableForSpawn
    {
        get { return Time.time >= spawnTimeInMinutes * 60; }
    }
}
