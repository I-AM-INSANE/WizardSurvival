using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    #region Fields

    PlayerStateMachine playerStateMachine;
    PlayerAttack playerAttack;

    #endregion

    public PlayerAttackState(PlayerStateMachine playerStateMachine, PlayerAttack playerAttack)
    {
        this.playerStateMachine = playerStateMachine;
        this.playerAttack = playerAttack;
    }

    #region Methods

    public override void EnterState()
    {
        Attack();
        Reload();
    }

    public override void Update()
    {
    }

    private void Attack()
    {
        playerAttack.Attack();
    }

    private void Reload()
    {
        playerStateMachine.TransitionToState(playerStateMachine.PlayerReloadState);
    }

    #endregion
}
