using UnityEngine;
using UnityEngine.AI;

public class EnemyRunningState : BaseEnemyState
{
    #region Fields

    private NavMeshAgent enemyAgent;

    #endregion

    #region Methods

    private void Start()
    {
        enemyAgent = enemyController.GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        FollowPlayer();
        if (enemyController.PlayerInAttackingZone)
            enemyStateManager.TransitionToState(enemyStateManager.AttackingState);
    }

    public override void EnterState()
    {
        enemyAnimator.Play("EnemyRun");
    }

    private void FollowPlayer()
    {
        if (enemyAgent != null)
            enemyAgent.SetDestination(player.transform.position);
    }

    #endregion
}
