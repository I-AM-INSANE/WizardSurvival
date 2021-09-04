using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
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
