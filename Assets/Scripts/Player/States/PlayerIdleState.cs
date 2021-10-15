using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    #region Fields

    Animator playerAnimator;

    #endregion

    public PlayerIdleState(Animator playerAnimator)
    {
        this.playerAnimator = playerAnimator;
    }

    #region Methods

    public override void EnterState()
    {
        PlayIdleAnimation();
    }

    public override void Update()
    {

    }

    private void PlayIdleAnimation()
    {
        playerAnimator.Play("Idle");
    }

    #endregion
}
