using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReloadState : BaseEnemyState
{
    public override void EnterState()
    {
        enemyAnimator.Play("EnemyReload");
        StartCoroutine(ReloadRoutine());
    }

    private IEnumerator ReloadRoutine()
    {
        yield return new WaitForSeconds(enemyStats.ReloadTime);

        if (enemyController.PlayerInAttackingZone)
            enemyStateManager.TransitionToState(enemyStateManager.AttackingState);
        else
            enemyStateManager.TransitionToState(enemyStateManager.RunningState);
    }
}
