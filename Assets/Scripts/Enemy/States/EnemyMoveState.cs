using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveState : EnemyBaseState
{
    #region Fields

    private EnemyStateMachine enemyStateMachine;
    private Animator enemyAnimator;
    private NavMeshAgent enemyAgent;
    private CheckerPlayerInAttackingZone checkerPlayerInAttackingZone;
    private Player player;

    #endregion
    public EnemyMoveState(EnemyStateMachine enemyStateMachine, Animator enemyAnimator, NavMeshAgent enemyAgent, 
        CheckerPlayerInAttackingZone checkerPlayerInAttackingZone, Player player)
    {
        this.enemyStateMachine = enemyStateMachine;
        this.enemyAnimator = enemyAnimator;
        this.enemyAgent = enemyAgent;
        this.checkerPlayerInAttackingZone = checkerPlayerInAttackingZone;
        this.player = player;
    }

    #region Methods

    public override void EnterState()
    {
        PlayMoveAnimation();
    }

    public override void Update()
    {
        FollowPlayer();
        CheckPlayerInAttackingZone();
    }

    private void PlayMoveAnimation()
    {
        enemyAnimator.Play("EnemyRun");
    }

    private void FollowPlayer()
    {
        enemyAgent.SetDestination(player.transform.position);
    }

    private void CheckPlayerInAttackingZone()
    {
        if (checkerPlayerInAttackingZone.PlayerInAttackingZone == true)
            enemyStateMachine.TransitionToState(enemyStateMachine.enemyAttackState);
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
