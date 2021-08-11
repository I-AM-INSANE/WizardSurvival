using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyState : MonoBehaviour
{
    #region Fields

    protected EnemyController enemyController;
    protected EnemyStats enemyStats;
    protected EnemyStateManager enemyStateManager;
    protected Animator enemyAnimator;
    protected Player player;

    #endregion

    #region Methods

    private void Awake()
    {
        enemyController = FindObjectOfType<EnemyController>();
        enemyStats = FindObjectOfType<EnemyStats>();
        enemyStateManager = FindObjectOfType<EnemyStateManager>();
        enemyAnimator = enemyController.GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    public abstract void EnterState();

    #endregion
}
