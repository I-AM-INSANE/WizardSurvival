using UnityEngine;
public class Spell_MagicCircle : Base_MagicSpell
{
    #region Fields

    [SerializeField] private GameObject magicCircle;

    #endregion

    #region Methods

    private void Start()
    {
        Instantiate(magicCircle, transform);
    }

    #endregion
}
