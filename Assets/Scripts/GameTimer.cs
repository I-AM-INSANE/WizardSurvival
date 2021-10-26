using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    #region Fields

    [SerializeField] private int timeToWin;
    [SerializeField] private int timeForNextLevel;

    private TextMeshProUGUI textMeshProUGUI;
    private const string prefixTimeToWin = "Time to win:";
    private const string postfixTimeToWin = ":00";
    private const string prefixTimeForNextLevel = "Time for next level:";
    private const string postfixTimeForNextLevel = ":00";
    private const string prefixCurrentTime = "Current time:";
    private string currentTime;

    #endregion

    #region Methods

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        RefreshCurrentTime();
        RefreshText();
    }

    private void RefreshCurrentTime()
    {
        int minutes = (int)Time.time / 60;
        int seconds = (int)Time.time % 60;

        currentTime = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
        currentTime += ":";
        currentTime += seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();
    }

    private void RefreshText()
    {
        textMeshProUGUI.text = $"{prefixTimeToWin} {timeToWin}{postfixTimeToWin}\n" +
            $"{prefixTimeForNextLevel} {timeForNextLevel}{postfixTimeForNextLevel}\n" +
            $"{prefixCurrentTime} {currentTime}";
    }

    #endregion
}
