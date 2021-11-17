using System.Collections;
using UnityEngine;

public class Spell_Hellfire : Base_MagicSpell
{
    #region Fields

    [SerializeField] private GameObject hellfire;
    [SerializeField] private float hellfireLifetime;
    [SerializeField] private float reloadTime;

    private bool isReloading = false;

    #endregion

    #region Properties

    public float HellfireLifetime => hellfireLifetime;

    #endregion

    #region Methods

    private void Update()
    {
        if (isReloading == false)
        {
            Instantiate(hellfire, transform);
            StartCoroutine(ReloadRoutine());
        }
    }
    private IEnumerator ReloadRoutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }

    #endregion
}
