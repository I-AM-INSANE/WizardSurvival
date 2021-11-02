using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    #region Fields

    private EnemyStats enemyStats;

    #endregion

    #region Methods

    private void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
    }

    public void TakeDamage(float damage)
    {
        enemyStats.Health -= damage;
        if (enemyStats.Health <= 0)
            Die();
    }

    private void Die()
    {
        // die anim
        Destroy(gameObject);
    }

    #endregion
}
