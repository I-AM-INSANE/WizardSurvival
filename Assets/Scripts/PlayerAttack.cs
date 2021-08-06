using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region

    [SerializeField] private GameObject projectileForSpawn;
    [SerializeField] public Transform spawnPosition;
    [SerializeField] private float projectileSpeed = 1000f;
    [SerializeField] private float reloadTime;

    //private RaycastHit hit;
    private Vector3 pointToShoot;
    private PlayerAim playerAim;
    private bool isReloading = false;


    #endregion

    #region

    private void Start()
    {
        playerAim = FindObjectOfType<PlayerAim>();
    }

    void Update()
    {
        if (!isReloading && Input.GetAxis("Fire1") > 0)
            Shoot();
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectileForSpawn, spawnPosition.position, Quaternion.identity);
        pointToShoot = playerAim.GetPointToShoot();     // MAYBE I NEED GET "HIT", NOT POINT
        projectile.transform.LookAt(pointToShoot);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * projectileSpeed);
        //projectile.GetComponent<MagicProjectileScript>().impactNormal = hit.normal;
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }

    #endregion
}
