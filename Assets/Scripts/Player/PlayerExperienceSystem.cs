using UnityEngine;
using System;

[RequireComponent(typeof(PlayerStats))]

public class PlayerExperienceSystem : MonoBehaviour
{
    #region Fields

    [SerializeField] private int xpInitialLimit;
    [SerializeField] private int xpLimitExtraPerLevel;

    private PlayerStats playerStats;
    private int xpLimit;
    private int currentXP = 0;

    public event Action OnLevelUp;

    #endregion

    #region Properties

    public int XPLimit => xpLimit;

    public int CurrentXP => currentXP;

    #endregion

    #region Methods

    private void Start()
    {
        xpLimit = xpInitialLimit;
        playerStats = GetComponent<PlayerStats>();
    }

    public void AddXP(int xp)
    {
        currentXP += xp;
        
        if (currentXP >= xpLimit)
        {
            playerStats.Level++;
            OnLevelUp.Invoke();
            xpLimit += xpLimitExtraPerLevel;
            currentXP = 0;
        }
    }

    #endregion
}
