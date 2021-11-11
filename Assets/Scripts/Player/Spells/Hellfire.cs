using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellfire : MonoBehaviour
{
    #region Fields

    private Spell_Hellfire spell_Hellfire;

    #endregion

    #region Methods

    private void Start()
    {
        spell_Hellfire = FindObjectOfType<Spell_Hellfire>();
        Destroy(gameObject, spell_Hellfire.HellfireLifetime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            ApplyDamage(other);
        }
    }

    private void ApplyDamage(Collider other)
    {
        other.GetComponent<IDamageable>().TakeDamage(spell_Hellfire.DamagePerSecond * Time.fixedDeltaTime);
    }

    #endregion
}
