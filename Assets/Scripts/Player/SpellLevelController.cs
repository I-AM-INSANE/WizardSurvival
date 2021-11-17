using UnityEngine;

public class SpellLevelController : MonoBehaviour
{
    #region Fields

    private Base_MagicSpell[] magicSpells;
    private PlayerExperienceSystem playerExperienceSystem;
    private UI_SpellSelector ui_SpellSelector;

    #endregion

    #region Methods

    private void OnEnable()
    {
        playerExperienceSystem.OnLevelUp += RunSpellSelector;
    }

    private void OnDisable()
    {
        playerExperienceSystem.OnLevelUp -= RunSpellSelector;
    }
    private void Awake()
    {
        magicSpells = GetComponents<Base_MagicSpell>();
        playerExperienceSystem = FindObjectOfType<PlayerExperienceSystem>();
        ui_SpellSelector = FindObjectOfType<UI_SpellSelector>();
    }

    public void IncreaseSpellLevel(Base_MagicSpell spell)
    {
        spell.LevelUp();
    }

    private void RunSpellSelector()
    {
        ui_SpellSelector.RefreshSelector(GetRandomSpell(), GetRandomSpell());
        ui_SpellSelector.gameObject.SetActive(true);
    }

    private Base_MagicSpell GetRandomSpell()
    {
        return magicSpells[Random.Range(0, magicSpells.Length)];
    }

    #endregion
}
