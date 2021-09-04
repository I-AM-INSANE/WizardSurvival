using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReloadState : EnemyBaseState
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

    //public override void EnterState()
    //{
    //    enemyAnimator.Play("EnemyReload");
    //    StartCoroutine(ReloadRoutine());
    //}

    //private IEnumerator ReloadRoutine()
    //{
    //    yield return new WaitForSeconds(enemyStats.ReloadTime);

    //    if (enemyController.PlayerInAttackingZone)
    //        enemyStateManager.TransitionToState(enemyStateManager.AttackingState);
    //    else
    //        enemyStateManager.TransitionToState(enemyStateManager.RunningState);
    //}

    #endregion
}
