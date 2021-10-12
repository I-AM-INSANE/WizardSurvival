using UnityEngine;
using UnityEngine.AI;

public class CheckerPlayerInAttackingZone : MonoBehaviour
{
    #region Fields

    private Player player;
    private EnemyStats enemyStats;
    private NavMeshAgent agent;
    private bool playerInAttackingZone = false;

    #endregion

    #region Properties

    public bool PlayerInAttackingZone => playerInAttackingZone;

    #endregion

    #region Methods

    private void Start()
    {
        player = FindObjectOfType<Player>();
        enemyStats = GetComponent<EnemyStats>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInAttackingZone = CheckPlayerInAttackingZone();
    }

    private bool CheckPlayerInAttackingZone()
    {
        if (player == null)
            return false;

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        return distanceToPlayer <= enemyStats.AttackRange;
    }

    #endregion
}
