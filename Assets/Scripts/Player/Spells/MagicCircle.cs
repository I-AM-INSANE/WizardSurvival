using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    #region Fields

    private Spell_MagicCircle spell_MagicCircle;

    #endregion

    #region Methods

    private void Start()
    {
        spell_MagicCircle = FindObjectOfType<Spell_MagicCircle>();
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
         other.GetComponent<IDamageable>().TakeDamage(spell_MagicCircle.DamagePerSecond * Time.fixedDeltaTime);
    }

    #endregion
}
