using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    #region Fields

    PlayerStateMachine playerStateMachine;

    #endregion

    public PlayerMoveState(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
    }

    #region Methods

    public override void EnterState()
    {

    }

    public override void Update()
    {

    }

    #endregion
}
