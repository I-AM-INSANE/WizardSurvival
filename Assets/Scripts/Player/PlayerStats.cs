using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Fields

    [SerializeField] private int health = 100;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private float reloadTime = 0.7f;
    [SerializeField] private int level = 1;

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

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    #endregion
}
