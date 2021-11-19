using UnityEngine;

[RequireComponent(typeof(EnemyStats))]

public class Enemy : MonoBehaviour, IDamageable
{
    #region Fields

    private EnemyStats enemyStats;
    private PlayerExperienceSystem playerExperienceSystem;

    #endregion

    #region Methods

    private void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
    }

    private void Start()
    {
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
