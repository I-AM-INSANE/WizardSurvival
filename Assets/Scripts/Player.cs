using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields

    [SerializeField] private int health;

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
