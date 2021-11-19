using UnityEngine;

public class SpellLevelController : MonoBehaviour
{
    #region Fields

    private Base_MagicSpell[] magicSpells;
    private PlayerExperienceSystem playerExperienceSystem;
    private UI_SpellSelector ui_SpellSelector;

    #endregion

    #region Methods

    private void Awake()
    {
        magicSpells = GetComponents<Base_MagicSpell>();
    }

    private void OnEnable()
    {
        ui_SpellSelector = FindObjectOfType<UI_SpellSelector>();
        playerExperienceSystem = FindObjectOfType<PlayerExperienceSystem>();
        playerExperienceSystem.OnLevelUp += RunSpellSelector;
    }

    private void OnDisable()
    {
        playerExperienceSystem.OnLevelUp -= RunSpellSelector;
    }

    public void IncreaseSpellLevel(Base_MagicSpell spell)
    {
        if (spell.SpellLevel == 0)
            spell.enabled = true;
        spell.LevelUp();
    }

    private void RunSpellSelector()
    {
        Base_MagicSpell spell_0 = GetRandomSpell();
        Base_MagicSpell spell_1;
        do
        {
            spell_1 = GetRandomSpell();
        } while (spell_0 == spell_1);

        ui_SpellSelector.gameObject.SetActive(true);
        ui_SpellSelector.RefreshSelector(spell_0, spell_1);
    }

    private Base_MagicSpell GetRandomSpell()
    {
        return magicSpells[Random.Range(0, magicSpells.Length)];
    }

    #endregion
}
