using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class UI_PlayerLevel : MonoBehaviour
{
    #region Fields

    private TextMeshProUGUI textMeshProUGUI;
    private PlayerStats playerStats;
    private PlayerExperienceSystem playerExperienceSystem;

    private const string prefixLevel = "Level:";
    private const string prefixXP = "XP:";

    #endregion

    #region Methods

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        playerStats = FindObjectOfType<PlayerStats>();
        playerExperienceSystem = FindObjectOfType<PlayerExperienceSystem>();
    }

    private void Update()
    {
        RefreshText();
    }

    private void RefreshText()
    {
        textMeshProUGUI.text = $"{prefixLevel} {playerStats.Level}\n" +
            $"{prefixXP} {playerExperienceSystem.CurrentXP}/{playerExperienceSystem.XPLimit}";
    }

    #endregion
}
