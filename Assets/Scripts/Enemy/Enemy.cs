using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    #region Fields

    private EnemyStats enemyStats;
    private PlayerExperienceSystem playerExperienceSystem;

    #endregion

    #region Methods

    private void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        playerExperienceSystem = FindObjectOfType<PlayerExperienceSystem>();
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
        playerExperienceSystem.AddXP(enemyStats.XPValue);
        Destroy(gameObject);
    }

    #endregion
}
