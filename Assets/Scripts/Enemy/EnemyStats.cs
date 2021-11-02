using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    #region Fields

    [SerializeField] private float health;
    [SerializeField] private int damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float reloadTime;

    #endregion

    #region Properties

    public float Health 
    { 
        get { return health; } 
        set { health = value; } 
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public float AttackRange
    {
        get { return attackRange; }
        set { attackRange = value; }
    }
    public float ReloadTime
    {
        get { return reloadTime; }
        set { reloadTime = value; }
    }

    #endregion
}
