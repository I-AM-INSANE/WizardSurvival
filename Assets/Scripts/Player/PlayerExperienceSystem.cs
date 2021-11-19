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
    public event Action OnXpGot;

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
            RefreshPlayerStats();
            OnLevelUp.Invoke();
            xpLimit += xpLimitExtraPerLevel;
            currentXP = 0;
        }

        OnXpGot.Invoke();
    }

    private void RefreshPlayerStats()
    {
        playerStats.Level++;
        playerStats.BaseDamage += playerStats.ExtraDamagePerLevel;
    }

    #endregion
}
