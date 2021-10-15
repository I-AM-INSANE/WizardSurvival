using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Fields

    [SerializeField] private int health;
    [SerializeField] private float moveSpeed;

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

    #endregion
}
