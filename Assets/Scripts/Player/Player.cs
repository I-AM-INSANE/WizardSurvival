using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields

    private PlayerStats playerStats;

    #endregion

    #region Methods

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
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
