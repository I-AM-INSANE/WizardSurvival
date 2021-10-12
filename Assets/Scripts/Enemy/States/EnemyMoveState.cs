using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveState : EnemyBaseState
{
    #region Fields

    private EnemyStateMachine enemyStateMachine;
    private Animator enemyAnimator;
    private CheckerPlayerInAttackingZone checkerPlayerInAttackingZone;

    #endregion

    public EnemyMoveState(EnemyStateMachine enemyStateMachine, Animator enemyAnimator, CheckerPlayerInAttackingZone checkerPlayerInAttackingZone)
    {
        this.enemyStateMachine = enemyStateMachine;
        this.enemyAnimator = enemyAnimator;
        this.checkerPlayerInAttackingZone = checkerPlayerInAttackingZone;
    }

    #region Methods

    public override void EnterState()
    {
        PlayMoveAnimation();
    }

    public override void Update()
    {
        CheckPlayerInAttackingZone();
    }

    private void PlayMoveAnimation()
    {
        enemyAnimator.Play("Run");
    }

    private void CheckPlayerInAttackingZone()
    {
        if (checkerPlayerInAttackingZone.PlayerInAttackingZone == true)
            enemyStateMachine.TransitionToState(enemyStateMachine.EnemyAttackState);
    }

    #endregion
}
