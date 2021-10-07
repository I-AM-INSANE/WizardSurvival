using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Fields

    [SerializeField] private int health;

    #endregion

    #region Properties

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    #endregion
}
