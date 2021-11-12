using UnityEngine;

[RequireComponent(typeof(PlayerStats))]

public class PlayerExperienceSystem : MonoBehaviour
{
    #region Fields

    [SerializeField] private int initialLimitXP;
    [SerializeField] private int increaseLimitXPPerLevel;

    private PlayerStats playerStats;
    private int limitXP;
    private int currentXP = 0;

    #endregion

    #region Properties

    public int LimitXP => limitXP;

    public int CurrentXP => currentXP;

    #endregion

    #region Methods

    private void Start()
    {
        limitXP = initialLimitXP;
        playerStats = GetComponent<PlayerStats>();
    }

    public void AddXP(int xp)
    {
        currentXP += xp;
        
        if (currentXP >= limitXP)
        {
            limitXP += increaseLimitXPPerLevel;
            currentXP = 0;
            playerStats.Level++;
        }
    }

    #endregion
}
