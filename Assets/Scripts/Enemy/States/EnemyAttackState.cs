using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using System;

public class EnemyAttackState : EnemyBaseState
{
    #region Fields

    private EnemyStateMachine enemyStateMachine;
    private Animator enemyAnimator;
    private EnemyStats enemyStats;
    private Player player;

    #endregion
    public EnemyAttackState(EnemyStateMachine enemyStateMachine, Animator enemyAnimator, EnemyStats enemyStats, Player player)
    {
        this.enemyStateMachine = enemyStateMachine;
        this.enemyAnimator = enemyAnimator;
        this.player = player;
        this.enemyStats = enemyStats;
    }

    #region Methods

    public override void EnterState()
    {
        enemyStateMachine.OnAnimationEnded += Reload;
        PlayAttackAnimation();
    }

    public override void Update()
    {
    }

    private void PlayAttackAnimation()
    {
        enemyAnimator.Play("Attack");
    }

    private void Reload()   // call when attack animation ended
    {
        ApplyDamage();
        enemyStateMachine.TransitionToState(enemyStateMachine.EnemyReloadState);
        enemyStateMachine.OnAnimationEnded -= Reload;
    }

    private void ApplyDamage()
    {
        player.TakeDamage(enemyStats.Damage);
    }

    #endregion
}
