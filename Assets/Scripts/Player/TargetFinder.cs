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

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > playerStats.AttackRange)
                target = null;
        }
        else
        {
            FindTarget();
        }
    }

    private void FindTarget()
    {
        enemies = FindObjectsOfType<Enemy>();
        float minDistance = float.MaxValue;
        float tempDistance;
        for (int i = 0; i < enemies.Length; i++)
        {
            tempDistance = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (tempDistance < minDistance && tempDistance < playerStats.AttackRange)
            {
                minDistance = tempDistance;
                target = enemies[i].gameObject;
            }
        }
    }

    #endregion
}
