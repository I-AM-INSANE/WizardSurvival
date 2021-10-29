using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields

    private PlayerStats playerStats;
    private float range = 0;

    #endregion

    #region Methods

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        range = playerStats.AttackRange;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void TakeDamage(int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
            Die();
    }

    private void Die()
    {
        // die anim
        Destroy(gameObject);
    }

    #endregion
}
