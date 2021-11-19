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
    }

    private void OnEnable()
    {
        playerExperienceSystem = FindObjectOfType<PlayerExperienceSystem>();
        playerExperienceSystem.OnXpGot += RefreshText;
    }

    private void OnDisable()
    {
        playerExperienceSystem.OnXpGot -= RefreshText;
    }

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void RefreshText()  // call when event invoke
    {
        textMeshProUGUI.text = $"{prefixLevel} {playerStats.Level}\n" +
            $"{prefixXP} {playerExperienceSystem.CurrentXP}/{playerExperienceSystem.XPLimit}";
    }

    #endregion
}
