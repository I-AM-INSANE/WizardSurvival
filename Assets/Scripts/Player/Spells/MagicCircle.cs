using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    #region Fields

    private float damagePerSecond;

    #endregion

    #region Methods

    private void Start()
    {
        damagePerSecond = FindObjectOfType<Spell_MagicCircle>().DamagePerSecond;
    }

    private void OnTriggerStay(Collider other)
    {
        ApplyDamage(other);
    }

    private void ApplyDamage(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            other.GetComponent<IDamageable>().TakeDamage(damagePerSecond * Time.fixedDeltaTime);
        }
    }

    #endregion
}
