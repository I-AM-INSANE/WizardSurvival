using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject projectileForSpawn;
    [SerializeField] private Transform spawnPosition;

    private PlayerStats playerStats;
    private PlayerAim playerAim;
    private float inputFire1;
    private bool isReloading = false;

    #endregion

    #region Methods

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerAim = GetComponent<PlayerAim>();
    }

    private void Update()
    {
        inputFire1 = Input.GetAxis("Fire1");
    }

    private void FixedUpdate()
    {
        if (!isReloading && inputFire1 > 0)
            Attack();
    }

    private void Attack()
    {
        GameObject projectile = Instantiate(projectileForSpawn, spawnPosition.position, Quaternion.identity);
        Vector3 pointToShoot = playerAim.GetPointToShoot();
        projectile.transform.LookAt(pointToShoot);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 
            projectile.GetComponent<MagicProjectile>().ProjectileSpeed, ForceMode.Acceleration);

        StartCoroutine(ReloadRoutine());
    }

    private IEnumerator ReloadRoutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(playerStats.ReloadTime);
        isReloading = false;
    }

    #endregion Methods
}
