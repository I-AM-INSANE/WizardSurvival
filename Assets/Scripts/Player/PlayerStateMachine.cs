using UnityEngine;
using System;

public class PlayerStateMachine : MonoBehaviour
{
    #region Fields

    private PlayerBaseState currentState;
    public event Action OnAnimationEnded;

    private Animator playerAnimator;
    private PlayerAttack playerAttack;
    private PlayerStats playerStats;

    #endregion

    #region Properties

    public PlayerIdleState PlayerIdleState { get; private set; }
    public PlayerMoveState PlayerMoveState { get; private set; }
    public PlayerAttackState PlayerAttackState { get; private set; }
    public PlayerReloadState PlayerReloadState { get; private set; }

    #endregion

    #region Methods

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
        playerStats = GetComponent<PlayerStats>();
    }

    private void Start()
    {
        InstantiateStates();
        TransitionToState(PlayerIdleState);
    }

    private void Update()
    {
        currentState.Update();
    }

    public void TransitionToState(PlayerBaseState state)
    {
        currentState = state;
        currentState.EnterState();
    }

    private void InstantiateStates()
    {
        PlayerIdleState = new PlayerIdleState(this, playerAnimator);
        PlayerMoveState = new PlayerMoveState(this);
        PlayerAttackState = new PlayerAttackState(this, playerAttack);
        PlayerReloadState = new PlayerReloadState(this);
    }

    private void EndOfAnimation()   // called when attack animation ended
    {
        OnAnimationEnded.Invoke();
    }

    #endregion
}
