using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    #region Fields

    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private float reloadTime;
    [SerializeField] private float rotationSpeed;

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
    public float RotationSpeed
    {
        get { return rotationSpeed; }
        set { rotationSpeed = value; }
    }

    #endregion
}
