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
        Attack();
    }

    public override void Update()
    {
    }

    private void Attack()
    {
        PlayAttackAnimation();
        player.TakeDamage(enemyStats.Damage);
    }

    private void PlayAttackAnimation()
    {
        enemyAnimator.Play("EnemyAttack");
    }

    private void Reload()
    {
        enemyStateMachine.TransitionToState(enemyStateMachine.enemyReloadState);
        enemyStateMachine.OnAnimationEnded -= Reload;
    }

    //private void OnEnable()
    //{
    //    enemyController.OnAnimationEnded += Reload;
    //}

    //private void OnDisable()
    //{
    //    enemyController.OnAnimationEnded -= Reload;
    //}

    //public override void EnterState()
    //{
    //    Attack();
    //}

    //private void Attack()
    //{
    //    enemyAnimator.Play("EnemyAttack");
    //    player.TakeDamage(enemyStats.Damage);
    //}

    //private void Reload()   // called when animation ended
    //{
    //    enemyStateManager.TransitionToState(enemyStateManager.ReloadState);
    //}

    #endregion
}
