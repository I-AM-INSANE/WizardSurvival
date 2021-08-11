using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    #region Fields

    [SerializeField] private BaseEnemyState runningState;
    [SerializeField] private BaseEnemyState attackingState;
    [SerializeField] private BaseEnemyState reloadState;

    private BaseEnemyState[] states;

    #endregion

    #region Properties

    public BaseEnemyState RunningState => runningState;
    public BaseEnemyState AttackingState => attackingState;
    public BaseEnemyState ReloadState => reloadState;

    #endregion

    private void Awake()
    {
        states = new BaseEnemyState[] { runningState, attackingState, reloadState };
        DisableStates();
    }

    public void TransitionToState(BaseEnemyState stateToTransition)
    {
        DisableStates();
        stateToTransition.enabled = true;
        stateToTransition.EnterState();
    }

    private void DisableStates()
    {
        foreach (BaseEnemyState state in states)
            state.enabled = false;
    }
}
