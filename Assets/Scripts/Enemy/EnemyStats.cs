using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    #region Fields

    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 20;
    [SerializeField] private float reloadTime = 0.5f;

    #endregion

    #region Properties

    public int Health 
    { 
        get { return health; } 
        set { health = value; } 
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public float ReloadTime
    {
        get { return reloadTime; }
        set { reloadTime = value; }
    }

    #endregion
}
