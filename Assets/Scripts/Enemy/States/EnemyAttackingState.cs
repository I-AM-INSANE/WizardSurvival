using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAttackingState : BaseEnemyState
{
    #region Methods

    private void OnEnable()
    {
        enemyController.OnAnimationEnded += Reload;
    }

    private void OnDisable()
    {
        enemyController.OnAnimationEnded -= Reload;
    }

    public override void EnterState()
    {
        Attack();
    }

    private void Attack()
    {
        enemyAnimator.Play("EnemyAttack");
        player.TakeDamage(enemyStats.Damage);
    }

    private void Reload()   // called when animation ended
    {
        enemyStateManager.TransitionToState(enemyStateManager.ReloadState);
    }

    #endregion
}
