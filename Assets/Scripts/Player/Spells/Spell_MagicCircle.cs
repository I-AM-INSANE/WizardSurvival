using UnityEngine;

public class Spell_MagicCircle : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject magicCircle;
    [SerializeField] private float damagePerSecond;

    #endregion

    #region Properties

    public float DamagePerSecond => damagePerSecond;

    #endregion

    #region Methods

    private void Start()
    {
        Instantiate(magicCircle, transform);
    }

    #endregion
}
