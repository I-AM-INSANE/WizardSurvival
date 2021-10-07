using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    #region Fields

    private EnemyBaseState currentState;
    public event Action OnAnimationEnded;

    private CheckerPlayerInAttackingZone checkerPlayerInAttackingZone;
    private Animator enemyAnimator;
    private EnemyStats enemyStats;
    private NavMeshAgent enemyAgent;
    private Player player;

    #endregion

    #region Properties

    public EnemyMoveState enemyMoveState { get; private set; }
    public EnemyAttackState enemyAttackState { get; private set; }
    public EnemyReloadState enemyReloadState { get; private set; }

    #endregion

    #region Methods

    private void Awake()
    {
        checkerPlayerInAttackingZone = GetComponent<CheckerPlayerInAttackingZone>();
        enemyAnimator = GetComponent<Animator>();
        enemyStats = GetComponent<EnemyStats>();
        enemyAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        InstantiateStates();
        TransitionToState(enemyMoveState);
    }

    private void Update()
    {
        currentState.Update();
        Debug.Log(currentState);
    }

    public void TransitionToState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnterState();
    }

    private void InstantiateStates()
    {
        enemyMoveState = new EnemyMoveState(this, enemyAnimator, enemyAgent, checkerPlayerInAttackingZone, player);
        enemyAttackState = new EnemyAttackState(this, enemyAnimator, enemyStats, player);
        enemyReloadState = new EnemyReloadState(this, enemyAnimator, enemyStats, checkerPlayerInAttackingZone);
    }

    private void EndOfAnimation()   // called when attack animation ended
    {
        OnAnimationEnded.Invoke();
    }

    #endregion
}
