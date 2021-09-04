using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    #region Fields

    private EnemyStats enemyStats;
    private NavMeshAgent agent;
    private Player player;
    private bool playerInAttackingZone = false;

    public event Action OnAnimationEnded;

    #endregion

    #region Properties

    public bool PlayerInAttackingZone => playerInAttackingZone;

    #endregion

    #region Methods

    private void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            playerInAttackingZone = distanceToPlayer <= agent.stoppingDistance ? true : false;
        }
    }

    public void TakeDamage(int damage)
    {
        enemyStats.Health -= damage;
        if (enemyStats.Health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
    private void EndOfAnimation()   // called when an event fires at the end of the animation in the inspector
    {
        OnAnimationEnded.Invoke();
    }

    #endregion
}
