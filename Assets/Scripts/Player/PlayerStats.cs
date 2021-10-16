using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Fields

    [SerializeField] private int health;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int magicProjectileSpeed;
    [SerializeField] private float reloadTime;

    #endregion

    #region Properties

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public int MagicProjectileSpeed
    {
        get { return magicProjectileSpeed; }
        set { magicProjectileSpeed = value; }
    }

    public float ReloadTime
    {
        get { return reloadTime; }
        set { reloadTime = value; }
    }

    #endregion
}
