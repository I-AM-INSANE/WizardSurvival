using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    #region Fields

    private PlayerStats playerStats;
    private GameObject target;
    private Enemy[] enemies;

    #endregion

    #region Properties

    public GameObject Target => target;

    #endregion

    #region Methods

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (target == null)
            FindTarget();
    }

    private void FindTarget()
    {
        enemies = FindObjectsOfType<Enemy>();
        float minDistance = float.MaxValue;
        float tempDistance;
        foreach (Enemy enemy in enemies)
        {
            tempDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (tempDistance < minDistance && tempDistance < playerStats.AttackRange)
            {
                minDistance = tempDistance;
                target = enemy.gameObject;
            }
        }
    }

    #endregion
}
