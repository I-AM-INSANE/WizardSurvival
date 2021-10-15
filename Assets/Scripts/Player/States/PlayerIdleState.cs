using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    #region Fields

    PlayerStateMachine playerStateMachine;
    Animator playerAnimator;

    #endregion

    public PlayerIdleState(PlayerStateMachine playerStateMachine, Animator playerAnimator)
    {
        this.playerStateMachine = playerStateMachine;
        this.playerAnimator = playerAnimator;
    }

    #region Methods

    public override void EnterState()
    {
        PlayIdleAnimation();
    }

    public override void Update()
    {
        //if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        //    GoToAnotherState(playerStateMachine.PlayerMoveState);
        if (Input.GetAxis("Fire1") > 0)
            GoToAnotherState(playerStateMachine.PlayerAttackState);
            
    }

    private void PlayIdleAnimation()
    {
        playerAnimator.Play("Idle");
    }

    private void GoToAnotherState(PlayerBaseState state)
    {
        playerStateMachine.TransitionToState(state);
    }

    #endregion
}
