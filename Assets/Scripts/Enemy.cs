using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    #region Fields

    [SerializeField] private int health = 100;

    #endregion

    #region Methods

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        // die anim
        Destroy(gameObject);
    }

    #endregion
}
