using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Hellfire : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject hellfire;
    [SerializeField] private float damagePerSecond;
    [SerializeField] private float hellfireLifetime;
    [SerializeField] private float reloadTime;

    private bool isReloading = false;

    #endregion

    #region Properties

    public float DamagePerSecond => damagePerSecond;

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
