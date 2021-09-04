using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveState : EnemyBaseState
{
    #region Fields

    private NavMeshAgent enemyAgent;

    #endregion

    #region Methods

    public override void EnterState(EnemyController enemy)
    {

    }

    public override void Update(EnemyController enemy)
    {

    }

    public override void OnCollisionEnter(EnemyController enemy)
    {

    }

    //private void Start()
    //{
    //    enemyAgent = enemyController.GetComponent<NavMeshAgent>();
    //}

    //private void FixedUpdate()
    //{
    //    FollowPlayer();
    //    if (enemyController.PlayerInAttackingZone)
    //        enemyStateManager.TransitionToState(enemyStateManager.AttackingState);
    //}

    //public override void EnterState()
    //{
    //    enemyAnimator.Play("EnemyRun");
    //}

    //private void FollowPlayer()
    //{
    //    if (enemyAgent != null)
    //        enemyAgent.SetDestination(player.transform.position);
    //}

    #endregion
}
