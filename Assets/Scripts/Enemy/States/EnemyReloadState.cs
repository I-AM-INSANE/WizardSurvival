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
    private bool reloadComplete = false;
    private float timeSinceReloadStart = 0f;

    #endregion
    public EnemyReloadState(EnemyStateMachine enemyStateMachine, Animator animator, EnemyStats enemyStats, 
        CheckerPlayerInAttackingZone checkerPlayerInAttackingZone)
    {
        this.enemyStateMachine = enemyStateMachine;
        this.animator = animator;
        this.enemyStats = enemyStats;
        this.checkerPlayerInAttackingZone = checkerPlayerInAttackingZone;
    }

    #region Methods

    public override void EnterState()
    {
        PlayReloadAnimation();
    }

    public override void Update()
    {
        if (reloadComplete == false)
            Reload();
        else
        {
            CheckPlayerInAttackingZone();
            timeSinceReloadStart = 0f;
            reloadComplete = false;
        }
    }

    private void PlayReloadAnimation()
    {
        animator.Play("EnemyReload");
    }

    private void Reload()
    {
        timeSinceReloadStart += Time.deltaTime;
        if (timeSinceReloadStart >= enemyStats.ReloadTime)
            reloadComplete = true;
    }

    private void CheckPlayerInAttackingZone()
    {
        if (checkerPlayerInAttackingZone.PlayerInAttackingZone == true)
            enemyStateMachine.TransitionToState(enemyStateMachine.EnemyAttackState);
        else
            enemyStateMachine.TransitionToState(enemyStateMachine.EnemyMoveState);
    }

    #endregion
}
