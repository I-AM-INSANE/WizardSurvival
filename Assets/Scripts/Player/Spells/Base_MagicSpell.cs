using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_MagicSpell : MonoBehaviour
{
    #region Fields

    [SerializeField] private string spellName;
    [SerializeField] private float damagePerSecond;
    [SerializeField] private float extraDamagePerLevel;

    private int spellLevel = 0;
    //private string textForSpellSelector = "Increase level";

    #endregion

    #region Properties

    public float DamagePerSecond => damagePerSecond;

    public string TextForSpellSelector 
    { 
        get { return $"Increase level \"{spellName}\" to {spellLevel + 1}"; } 
    }


    #endregion

    #region Methods

    public virtual void LevelUp() 
    {
        spellLevel++;
        damagePerSecond += extraDamagePerLevel;
    }

    #endregion
}
