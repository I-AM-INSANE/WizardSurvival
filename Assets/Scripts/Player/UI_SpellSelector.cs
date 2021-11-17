using UnityEngine;
using UnityEngine.UI;
using TMPro;

enum GameStates
{
    pause,
    resume
}
public class UI_SpellSelector : MonoBehaviour
{
    #region Fields

    [SerializeField] private Button topButton;
    [SerializeField] private Button botButton;

    private SpellLevelController spellLevelController;
    private MouseLook mouseLook;
    private PlayerMovement playerMovement;
    private Base_MagicSpell spell_0;
    private Base_MagicSpell spell_1;

    #endregion

    #region Methods

    private void Awake()
    {
        spellLevelController = FindObjectOfType<SpellLevelController>();
        mouseLook = FindObjectOfType<MouseLook>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        HideSpellSelector();
    }
    public void TopButtonPressed()  // call when player click on top button
    {
        spellLevelController.IncreaseSpellLevel(spell_0);
        HideSpellSelector();
    }

    public void BotButtonPressed()  // call when player click on bot button
    {
        spellLevelController.IncreaseSpellLevel(spell_1);
        HideSpellSelector();
    }
    public void RefreshSelector(Base_MagicSpell spell_0, Base_MagicSpell spell_1)
    {
        ChangeGameState(GameStates.pause);
        RefreshSpells(spell_0, spell_1);
        RefreshButtonText();
    }
    private void RefreshSpells(Base_MagicSpell spell_0, Base_MagicSpell spell_1)
    {
        this.spell_0 = spell_0;
        this.spell_1 = spell_1;
    }

    private void RefreshButtonText()
    {
        topButton.GetComponentInChildren<TextMeshProUGUI>().text = spell_0.TextForSpellSelector;
        botButton.GetComponentInChildren<TextMeshProUGUI>().text = spell_1.TextForSpellSelector;
    }

    private void HideSpellSelector()
    {
        ChangeGameState(GameStates.resume);
        gameObject.SetActive(false);
    }

    private void ChangeGameState(GameStates state)
    {
        if (state == GameStates.pause)
        {
            playerMovement.enabled = false;
            mouseLook.enabled = false;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(state == GameStates.resume)
        {
            playerMovement.enabled = true;
            mouseLook.enabled = true;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    #endregion
}
