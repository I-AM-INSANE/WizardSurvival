using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReloadState : EnemyBaseState
{
    #region Fields

    private EnemyStateMachine enemyStateMachine;
    private Animator animator;
    private EnemyStats enemyStats;
    private CheckerPlayerInAttackingZone checkerPlayerInAttackingZone;
    private Transform enemyTransform;
    private Transform playerTransform;
    private bool reloadComplete = false;
    private float timeSinceReloadStart = 0f;

    #endregion
    public EnemyReloadState(EnemyStateMachine enemyStateMachine, Animator animator, EnemyStats enemyStats, 
        CheckerPlayerInAttackingZone checkerPlayerInAttackingZone, Transform enemyTransform, Transform playerTransform)
    {
        this.enemyStateMachine = enemyStateMachine;
        this.animator = animator;
        this.enemyStats = enemyStats;
        this.checkerPlayerInAttackingZone = checkerPlayerInAttackingZone;
        this.enemyTransform = enemyTransform;
        this.playerTransform = playerTransform;
    }

    #region Methods

    public override void EnterState()
    {
    }

    public override void Update()
    {
        PlayAnimation();

        if (reloadComplete == false)
            Reload();
        else
        {
            GoToAnotherState();
            timeSinceReloadStart = 0f;
            reloadComplete = false;
        }
    }

    private void PlayAnimation()
    {
        if (checkerPlayerInAttackingZone.PlayerInAttackingZone == true)
            animator.Play("Idle");
        else
            animator.Play("Run");
    }

    private void Reload()
    {
        timeSinceReloadStart += Time.deltaTime;
        if (timeSinceReloadStart >= enemyStats.ReloadTime)
            reloadComplete = true;
    }

    private void GoToAnotherState()
    {
        if (checkerPlayerInAttackingZone.PlayerInAttackingZone == true)
            enemyStateMachine.TransitionToState(enemyStateMachine.EnemyAttackState);
        else
            enemyStateMachine.TransitionToState(enemyStateMachine.EnemyMoveState);
    }

    #endregion
}
