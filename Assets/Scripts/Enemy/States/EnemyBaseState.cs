using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    #region Methods

    public abstract void EnterState(EnemyController enemy);

    public abstract void Update(EnemyController enemy);

    public abstract void OnCollisionEnter(EnemyController enemy);

    #endregion
}
